using System;
using System.Text;

namespace CSharp
{
    [Serializable]
    public class TimeItem
    {
        public int matrixOrder;
        public int repetitionsNumber;
        public long CSTime;
        public double CPPTime;
        public double coefficient;


        public TimeItem(int matrixOrder_, int repetitionsCount_, long CSTime_, double CPPTime_)
        {
            matrixOrder = matrixOrder_;
            repetitionsNumber = repetitionsCount_;
            CSTime = CSTime_;
            CPPTime = CPPTime_;
            coefficient = CSTime_ / CPPTime_;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Matrix order: {matrixOrder}\n");
            sb.Append($"Repetitions number: {repetitionsNumber}\n");
            sb.Append($"Time for C# code: {CSTime}\n");
            sb.Append($"Time for C++ code: {CPPTime}\n");
            sb.Append($"Radio of C# time to C++ time: {coefficient}\n\n");

            return sb.ToString();
        }
    }
}