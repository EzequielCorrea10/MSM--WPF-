using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSM.Utility.Common.Catalogs
{
    /// <summary>
    /// Structures of Base
    /// </summary>
    public abstract class CT_Base<T> : CT_Base
    {
        #region attributes
        /// <summary>
        /// _reference
        /// </summary>
        private T _reference;
        #endregion

        #region public properties
        /// <summary>
        /// Reference
        /// </summary>
        public T Reference
        {
            get { return _reference; }
            protected set { _reference = value; }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CT_Base"/> class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="reference"></param>
        public CT_Base(int id, string name, string description, T reference)
            : base(id, name, description)
        {
            this._reference = reference;
        }
        #endregion
    }

    /// <summary>
    /// Structures of Base
    /// </summary>
    public abstract class CT_Base
    {
        #region attributes
        /// <summary>
        /// _id
        /// </summary>
        private int _id;

        /// <summary>
        /// _name
        /// </summary>
        private string _name;

        /// <summary>
        /// _name
        /// </summary>
        private string _description;
        #endregion

        #region public properties
        /// <summary>
        /// Id
        /// </summary>
        public int Id
        {
            get { return _id; }
            protected set { _id = value; }
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get { return _name; }
            protected set { _name = value; }
        }

        /// <summary>
        /// Description
        /// </summary>
        public string Description
        {
            get { return _description; }
            protected set { _description = value; }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CT_Base"/> class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public CT_Base(int id, string name, string description)
        {
            this._id = id;
            this._name = name;
            this._description = description;
        }
        #endregion
    }
}