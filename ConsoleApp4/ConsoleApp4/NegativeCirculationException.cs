using System;

namespace CS_4
{
    public class NegativeCirculationException : ArgumentException
    {
        public NegativeCirculationException(string _message) : base(_message) {}
    }
}