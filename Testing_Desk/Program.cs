using System;
using Task_001;

namespace Testing_Desk
{
    class Program
    {
        static void Show(Matrix matrix)
        {
            for (int i = 0; i < matrix.Columns; i++)
            {
                for (int j = 0; j < matrix.Rows; j++)
                {
                    Console.Write("\t{0}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int[,] array1 =
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            Matrix matrix1 = new Matrix(array1);
            Console.WriteLine("\tMatrix 1");
            Show(matrix1);
            Console.WriteLine(new string('-', 30));

            int[,] array2 =
            {
                { 10, 11, 12 },
                { 13, 14, 15 },
                { 16, 17, 18 }
            };
            Matrix matrix2 = new Matrix(array2);
            Console.WriteLine("\tMatrix 2");
            Show(matrix2);
            Console.WriteLine(new string('-', 30));

            Matrix matrix3 = matrix1 + matrix2; // Matrix addition.
            Console.WriteLine("\tMatrix 1 + Matrix 2");
            Show(matrix3);
            Console.WriteLine(new string('-', 30));

            matrix3 = matrix1 - matrix2; // Matrix differeence.
            Console.WriteLine("\tMatrix 1 - Matrix 2");
            Show(matrix3);
            Console.WriteLine(new string('-', 30));

            matrix3 = matrix1.MulMatrix(matrix2); // Matrix multiply.
            Console.WriteLine("\tMatrix 1 * Matrix 2");
            Show(matrix3);
            Console.WriteLine(new string('-', 30));

            Console.WriteLine("Item[1,2] from Matrix 1 = {0}\n", matrix1[1, 2]); // Indexator.

            int[,] array3 =
{
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            Matrix matrix4 = new Matrix(array3);
            Console.WriteLine("Matrix 1 equals Matrix 4 = {0}\n", matrix1.Equals(matrix4)); // Comparison.

            Console.WriteLine("Serialization - {0}\n", Matrix.Serialization(matrix3)); // Serialization.

            Matrix matrix5;
            Console.WriteLine("Deserialization - {0}\n", Matrix.Deserialization(out matrix5)); // Deserialization.
            Show(matrix5);
        }
    }
}