using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.Data.Odbc;



namespace Module1_lesson1
{
    class Program
    {
        static void Main(string[] args)
        {

            ////     Console.BackgroundColor = ConsoleColor.Yellow;
            //////https://www.connectionstrings.com


            ////DefaultConnection Data Source = 192.168.110.195;
            //string connectionString =
            //       ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            ////  Console.WriteLine(connectionString);



            ////Первый вариант 1
            ////  SqlConnection con = new SqlConnection(connectionString);
            ////try
            ////{
            ////    con.Open();
            ////    Console.WriteLine("Соединение Открыто!");
            ////}
            ////catch (Exception ex)
            ////{

            ////    Console.WriteLine(ex.Message);
            ////}
            ////finally
            ////{
            ////    con.Close();
            ////    Console.WriteLine("Соединение Закрыто!");
            ////}


            ////Второй вариант 2
            //SqlConnection con;
            //using (con = new SqlConnection(connectionString))
            //{
            //    con.Open();
            //    Console.WriteLine("Соединение Открыто!");
            //    Console.WriteLine(con.State);

            //    Console.WriteLine("Свойства подключения: ");
            //    Console.WriteLine(" \t строка подключения: {0} ", con.ConnectionString);
            //    Console.WriteLine(" \t база данных: {0} ", con.Database);
            //    Console.WriteLine(" \t сервер: {0} ", con.DataSource);
            //    Console.WriteLine(" \t версия сервера: {0} ", con.ServerVersion);
            //    Console.WriteLine(" \t warkstation: {0} ", con.WorkstationId);



            //}// con.Close();

            //Console.WriteLine(con.State);
            ////-------------------------------------------------------------------------------------

            //// OleDb; Provider=Provider=Microsoft.Jet.OLEDB.4.0
            //string connectionStringOle =
            //      ConfigurationManager.ConnectionStrings["DefaultConnectionAccess"].ConnectionString;



            //OleDbConnection olecon;
            //using (olecon = new OleDbConnection(connectionStringOle))
            //{
            //    olecon.Open();
            //    Console.WriteLine("Соединение Открыто!");
            //    Console.WriteLine(olecon.State);

            //    Console.WriteLine("Свойства подключения: ");
            //    Console.WriteLine(" \t строка подключения: {0} ", olecon.ConnectionString);
            //    Console.WriteLine(" \t база данных: {0} ", olecon.Database);
            //    Console.WriteLine(" \t сервер: {0} ", olecon.DataSource);
            //    Console.WriteLine(" \t версия сервера: {0} ", olecon.ServerVersion);
              


            //}// con.Close();

            //Console.WriteLine(olecon.State);

            ////-------------------------------------------------------------------------------------

            //// OleDb; Provider=SQLNCLI11
            //string connectionString2 =
            //    ConfigurationManager.ConnectionStrings["DefaultConnection2"].ConnectionString;



            //OleDbConnection con2;
            //using (con2 = new OleDbConnection(connectionString2))
            //{
            //    con2.Open();
            //    Console.WriteLine("Соединение Открыто!");
            //    Console.WriteLine(con2.State);

            //    Console.WriteLine("Свойства подключения: ");
            //    Console.WriteLine(" \t строка подключения: {0} ", con2.ConnectionString);
            //    Console.WriteLine(" \t база данных: {0} ", con2.Database);
            //    Console.WriteLine(" \t сервер: {0} ", con2.DataSource);
            //    Console.WriteLine(" \t версия сервера: {0} ", con2.ServerVersion);



            //}// con.Close();

            //Console.WriteLine(con2.State);

            ////-------------------------------------------------------------------------------------

            ////ODBC Connect
            //string connectionString3 =
            //    ConfigurationManager.ConnectionStrings["DefaultConnection3"].ConnectionString;



            //OdbcConnection con3;
            //using (con3 = new OdbcConnection(connectionString3))
            //{
            //    con3.Open();
            //    Console.WriteLine("Соединение Открыто!");
            //    Console.WriteLine(con3.State);

            //    Console.WriteLine("Свойства подключения: ");
            //    Console.WriteLine(" \t строка подключения: {0} ", con3.ConnectionString);
            //    Console.WriteLine(" \t база данных: {0} ", con3.Database);
            //    Console.WriteLine(" \t сервер: {0} ", con3.DataSource);
            //    Console.WriteLine(" \t версия сервера: {0} ", con3.ServerVersion);



            //}// con.Close();

            //Console.WriteLine(con3.State);

            //-------------------------------------------------------------------------------------



            string connectionString =
           ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            List<AccessTab> AccessTabs = new List<AccessTab>();

            SqlConnection con;
            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select top 15 * from AccessTab";

                SqlDataReader rdr = cmd.ExecuteReader();

              
                while (rdr.Read())
                {
                    AccessTab accessTab = new AccessTab();
                    accessTab.intTabId = Int32.Parse(rdr[0].ToString());
                    accessTab.strTabName = rdr[1].ToString();
                    accessTab.strDescription = rdr[2].ToString();

                    AccessTabs.Add(accessTab);
                }
            }// con.Close();

            //  Console.WriteLine(con.State);

            
            foreach (AccessTab item in AccessTabs)
            {
                Console.WriteLine(item);

            }
        }
    }


     public class AccessTab
    {
        public int intTabId { get; set; }
        public string strTabName { get; set; }
        public string strDescription { get; set; }


        public override string ToString()
        {
            string str = string.Format("{0}. {1} ({2})", intTabId, strTabName, strDescription);
            return str;
        }
        //8888
    }



}
