using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MSM.HMI.Safety.Operation.Selectors
{
    using MSM.HMI.Safety.Operation.ViewModels;

    public class LayoutElementSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement elemnt = container as FrameworkElement;
            if (item is vmLayoutZoneSection)
            {
                return elemnt.FindResource("sectionDataTemplate") as DataTemplate;
            }

            return null;
        }
    }
}