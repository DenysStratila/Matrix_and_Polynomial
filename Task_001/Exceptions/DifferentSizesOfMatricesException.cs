using System;
using System.Runtime.Serialization;

namespace Task_001
{
    class DifferentSizesOfMatricesException : Exception
    {
        #region Constructors

        public DifferentSizesOfMatricesException()
        {
        }

        public DifferentSizesOfMatricesException(string message)
            : base(message)
        {
        }

        public DifferentSizesOfMatricesException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public DifferentSizesOfMatricesException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion
    }


}