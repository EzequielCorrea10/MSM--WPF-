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
using System.ComponentModel;

namespace MSM.Utility.Controls
{
    /// <summary>
    /// Lógica de interacción para usrButtonIndicator.xaml
    /// </summary>
    using Janus.Rodeo.Windows.Library.UI.Controls;
    using Janus.Rodeo.Windows.Library.UI.Controls.Helpers;


    /// <summary>
    /// Interaction logic for usrButtonIndicator.xaml
    /// </summary>
    public partial class usrButtonIndicator : UserControl, INotifyPropertyChanged
    {

        public usrButtonIndicator()
        {
            
                InitializeComponent();
            
        }


        public RelayCommand DoSomething { get; set; }

        #region public properties
        public static DependencyProperty Button1OnProperty = DependencyProperty.Register("Button1On", typeof(bool), typeof(usrButtonIndicator), new PropertyMetadata(false));
        public bool Button1On
        {
            get { return (bool)this.GetValue(Button1OnProperty); }
            set
            {
                this.SetValue(Button1OnProperty, value);
                OnPropertyChanged("Button1On");
            }
        }

        public static DependencyProperty Button1WidthProperty = DependencyProperty.Register("Button1Width", typeof(int), typeof(usrButtonIndicator), new PropertyMetadata(60));
        public int Button1Width
        {
            get { return (int)this.GetValue(Button1WidthProperty); }
            set
            {
                this.SetValue(Button1WidthProperty, value);
                OnPropertyChanged("Button1Width");
            }
        }

        public static DependencyProperty IsButton1OffRedProperty = DependencyProperty.Register("IsButton1OffRed", typeof(bool), typeof(usrButtonIndicator), new PropertyMetadata(false));
        public bool IsButton1OffRed
        {
            get { return (bool)this.GetValue(IsButton1OffRedProperty); }
            set
            {
                this.SetValue(IsButton1OffRedProperty, value);
                OnPropertyChanged("IsButton1OffRed");
            }
        }

        public static DependencyProperty IsButton1OnGreenProperty = DependencyProperty.Register("IsButton1OnGreen", typeof(bool), typeof(usrButtonIndicator), new PropertyMetadata(false));
        public bool IsButton1OnGreen
        {
            get { return (bool)this.GetValue(IsButton1OnGreenProperty); }
            set
            {
                this.SetValue(IsButton1OnGreenProperty, value);
                OnPropertyChanged("IsButton1OnGreen");
            }
        }

        public static DependencyProperty Button2OnProperty = DependencyProperty.Register("Button2On", typeof(bool), typeof(usrButtonIndicator), new PropertyMetadata(false));
        public bool Button2On
        {
            get { return (bool)this.GetValue(Button2OnProperty); }
            set
            {
                this.SetValue(Button2OnProperty, value);
                OnPropertyChanged("Button2On");
            }
        }

        public static DependencyProperty Button2WidthProperty = DependencyProperty.Register("Button2Width", typeof(int), typeof(usrButtonIndicator), new PropertyMetadata(60));
        public int Button2Width
        {
            get { return (int)this.GetValue(Button2WidthProperty); }
            set
            {
                this.SetValue(Button2WidthProperty, value);
                OnPropertyChanged("Button2Width");
            }
        }

        public static DependencyProperty IsButton2OffRedProperty = DependencyProperty.Register("IsButton2OffRed", typeof(bool), typeof(usrButtonIndicator), new PropertyMetadata(false));
        public bool IsButton2OffRed
        {
            get { return (bool)this.GetValue(IsButton2OffRedProperty); }
            set
            {
                this.SetValue(IsButton2OffRedProperty, value);
                OnPropertyChanged("IsButton2OffRed");
            }
        }

        public static DependencyProperty IsButton2OnGreenProperty = DependencyProperty.Register("IsButton2OnGreen", typeof(bool), typeof(usrButtonIndicator), new PropertyMetadata(false));
        public bool IsButton2OnGreen
        {
            get { return (bool)this.GetValue(IsButton2OnGreenProperty); }
            set
            {
                this.SetValue(IsButton2OnGreenProperty, value);
                OnPropertyChanged("IsButton2OnGreen");
            }
        }

        public static DependencyProperty Button3OnProperty = DependencyProperty.Register("Button3On", typeof(bool), typeof(usrButtonIndicator), new PropertyMetadata(false));
        public bool Button3On
        {
            get { return (bool)this.GetValue(Button3OnProperty); }
            set
            {
                this.SetValue(Button3OnProperty, value);
                OnPropertyChanged("Button3On");
            }
        }

        public static DependencyProperty Button3WidthProperty = DependencyProperty.Register("Button3Width", typeof(int), typeof(usrButtonIndicator), new PropertyMetadata(60));
        public int Button3Width
        {
            get { return (int)this.GetValue(Button3WidthProperty); }
            set
            {
                this.SetValue(Button3WidthProperty, value);
                OnPropertyChanged("Button3Width");
            }
        }

