﻿using System;
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
using System.Windows.Shapes;

namespace MSM.HMI.Safety.Operation.Views.Windows
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ZoneDetail : Window
    {
        public ZoneDetail()
        {
            InitializeComponent();

            this.Loaded += winEStopDetails_Loaded;
            this.Closing += winEStopDetails_Closing;
        }

        private void winEStopDetails_Loaded(object sender, RoutedEventArgs e)
        { }

        private void winEStopDetails_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        { }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}