using TagTest.Classes;
using TagTest.ViewModels;
//using CPL.Utility.Configuration;
//using CPL.Utility.Controls;
using Janus.Rodeo.Windows.Library.UI.Controls;
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

namespace TagTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
            :base()
        {
            InitializeComponent();
        }

        #region Tags
        private void btnGetTags_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel vm = (MainViewModel)this.DataContext;
            vm.GetTags();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel vm = (MainViewModel)this.DataContext;
            vm.UpdateTag();
        }

        private void btnUpdateAll_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel vm = (MainViewModel)this.DataContext;

            if (grdItems.SelectedItems.Count > 0)
            {
                foreach (var item in grdItems.SelectedItems)
                {
                    try
                    {
                        RodeoTag tag = (RodeoTag)item;
                        vm.UpdateTag(tag);
                    }
                    catch (Exception ex)
                    {
                        string errorMsg = ex.Message;
                    }
                }

                vm.GetTags();
                vm.ValueAsText = false;
            }
        }

        private void MessageBox(string message)
        {
            throw new NotImplementedException();
        }
        #endregion

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