        public static DependencyProperty IsButton3OffRedProperty = DependencyProperty.Register("IsButton3OffRed", typeof(bool), typeof(usrButtonIndicator), new PropertyMetadata(false));
        public bool IsButton3OffRed
        {
            get { return (bool)this.GetValue(IsButton3OffRedProperty); }
            set
            {
                this.SetValue(IsButton3OffRedProperty, value);
                OnPropertyChanged("IsButton3OffRed");
            }
        }

        public static DependencyProperty IsButton3OnGreenProperty = DependencyProperty.Register("IsButton3OnGreen", typeof(bool), typeof(usrButtonIndicator), new PropertyMetadata(false));
        public bool IsButton3OnGreen
        {
            get { return (bool)this.GetValue(IsButton3OnGreenProperty); }
            set
            {
                this.SetValue(IsButton3OnGreenProperty, value);
                OnPropertyChanged("IsButton3OnGreen");
            }
        }

        public static DependencyProperty Button4OnProperty = DependencyProperty.Register("Button4On", typeof(bool), typeof(usrButtonIndicator), new PropertyMetadata(false));
        public bool Button4On
        {
            get { return (bool)this.GetValue(Button4OnProperty); }
            set
            {
                this.SetValue(Button4OnProperty, value);
                OnPropertyChanged("Button4On");
            }
        }

        public static DependencyProperty Button4WidthProperty = DependencyProperty.Register("Button4Width", typeof(int), typeof(usrButtonIndicator), new PropertyMetadata(60));
        public int Button4Width
        {
            get { return (int)this.GetValue(Button4WidthProperty); }
            set
            {
                this.SetValue(Button4WidthProperty, value);
                OnPropertyChanged("Button4Width");
            }
        }

        public static DependencyProperty IsButton4OffRedProperty = DependencyProperty.Register("IsButton4OffRed", typeof(bool), typeof(usrButtonIndicator), new PropertyMetadata(false));
        public bool IsButton4OffRed
        {
            get { return (bool)this.GetValue(IsButton4OffRedProperty); }
            set
            {
                this.SetValue(IsButton4OffRedProperty, value);
                OnPropertyChanged("IsButton4OffRed");
            }
        }

        public static DependencyProperty IsButton4OnGreenProperty = DependencyProperty.Register("IsButton4OnGreen", typeof(bool), typeof(usrButtonIndicator), new PropertyMetadata(false));
        public bool IsButton4OnGreen
        {
            get { return (bool)this.GetValue(IsButton4OnGreenProperty); }
            set
            {
                this.SetValue(IsButton4OnGreenProperty, value);
                OnPropertyChanged("IsButton4OnGreen");
            }
        }

        public static DependencyProperty Button5OnProperty = DependencyProperty.Register("Button5On", typeof(bool), typeof(usrButtonIndicator), new PropertyMetadata(false));
        public bool Button5On
        {
            get { return (bool)this.GetValue(Button5OnProperty); }
            set
            {
                this.SetValue(Button5OnProperty, value);
                OnPropertyChanged("Button5On");
            }
        }

        public static DependencyProperty Button5WidthProperty = DependencyProperty.Register("Button5Width", typeof(int), typeof(usrButtonIndicator), new PropertyMetadata(60));
        public int Button5Width
        {
            get { return (int)this.GetValue(Button5WidthProperty); }
            set
            {
                this.SetValue(Button5WidthProperty, value);
                OnPropertyChanged("Button5Width");
            }
        }

        public static DependencyProperty IsButton5OffRedProperty = DependencyProperty.Register("IsButton5OffRed", typeof(bool), typeof(usrButtonIndicator), new PropertyMetadata(false));
        public bool IsButton5OffRed
        {
            get { return (bool)this.GetValue(IsButton5OffRedProperty); }
            set
            {
                this.SetValue(IsButton5OffRedProperty, value);
                OnPropertyChanged("IsButton5OffRed");
            }
        }

        public static DependencyProperty IsButton5OnGreenProperty = DependencyProperty.Register("IsButton5OnGreen", typeof(bool), typeof(usrButtonIndicator), new PropertyMetadata(false));
        public bool IsButton5OnGreen
        {
            get { return (bool)this.GetValue(IsButton5OnGreenProperty); }
            set
            {
                this.SetValue(IsButton5OnGreenProperty, value);
                OnPropertyChanged("IsButton5OnGreen");
            }
        }

        public static DependencyProperty vmCommandParameterProperty = DependencyProperty.Register("vmCommandParameter", typeof(string), typeof(usrButtonIndicator), new PropertyMetadata(string.Empty));
        public string vmCommandParameter
        {
            get { return (string)this.GetValue(vmCommandParameterProperty); }
            set
            {
                this.SetValue(vmCommandParameterProperty, value);
                OnPropertyChanged("vmCommandParameter");
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