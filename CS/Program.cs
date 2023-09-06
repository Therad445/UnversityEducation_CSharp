using System;
using System.IO;
using System.Runtime.InteropServices;

namespace CSharp
{
    class Program
    {
        [DllImport(@"CPP.dll")]
        public static extern double SolveRepeatCPP(int matrixOrder, int repetitionCount);

        [DllImport(@"CPP.dll")]
        public static extern void SolveMatrixCPP(int matrixOrder, double[] sourceMatrix, double[] right, double[] ans);


        static void Main(string[] args)
        {

            #region Test

            var rightTest = new double[6] { 21, 17, 15, 15, 17, 21 };
            var testMatrix = new double[] { 1, 2, 3, 4, 5, 6 };
            var x = new double[6] { 0, 0, 0, 0, 0, 0 };

            // C# test
            var test = new Matrix(6, testMatrix);
            test.Solve(rightTest, x);
            Console.WriteLine("C# solve for test matrix (should all be 1):");
            foreach (var i in x)
            {
                Console.WriteLine($"{i:f4}");
            }

            // C++ test
            SolveMatrixCPP(6, testMatrix, rightTest, x);
            Console.WriteLine("C++ solve for test matrix (should all be 1):");
            foreach (var i in x)
            {
                Console.WriteLine($"{i:f4}");
            }

            #endregion

            var times = new TimesList();
            Console.WriteLine("Enter file's name: ");
            string filename;
            do
            {
                filename = Console.ReadLine();
            } while (filename.Length == 0);

            try
            {
                var fileInfo = new FileInfo(filename);
                if (fileInfo.Exists)
                {
                    times.Load(filename);
                    Console.WriteLine(times);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("File wasn't found and was created");
                    Console.ResetColor();
                    fileInfo.Create().Close();
                }

                var command = "1";
                while (command == "1")
                {
                    Console.WriteLine("Enter 1 to enter matrix order and repetitions number. Any other input - EXIT");
                    command = Console.ReadLine();
                    if (command != "1") break;

                    Console.Write("Enter matrix order: ");
                    var matrixOrder = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter repetitions number: ");
                    var repetitionsNumber = Convert.ToInt32(Console.ReadLine());

                    // C# calculations
                    var CSTime = Solver.SolveRepeatCS(matrixOrder, repetitionsNumber);

                    // C++ calculations
                    var CPPTime = SolveRepeatCPP(matrixOrder, repetitionsNumber);

                    times.Add(new TimeItem(matrixOrder, repetitionsNumber, CSTime, CPPTime));

                }

                Console.WriteLine("All time measurements: ");
                Console.WriteLine(times);
                times.Save(filename);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }


        }
    }
}