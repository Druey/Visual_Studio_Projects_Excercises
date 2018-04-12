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


namespace IfuControl
{
    /// <summary>
    /// Logica di interazione per MaterialComboBox.xaml
    /// </summary>
    public partial class MaterialComboBox : UserControl
    {
        Exchanges ElementaryExchanges = null; 
        validIntermediateExchanges IntermediateExchanges = null; 
        public string strSelectedItem;
        public string strUnitName;
        public event EventHandler<EventArgs> ObjectSelected;

        

        public MaterialComboBox()
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
            
            if (Research.Text.Length >= 3)
            {
                

                List<intermediateExchange> List1 = IntermediateExchanges.Materials.FindAll(x => x.Name.IndexOf(Research.Text,0, StringComparison.OrdinalIgnoreCase) >=0);

                List<intermediateExchange> List2 = IntermediateExchanges.Materials.FindAll(x => x.Classification_Value.ClassValue.IndexOf(Research.Text, 0, StringComparison.OrdinalIgnoreCase) >= 0);

                List<elementaryExchange> List3 = ElementaryExchanges.Materials.FindAll(x => x.Name.IndexOf(Research.Text, 0, StringComparison.OrdinalIgnoreCase) >= 0);

                List<elementaryExchange> List4 = ElementaryExchanges.Materials.FindAll(x => x.Classification_Compartment.Compartment.IndexOf(Research.Text, 0, StringComparison.OrdinalIgnoreCase) >= 0);

                List<elementaryExchange> List5 = ElementaryExchanges.Materials.FindAll(x => x.Classification_Compartment.Subcompartment.IndexOf(Research.Text, 0, StringComparison.OrdinalIgnoreCase) >= 0);

                List1.AddRange(List2);
                

                List3.AddRange(List4);
                List3.AddRange(List5);
                

                List<intermediateExchange> uniqueIntermediate = null;
                List<elementaryExchange> uniqueElementary = null;

                uniqueIntermediate = List1.Distinct().ToList();
                uniqueElementary = List3.Distinct().ToList();
                List<object> MaterialList = new List<object>();
                MaterialList.AddRange(uniqueIntermediate);
                MaterialList.AddRange(uniqueElementary);


                Research.ItemsSource = MaterialList;
                Research.IsDropDownOpen = true;
                var edit = (TextBox)Research.Template.FindName("PART_EditableTextBox", Research);
                edit.Select(0, 0);
                edit.CaretIndex = edit.Text.Length;
                if (strSelectedItem != null)
                {

                    edit.Text = strSelectedItem;
                    strSelectedItem = null;
                }
            }

        }


        private void Research_SelectedItem(object sender, SelectionChangedEventArgs e)
        {
            
            
            if (Research.SelectedItem is intermediateExchange)
            {
                strSelectedItem = ((intermediateExchange)Research.SelectedItem).Name;
                strUnitName= ((intermediateExchange)Research.SelectedItem).UnitName;

            }
            else if (Research.SelectedItem is elementaryExchange)
            {
                strSelectedItem = ((elementaryExchange)Research.SelectedItem).Name;
                strUnitName= ((elementaryExchange)Research.SelectedItem).UnitName;

            }
            Research.IsDropDownOpen = false;
            EventArgs args=new EventArgs();
            if (ObjectSelected != null) ObjectSelected(this,args);


        }
    }
}
