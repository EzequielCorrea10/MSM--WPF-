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
using System.Collections.Concurrent;

namespace HSM.HMI.Safety.Operation.Views
{
    using HSM.HMI.Safety.Operation.ViewModels;
    using HSM.Utility.Configuration;
    using HSM.Utility.Common.Catalogs;

    /// <summary>
    /// Interaction logic for usrLayout.xaml
    /// </summary>
    public partial class usrPillingLayout : UserControl
    {
        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="usrPillingLayout"/> class.
        /// </summary>
        public usrPillingLayout()
        {
            this.DataContext = new vmPillingZone();
            InitializeComponent();
        }

        #endregion

        #region private events
        private void btnLayoutLeft_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.ScrollViewer scroll = scrollXY as System.Windows.Controls.ScrollViewer;
            if (scroll != null)
            {
                double actual_offset;
                if (Configurations.HMIs.safety_layout_inverted)
                {
                    actual_offset = scroll.HorizontalOffset + 100;
                    if (actual_offset > scroll.ScrollableWidth)
                    {
                        actual_offset = scroll.ScrollableWidth;
                    }
                }
                else
                {
                    actual_offset = scroll.HorizontalOffset - 100;
                    if (actual_offset < 0)
                    {
                        actual_offset = 0;
                    }
                }
                scroll.ScrollToHorizontalOffset(actual_offset);
            }
        }

        private void btnLayoutRight_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.ScrollViewer scroll = scrollXY as System.Windows.Controls.ScrollViewer;
            if (scroll != null)
            {
                double actual_offset;
                if (Configurations.HMIs.safety_layout_inverted)
                {
                    actual_offset = scroll.HorizontalOffset - 100;
                    if (actual_offset < 0)
                    {
                        actual_offset = 0;
                    }
                }
                else
                {
                    actual_offset = scroll.HorizontalOffset + 100;
                    if (actual_offset > scroll.ScrollableWidth)
                    {
                        actual_offset = scroll.ScrollableWidth;
                    }
                }
                scroll.ScrollToHorizontalOffset(actual_offset);
            }
        }


        private void btn_Zoom_Click(object sender, RoutedEventArgs e)
        {
            West.Visibility = (West.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            East.Visibility = (East.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            WestD.Visibility = (WestD.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            EastD.Visibility = (EastD.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
        }


        private void btnSelectYard1_Click(object sender, RoutedEventArgs e)
        {            
            //Button _button = (Button)sender;
            //vmYard y = (vmYard)_button.Tag;        
            //HSM.HMI.Safety.Operation.Behaviours.ClickZoom.ZoomYard(this.scrollXY, this.zoomScale, y.Properties.Id);      
        }
        #endregion

        private void MultiSelect_ComboBox_SelectedItemsChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            vmLayout data = (vmLayout)this.DataContext;
            data.EnableFeaturesCommand.Execute(sender);
        }

        private void Multi_SelectMachineComboBox_SelectedItemsChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            vmLayout data = (vmLayout)this.DataContext;
            data.ShowCommand.Execute(sender);
        }

        private void btnArrow_Checked(object sender, RoutedEventArgs e)
        {
            West.Visibility = West.Visibility;
            West.Visibility = West.Visibility;

        }

        private void btnBinocular_Checked(object sender, RoutedEventArgs e)
        {
            West.Visibility = (West.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            East.Visibility = (East.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
        }        
    }
}