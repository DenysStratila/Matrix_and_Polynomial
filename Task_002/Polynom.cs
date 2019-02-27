using System.Collections.Generic;
using System.Linq;

namespace Task_002
{
    public class Polynom
    {
        private Dictionary<int, double> pairs;

        public int Degree { get; private set; }
        public int Length { get; private set; }

        #region Constructors

        public Polynom(double[] coefficients, int degree)
        {
            pairs = new Dictionary<int, double>();

            Add(coefficients, degree);
            CheckDegree();
            CheckLength();
        }

        public Polynom(double[] coefficients)
            : this(coefficients, coefficients.Length - 1)
        {
        }

        public Polynom(Dictionary<int, double> pairs)
        {
            this.pairs = pairs;

            CheckDegree();
            CheckLength();
        }

        #endregion

        #region Private methods

        private void Add(double[] coefficients, int degree)
        {
            if (this.pairs != null)
            {
                int counter = 0;
                int temp = degree;

                for (int i = coefficients.Length - 1; i >= 0; i--)
                {
                    if (coefficients[counter] != 0)
                    {
                        pairs.Add(temp, coefficients[counter]);
                    }
                    counter++;
                    temp--;
                }
            }
        }

        private void CheckDegree()
        {
            if (this.pairs != null)
            {
                var degrees = pairs.Select(x => new { x.Key }).OrderByDescending(x => x.Key);

                foreach (var degree in degrees)
                {
                    if (pairs[degree.Key] != 0)
                    {
                        Degree = degree.Key;
                        break;
                    }
                    pairs.Remove(degree.Key);
                }
            }
        }

        private void CheckLength()
        {
            if (this.pairs != null)
            {
                int counter = 0;

                foreach (var pair in pairs)
                {
                    if (pair.Value != 0)
                        counter++;
                }

                Length = counter;
            }
        }

        #endregion

        #region Operator "+"

        public static Polynom operator +(Polynom a, Polynom b)
        {
            Dictionary<int, double> pairsC = new Dictionary<int, double>();

            foreach (var pairA in a.pairs)
            {
                foreach (var pairB in b.pairs)
                {
                    if (pairA.Key == pairB.Key)
                    {
                        pairsC.Add(pairA.Key, pairA.Value + pairB.Value);
                    }
                    else if (!a.pairs.ContainsKey(pairB.Key) && !pairsC.ContainsKey(pairB.Key))
                    {
                        pairsC.Add(pairB.Key, pairB.Value);
                    }
                }
                if (!pairsC.ContainsKey(pairA.Key))
                {
                    pairsC.Add(pairA.Key, pairA.Value);
                }
            }

            return new Polynom(pairsC);
        }

        #endregion

        #region Operator "-"

        public static Polynom operator -(Polynom a, Polynom b)
        {
            Dictionary<int, double> pairsC = new Dictionary<int, double>();

            foreach (var pairA in a.pairs)
            {
                foreach (var pairB in b.pairs)
                {
                    if (pairA.Key == pairB.Key)
                    {
                        pairsC.Add(pairA.Key, pairA.Value - pairB.Value);
                    }
                    else if (!a.pairs.ContainsKey(pairB.Key) && !pairsC.ContainsKey(pairB.Key))
                    {
                        pairsC.Add(pairB.Key, (0 - pairB.Value));
                    }
                }
                if (!pairsC.ContainsKey(pairA.Key))
                {
                    pairsC.Add(pairA.Key, pairA.Value);
                }
            }

            return new Polynom(pairsC);
        }

        #endregion

        #region Operator "*"

        public static Polynom operator *(Polynom a, Polynom b)
        {
            int degree = a.Degree + b.Degree + 1;

            var result = new double[degree];

            foreach (var pairA in a.pairs)
            {
                foreach (var pairB in b.pairs)
                {
                    result[pairA.Key + pairB.Key] += pairA.Value * pairB.Value;
                }
            }

            return new Polynom(TakeReverse(result));
        }

        private static double[] TakeReverse(double[] coefficients)
        {
            IEnumerable<double> temp = coefficients.Reverse();
            var result = new double[coefficients.Length];

            int i = 0;
            foreach (var item in temp)
            {
                result[i] = item;
                i++;
            }

            return result;
        }

        #endregion

        #region Indexator

        public double this[int index]
        {
            get
            {
                if (!pairs.ContainsKey(index) || index > Degree)
                    return 0;
                else if (index < 0)
                    throw new DegreeIsLessThanZeroException("This degree is less than 0");
                else
                    return pairs[index];
            }
            set
            {
                if (!pairs.ContainsKey(index) || index > Degree)
                {
                    pairs.Add(index, value);
                    CheckDegree();
                    CheckLength();
                }
                else if (index < 0)
                    throw new DegreeIsLessThanZeroException("This degree is less than 0");
                else
                    pairs[index] = value;
            }
        }

        #endregion
    }
}