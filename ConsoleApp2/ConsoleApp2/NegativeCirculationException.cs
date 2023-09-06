using System;

namespace CS_1
{
    public class NegativeCirculationException : ArgumentException
    {
        public NegativeCirculationException(string _message) : base(_message) {}
    }
}