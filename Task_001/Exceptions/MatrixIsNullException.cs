using System;
using System.Runtime.Serialization;

namespace Task_001
{
    class MatrixIsNullException : Exception
    {
        #region Constructors

        public MatrixIsNullException()
        {
        }

        public MatrixIsNullException(string message)
            : base(message)
        {
        }

        public MatrixIsNullException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public MatrixIsNullException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion
    }
}
