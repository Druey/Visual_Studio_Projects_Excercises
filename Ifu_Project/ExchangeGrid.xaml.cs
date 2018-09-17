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


namespace IfuControl
{
    /// <summary>
    /// Logica di interazione per ExchangeGrid.xaml
    /// </summary>
    public partial class ExchangeGrid : UserControl
    {
        public ExchangeGrid()
        {
            InitializeComponent();
            MaterialSearch.ObjectSelected += MaterialSelected;
            
            MaterialSearch.Visibility = Visibility.Hidden;
        }
        private void StackPanel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Panel.Visibility = Visibility.Hidden;
            PanelUnit.Visibility = Visibility.Hidden;
            MaterialSearch.Visibility = Visibility.Visible;
            
            
            var edit = (TextBox)MaterialSearch.Research.Template.FindName("PART_EditableTextBox", MaterialSearch.Research);
            edit.Focus();

        }
        void MaterialSelected(object sender, EventArgs e)
        {
            Panel.Visibility = Visibility.Visible;
            Panel.Content = MaterialSearch.strSelectedItem;
            PanelUnit.Visibility = Visibility.Visible;
            PanelUnit.Content = MaterialSearch.strUnitName;
            MaterialSearch.Visibility = Visibility.Hidden;
        }
    }
}
