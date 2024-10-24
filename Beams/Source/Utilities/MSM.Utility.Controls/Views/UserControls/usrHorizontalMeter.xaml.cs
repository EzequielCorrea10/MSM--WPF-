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

namespace MSM.Utility.Controls
{
    /// <summary>
    /// Interaction logic for usrHorizontalMeter.xaml
    /// </summary>
    public partial class usrHorizontalMeter : UserControl, INotifyPropertyChanged
    {
        #region constructor
        public usrHorizontalMeter()
        {
            InitializeComponent();
        }
        #endregion

        #region public properties

        public static DependencyProperty MeterBorderThicknessProperty = DependencyProperty.Register("MeterBorderThickness", typeof(Thickness), typeof(usrHorizontalMeter), new PropertyMetadata(new Thickness(1)));
        public Thickness MeterBorderThickness
        {
            get { return (Thickness)this.GetValue(MeterBorderThicknessProperty); }
            set
            {
                this.SetValue(MeterBorderThicknessProperty, value);
                OnPropertyChanged("MeterBorderThickness");
            }
        }

        public static DependencyProperty MeterBorderBrushProperty = DependencyProperty.Register("MeterBorderBrush", typeof(Brush), typeof(usrHorizontalMeter), new PropertyMetadata(Brushes.WhiteSmoke));
        public Brush MeterBorderBrush
        {
            get { return (Brush)this.GetValue(MeterBorderBrushProperty); }
            set
            {
                this.SetValue(MeterBorderBrushProperty, value);
                OnPropertyChanged("MeterBorderBrush");
            }
        }

        public static DependencyProperty MeterCornerRadiusProperty = DependencyProperty.Register("MeterCornerRadius", typeof(CornerRadius), typeof(usrHorizontalMeter), new PropertyMetadata(new CornerRadius(0)));
        public CornerRadius MeterCornerRadius
        {
            get { return (CornerRadius)this.GetValue(MeterCornerRadiusProperty); }
            set
            {
                this.SetValue(MeterCornerRadiusProperty, value);
                OnPropertyChanged("MeterCornerRadius");
            }
        }

        public static DependencyProperty MeterHeightProperty = DependencyProperty.Register("MeterHeight", typeof(double), typeof(usrHorizontalMeter), new PropertyMetadata(30.0));
        public double MeterHeight
        {
            get { return (double)this.GetValue(MeterHeightProperty); }
            set
            {
                this.SetValue(MeterHeightProperty, value);
                OnPropertyChanged("MeterHeight");
            }
        }

        public static DependencyProperty TitleWidthProperty = DependencyProperty.Register("TitleWidth", typeof(double), typeof(usrHorizontalMeter), new PropertyMetadata(100.0));
        public double TitleWidth
        {
            get { return (double)this.GetValue(TitleWidthProperty); }
            set
            {
                this.SetValue(TitleWidthProperty, value);
                OnPropertyChanged("TitleWidth");
            }
        }

        public static DependencyProperty ValueWidthProperty = DependencyProperty.Register("ValueWidth", typeof(double), typeof(usrHorizontalMeter), new PropertyMetadata(60.0));
        public double ValueWidth
        {
            get { return (double)this.GetValue(ValueWidthProperty); }
            set
            {
                this.SetValue(ValueWidthProperty, value);
                OnPropertyChanged("ValueWidth");
            }
        }

        public static DependencyProperty UnitWidthProperty = DependencyProperty.Register("UnitWidth", typeof(double), typeof(usrHorizontalMeter), new PropertyMetadata(40.0));
        public double UnitWidth
        {
            get { return (double)this.GetValue(UnitWidthProperty); }
            set
            {
                this.SetValue(UnitWidthProperty, value);
                OnPropertyChanged("UnitWidth");
            }
        }

        public static DependencyProperty TitleDescriptionProperty = DependencyProperty.Register("TitleDescription", typeof(string), typeof(usrHorizontalMeter), new PropertyMetadata("TITLE"));
        public string TitleDescription
        {
            get { return (string)this.GetValue(TitleDescriptionProperty); }
            set
            {
                this.SetValue(TitleDescriptionProperty, value);
                OnPropertyChanged("TitleDescription");
            }
        }

        public static DependencyProperty ValueDescriptionProperty = DependencyProperty.Register("ValueDescription", typeof(string), typeof(usrHorizontalMeter), new PropertyMetadata("0.0"));
        public string ValueDescription
        {
            get { return (string)this.GetValue(ValueDescriptionProperty); }
            set
            {
                this.SetValue(ValueDescriptionProperty, value);
                OnPropertyChanged("ValueDescription");
            }
        }

        public static DependencyProperty SPDescriptionProperty = DependencyProperty.Register("SPDescription", typeof(string), typeof(usrHorizontalMeter), new PropertyMetadata(null));
        public string SPDescription
        {
            get { return (string)this.GetValue(SPDescriptionProperty); }
            set
            {
                this.SetValue(SPDescriptionProperty, value);
                OnPropertyChanged("SPDescription");
            }
        }

        public static DependencyProperty ExtraDescriptionProperty = DependencyProperty.Register("ExtraDescription", typeof(string), typeof(usrHorizontalMeter), new PropertyMetadata(null));
        public string ExtraDescription
        {
            get { return (string)this.GetValue(ExtraDescriptionProperty); }
            set
            {
                this.SetValue(ExtraDescriptionProperty, value);
                OnPropertyChanged("ExtraDescription");
            }
        }

        public static DependencyProperty UnitDescriptionProperty = DependencyProperty.Register("UnitDescription", typeof(string), typeof(usrHorizontalMeter), new PropertyMetadata(null));
        public string UnitDescription
        {
            get { return (string)this.GetValue(UnitDescriptionProperty); }
            set
            {
                this.SetValue(UnitDescriptionProperty, value);
                OnPropertyChanged("UnitDescription");
            }
        }

        public static DependencyProperty TitleFontSizeProperty = DependencyProperty.Register("TitleFontSize", typeof(double), typeof(usrHorizontalMeter), new PropertyMetadata(18.0));
        public double TitleFontSize
        {
            get { return (double)this.GetValue(TitleFontSizeProperty); }
            set
            {
                this.SetValue(TitleFontSizeProperty, value);
                OnPropertyChanged("TitleFontSize");
            }
        }

        public static DependencyProperty ValueFontSizeProperty = DependencyProperty.Register("ValueFontSize", typeof(double), typeof(usrHorizontalMeter), new PropertyMetadata(18.0));
        public double ValueFontSize
        {
            get { return (double)this.GetValue(ValueFontSizeProperty); }
            set
            {
                this.SetValue(ValueFontSizeProperty, value);
                OnPropertyChanged("ValueFontSize");
            }
        }

        public static DependencyProperty UnitFontSizeProperty = DependencyProperty.Register("UnitFontSize", typeof(double), typeof(usrHorizontalMeter), new PropertyMetadata(14.0));
        public double UnitFontSize
        {
            get { return (double)this.GetValue(UnitFontSizeProperty); }
            set
            {
                this.SetValue(UnitFontSizeProperty, value);
                OnPropertyChanged("UnitFontSize");
            }
        }

        public static DependencyProperty EffectColorProperty = DependencyProperty.Register("EffectColor", typeof(Brush), typeof(usrHorizontalMeter), new PropertyMetadata(null));
        public Brush EffectColor
        {
            get { return (Brush)this.GetValue(EffectColorProperty); }
            set
            {
                this.SetValue(EffectColorProperty, value);
                OnPropertyChanged("EffectColor");
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
