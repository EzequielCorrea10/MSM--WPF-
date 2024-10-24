using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagLoader.Clases
{
    public class RodeoTag
    {

        private string _TagName;
        public string TagName
        {
            get
            {
                return _TagName;
            }

            set
            {
                _TagName = value;
            }
        }
        private string _TagValue;
        public string TagValue
        {
            get
            {
                return _TagValue;
            }

            set
            {
                _TagValue = value;
            }
        }
        private int _TagLength;
        public int TagLength
        {
            get
            {
                return _TagLength;
            }
            set
            {
                _TagLength = value;
            }
        }
    }
}
