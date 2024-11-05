using Janus.Rodeo.Windows.Library.Rd_Log;
using Janus.Rodeo.Windows.Library.UI.Common;
using Janus.Rodeo.Windows.Library.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace HSM.HMI.Safety.Operation.ViewModels
{
    public class Beam : ModelViewBase, INotifyPropertyChanged
    {

        #region private attribute

        /// <summary>
        /// _name
        /// </summary>
        private string _name;

        /// <summary>
        /// _name
        /// </summary>
        private string _zone;

        /// <summary>
        /// _name
        /// </summary>
        private int? _positionX;

        /// <summary>
        /// _name
        /// </summary>
        private int? _positionY;

        /// <summary>
        /// _name
        /// </summary>
        private string _imageSource;
        #endregion

        #region public properties

        /// <summary>
        /// Verify if Pickup is allowed
        /// </summary>
        /// <returns></returns>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Length
        /// </summary>
        public string Zone
        {
            get { return _zone; }
            set { _zone = value; }
        }


        public int? PositionX
        {
            get { return _positionX; }
            set
            {
                if (this._positionX != value)
                {
                    this._positionX = value;

                    OnPropertyChanged("PositionX");
                }
            }
        }


        public int? PositionY
        {
            get { return _positionY; }
            set
            {
                if (this._positionY != value)
                {
                    this._positionY = value;

                    OnPropertyChanged("PositionY");
                }
            }
        }


        #endregion

        #region constructors
        /// <summary>
        /// Initializes a machine
        /// </summary>
        /// <param name="machine"></param>
        public Beam(string name, string zone)
        {
            _name = name;
            _zone = zone;
        }

        /// <summary>
        /// Initializes a machine
        /// </summary>
        /// <param name="machine"></param>
        public Beam(string name, string zone, int? positionX, int? positionY)
        {
            _name = name;
            _zone = zone;
            _positionX = positionX;
            _positionY = positionY;
        }
        #endregion

    }
}
