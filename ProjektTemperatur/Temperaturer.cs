using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ProjektTemperatur
{
  //  EF code first skapar datasen genom skapa innan klassen. 
 //  Klassen innehåller meteologiska temperaturerna som plockas från cvs filen 

    public class Temperaturer           
    {
        public int Id  { get; set; }       // i EF skriver man Id  så att den känns igen som  primary key
        public  DateTime datum { get; set; } 
        public string plats { get; set; }
        public  float temp { get; set; }
        public int luftfuktighet { get; set; }

    }

    public class luft
    {

        public int ID { get; set; }
        public string name { get; set; }

       
    }


    public class ProjektarbeteContext : DbContext            // denna klass sköter kommunikationen med vår    (DbContext är entity f)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Projektarbete2; Integrated Security = True");
        } 

        public ProjektarbeteContext()
        {
            Database.SetCommandTimeout(100);  // Set Timeout time på 100 sekunder
        }


        public DbSet<Temperaturer> Datavardes { get; set; }
        
    }









}
