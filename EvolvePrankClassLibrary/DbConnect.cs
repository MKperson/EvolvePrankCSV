using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace EvolvePrankClassLibrary
{
    public class DbConnect
    {
            private DbConnect()
            {
            }

            private string databaseName = string.Empty;
            public string DatabaseName
            {
                get { return databaseName; }
                set { databaseName = value; }
            }

            public string Password { get; set; }
            private MySqlConnection connection = null;
            public MySqlConnection Connection
            {
                get { return connection; }
            }

            private static DbConnect _instance = null;
            public static DbConnect Instance()
            {
                if (_instance == null)
                    _instance = new DbConnect();
                return _instance;
            }

            public bool IsConnect()
            {
                if (Connection == null)
                {
                    if (String.IsNullOrEmpty(databaseName))
                        return false;
                    string connstring = string.Format("server={0};UID={1}; password={2}; database={3}",server,UID,password,databaseName);
                
                    connection = new MySqlConnection(connstring);
                    connection.Open();
            }
            else
            {
                connection.Open();
            }

                return true;
            }

            public void Close()
            {
                connection.Close();
            }
        }
    }
