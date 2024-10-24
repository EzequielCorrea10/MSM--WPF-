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
    using Janus.Rodeo.Windows.Library.Rd_Log;

    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class usrCraneGrabberControl : UserControl, INotifyPropertyChanged
    {
        #region private methods
        ModelVisual3D[] oPiece_Parts;
        ModelVisual3D[] oWrapped_Parts;
        #endregion

        #region public properties
        private static FrameworkPropertyMetadata RotationPropertyMetadata = new FrameworkPropertyMetadata((double)0.0);

        public static DependencyProperty RotationProperty = DependencyProperty.Register("Rotation", typeof(double), typeof(usrCraneGrabberControl), RotationPropertyMetadata);
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
            ((usrCraneGrabberControl)(d)).PieceCaughtAction((bool)e.NewValue);
        }

        public static DependencyProperty PieceCaughtProperty = DependencyProperty.Register("PieceCaught", typeof(bool), typeof(usrCraneGrabberControl), PieceCaughtPropertyMetadata);
        public bool PieceCaught
        {
            get { return (bool)this.GetValue(PieceCaughtProperty); }
            set { this.SetValue(PieceCaughtProperty, value); }
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
            ((usrCraneGrabberControl)(d)).PieceWrappedAction((bool)e.NewValue);
        }

        public static DependencyProperty PieceWrappedProperty = DependencyProperty.Register("PieceWrapped", typeof(bool), typeof(usrCraneGrabberControl), PieceWrappedPropertyMetadata);
        public bool PieceWrapped
        {
            get { return (bool)this.GetValue(PieceWrappedProperty); }
            set { this.SetValue(PieceWrappedProperty, value); }
        }
        #endregion

        #region constructor
        public usrCraneGrabberControl()
        {
            InitializeComponent();

            oPiece_Parts = new ModelVisual3D[] { Cylinder_253_Cylinder_719Container, 
                                                Cylinder_254_Cylinder_720Container,
                                                Material_013Container,
												centro_pinza_Cylinder_013Container };

            oWrapped_Parts = new ModelVisual3D[] { Cylinder_012_Cylinder_003Container };

            this.PieceCaughtAction(this.PieceCaught);
            this.PieceWrappedAction(this.PieceWrapped);
        }
        #endregion

        #region private methods
        private void PieceCaughtAction(bool status)
        {
            try
            {
                if (status)
                {
                    for (int i = 0; i < oPiece_Parts.Length; i++)
                        if (!DefaultGroup.Children.Contains(oPiece_Parts[i]))
                            DefaultGroup.Children.Add(oPiece_Parts[i]);
                }
                else
                {
                    for (int i = 0; i < oPiece_Parts.Length; i++)
                        if (DefaultGroup.Children.Contains(oPiece_Parts[i]))
                            DefaultGroup.Children.Remove(oPiece_Parts[i]);
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
                        if (!DefaultGroup.Children.Contains(oWrapped_Parts[i]))
                            DefaultGroup.Children.Add(oWrapped_Parts[i]);
                }
                else
                {
                    for (int i = 0; i < oWrapped_Parts.Length; i++)
                        if (DefaultGroup.Children.Contains(oWrapped_Parts[i]))
                            DefaultGroup.Children.Remove(oWrapped_Parts[i]);
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
