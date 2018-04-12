using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace IfuControl
{
    class MaterialTemplateSelector:DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null)
            {
                if (item is elementaryExchange)
                {
                    
                        return element.FindResource("elementary") as DataTemplate;
                    
                            
                }
                else if(item is intermediateExchange)
                {
                    return element.FindResource("intermediate") as DataTemplate;

                }
            }

            return null;
        }
    }
}
