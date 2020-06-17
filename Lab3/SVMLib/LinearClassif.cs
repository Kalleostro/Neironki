namespace SVMLib
{
    public class LinearClassif : IKernel
    {
        public double Constant { get; set; }


        public LinearClassif(double constant = 0)
        {
            Constant = constant;
        }

        public double Function(double[] x, double[] y)
        {
            double sum = Constant;
            for (int i = 0; i < y.Length; i++)
                sum += x[i] * y[i];

            return sum;
        }
    }
}