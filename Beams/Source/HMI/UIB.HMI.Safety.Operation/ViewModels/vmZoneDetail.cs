using Janus.Rodeo.Windows.Library.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM.HMI.Safety.Operation.ViewModels
{
    public class vmZoneDetail : ModelViewBase
    {
        #region Constructors
        string _name;
        int? _posY;

        public vmZoneDetail(Beam beam)
    : base()
        {
            Name = beam.Name;
            PosY = beam.PositionY;
        }
        #endregion

        #region Properties

        public string Name
        {
            get { return this._name; }
            set
            {
                if (this._name != value)
                {
                    this._name = value;

                    this.OnPropertyChanged("Name");
                }
            }
        }

        public int? PosY
        {
            get { return this._posY; }
            set
            {
                if (this._posY != value)
                {
                    this._posY = value;

                    OnPropertyChanged("PosY");
                }
            }
        }
        #endregion
    }
}
