using System;
using System.Runtime.Serialization;

namespace Task_002
{
    class DegreeIsLessThanZeroException: Exception
    {
        #region Constructors

        public DegreeIsLessThanZeroException()
        {
        }

        public DegreeIsLessThanZeroException(string message)
            : base(message)
        {
        }

        public DegreeIsLessThanZeroException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public DegreeIsLessThanZeroException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion
    }
}
