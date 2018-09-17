using System;
using MySql.Data;
using MySql.Data.MySqlClient;

 namespace IfuControl
{
   
    
        public class DBConnection
        {
            private DBConnection()
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

            private static DBConnection _instance = null;
            public static DBConnection Instance()
            {
                if (_instance == null)
                    _instance = new DBConnection();
                return _instance;
            }

            public bool IsConnect()
            {
                if (Connection == null)
                {
                    if (String.IsNullOrEmpty(databaseName))
                        return false;
                    string connstring = string.Format("Server=sql2.freemysqlhosting.net; database=sql2257273; UID=sql2257273; password= vU6*qC9*");
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
