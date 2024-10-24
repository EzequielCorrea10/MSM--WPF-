using System;
 
namespace MSM.Utility.Common.Exceptions
{
    /// <summary>
    ///  Class to manage the custom exception of Crane control
    /// </summary>
    public class ControlException<T> : Exception where T : struct, IConvertible
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlException"/> class.
        /// </summary>
        /// <param name="errorCode"></param>
        public ControlException(ControlException<T> ex)
            : this(ex.ErrorCode, ex.Message, ex.InnerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlException"/> class.
        /// </summary>
        /// <param name="errorCode"></param>
        public ControlException(T errorCode)
            : base()
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlException"/> class.
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        public ControlException(T errorCode, string message)
            : base(message)
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlException"/> class.
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public ControlException(T errorCode, string message, Exception inner)
            : base(message, inner)
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Gets the code of error
        /// </summary>
        public T ErrorCode { get; private set; }
    }
}
