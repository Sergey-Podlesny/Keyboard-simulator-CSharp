using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace kursaCH
{
    static class DataBase
    {
        static string connectionString;
        static string commandString;

        static MySqlConnection sqlConnection;
        static MySqlCommand sqlCommand;

        static MySqlDataReader reader;
        public static ServerData serverData { get; set; }
        public static string dataBaseTableName { get; set; }



        public static void SetData(string dbName, string dbPassword, string dbUserName, string dbServerName, string dbTableName)
        {
            serverData = new ServerData(dbName, dbPassword, dbUserName, dbServerName);
            dataBaseTableName = dbTableName;
        }
     
        public static void SetConnection()
        {
            connectionString = $"server = {serverData.dataBaseServerName}; user = {serverData.dataBaseUserName}; database = {serverData.dataBaseName}; password = {serverData.dataBasePassword};";
            try
            {
                sqlConnection = new MySqlConnection(connectionString);
                sqlCommand = new MySqlCommand();
                sqlCommand.Connection = sqlConnection;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void OpenConnection()
        {
            try
            {
                sqlConnection.Open();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void SetCommandString(string comStr)
        {
            commandString = comStr;
        }

        public static void Execute()
        {
            try
            {
                sqlCommand.CommandText = commandString;
                sqlCommand.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static MySqlDataReader Select()
        {
            try 
            {
                sqlCommand.CommandText = commandString;
                reader = sqlCommand.ExecuteReader();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return reader;
        }



        public static void CloseConnection()
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}