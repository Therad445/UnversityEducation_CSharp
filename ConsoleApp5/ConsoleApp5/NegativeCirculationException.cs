using System;

namespace CS_5
{
    public class NegativeCirculationException : ArgumentException
    {
        public NegativeCirculationException(string _message) : base(_message) {}
    }
}