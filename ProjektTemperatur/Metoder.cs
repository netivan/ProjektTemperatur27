using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace ProjektTemperatur
{
    class Metoder      // SQL method
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

        public static SqlConnection ÖppnaAnslutning()
        {

            SqlConnection DBCo = new SqlConnection();
            DBCo.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Projektarbete;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return DBCo;
        }


        public static object SqlQuery(string query)
        {

            try
            {
                var Connection = Metoder.ÖppnaAnslutning();
                var command = new SqlCommand();

                var dataAdapter = new SqlDataAdapter(query, Connection);
                var dataSet = new DataSet();


                Connection.Open();
                dataAdapter.Fill(dataSet, "datavarde");

                return dataSet;

                

            }
            catch { return null; }
        }



        public static void InsertData(Temperaturer t, SqlConnection dbConnection)
        {

            //var dbConnection = ÖppnaAnslutning();
            //dbConnection.Open();
            SqlCommand query = new SqlCommand();
            query.CommandType = System.Data.CommandType.Text;

            query.CommandText = "insert into datavarde values (@datum, @plats,@temp,@luftfuktighet)";

            SqlParameter Par0 = new SqlParameter("@datum",t.datum);
            Par0.SqlDbType = System.Data.SqlDbType.DateTime;
            Par0.Direction = System.Data.ParameterDirection.Input;
            query.Parameters.Add(Par0);

            SqlParameter Par1 = new SqlParameter("@plats",t.plats);                
            Par1.SqlDbType = System.Data.SqlDbType.VarChar;
            Par1.Size = 32;
            Par1.Direction = System.Data.ParameterDirection.Input;
            query.Parameters.Add(Par1);

            SqlParameter Par2 = new SqlParameter("@temp", t.temp);
            Par2.SqlDbType = System.Data.SqlDbType.Float;
            Par2.Direction = System.Data.ParameterDirection.Input;
            query.Parameters.Add(Par2);

            SqlParameter Par3 = new SqlParameter("@luftfuktighet", t.luftfuktighet);
            Par3.SqlDbType = System.Data.SqlDbType.Int;
            Par3.Direction = System.Data.ParameterDirection.Input;
            query.Parameters.Add(Par3);


            query.Connection = dbConnection;
            int r = query.ExecuteNonQuery();

            //dbConnection.Close();


        }




       

        //public static void CreateContact(Contact co)   // id in parameter
        //{
        //    // skapar en anslutning till sql server som vi ska kalla för DBCo 
        //    var DBCo = ÖppnaAnslutning();
        //    DBCo.Open();     // med metoden open() öppnar vi databasen 
        //    SqlCommand comand = Util.StoredProcedure("cretecontact2");     // skapar sql 'comand' 


        //    comand.Parameters.Add(Util.paraCharI("@SSN", co.SSN, 32));
        //    comand.Parameters.Add(Util.paraCharI("@fn", co.Firstname, 32));
        //    comand.Parameters.Add(Util.paraCharI("@ln", co.Lastname, 32));

        //    comand.Connection = DBCo;  // överför comand till databasen
        //    int r = comand.ExecuteNonQuery();  // executes och resultaten hamnar il 'result'
        //                                       //   Contact co = new Contact();
        //    Console.WriteLine("Sono state modificate {r} ");

        //    DBCo.Close();

    }
}
