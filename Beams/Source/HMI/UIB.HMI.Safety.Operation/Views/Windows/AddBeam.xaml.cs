using HSM.HMI.Safety.Operation.ViewModels;
using HSM.Utility.Configuration;
using Janus.Rodeo.Windows.Library.UI.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddBeam.xaml
    /// </summary>
    public partial class AddBeam : Window, INotifyPropertyChanged
    {
        #region attributes
        private ObservableCollection<string> _zones;
        private ObservableCollection<string> _positions;
        private string _storageGroupSelected;
        private string _positionSelected;
        private string tag;
        #endregion

        #region public attributes
        public ObservableCollection<string> Zones
        {
            get { return _zones; }
            set { _zones = value; OnPropertyChanged(); }
        }
        public string StorageGroupSelected
        {
            get { return _storageGroupSelected; }
            set
            {
                if (_storageGroupSelected != value)
                {
                    _storageGroupSelected = value;
                    OnPropertyChanged();
                    UpdatePositions();
                }
            }
        }

        public string PositionSelected
        {
            get { return _positionSelected; }
            set
            {
                if (_positionSelected != value)
                {
                    _positionSelected = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<string> Positions
        {
            get { return _positions; }
            set { _positions = value; OnPropertyChanged(); }
        }
        #endregion

        #region private methods

        public AddBeam(List<string> zones)
        {
            InitializeComponent();
            Zones = new ObservableCollection<string>();
            Positions = new ObservableCollection<string>();
            foreach (string zone in zones)
            {
                string fixedZone = String.Empty;

                if (zone == "PilingBedQueueE")
                {
                    fixedZone = "Confirmed In Next Bundle E";
                    Zones.Add(fixedZone);
                }
                else if (zone == "PilingBedQueueW")
                {
                    fixedZone = "Confirmed In Next Bundle W";
                    Zones.Add(fixedZone);
                }
                else
                {
                    StringBuilder formattedZone = new StringBuilder();
                    foreach (char c in zone)
                    {
                        if ((char.IsUpper(c) || char.IsNumber(c)) && formattedZone.Length > 0)
                        {
                            formattedZone.Append(" ");
                        }
                        formattedZone.Append(c);
                    }
                    Zones.Add(formattedZone.ToString());
                }
            }
            StorageGroupSelected = Zones.FirstOrDefault();
            DataContext = this;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdatePositions()
        {
            // Limpiar posiciones actuales
            Positions.Clear();
            if (string.IsNullOrEmpty(StorageGroupSelected))
                return;

            if (StorageGroupSelected == "Confirmed In Next Bundle E")
                StorageGroupSelected = "Piling Bed Queue E";
            else if(StorageGroupSelected == "Confirmed In Next Bundle W")
                StorageGroupSelected = "Piling Bed Queue W";

            string output = string.Concat(StorageGroupSelected.Split(' ').Select(word =>
                CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word.ToLower()))); 
            
            if (!RodeoHandler.Tag.GetText(string.Format("HSM." + output, Configurations.General.RodeoSector), out tag))
            {
                throw new Exception("Error");
            }
            string[] beamsInZoneName = tag.Split(',');
            if (beamsInZoneName.Length > 0 && !String.IsNullOrEmpty(beamsInZoneName[0]))
            {
                for (int i = 1; i <= beamsInZoneName.Length + 1; i++)
                {
                    if (!Positions.Contains("Position " + i))
                    {
                        Positions.Add("Position " + i);
                    }
                    
                }
            }
            else
            {
                if (!Positions.Contains("Position 1"))
                {
                    Positions.Add("Position 1");
                }
            }
            PositionSelected = Positions.FirstOrDefault();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (StorageGroupSelected == "Confirmed In Next Bundle E")
                StorageGroupSelected = "Piling Bed Queue E";
            else if (StorageGroupSelected == "Confirmed In Next Bundle W")
                StorageGroupSelected = "Piling Bed Queue W";

            string outputZone = string.Concat(StorageGroupSelected.Split(' ').Select(word =>
            CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word.ToLower())));

            int index = PositionSelected.IndexOf("Position");
            int numberPart = int.Parse(PositionSelected.Substring(index + "Position".Length).Trim());

            string[] beamsInZoneName = tag.Split(',');

            List<string> result = new List<string>();

            if (beamsInZoneName.Length > numberPart)
            {
                for (int i = 1; i <= beamsInZoneName.Length; i++)
                {
                    if (numberPart == i)
                    {
                        result.Add(BeamName.Text);
                    }

                    if (i <= beamsInZoneName.Length && !String.IsNullOrEmpty(beamsInZoneName[i - 1])) // Asegura que no se salga del rango original
                    {
                        result.Add(beamsInZoneName[i - 1]);
                    }
                }
            }
            else
            {
                for (int i = 1; i <= numberPart; i++)
                {
                    if (numberPart == i)
                    {
                        result.Add(BeamName.Text);
                    }

                    if (i <= beamsInZoneName.Length && !String.IsNullOrEmpty(beamsInZoneName[i - 1])) // Asegura que no se salga del rango original
                    {
                        result.Add(beamsInZoneName[i - 1]);
                    }
                }
            }


            string finalResult = string.Join(",", result);

            if (!RodeoHandler.Tag.SetValue(string.Format("HSM." + outputZone), finalResult))
            {
                throw new Exception("Error");
            }

            if (outputZone.Contains("Piling"))
            {
                if (!RodeoHandler.Tag.SetValue(string.Format("HSM.Check_On_Tag_Piling"), string.Format("HSM." + outputZone)))
                {
                    throw new Exception("Error");
                }
            }
            else
            {
                if (!RodeoHandler.Tag.SetValue(string.Format("HSM.Check_On_Tag_Collecting"), string.Format("HSM." + outputZone)))
                {
                    throw new Exception("Error");
                }
            }

            this.Close();
        }
        #endregion
    }
}
