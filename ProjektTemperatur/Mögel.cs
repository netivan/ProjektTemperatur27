using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace ProjektTemperatur
{
    class Fuktig 
    {       public DateTime DagDatum { get; set; }
            public float tempMedel { get; set; }
            public double fuktMedel { get; set; }
            public double Mogelindex { get; set; }


        public static int RHcrit(double t)       // Critical Relative Umidity below which no moult growth happens 
        {
            double RHmin;
            //Math är klassen som innehåller alla matematiska metoder  
            if (t <= 20) RHmin = -0.00267 * Math.Pow(t, 3) + 0.16 * Math.Pow(t, 2) - 3.13 * t + 100;
            else
                RHmin = 80;     
            // Math funkar bara med double så jag måste convertera den till Int
            return Convert.ToInt32(RHmin);
        }

        public static List<Fuktig> RiskForMogel(string plats)
        {
            

            using (var db = new ProjektarbeteContext())

            {
              
                var q = from rad in db.Datavardes
                        where rad.plats == plats
                        group rad by rad.datum.Date    // Här bestämmer vi vad g.Key ska ha.
                        into g
                        select new Fuktig() { DagDatum = g.Key, fuktMedel = g.Average(rad => rad.luftfuktighet), tempMedel = g.Average(rad => rad.temp) };

                // linq gör egengligen inget hittils. 

                //   select new Fuktig() { g.Key, g.Average(rad => rad.temp),  g.Average(rad => rad.luftfuktighet), 0 };


                var listMogel = (from rad in q
                                orderby rad.DagDatum
                                select rad).ToList();

                //  beräkning av mögelindex

                foreach (var x in listMogel)     // x är första dagen DagDatum i tabellen 

                {
                    x.Mogelindex = Mmax(x.tempMedel, x.fuktMedel);

                                    //if (x.fuktMedel > Fuktig.RHcrit((double)x.tempMedel)) x.Mogelindex = gammalRiskindex + 0.1;
                                   //else
                                  //{
                                 //    x.Mogelindex = gammalRiskindex - 0.1;
                                //    if (x.Mogelindex < 0) x.Mogelindex = 0;
                               //}
                              //gammalRiskindex = x.Mogelindex;
                }
                                      //      fl.Close();
                                     //      Console.WriteLine("End of printing");
                                    // Console.WriteLine($"{x.dagensdatum}   {x.luftfuktigmedel.ToString()}");

                return listMogel;
            }
        }
        public static double Mmax(double t, double f)
        {
                                  // Om fuktmedel föreblir.....     // Max moult index possible for a certain Relative Umidity after long time  
                                 // mögelrisk = ((fuktighet - 78) * (temperatur / 15)) / 0,22
                                //   double m = ((f - 78 )* (t/15))/0.22;

            double mr = (RHcrit(t) - f) / (RHcrit(t) - 100); // Hannu Viitamen   Performance of Bio-based Building Materials

            double m = 1 + 7 * mr - 2 * Math.Pow(mr, 2);   

            if (m < 0) m = 0;

            return m;  
        }

    }   }








//fl.WriteLine("{0,10:d} ; {3,5:N1} ; {1,5:N0} ; {2,5:N2}", x.dagensdatum, x.fuktMedel, riskindex[i], x.tempMedel);
// {position : date utan
//  i++;

