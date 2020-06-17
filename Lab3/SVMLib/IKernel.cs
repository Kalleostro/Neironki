namespace SVMLib
{
    public interface IKernel
    {
        double Function(double[] v, double[] inputs);
    }
}