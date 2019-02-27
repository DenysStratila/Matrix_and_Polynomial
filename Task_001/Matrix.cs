using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task_001
{
    [Serializable]
    public class Matrix : IEnumerable
    {
        private readonly int[,] _items;

        #region Properties

        public int Rows { get; private set; }

        public int Columns { get; private set; }

        #endregion

        #region Constructors

        public Matrix(int[,] array) // Matrix by using a two-dimensional array.
        {
            _items = array;
            Rows = array.GetLength(0);
            Columns = array.GetLength(1);
        }

        public Matrix(int[] array, int rows, int columns) // Matrix NxM by using a simple array.
        {
            _items = new int[rows, columns];
            Rows = rows;
            Columns = columns;
            AddArray(array);
        }

        #endregion

        #region AddArray

        private void AddArray(int[] array)
        {
            int k = 0;

            for (int i = 0; i < Columns; i++)
            {
                for (int j = i; j < Rows; j++)
                {
                    _items[i, j] = array[k];
                    k++;
                }
            }
        }

        #endregion

        #region Enumerator

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        #endregion

        #region Matrix Addition

        public Matrix AddMatrix(Matrix matrix)
        {
            if (this.Rows != matrix.Rows && this.Columns != matrix.Columns)
            {
                throw new DifferentSizesOfMatricesException("Matrices have different size!");
            }

            Matrix newMatrix = new Matrix(matrix.CopyToArray(), Rows, Columns);

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    newMatrix._items[i, j] = this._items[i, j] + matrix._items[i, j];
                }
            }

            return newMatrix;
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            return m1.AddMatrix(m2);
        }

        #endregion

        #region Matrix Difference

        public Matrix DifMatrix(Matrix matrix)
        {
            if (this.Rows != matrix.Rows && this.Columns != matrix.Columns)
            {
                throw new DifferentSizesOfMatricesException("Matrices have different size!");
            }

            Matrix newMatrix = new Matrix(matrix.CopyToArray(), Rows, Columns);

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    newMatrix._items[i, j] = this._items[i, j] - matrix._items[i, j];
                }

            }

            return newMatrix;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            return m1.DifMatrix(m2);
        }

        #endregion

        #region Matrix Multiplication

        public Matrix MulMatrix(Matrix matrix)
        {
            if (matrix == null)
            {
                throw new MatrixIsNullException("Matrices can not be multiplied!");
            }

            Matrix newMatrix = new Matrix(new int[this.Rows, matrix.Columns]);

            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    for (int k = 0; k < matrix.Rows; k++)
                    {
                        newMatrix._items[i, j] += this._items[i, k] * matrix._items[k, j];
                    }
                }
            }
            return newMatrix;
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            return m1.MulMatrix(m2);
        }

        #endregion

        #region Indexator

        public int this[int row, int column]
        {
            get
            {
                CheckIndex(row, column);
                return _items[row, column];
            }
            set
            {
                CheckIndex(row, column);
                _items[row, column] = value;
            }
        }

        private void CheckIndex(int row, int column)
        {
            if (row >= Rows || row < 0)
                throw new IndexOutOfRangeException("Index of a row is not in the range of the matrix");
            else if (column >= Columns || column < 0)
                throw new IndexOutOfRangeException("Index of a column is not in the range of the matrix");
            else
                return;
        }

        #endregion

        #region CopyToArray

        public int[] CopyToArray()
        {
            int[] newArray = new int[_items.Length];

            int k = 0;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = i; j < Columns; j++)
                {
                    newArray[k] = _items[i, j];
                    k++;
                }
                k++;
            }

            return newArray;
        }

        #endregion

        #region Comparison

        public override bool Equals(object obj)
        {
            if (!(obj is Matrix))
                return false;

            Matrix matrix = obj as Matrix;

            if (this.Rows != matrix.Rows || this.Columns != matrix.Columns)
                return false;

            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    if (this._items[i, j] != matrix._items[i, j])
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region Serialization

        public static bool Serialization(Matrix matrix)
        {
            if (matrix == null)
                throw new MatrixIsNullException("Serialization cannot be completed, because matrix is null!");

            FileStream fileStream = File.Create("Matrix.dat");

            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fileStream, matrix);

            fileStream.Close();

            return true;
        }

        #endregion

        #region Deserialization

        public static bool Deserialization(out Matrix matrix)
        {
            Stream stream = File.OpenRead("Matrix.dat");

            BinaryFormatter formatter = new BinaryFormatter();
            matrix = formatter.Deserialize(stream) as Matrix;

            stream.Close();

            return true;
        }

        #endregion
    }
}