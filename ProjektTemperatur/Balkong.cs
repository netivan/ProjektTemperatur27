using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTemperatur
{

    // tar ifrån databasen datan innehållande datum, inne & ute temperaturer och skapar två tabeller,
    //  den första är för inne temperaturen, den andra för yttretremperaturen.
    // Sen joinas dem för att få ut en enda tabell som följande:  datum, temp inne, temp ute
    class Balkong

    {

        public DateTime datum;
        public float TempInne;
        public float TempUte;


        public static List<Balkong> TabellTempInneUte(DateTime dag)
        {
            // 1 skapar tabellen som har innetemperaturer

            using (var db = new ProjektarbeteContext())
            {

                var TabInne =
                      from rad in db.Datavardes
                      where rad.datum.Date == dag.Date && rad.plats == "Inne"
                      select new { datum = rad.datum, TempInne = rad.temp };

                // 2 skapar tabellen som har yttretemperaturer

                var TabYttre =
                      from rad in db.Datavardes
                      where rad.datum.Date == dag.Date && rad.plats == "Ute"
                      select new { datum = rad.datum, TempUte = rad.temp };

                // 3  joinar dessa två tabeller för att få ut en enda

                var TabInUte = (
                      from radInne in TabInne         
                          join radUte in TabYttre
                      on radInne.datum equals radUte.datum   // data della radInne coincide cn la data della riga TempUte
                          select new Balkong { datum = radInne.datum, TempInne = radInne.TempInne, TempUte = radUte.TempUte }).ToList();

                return TabInUte;  // sorterar för datum och lägger den i en lista  
                                 // Tabell med nummer men utan titel             
            }

        }
        public static void BalkongOpen(DateTime dag)

        // När innetemperaturen höjs/sänks innebär att balkogen är öppen dok att kall/varm luft kommer in från utsidan i lägenheten.
        // Innetemperaturen höjs/sänks plötsligt i början för att sedan uppnå en viss temperatur. 
        // Är balkogen öppen bara några sekunder så höjs temperaturen bara lite gran för att sen återgå till den normala temp.
        // Samma sak händer med yttretemperaturen men tvärtom eftersom sensoren ligger nära balkongdörren.
        {
                                                                                               
            var tabelltempinneute = TabellTempInneUte(dag);

            // Verifierar om innetemperaturen ändrar

            float GränsTemp = 1.0f;   // 1 grader temperaturen under vilket den innebär att blkongen inte är öppen
            float tempMedel = tabelltempinneute.Average(x => x.TempInne);

            foreach (var rad in tabelltempinneute)
            {
                if (Math.Abs(rad.TempInne - tempMedel) > GränsTemp)
                {
                    // Balkongen är öppen!
                }
            }

        }

        public static DateTime BalkongOpen2(DateTime dag)
        {
            // Gäller endast för vintertiden (TempInne >> TempUte) 
            // Definerar när  balkongen öppnas 

            var matt = TabellTempInneUte(dag).ToArray();
            int nMax = matt.Count();   // antal data 
            if (nMax < 10) return dag;    // otillräckligt antal data för att definera om balkongen öppnas.
            for (int i = 1; i < nMax - 8; i++)
            {



                // Så fort balkongen öppnas så går värmen ut ur lägenheten 
                // Sensoren ligger på utsidan nära balkongen

                if (matt[i + 3].TempUte > matt[i + 2].TempUte && matt[i + 2].TempUte > matt[i + 1].TempUte && matt[i + 1].TempUte > matt[i].TempUte)

                { // kanske balkongen öppnades

                    if (matt[i + 4].TempInne < matt[i + 3].TempInne && matt[i + 3].TempInne < matt[i + 2].TempInne && matt[i + 2].TempInne < matt[i + 1].TempInne)
                    {
                        // Strax efter sänker UteTemperaturen
                        return matt[i].datum;    // Här är det momenten att bolkongen öppnats
                    }
                }

            }
            return dag;       // Balkongen aldrig öppnad
        }

        public static Object MestMinst(DateTime dag)      
        {
            var tab = TabellTempInneUte(dag);                                             //.OrderBy(x => x.TempInne - x.TempUte);
            var q = from x in tab
                    select new { datum = x.datum, diff = x.TempInne - x.TempUte, tempInne = x.TempInne, tempute = x.TempUte };

            var q2 = from z in q          //  order för 'diff'
                     orderby z.diff
                     select z;

            return q2.ToList();



        }

        public static Object MestMinst2(DateTime dag)
        {
            var tab = TabellTempInneUte(dag);                                             //.OrderBy(x => x.TempInne - x.TempUte);
            var q = from x in tab
                    select new { datum = x.datum, diff = x.TempInne - x.TempUte, tempInne = x.TempInne, tempute = x.TempUte };

            var q2 = from z in q          //  order för 'diff'
                     orderby z.datum
                     select z;

            return q2.ToList();



        }

    }

    }

