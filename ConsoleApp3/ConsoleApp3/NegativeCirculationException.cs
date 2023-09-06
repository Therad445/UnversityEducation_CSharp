using System;

namespace CS_3
{
    public class NegativeCirculationException : ArgumentException
    {
        public NegativeCirculationException(string _message) : base(_message) {}
    }
}