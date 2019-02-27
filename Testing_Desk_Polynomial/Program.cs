using System;
using Task_002;

namespace Testing_Desk_Polynomial
{
    class Program
    {
        #region Read Polynoms

        public static void ReadPolynoms(Polynom polynom, string topic, string polName)
        {
            Console.WriteLine(topic);

            int temp = polynom.Length;

            for (int i = polynom.Degree; i >= 0; i--)
            {
                if (polynom[i] != 0)
                {
                    Console.Write("(" + polynom[i]
                          + ((i != 0) ? ("X" + "^" + (i)) : "") + ")"
                          + (temp != 1 ? "+" : ";\n"));
                    temp--;
                }
            }

            Console.WriteLine($"Show degree of the polynom \"{polName}\": {polynom.Degree}");
            Console.WriteLine($"Show length of the polynom \"{polName}\": {polynom.Length}");
            Console.WriteLine(new string('-', 30));
        }

        #endregion

        static void Main(string[] args)
        {
            double[] members1 = { 9, 1, -2, 5, 7 };
            Polynom a = new Polynom(members1);
            ReadPolynoms(a, "1st polynom", "A");

            double[] members2 = { -9, -6, 8 };
            Polynom b = new Polynom(members2, 4);
            ReadPolynoms(b, "2nd polynom", "B");

            Polynom c = a + b;
            ReadPolynoms(c, "A + B = C", "C");

            c = a - b;
            ReadPolynoms(c, "A - B = C", "C");

            c = a * b;
            ReadPolynoms(c, "A * B = C", "C");

            c[15] = 13;
            ReadPolynoms(c, "Adding a new degree of polynom", "C");

            Console.ReadLine();
        }
    }
}