namespace CS_4
{
    interface IRateAndCopy
    {
        double Rating { get; }

        public object DeepCopy();
    }
}