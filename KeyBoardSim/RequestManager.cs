//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using MySql.Data.MySqlClient;

//namespace kursaCH
//{
//    static class RequestManager
//    {
//        static DataBase dataBase;
//        static MySqlDataReader reader;

//        static RequestManager()
//        {
//            dataBase = new DataBase("keyboard_simulator", "admin", "root", "localhost", "users");

//        }

//        public static void SartServer()
//        {
//            dataBase.SetConnection();
//            dataBase.OpenConnection();
//        }


//        public static void SelectRequest(string select, string where, string value)
//        {
//            dataBase.SetCommandString($"SELECT {select} FROM users WHERE {where} = '{value}'");
//            reader = dataBase.SelectRequest();
//        }

//        public static bool PasswordCompare(string inputPassword)
//        {
//            bool compare = false;
//            if (reader.Read())
//            {
//                string rightPassword = reader[0].ToString();
//                compare = (rightPassword == inputPassword) ? true : false;
//            }
//            reader.Close();
//            return compare;
//        }

        

//        public static void CloseServer()
//        {
//            dataBase.CloseConnection();
//        }

//    }
//}
