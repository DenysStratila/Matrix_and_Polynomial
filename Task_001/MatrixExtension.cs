using System;
using System.Collections.Generic;
using System.Text;

namespace Task_001
{
    public static class MatrixExtension
    {
        public static Matrix Clone(this Matrix matrix)
        {
            Matrix newMatrix = new Matrix(matrix.CopyToArray(), matrix.Rows, matrix.Columns);

            return newMatrix;
        }
    }
}
