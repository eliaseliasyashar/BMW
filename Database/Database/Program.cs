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
         // for table UserFinder
         String user="";
        // for table bandpower
         Queue<float> alpha = new Queue<float>();
         Queue<float> beta = new Queue<float>();
        // for table EEG
         Queue<float> AF3 = new Queue<float>();
         Queue<float> F7 = new Queue<float>();
         Queue<float> F3 = new Queue<float>();
         Queue<float> FC5 = new Queue<float>();
         Queue<float> T7 = new Queue<float>();
         Queue<float> P7 = new Queue<float>();
         Queue<float> O1 = new Queue<float>();
         Queue<float> O2 = new Queue<float>();
         Queue<float> P8 = new Queue<float>();
         Queue<float> T8 = new Queue<float>();
         Queue<float> FC6 = new Queue<float>();
         Queue<float> F4 = new Queue<float>();
         Queue<float> F8 = new Queue<float>();
         Queue<float> AF4 = new Queue<float>();
         Queue<float> TimeStamp = new Queue<float>();
    
         Queue<int> section = new Queue<int>();
         Queue<String> ComputerTime = new Queue<String>();
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
            sqlite_cmd.CommandText = "SELECT * FROM UserFinder where UserName="+user+";";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            if (!sqlite_datareader.Read())
            {
                sqlite_cmd.CommandText = "CREATE TABLE " + user + "_EEG" + "(UserName varchar(20) primary key,AF3 float , F7 float , F3 float,FC5 float, T7 float,P7 float,O1 float, O2 float,P8 float ,T8 float,FC6 float,F4 float,F8 float,AF4 float,TimeStamp float,section integer, ComputerTime varchar);";
                sqlite_cmd.ExecuteNonQuery();
                sqlite_cmd.CommandText = "CREATE TABLE " + user + "_BandPower" + "(UserName varchar(20) primary key,Alpha float, Beta float,TimeStamp float,section integer, ComputerTime varchar);";
                sqlite_cmd.ExecuteNonQuery();
                sqlite_cmd.CommandText = "INSERT INTO UserFinder (UserName) VALUES ("+user+");";
                sqlite_cmd.ExecuteNonQuery();
            }
            sqlite_conn.Close();
        }

        void CreateUserFinder()
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
            sqlite_cmd.CommandText = "CREATE TABLE UserFinder (UserName varchar(50) primary key);";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }


        void EEG_Insert(String UserName, float AF3,  float F7 ,  float F3, float FC5,  float T7, float P7, float O1,  float O2, float P8 , float T8, float FC6, float F4, float F8, float AF4, float TimeStamp, int section,  String ComputerTime )
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
            sqlite_cmd.CommandText = "INSERT INTO "+user + "_EEG (UserName varchar(20) primary key,AF3 float , F7 float , F3 float,FC5 float, T7 float,P7 float,O1 float, O2 float,P8 float ,T8 float,FC6 float,F4 float,F8 float,AF4 float,TimeStamp float,section integer, ComputerTime varchar) VALUES("+UserName+","+AF3+","+F7+","+","+F3+","+FC5+","+T7+","+P7+","+O1+","+O2+","+P8+","+FC6+","+F4+","+F8+","+AF4+","+TimeStamp+","+section+","+ComputerTime+");" ;
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }

         void BandPowerInsert(String UserName,float Alpha , float Beta, float TimeStamp, int section, String ComputerTime)
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
            sqlite_cmd.CommandText = "INSERT INTO " + user + "_BandPower(UserName varchar(20) primary key,Alpha float, Beta float,TimeStamp float,section integer, ComputerTime varchar) VALUES("+user+","+Alpha+","+Beta+","+TimeStamp+","+section+","+ComputerTime+");";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }

        
        void Loa_EEGData(String User )
        {
            Console.WriteLine("Start Loading EEG Data");
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
            sqlite_cmd.CommandText = "SELECT * FROM "+ User+"_EEG";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                AF3.Enqueue((float)sqlite_datareader["AF3"]);
                F7.Enqueue((float)sqlite_datareader["F7"]);
                F3.Enqueue((float)sqlite_datareader["F3"]);
                FC5.Enqueue((float)sqlite_datareader["FC5"]);
                T7.Enqueue((float)sqlite_datareader["T7"]); 
                P7.Enqueue((float)sqlite_datareader["P7"]);
                O1.Enqueue((float)sqlite_datareader["O1"]);
                O2.Enqueue((float)sqlite_datareader["O2"]);
                P8.Enqueue((float)sqlite_datareader["P8"]);
                T8.Enqueue((float)sqlite_datareader["T8"]);
                FC6.Enqueue((float)sqlite_datareader["FC6"]);
                F4.Enqueue((float)sqlite_datareader["F4"]);
                F8.Enqueue((float)sqlite_datareader["F8"]);
                AF4.Enqueue((float)sqlite_datareader["AF4"]);
                TimeStamp.Enqueue((float)sqlite_datareader["TimeStamp"]);
            }
            sqlite_conn.Close();
            Console.WriteLine("Finish Loading EEG Data");
        }

        void Load_BandPowerData(String UserName)
        {
            Console.WriteLine("Start Loading BandPower Data");
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
            sqlite_cmd.CommandText = "SELECT * FROM " + UserName + "_BandPower";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                alpha.Enqueue((float)sqlite_datareader["Alpha"]);
                beta.Enqueue((float)sqlite_datareader["Beta"]);
            }
             sqlite_conn.Close();
             Console.WriteLine("Finish Loading BandPower Data\n");
        }





        void SetUserName(String username)
        {
            user = username;
        }

     

        static void Main(string[] args)
        {
      
            Console.ReadKey();
        }
    }
}
