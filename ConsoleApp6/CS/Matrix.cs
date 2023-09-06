using System;
using System.Text;

namespace CSharp
{
    public class Matrix
    {
        public int MatrixOrder { get; }
        public double[] Row;

        // initialize by default
        public Matrix(int n)
        {
            var rnd = new Random();
            MatrixOrder = n;
            Row = new double[MatrixOrder];
            Row[0] = rnd.NextDouble() * 10000 + 1000;
            for (var i = 1; i < MatrixOrder; i++)
            {
                Row[i] = rnd.NextDouble() * 10 + 1;
            }
        }

        // custom initialize from console
        public Matrix()
        {
            var rnd = new Random();
            Console.Write("Enter matrix size: ");
            MatrixOrder = Convert.ToInt32(Console.ReadLine());
            Row = new double[MatrixOrder];
            for (var i = 0; i < MatrixOrder; i++)
            {
                Console.Write($"{i} element: ");
                Row[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        // custom initialize from array
        public Matrix(int size, double[] source)
        {
            MatrixOrder = size;
            Row = new double[MatrixOrder];
            for (var i = 0; i < MatrixOrder; i++)
            {
                Row[i] = source[i];
            }
        }

        /*
         b - left part
         x - array for answers
         */
        public void Solve(double[] b, double[] x)
        {
            int m = MatrixOrder;
            var a1 = new double[m];
            var b1 = new double[m];

            int j, k, kj;
            double rk, sk, fkk;

            a1[0] = 1 / Row[0];
            x[0] = b[0] * a1[0];
            b1[0] = 0;
            for (k = 2; k <= m; ++k)
            {
                a1[k - 1] = 0;
                x[k - 1] = 0;
                rk = 0;
                fkk = 0;
                for (j = 2; j <= k; ++j)
                {
                    kj = k - j + 1;
                    b1[j - 1] = a1[kj - 1];
                    rk += Row[j - 1] * b1[j - 1];
                    fkk += Row[j - 1] * x[kj - 1];
                }
                fkk = b[k - 1] - fkk;
                sk = 1 / (1 - rk * rk);
                rk = -rk * sk;
                for (j = 1; j <= k; ++j)
                {
                    kj = k - j + 1;
                    a1[j - 1] = a1[j - 1] * sk + b1[j - 1] * rk;
                    x[kj - 1] += a1[j - 1] * fkk;
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < MatrixOrder; i++)
            {
                for (var j = 0; j < MatrixOrder; j++)
                {
                    sb.Append($"{GetElement(i, j):f4}");
                }
            }

            return sb.ToString();
        }

        private double GetElement(int i, int j)
        {
            return Row[Math.Abs(i - j)];
        }
    }
}