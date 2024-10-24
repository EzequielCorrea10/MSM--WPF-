using TagTest.Classes;
//using TagTest.Handlers;
using Janus.Rodeo.Windows.Library.Rd_Common;
using Janus.Rodeo.Windows.Library.UI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagTest.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {

        #region properties
        private List<RodeoTag> lstTags;
        public List<RodeoTag> LstTags
        {
            get { return lstTags; }
            set
            {
                lstTags = value;
                OnPropertyChanged("LstTags");
                OnPropertyChanged("InfoCountTags");
            }
        }

        private List<RodeoTag> lstFilterTags;
        public List<RodeoTag> LstFilterTags
        {
            get { return lstFilterTags; }
            set
            {
                lstFilterTags = value;
                OnPropertyChanged("LstFilterTags");
                OnPropertyChanged("InfoCountTags");
            }
        }

        private RodeoTag currentTag;
        public RodeoTag CurrentTag
        {
            get { return currentTag; }
            set
            {
                if (currentTag != value)
                {
                    currentTag = value;
                    OnPropertyChanged("CurrentTag");
                    if (currentTag != null)
                    {
                        NewValue = currentTag.TagValue;
                        OnPropertyChanged("NewValue");
                    }
                }
            }
        }

        public string InfoCountTags
        {
            get
            {
                string info = "";
                if (this.LstTags != null)
                {
                    info = string.Format("Tags {0} of {1}", (this.LstFilterTags != null) ? this.LstFilterTags.Count() : 0, this.LstTags.Count());
                }

                return info;
            }
        }

        private string newValue = string.Empty;
        public string NewValue
        {
            get { return newValue; }
            set
            {
                newValue = value;
                OnPropertyChanged("NewValue");
            }
        }

        private bool valueAsText = false;
        public bool ValueAsText
        {
            get { return valueAsText; }
            set
            {
                valueAsText = value;
                OnPropertyChanged("ValueAsText");
            }
        }

        private string txtFilter = string.Empty;
        public string TxtFilter
        {
            get { return txtFilter; }
            set
            {

                if (txtFilter != value)
                {
                    txtFilter = value;
                    OnPropertyChanged("TxtFilter");

                  //  if (this.UpdateWhileType)
                    {
                        this.FilterTags();
                    }
                }


            }
        }
        #endregion

        private void FilterTags()
        {
            if (this.LstTags == null)
                this.LstTags = new List<RodeoTag>();

            if (this.LstFilterTags == null)
                this.LstFilterTags = new List<RodeoTag>();

            string _filter = this.TxtFilter.ToUpper();
            string _txtFilter = string.Empty;
            string _txtFilter2 = string.Empty;
            if (this.TxtFilter.Contains("&&"))
            {
                _filter = _filter.Replace("&&", "&");
                _txtFilter = _filter.Split('&')[0].Trim();
                _txtFilter2 = _filter.Split('&')[1].Trim();

                this.LstFilterTags = this.LstTags.Where(t => t.TagName.ToUpper().Contains(_txtFilter) && t.TagName.ToUpper().Contains(_txtFilter2)).ToList();
            }
            else if (this.TxtFilter.Contains("||"))
            {
                _filter = _filter.Replace("||", "|");
                _txtFilter = _filter.Split('|')[0].Trim();
                _txtFilter2 = _filter.Split('|')[1].Trim();

                this.LstFilterTags = this.LstTags.Where(t => t.TagName.ToUpper().Contains(_txtFilter) || t.TagName.ToUpper().Contains(_txtFilter2)).ToList();
            }
            else
            {
                this.LstFilterTags = this.LstTags.Where(t => t.TagName.ToUpper().Contains(_filter)).ToList();
            }

            if (LstFilterTags.Any())
            {
                CurrentTag = LstFilterTags.FirstOrDefault();
            }
        }
        private void LoadTagsFromRodeo()
        {
            List<RTSInfoTag> tagList = RodeoHandler.Tag.Handler.RtServer_GetTags(Properties.Settings.Default.RodeoSector);
            List<RTSInfoTag> SortedList = tagList.OrderBy(o => o.tag).ToList();
            //Get each tag value            

            LstTags = new List<RodeoTag>();

            for (int i = 0; i < SortedList.Count; i++)
            {
                RodeoTag thisTag = new RodeoTag();
                string tagname;
                char type;

                var tagname1 = SortedList[i].tag;
                tagname = tagname1.Replace("\0", "");
                type = GetRdType(SortedList[i].dataType);

                if (type == Rd_GeneralConstant.RdRTD_STRING)
                {

                    string val;
                    string val2;
                    RodeoHandler.Tag.GetText(tagname, out val2);
                    val = val2.Replace("\0", "");
                    thisTag.TagName = tagname;
                    thisTag.TagValue = val.ToString();
                    thisTag.TagLength = tagname.Length;
                }
                else if (type == Rd_GeneralConstant.RdRTD_RAW)
                {
                    byte[] val;
                    RodeoHandler.Tag.GetByte(tagname, out val);
                    thisTag.TagName = tagname;
                    thisTag.TagValue = string.Join(":", val);
                    thisTag.TagLength = tagname.Length;
                }
                else
                {
                    double val;
                    RodeoHandler.Tag.GetNumeric(tagname, out val);
                    thisTag.TagName = tagname;
                    thisTag.TagValue = val.ToString();
                    thisTag.TagLength = tagname.Length;
                }

                //if (tagname.Length > 59) { MessageBox.Show("Mas de 60!!!"); }
                LstTags.Add(thisTag);
            }

            //if (LstTags.Any())
            //{
            //    CurrentTag = LstTags.FirstOrDefault();
            //}
        }

        private char GetRdType(char ltype)
        {
            char val = 'E';

            switch (ltype)
            {
                //PREGUNTAR
                case 'r':
                    val = (char)Rd_GeneralConstant.RdRTD_REAL;
                    break;
                case 'R':
                    val = (char)Rd_GeneralConstant.RdRTD_DREAL;
                    break;
                case 'B':
                    val = (char)Rd_GeneralConstant.RdRTD_BIT;
                    break;
                case 'I':
                    val = (char)Rd_GeneralConstant.RdRTD_INT;
                    break;
                case 'l':
                    val = (char)Rd_GeneralConstant.RdRTD_LONG;
                    break;
                case 'L':
                    val = (char)Rd_GeneralConstant.RdRTD_DLONG;
                    break;
                case 'S':
                    val = (char)Rd_GeneralConstant.RdRTD_STRING;
                    break;
                case 'Y':
                    val = (char)Rd_GeneralConstant.RdRTD_BYTE;
                    break;
                case 'A':
                    val = (char)Rd_GeneralConstant.RdRTD_RAW;
                    break;
            }

            return val;
        }

        #region Public Methods
        public void UpdateTag()
        {
            try
            {
                if (CurrentTag != null)
                {
                    this.UpdateTag(CurrentTag);

                    this.GetTags();
                    ValueAsText = false;
                }
            }
            catch
            {

            }
        }

        public void UpdateTag(RodeoTag tag)
        {
            try
            {
                if (tag != null)
                {
                    double Num;
                    bool isNum = double.TryParse(NewValue, out Num);
                    if (isNum && ValueAsText == false)
                    {
                        RodeoHandler.Tag.SetValue(tag.TagName, Double.Parse(NewValue));
                    }
                    else
                    {
                        RodeoHandler.Tag.SetValue(tag.TagName, NewValue);
                    }
                }
            }
            catch
            {

            }
        }

        public void GetTags()
        {
            this.LoadTagsFromRodeo();

            this.FilterTags();
        }
        #endregion

        #region Handlers
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
