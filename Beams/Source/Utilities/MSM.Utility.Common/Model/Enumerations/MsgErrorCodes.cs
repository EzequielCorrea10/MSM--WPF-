using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSM.Utility.Common.Enumerations
{
    using MSM.Utility.Common.Helpers;

    public class MsgErrorCodes<T> : CustomEnum<MsgErrorCodes<T>, int> where T : MsgErrorCodes<T>
    {
        #region public enum
        /// <summary>
        /// Public enum
        /// </summary>
        public static readonly MsgErrorCodes<T> REQUEST_ACCEPTED = new MsgErrorCodes<T>(0);

        /// <summary>
        /// Crane
        /// </summary>
        public static readonly MsgErrorCodes<T> MACHINE_NOT_INDICATED = new MsgErrorCodes<T>(-1);
        public static readonly MsgErrorCodes<T> MACHINE_NOT_EXIST = new MsgErrorCodes<T>(-2);

        /// <summary>
        /// Piece
        /// </summary>
        public static readonly MsgErrorCodes<T> PIECE_NOT_INDICATED = new MsgErrorCodes<T>(-11);
        public static readonly MsgErrorCodes<T> PIECE_NOT_PRESENT = new MsgErrorCodes<T>(-12);
        public static readonly MsgErrorCodes<T> PIECE_NOT_EXIST = new MsgErrorCodes<T>(-13);
        public static readonly MsgErrorCodes<T> PIECE_ATTRIBUTES_NOT_INDICATED = new MsgErrorCodes<T>(-14);
        public static readonly MsgErrorCodes<T> PIECE_ATTRIBUTES_OUT_OF_RANGE = new MsgErrorCodes<T>(-15);
        public static readonly MsgErrorCodes<T> PIECE_HEADING_NOT_INDICATED = new MsgErrorCodes<T>(-16);


        /// <summary>
        /// Location
        /// </summary>
        public static readonly MsgErrorCodes<T> LOCATION_NOT_INDICATED = new MsgErrorCodes<T>(-21);
        public static readonly MsgErrorCodes<T> LOCATION_NOT_EXIST = new MsgErrorCodes<T>(-22);

        /// <summary>
        /// Zone
        /// </summary>
        public static readonly MsgErrorCodes<T> ZONE_NOT_INDICATED = new MsgErrorCodes<T>(-31);
        public static readonly MsgErrorCodes<T> ZONE_NOT_EXIST = new MsgErrorCodes<T>(-32);

        /// <summary>
        /// User
        /// </summary>
        public static readonly MsgErrorCodes<T> USER_NOT_INDICATED = new MsgErrorCodes<T>(-41);
        public static readonly MsgErrorCodes<T> USER_NOT_EXIST = new MsgErrorCodes<T>(-42);
        public static readonly MsgErrorCodes<T> USER_NOT_ALLOWED = new MsgErrorCodes<T>(-43);

        ///// <summary>
        ///// Rail
        ///// </summary>
        //public static readonly MsgErrorCodes<T> RAIL_NOT_INDICATED = new MsgErrorCodes<T>(-51);
        //public static readonly MsgErrorCodes<T> RAIL_NOT_PRESENT = new MsgErrorCodes<T>(-52);
        //public static readonly MsgErrorCodes<T> RAIL_NOT_EXIST = new MsgErrorCodes<T>(-53);
        //public static readonly MsgErrorCodes<T> RAIL_BEING_SCANNING = new MsgErrorCodes<T>(-54);
        //public static readonly MsgErrorCodes<T> TRUCK_NOT_INDICATED = new MsgErrorCodes<T>(-55);
        //public static readonly MsgErrorCodes<T> TRUCK_NOT_PRESENT = new MsgErrorCodes<T>(-56);
        //public static readonly MsgErrorCodes<T> TRUCK_NOT_EXIST = new MsgErrorCodes<T>(-57);
        //public static readonly MsgErrorCodes<T> TRUCK_BEING_SCANNING = new MsgErrorCodes<T>(-58);

        /// <summary>
        /// Position
        /// </summary>
        public static readonly MsgErrorCodes<T> YARD_NOT_INDICATED = new MsgErrorCodes<T>(-61);
        public static readonly MsgErrorCodes<T> YARD_NOT_EXIST = new MsgErrorCodes<T>(-62);
        public static readonly MsgErrorCodes<T> POSITION_NOT_INDICATED = new MsgErrorCodes<T>(-63);
        public static readonly MsgErrorCodes<T> POSITION_OUT_OF_RANGE = new MsgErrorCodes<T>(-64);
        public static readonly MsgErrorCodes<T> POSITION_NOT_EXIST = new MsgErrorCodes<T>(-65);

        /// <summary>
        /// System
        /// </summary>
        public static readonly MsgErrorCodes<T> ACTION_NOT_ALLOWED = new MsgErrorCodes<T>(-91);
        public static readonly MsgErrorCodes<T> INVALID_MESSAGE_TYPE = new MsgErrorCodes<T>(-92);
        public static readonly MsgErrorCodes<T> DATA_INCOMPLETED = new MsgErrorCodes<T>(-93);
        public static readonly MsgErrorCodes<T> ERROR_PROCESSING = new MsgErrorCodes<T>(-94);
        public static readonly MsgErrorCodes<T> OTHER_REASONS = new MsgErrorCodes<T>(-95);
        public static readonly MsgErrorCodes<T> TIMEOUT = new MsgErrorCodes<T>(-96);
        #endregion

        #region public contract
        public MsgErrorCodes(int aValue)
            : base(aValue, typeof(T))
        { }
        #endregion

        #region abstract methods
        /// <summary>
        /// DoGetErrorDescription
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        protected virtual string DoGetErrorDescription() { return string.Empty; }
        #endregion

        #region public methods
        /// <summary>
        /// GetErrorDescription
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public string GetErrorDescription()
        {
            if (this.Value == REQUEST_ACCEPTED)
            {
                return "Accepted";
            }
            else if (this.Value == MACHINE_NOT_INDICATED)
            {
                return "Machine is not indicated";
            }
            else if (this.Value == MACHINE_NOT_EXIST)
            {
                return "Machine does not exist";
            }
            else if (this.Value == PIECE_NOT_INDICATED)
            {
                return "Piece is not indicated";
            }
            else if (this.Value == PIECE_NOT_EXIST)
            {
                return "Piece does not exist";
            }
            else if (this.Value == PIECE_NOT_PRESENT)
            {
                return "Piece is not present";
            }
            else if (this.Value == PIECE_ATTRIBUTES_NOT_INDICATED)
            {
                return "Piece attributes is not indicated";
            }
            else if (this.Value == PIECE_ATTRIBUTES_OUT_OF_RANGE)
            {
                return "Piece attributes is out of range";
            }
            else if (this.Value == PIECE_HEADING_NOT_INDICATED)
            {
                return "Piece heading is not indicated";
            }
            else if (this.Value == LOCATION_NOT_INDICATED)
            {
                return "Location is not indicated";
            }
            else if (this.Value == LOCATION_NOT_EXIST)
            {
                return "Location does not exist";
            }
            else if (this.Value == ZONE_NOT_INDICATED)
            {
                return "Zone is not indicated";
            }
            else if (this.Value == ZONE_NOT_EXIST)
            {
                return "Zone does not exist";
            }
            else if (this.Value == USER_NOT_INDICATED)
            {
                return "User is not indicated";
            }
            else if (this.Value == USER_NOT_EXIST)
            {
                return "User does not exist";
            }
            else if (this.Value == USER_NOT_ALLOWED)
            {
                return "User is not allowed";
            }
            else if (this.Value == YARD_NOT_INDICATED)
            {
                return "Yard is not indicated";
            }
            else if (this.Value == YARD_NOT_EXIST)
            {
                return "Yard does not exist";
            }
            else if (this.Value == POSITION_NOT_INDICATED)
            {
                return "Position is not indicated";
            }
            else if (this.Value == POSITION_OUT_OF_RANGE)
            {
                return "Position coordinates are out of range";
            }
            else if (this.Value == INVALID_MESSAGE_TYPE)
            {
                return "Invalid Message Type";
            }
            else if (this.Value == DATA_INCOMPLETED)
            {
                return "Data Incompleted";
            }
            else if (this.Value == ERROR_PROCESSING)
            {
                return "Error processing";
            }
            else if (this.Value == OTHER_REASONS) 
            {
                return "Other Reasons";
            }
            else if (this.Value == TIMEOUT)
            {
                return "Timeout";
            }            
            else if (this.Value == ACTION_NOT_ALLOWED) 
            {
                return "Action is not allowed";
            }
            else
            {
                string description = DoGetErrorDescription();
                if (!string.IsNullOrEmpty(description))
                {
                    return description;
                }
            }

            return "UNKNOWN ERROR";
        }

        /// <summary>
        /// GetErrorDescription
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public static string GetErrorDescription(int aValue)
        {
            MsgErrorCodes<T> err_code = GetMemberByValue(aValue);
            if (err_code != null)
            {
                return err_code.GetErrorDescription();
            }

            return "UNKNOWN ERROR";
        }
        #endregion
    }
}