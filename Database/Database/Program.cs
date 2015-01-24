using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finisar.SQLite;

namespace Database
{
    class Program
    {
         
         String user="";
        void CreateUser()
        {
            // We use these three SQLite objects:
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");
            // open connecttion to database
            sqlite_conn.Open();
            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();
            // Let the SQLiteCommand object know our SQL-Query:

            // need to find the user in the databse table userFinder
            // TODO  create table userFinder
            sqlite_cmd.CommandText = "CREATE TABLE "+ user+ "_EEG" +  "(UserName varchar(20) primary key,AF3 float , F7 float , F3 float,FC5 float, T7 float,P7 float,O1 float, O2 float,P8 float ,T8 float,FC6 float,F4 float,F8 float,AF4 float,TimeStamp float,section integer, ComputerTime varchar);";
            // Now lets execute the SQL ;D
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }

     

        static void Main(string[] args)
        {
           
           
            Console.ReadKey();
        }
    }
}
