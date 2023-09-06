namespace CS_1
{
    public interface IRateAndCopy
    {
        double Rating { get; }

        public object DeepCopy();
    }
}