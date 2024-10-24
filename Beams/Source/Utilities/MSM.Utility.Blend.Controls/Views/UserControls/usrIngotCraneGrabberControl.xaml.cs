using HelixToolkit.Wpf;
using Janus.Rodeo.Windows.Library.Rd_Log;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for usrIngotCraneGrabberControl.xaml
    /// </summary>
    public partial class usrIngotCraneGrabberControl : UserControl, INotifyPropertyChanged
    {
        Model3DGroup model1;

        List<Model3D> oPiece_Parts;

        #region public properties
        private static FrameworkPropertyMetadata RotationPropertyMetadata = new FrameworkPropertyMetadata((double)0.0);

        public static DependencyProperty RotationProperty = DependencyProperty.Register("Rotation", typeof(double), typeof(usrIngotCraneGrabberControl), RotationPropertyMetadata);
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
            ((usrIngotCraneGrabberControl)(d)).PieceCaughtAction((bool)e.NewValue);
        }

        public static DependencyProperty PieceCaughtProperty = DependencyProperty.Register("PieceCaught", typeof(bool), typeof(usrIngotCraneGrabberControl), PieceCaughtPropertyMetadata);
        public bool PieceCaught
        {
            get { return (bool)this.GetValue(PieceCaughtProperty); }
            set
            {
                this.SetValue(PieceCaughtProperty, value);
                this.PieceCaughtAction(value);
            }
        }        
        #endregion


        public usrIngotCraneGrabberControl()
        {
            InitializeComponent();

            this.Loaded += usrIngotCraneGrabberControl_Loaded;
        }

        private void usrIngotCraneGrabberControl_Loaded(object sender, RoutedEventArgs e)
        {
            CreateObject();
        }

        private async void CreateObject()
        {
            await Task.Run(() =>
            {
                try
                {
                    Thread.Sleep(250);

                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        try
                        {
                            ObjReader Reader = new HelixToolkit.Wpf.ObjReader();
                            model1 = Reader.Read(@"Model\IngotGrab\IngotGrab1.obj");
                            DefaultGroup.Content = model1;

                            //Reader.Groups

                            oPiece_Parts = model1.Children.Where(o => o.GetName().Contains("IngotPiece") || o.GetName().Contains("default")).ToList();
                            int counter = 0;
                            foreach (var item in oPiece_Parts)
                            {
                                Transform3DGroup group = new Transform3DGroup();
                                TranslateTransform3D t = new TranslateTransform3D();
                                ScaleTransform3D s = new ScaleTransform3D();
                                group.Children.Add(t);
                                group.Children.Add(s);
                                item.Transform = group;
                                counter++;
                            }

                            this.PieceCaughtAction(this.PieceCaught);


                            foreach (GeometryModel3D item in model1.Children)
                            {
                                RdTrace.Debug(item.GetName());
                            }
                        }
                        catch (Exception ex)
                        {
                            RdTrace.Exception(ex);
                        }
                    }), System.Windows.Threading.DispatcherPriority.ContextIdle);
                }
                catch (Exception ex)
                {
                    RdTrace.Exception(ex);
                }
            });
        }

        #region private methods
        private void PieceCaughtAction(bool status)
        {
            try
            {
                if (status)
                {
                    for (int i = 0; i < oPiece_Parts.Count; i++)
                        if (!model1.Children.Contains(oPiece_Parts[i]))
                            model1.Children.Add(oPiece_Parts[i]);
                }
                else
                {
                        if (model1.Children.Contains(oPiece_Parts[32])) //Remuevo el saddle
                            model1.Children.Remove(oPiece_Parts[32]);
                }

                RdTrace.Debug("Status {0}", status);
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
