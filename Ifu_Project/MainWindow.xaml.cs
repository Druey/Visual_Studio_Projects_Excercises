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
using System.Xml.Serialization;
using System.IO;

namespace Ifu_Project
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Exchanges ElementaryExchanges=null;
        validIntermediateExchanges IntermediateExchanges = null;
        
        public MainWindow()
        {
            
            XmlSerializer serializer = new XmlSerializer(typeof(Exchanges));
            string path = "C:\\Users\\druey\\Documents\\Visual Studio 2015\\Projects\\Ifu_Project\\Ifu_Project\\Resocurces\\" + "ElementaryExchanges.xml";
            using (StreamReader reader = new StreamReader(path))
            {

                ElementaryExchanges = (Exchanges)serializer.Deserialize(reader);
                
            }

            
            serializer = new XmlSerializer(typeof(validIntermediateExchanges));
            path = "C:\\Users\\druey\\Documents\\Visual Studio 2015\\Projects\\Ifu_Project\\Ifu_Project\\Resocurces\\" + "IntermediateExchanges.xml";
            using (StreamReader reader = new StreamReader(path))
            {
                IntermediateExchanges = (validIntermediateExchanges)serializer.Deserialize(reader);
                
            }

            InitializeComponent();
            
        }

       

        private void Research_TextChanged(object sender, RoutedEventArgs e)
        {
            //IndexOf("string", StringComparison.OrdinalIgnoreCase) >= 0;

            List<intermediateExchange> uniqueIntermediate = null;
            List<elementaryExchange> uniqueElementary = null;
            if (Research.Text.Length>=3)
            {   
                List<intermediateExchange> List1 = IntermediateExchanges.Materials.FindAll(x => x.Name.Contains(Research.Text));
                                
                List<intermediateExchange> List2 = IntermediateExchanges.Materials.FindAll(x => x.classificationValue.ClassValue.Contains(Research.Text));

                List<elementaryExchange> List3 =  ElementaryExchanges.Materials.FindAll(x => x.Name.Contains(Research.Text));

                List<elementaryExchange> List4 = ElementaryExchanges.Materials.FindAll(x => x.Compartment.Compartment.Contains(Research.Text));

                List<elementaryExchange> List5 = ElementaryExchanges.Materials.FindAll(x => x.Compartment.Subcompartment.Contains(Research.Text));
                
                var result1 = List1.Concat(List2);
                List<intermediateExchange> intermediateCompleteList = result1.ToList();

                var result2 = List3.Concat(List4).Concat(List5);
                List<elementaryExchange> elementaryCompleteList = result2.ToList();   

                uniqueIntermediate = intermediateCompleteList.Distinct().ToList();
                uniqueElementary = elementaryCompleteList.Distinct().ToList();
                List<object> MaterialList = new List<object>();
                MaterialList.AddRange(uniqueIntermediate);
                MaterialList.AddRange(uniqueElementary);
                

                Research.ItemsSource = MaterialList;
                Research.IsDropDownOpen = true;
                var edit = (TextBox)Research.Template.FindName("PART_EditableTextBox", Research);
                edit.Select(0, 0);
                edit.CaretIndex = edit.Text.Length;

            }
            
        }


        private void Research_SelectedItem(object sender, SelectionChangedEventArgs e)
        {
            bool elementary;
            object SelectedItem = null;
            if (Research.SelectedItem is intermediateExchange)
            {
                SelectedItem = (intermediateExchange)Research.SelectedItem;
                elementary = false;
            }
            else
            {
                SelectedItem = (elementaryExchange)Research.SelectedItem;
                elementary = true;
            }
            if (SelectedItem != null)
            {
                if (elementary == true)
                {
                    Research.Text = ((elementaryExchange)SelectedItem).Name;
                }
                else {

                    Research.Text = ((intermediateExchange)SelectedItem).Name;
                    Material.Content = ((intermediateExchange)SelectedItem).Name;
                }
            }
        }
    }
}
