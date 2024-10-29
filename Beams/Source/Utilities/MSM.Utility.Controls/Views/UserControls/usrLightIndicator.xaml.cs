using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace HSM.Utility.Controls
{
    /// <summary>
    /// Interaction logic for usrLightIndicator.xaml
    /// </summary>
    public partial class usrLightIndicator : UserControl, INotifyPropertyChanged
    {
        #region constructor
        public usrLightIndicator()
        {
            InitializeComponent();
        }
        #endregion

        #region public properties
        public static DependencyProperty LightOnProperty = DependencyProperty.Register("LightOn", typeof(bool), typeof(usrLightIndicator), new PropertyMetadata(false));
        public bool LightOn
        {
            get { return (bool)this.GetValue(LightOnProperty); }
            set
            {
                this.SetValue(LightOnProperty, value);
                OnPropertyChanged("LightOn");
            }
        }

        public static DependencyProperty IsLightOffRedProperty = DependencyProperty.Register("IsLightOffRed", typeof(bool), typeof(usrLightIndicator), new PropertyMetadata(false));
        public bool IsLightOffRed
        {
            get { return (bool)this.GetValue(IsLightOffRedProperty); }
            set
            {
                this.SetValue(IsLightOffRedProperty, value);
                OnPropertyChanged("IsLightOffRed");
            }
        }

        public static DependencyProperty IsLightOnGreenProperty = DependencyProperty.Register("IsLightOnGreen", typeof(bool), typeof(usrLightIndicator), new PropertyMetadata(false));
        public bool IsLightOnGreen
        {
            get { return (bool)this.GetValue(IsLightOnGreenProperty); }
            set
            {
                this.SetValue(IsLightOnGreenProperty, value);
                OnPropertyChanged("IsLightOnGreen");
            }
        }
        #endregion

        #region Property Changed
        /// <summary>
        /// OnPropertyChanged
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
