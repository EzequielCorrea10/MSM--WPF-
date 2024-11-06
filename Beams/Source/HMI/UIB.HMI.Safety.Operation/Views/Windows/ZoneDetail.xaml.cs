using HSM.HMI.Safety.Operation.ViewModels;
using HSM.Utility.Configuration;
using Janus.Rodeo.Windows.Library.UI.Common;
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
using System.Windows.Shapes;

namespace HSM.HMI.Safety.Operation.Views.Windows
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ZoneDetail : Window
    {
        #region private attributes
        private vmZoneDetail controller;
        private Beam beam;
        private List<Beam> beams;
        #endregion
        public ZoneDetail(Beam beam, List<Beam> beams)
        {
            InitializeComponent();

            this.controller = new vmZoneDetail(beam);
            this.beam = beam;
            this.beams = beams;
            this.Left = (double)beam.PositionX;
            this.Top = (double)beam.PositionY;

            this.Loaded += winEStopDetails_Loaded;
            this.Closing += winEStopDetails_Closing;
            this.DataContext = this.controller;

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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(BeamName.Text))
            {
                if (beams.Contains(beam))
                {
                    string tagsSet = string.Empty;
                    for (int i = 0; i< beams.Count; i++)
                    {
                        if(i != beams.Count - 1) { 
                            if (beams[i] == beam) {
                                tagsSet += BeamName.Text + ',';
                            }
                            else
                            {
                                tagsSet += beams[i].Name + ',';
                            }
                        }
                        else
                        {
                            if (beams[i] == beam)
                            {
                                tagsSet += BeamName.Text;
                            }
                            else
                            {
                                tagsSet += beams[i].Name;
                            }
                        }

                    }
                    if (!RodeoHandler.Tag.SetValue(string.Format("HSM." + beam.Zone, Configurations.General.RodeoSector ), tagsSet))
                    {                        
                        throw new Exception("Error");
                    }

                    if (!RodeoHandler.Tag.SetValue(string.Format("HSM.Check_On_Tag" , Configurations.General.RodeoSector), beam.Zone))
                    {
                        throw new Exception("Error");
                    }
                }
            }
            else
            {
                throw new Exception("Error");

            }
        }
    }
}
