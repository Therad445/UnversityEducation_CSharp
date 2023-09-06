using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace CSharp
{
	class Solver
	{
		public static long SolveRepeatCS(int matrixOrder, int repetitionCount)
		{
			Random rnd = new Random();
			Matrix matrix = new Matrix(matrixOrder);
			var b = new double[matrixOrder]; // right part
			var x = new double[matrixOrder]; // array for answers
			for (var i = 0; i < matrixOrder; i++) b[i] = rnd.NextDouble() * 10;

			var timer = new Stopwatch();
			timer.Start();

			for (var i = 0; i < repetitionCount; i++)
			{
				matrix.Solve(b, x);
			}

			timer.Stop();
			return timer.ElapsedMilliseconds;

		}

		public static void SolveMatrixCS(int matrixOrder, double[] sourceMatrix, double[] right, double[] ans)
		{
			var matrix = new Matrix(matrixOrder, sourceMatrix);
			matrix.Solve(right, ans);
		}
	}


}
