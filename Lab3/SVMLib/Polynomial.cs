using System;

namespace SVMLib
{
    public class Polynomial : IKernel
    {
        private int degree;

        public int Degree
        {
            get { return degree; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("value", "Degree must be positive.");

                degree = value;
            }
        }

        public double Constant { get; set; }


        public Polynomial(int degree, double constant = 1.0)
        {
            this.degree = degree;
            Constant = constant;
        }


        public double Function(double[] x, double[] y)
        {
            double sum = Constant;
            for (int i = 0; i < x.Length; i++)
                sum += x[i] * y[i];

            return Math.Pow(sum, degree);
        }
    }
}