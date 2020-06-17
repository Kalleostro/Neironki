namespace NeuroLib
{
    public class Data
    {
        public double Expected { get; private set; }
        public double[] InputsSignals { get; private set; }

        public Data(double expected, double[] inputsSignals)
        {
            Expected = expected;
            InputsSignals = inputsSignals;
        }
    }
}
