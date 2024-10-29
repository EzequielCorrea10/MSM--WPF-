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

namespace HCM.Utility.Controls
{
    /// <summary>
    /// Interaction logic for usrSelectorTwoButtons.xaml
    /// </summary>
    public partial class usrSelectorTwoButtons : UserControl, INotifyPropertyChanged
    {
        #region constructor
        public usrSelectorTwoButtons()
        {
            InitializeComponent();
        }
        #endregion

        #region public properties
        public static DependencyProperty OptionSelectedProperty = DependencyProperty.Register("OptionSelected", typeof(int), typeof(usrSelectorTwoButtons), new PropertyMetadata(1));
        public int OptionSelected
        {
            get { return (int)this.GetValue(OptionSelectedProperty); }
            set
            {
                this.SetValue(OptionSelectedProperty, value);
                OnPropertyChanged("OptionSelected");
            }
        }

        public static DependencyProperty ImageWidthProperty = DependencyProperty.Register("ImageWidth", typeof(double), typeof(usrSelectorTwoButtons), new PropertyMetadata(100.0));
        public double ImageWidth
        {
            get { return (double)this.GetValue(ImageWidthProperty); }
            set
            {
                this.SetValue(ImageWidthProperty, value);
                OnPropertyChanged("ImageWidth");
            }
        }

        public static DependencyProperty ImageHeightProperty = DependencyProperty.Register("ImageHeight", typeof(double), typeof(usrSelectorTwoButtons), new PropertyMetadata(100.0));
        public double ImageHeight
        {
            get { return (double)this.GetValue(ImageHeightProperty); }
            set
            {
                this.SetValue(ImageHeightProperty, value);
                OnPropertyChanged("ImageHeight");
            }
        }

        public static DependencyProperty ButtonWidthProperty = DependencyProperty.Register("ButtonWidth", typeof(double), typeof(usrSelectorTwoButtons), new PropertyMetadata(100.0));
        public double ButtonWidth
        {
            get { return (double)this.GetValue(ButtonWidthProperty); }
            set
            {
                this.SetValue(ButtonWidthProperty, value);
                OnPropertyChanged("ButtonWidth");
            }
        }

        public static DependencyProperty ButtonHeightProperty = DependencyProperty.Register("ButtonHeight", typeof(double), typeof(usrSelectorTwoButtons), new PropertyMetadata(25.0));
        public double ButtonHeight
        {
            get { return (double)this.GetValue(ButtonHeightProperty); }
            set
            {
                this.SetValue(ButtonHeightProperty, value);
                OnPropertyChanged("ButtonHeight");
            }
        }

        public static DependencyProperty ButtonFontSizeProperty = DependencyProperty.Register("ButtonFontSize", typeof(double), typeof(usrSelectorTwoButtons), new PropertyMetadata(14.0));
        public double ButtonFontSize
        {
            get { return (double)this.GetValue(ButtonFontSizeProperty); }
            set
            {
                this.SetValue(ButtonFontSizeProperty, value);
                OnPropertyChanged("ButtonFontSize");
            }
        }

        public static DependencyProperty DescriptionFontSizeProperty = DependencyProperty.Register("DescriptionFontSize", typeof(double), typeof(usrSelectorTwoButtons), new PropertyMetadata(16.0));
        public double DescriptionFontSize
        {
            get { return (double)this.GetValue(DescriptionFontSizeProperty); }
            set
            {
                this.SetValue(DescriptionFontSizeProperty, value);
                OnPropertyChanged("DescriptionFontSize");
            }
        }

        public static DependencyProperty FirstOptionNameProperty = DependencyProperty.Register("FirstOptionName", typeof(string), typeof(usrSelectorTwoButtons), new PropertyMetadata("FIRST"));
        public string FirstOptionName
        {
            get { return (string)this.GetValue(FirstOptionNameProperty); }
            set
            {
                this.SetValue(FirstOptionNameProperty, value);
                OnPropertyChanged("FirstOptionName");
            }
        }

        public static DependencyProperty SecondOptionNameProperty = DependencyProperty.Register("SecondOptionName", typeof(string), typeof(usrSelectorTwoButtons), new PropertyMetadata("SECOND"));
        public string SecondOptionName
        {
            get { return (string)this.GetValue(SecondOptionNameProperty); }
            set
            {
                this.SetValue(SecondOptionNameProperty, value);
                OnPropertyChanged("SecondOptionName");
            }
        }

        public static DependencyProperty IsFirstOptionRedProperty = DependencyProperty.Register("IsFirstOptionRed", typeof(bool), typeof(usrSelectorTwoButtons), new PropertyMetadata(false));
        public bool IsFirstOptionRed
        {
            get { return (bool)this.GetValue(IsFirstOptionRedProperty); }
            set
            {
                this.SetValue(IsFirstOptionRedProperty, value);
                OnPropertyChanged("IsFirstOptionRed");
            }
        }        

        public static DependencyProperty IsSecondOptionRedProperty = DependencyProperty.Register("IsSecondOptionRed", typeof(bool), typeof(usrSelectorTwoButtons), new PropertyMetadata(false));
        public bool IsSecondOptionRed
        {
            get { return (bool)this.GetValue(IsSecondOptionRedProperty); }
            set
            {
                this.SetValue(IsSecondOptionRedProperty, value);
                OnPropertyChanged("IsSecondOptionRed");
            }
        }        

        public static DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(usrSelectorTwoButtons), new PropertyMetadata(null));
        public string Description
        {
            get { return (string)this.GetValue(DescriptionProperty); }
            set
            {
                this.SetValue(DescriptionProperty, value);
                OnPropertyChanged("Description");
            }
        }
        #endregion

        #region public command
        public static DependencyProperty FirstOptionCommandProperty = DependencyProperty.Register("FirstOptionCommand", typeof(ICommand), typeof(usrSelectorTwoButtons), new UIPropertyMetadata(null));
        public ICommand FirstOptionCommand
        {
            get { return (ICommand)this.GetValue(FirstOptionCommandProperty); }
            set
            {
                this.SetValue(FirstOptionCommandProperty, value);
                OnPropertyChanged("FirstOptionCommand");
            }
        }

        public static DependencyProperty FirstOptionCommandParameterProperty = DependencyProperty.Register("FirstOptionCommandParameter", typeof(object), typeof(usrSelectorTwoButtons), new UIPropertyMetadata(null));
        public object FirstOptionCommandParameter
        {
            get { return (object)this.GetValue(FirstOptionCommandParameterProperty); }
            set
            {
                this.SetValue(FirstOptionCommandParameterProperty, value);
                OnPropertyChanged("FirstOptionCommandParameter");
            }
        }

        public static DependencyProperty SecondOptionCommandProperty = DependencyProperty.Register("SecondOptionCommand", typeof(ICommand), typeof(usrSelectorTwoButtons), new UIPropertyMetadata(null));
        public ICommand SecondOptionCommand
        {
            get { return (ICommand)this.GetValue(SecondOptionCommandProperty); }
            set
            {
                this.SetValue(SecondOptionCommandProperty, value);
                OnPropertyChanged("SecondOptionCommand");
            }
        }

        public static DependencyProperty SecondOptionCommandParameterProperty = DependencyProperty.Register("SecondOptionCommandParameter", typeof(object), typeof(usrSelectorTwoButtons), new UIPropertyMetadata(null));
        public object SecondOptionCommandParameter
        {
            get { return (object)this.GetValue(SecondOptionCommandParameterProperty); }
            set
            {
                this.SetValue(SecondOptionCommandParameterProperty, value);
                OnPropertyChanged("SecondOptionCommandParameter");
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
