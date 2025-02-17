using HSM.HMI.Safety.Operation.ViewModels;
using Janus.Rodeo.Windows.Library.UI.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
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
    /// Interaction logic for BeamList.xaml
    /// </summary>
    public partial class BeamList : Window, INotifyPropertyChanged
    {
        private string _zoneDisplay;

        public string ZoneDisplay
        {
            get { return _zoneDisplay; }
            set
            {
                if (_zoneDisplay != value)
                {
                    _zoneDisplay = value;
                    OnPropertyChanged();
                }
            }
        }

        public BeamList(Beam beam,List<Beam> beams)
        {
            InitializeComponent();
            
            icTodoList.ItemsSource = beams;

            this.Left = (double)beam.PositionX;
            this.Top = (double)beam.PositionY;

            this.Loaded += winEStopDetails_Loaded;
            this.Closing += winEStopDetails_Closing;

            DataContext = this;

            StringBuilder formattedZone = new StringBuilder();
            foreach (char c in beam.Zone)
            {
                if ((char.IsUpper(c) || char.IsNumber(c)) && formattedZone.Length > 0)
                {
                    formattedZone.Append(" ");
                }
                formattedZone.Append(c);
            }
            ZoneDisplay = formattedZone.ToString();
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
            var test = (System.Windows.Controls.Button)sender;
            var beam = (Beam)test.DataContext;
            vmZoneDetail generalDetails = new vmZoneDetail(beam);
            ZoneDetail zoneDetail = new ZoneDetail(beam, (List<Beam>)icTodoList.ItemsSource);
            zoneDetail.ShowDialog();
            this.Close();


        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
