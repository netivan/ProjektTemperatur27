using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Globalization;



namespace ProjektTemperatur
{
    class EFMethods
    {
        public static Temperaturer ConvertData(string rad)
        {       // Plockar raden 'rad' från cvs filen och placerar den i objekten t
                // om data i t är ej rätt får t = null
            NumberFormatInfo provider = new NumberFormatInfo();    // 
            provider.NumberDecimalSeparator = ".";
            provider.NumberGroupSeparator = ",";
            provider.CurrencyDecimalDigits = 1;
            {
                string[] fält = rad.Split(';');

                Temperaturer t = new Temperaturer();      // Tar raden och sätter den i t
                try
                {
                    t.datum = DateTime.Parse(fält[0]);
                    t.plats = fält[1];
                    t.temp = Convert.ToSingle(fält[2], provider);
                    t.luftfuktighet = int.Parse(fält[3]);
                    // Nedan, stämmer jag av att all data är rätt  
                    if (t.luftfuktighet > 100) t = null;                      // om t = null kommer det inte 
                    if (t.temp > 50) t = null;
                }
                catch { t = null; }



                return t;
            }
        }

                public static void InsertData(Temperaturer t)
        {
            using ( var db = new ProjektarbeteContext())
            {
                db.Add(t);
                db.SaveChanges();
            }
        }

        public static void InsertData1(string FilNamn)     // tar all data från cvs filNamn och lägger den i databasen.
        {                                                         // FilNamn är cvs filen därifrån vi hämtar all data.
            using (var db = new ProjektarbeteContext())
            {
                foreach (string rad in File.ReadLines(FilNamn))
                {
                    var tmpx = ConvertData(rad);   // skapar objekt temperatur i vilken rad konverteras (rad viene convertito nell´oggetto tmpx).
                    if (tmpx is not null)
                    {
                        db.Add(tmpx);
                        db.SaveChanges();  // 4 gånger snabbare om jag skriver metoden Savechanges() inne i foreach, dvs efter att all data skrivs in i databasen.
                    }
                }
            }
        } 
             // Nedan, snabbare alternativ  därför att  db.SaveChanges() ligger efter foreach
        public static void InsertData2(string FilNamn)     // tar all data från cvs filNamn och lägger den i databasen
        {                                                      
            using (var db = new ProjektarbeteContext())
            {
                foreach (string rad in File.ReadLines(FilNamn))
                {
                    var tmpx = ConvertData(rad);   // skapar objekt temperatur i vilken rad konverteras (rad viene convertito nell´oggetto tmpx)
                    if (tmpx is not null)   // 
                        
                        db.Add(tmpx);
                }

                db.SaveChanges();  // 4 gånger långsammare om jag skriver metoden Savechanges() efter foreach, dvs efter att all data skrivs in i databasen
            }

        }





        public static float MedelTempInUtomhus(DateTime dag , string plats )
        {
            using (var db = new ProjektarbeteContext())
            {

                var q =
                      from rad in db.Datavardes
                      where rad.datum.Date == dag.Date && rad.plats == plats
                      select rad.temp;
                if (q.Count() > 1) return q.Average();
                else 
                return 0;
            }

        }

        public static Object VarmastTillKallasteUte(string plats)
        {
            using (var db = new ProjektarbeteContext())

            {

                var q =
                    (from rad in db.Datavardes
                     where rad.plats == plats
                     group rad by rad.datum.Date
                     into g   
                     select new { dagDatum = g.Key, tempMedel = g.Average(rad => rad.temp), tempMax = g.Max(rad => rad.temp), tempMin = g.Min(rad => rad.temp)}).OrderBy(g => g.tempMedel);
                     

                return q.ToList();

               


            }



        }

        public static Object TorrastTillfuktigaste(string plats)       // TORRAST  TILL  FUKTIGASTE
        {
            using (var db = new ProjektarbeteContext())

            {
                var q =
                   (from rad in db.Datavardes
                    where rad.plats == plats
                    group rad by rad.datum.Date      //grupperar raderna  ordnade enligt dagdatumen  "raggruppa le righe in ordine di data escludend ore e minuti" (.Date  toglie ore e minuti)
                   into g
                    select new { DagDatum = g.Key, FuktMedel = g.Average(rad => rad.luftfuktighet), fuktMax = g.Max(rad => rad.luftfuktighet), fuktMin = g.Min(rad => rad.luftfuktighet)}).OrderBy(g => g.FuktMedel);


                return q.ToList();

                

            }



        }




        public static DateTime  MeteorologiskHost()        // ska hitta 5 dagar varsin temperaturen är < 10
        {                                                   // ? tillåter null värde.    (I vårat fall DateTime kan inte vara null)
            using (var db = new ProjektarbeteContext())

            {
                var q =
                    from rad in db.Datavardes
                    where rad.plats == "Ute" && rad.datum > DateTime.Parse("2016-08-01")
                    group rad by rad.datum.Date
                    into g         
                    select new { dag = g.Key, tempMedel = g.Average(rad => rad.temp) };
                var q2 = from radg in q              // order resultatet in q by dag  
                         orderby radg.dag
                         select radg;

                int n = 0;

                foreach (var z in q2)
                {
                    if (z.tempMedel < 10)       // kontrollerar om  temperaturen är < 10 grader
                    {
                        n++;                   // räknar för hur många dagar i rad temperaturen är < 10 grader  

                        if (n == 5) return z.dag;
                            
                    }
                    else
                    {
                        n = 0;
                    }
                }
                return DateTime.Parse("2099 12 12");   // StartHostdag  ej hittad
            }


        }


        public static DateTime MeteorologiskVinter()
        {

            using (var db = new ProjektarbeteContext())

            {
                var q =
                    from rad in db.Datavardes
                    where rad.plats == "Ute" && rad.datum > DateTime.Parse("2016-08-01")
                    group rad by rad.datum.Date
                    into g
                    select new { dag = g.Key, tempMedel = g.Average(rad => rad.temp) };
                var q2 = from radg in q              // order resultatet in q by dag  
                         orderby radg.dag
                         select radg;

                int n = 0;

                foreach (var z in q2)
                {
                    if (z.tempMedel <= 0 )       // kontrollerar om  temperaturen är <= 10 grader
                    {
                        n++;                   // räknar för hur många dagar i rad temperaturen är <= 10 grader  

                        if (n == 5) return z.dag;

                    }
                    else
                    {
                        n = 0;
                    }
                }
                return DateTime.Parse("2099 12 12");   // StartVinterDag  ej hittad
            }

        }
        public static DateTime MaxDatum()     //  vi får Max Datumet som finns (tillgänglig) i databasen  dvs 2017-01-17
        {
            using (var db = new ProjektarbeteContext())
            {
                var q = db.Datavardes
                         .Max(x => x.datum); 
                return q;
            }
           
        }

        public static DateTime MinDatum()     //  vi får Min Datumet som finns (tillgänglig) i databasen  dvs 2016-05-31
        {
            using (var db = new ProjektarbeteContext())
            {
                var q = db.Datavardes
                         .Min(x => x.datum);
                return q;
            }


        }


    }
}
    


