using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace IfuControl
{
    /// <summary>
    /// Logica di interazione per QueryCommand.xaml
    /// </summary>
    public partial class QueryCommand : UserControl
    {
        private DBConnection dbCon; 
        public QueryCommand()
        {
            InitializeComponent();
           dbCon = DBConnection.Instance();
           dbCon.DatabaseName = "YourDatabase";
        }

        private void QueryButton_Click(object sender, RoutedEventArgs e)
        {
            
            
            if (dbCon.IsConnect())
            {
                
                string query = "SELECT Nome,Cognome FROM Amici WHERE Id=1";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string someStringFromColumnZero = reader.GetString(0);
                    string someStringFromColumnOne = reader.GetString(1);
                    QueryResult.Text=someStringFromColumnZero + "," + someStringFromColumnOne;
                }
                dbCon.Close();
            }
        }
    }
}
