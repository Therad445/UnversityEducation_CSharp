namespace CS_3
{
    interface IRateAndCopy
    {
        double Rating { get; }

        public object DeepCopy();
    }
}