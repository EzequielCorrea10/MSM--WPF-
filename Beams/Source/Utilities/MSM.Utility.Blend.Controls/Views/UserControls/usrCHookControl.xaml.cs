using HelixToolkit.Wpf;
using Janus.Rodeo.Windows.Library.Rd_Log;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MSM.Utility.Blend.Controls
{
    /// <summary>
    /// Interaction logic for usrCHookControl.xaml
    /// </summary>
    public partial class usrCHookControl : UserControl, INotifyPropertyChanged
    {
        Model3DGroup model1;

        Model3D[] oPiece_Parts;
        Model3D[] oWrapped_Parts;

        #region public properties
        private static FrameworkPropertyMetadata RotationPropertyMetadata = new FrameworkPropertyMetadata((double)0.0);

        public static DependencyProperty RotationProperty = DependencyProperty.Register("Rotation", typeof(double), typeof(usrCHookControl), RotationPropertyMetadata);
        public double Rotation
        {
            get { return (double)this.GetValue(RotationProperty); }
            set
            {
                this.SetValue(RotationProperty, value);
                OnPropertyChanged("Rotation");
            }
        }

        private static FrameworkPropertyMetadata PieceCaughtPropertyMetadata = new FrameworkPropertyMetadata(false,
                                                                                                            FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.AffectsRender,
                                                                                                            new PropertyChangedCallback(PieceCaught_PropertyChanged),
                                                                                                            new CoerceValueCallback(PieceCaugth_CoerceValue),
                                                                                                            false,
                                                                                                            UpdateSourceTrigger.PropertyChanged);
        private static object PieceCaugth_CoerceValue(DependencyObject d, object baseValue)
        {
            return baseValue;
        }

        private static void PieceCaught_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((usrCHookControl)(d)).PieceCaughtAction((bool)e.NewValue);
        }

        public static DependencyProperty PieceCaughtProperty = DependencyProperty.Register("PieceCaught", typeof(bool), typeof(usrCHookControl), PieceCaughtPropertyMetadata);
        public bool PieceCaught
        {
            get { return (bool)this.GetValue(PieceCaughtProperty); }
            set { this.SetValue(PieceCaughtProperty, value);

                this.PieceCaughtAction(value);
            }
        }

        private static FrameworkPropertyMetadata PieceWrappedPropertyMetadata = new FrameworkPropertyMetadata(false,
                                                                                                    FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.AffectsRender,
                                                                                                    new PropertyChangedCallback(PieceWrapped_PropertyChanged),
                                                                                                    new CoerceValueCallback(PieceWrapped_CoerceValue),
                                                                                                    false,
                                                                                                    UpdateSourceTrigger.PropertyChanged);
        private static object PieceWrapped_CoerceValue(DependencyObject d, object baseValue)
        {
            return baseValue;
        }

        private static void PieceWrapped_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((usrCHookControl)(d)).PieceWrappedAction((bool)e.NewValue);
        }

        public static DependencyProperty PieceWrappedProperty = DependencyProperty.Register("PieceWrapped", typeof(bool), typeof(usrCHookControl), PieceWrappedPropertyMetadata);
        public bool PieceWrapped
        {
            get { return (bool)this.GetValue(PieceWrappedProperty); }
            set { this.SetValue(PieceWrappedProperty, value);
                this.PieceWrappedAction(value);
            }
        }
        #endregion

        public usrCHookControl()
        {
            InitializeComponent();

            ModelImporter import = new ModelImporter();
            model1 = import.Load(@"Model\CHook\CHook.obj");
            DefaultGroup.Content = model1;

            oPiece_Parts = model1.Children.Select((o, i) => new { o, i }).Where(o => o.i >= 32).Select(o => o.o).ToArray();

            oWrapped_Parts = model1.Children.Select((o, i) => new { o, i }).Where(o => o.i >= 32 && o.i <= 33).Select(o => o.o).ToArray();

            this.PieceCaughtAction(this.PieceCaught);
            this.PieceWrappedAction(this.PieceWrapped);

            this.Loaded += UsrCHookControl_Loaded;
        }

        private void UsrCHookControl_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (GeometryModel3D item in model1.Children)
            {
                System.Diagnostics.Debug.Print(item.GetName());
            }
        }

        #region private methods
        private void PieceCaughtAction(bool status)
        {
            try
            {
                if (status)
                {
                    for (int i = 0; i < oPiece_Parts.Length; i++)
                        if (!model1.Children.Contains(oPiece_Parts[i]))
                            model1.Children.Add(oPiece_Parts[i]);
                }
                else
                {
                    for (int i = 0; i < oPiece_Parts.Length; i++)
                        if (model1.Children.Contains(oPiece_Parts[i]))
                            model1.Children.Remove(oPiece_Parts[i]);
                }

                RdTrace.Debug("Status {0}", status);
            }
            catch (Exception ex)
            {
                RdTrace.Exception(ex);
            }
        }

        private void PieceWrappedAction(bool status)
        {
            try
            {
                if (status)
                {
                    for (int i = 0; i < oWrapped_Parts.Length; i++)
                        if (!model1.Children.Contains(oWrapped_Parts[i]))
                            model1.Children.Add(oWrapped_Parts[i]);
                }
                else
                {
                    for (int i = 0; i < oWrapped_Parts.Length; i++)
                        if (model1.Children.Contains(oWrapped_Parts[i]))
                            model1.Children.Remove(oWrapped_Parts[i]);
                }

                RdTrace.Debug("Wrapped {0}", status);
            }
            catch (Exception ex)
            {
                RdTrace.Exception(ex);
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
