namespace SVMLib
{
    public class VectorMachine : SupportVectorMachine
    {
        /// <summary>
        /// Создание SVM
        /// </summary>
        /// <param name="kernel">Ядро.</param>
        /// <param name="inputs">Количество входов</param>
        public VectorMachine(IKernel kernel, int inputs) : base(inputs)
        {
            Kernel = kernel;
        }

        /// <summary>
        /// Получение или задание ядра
        /// </summary>
        public IKernel Kernel { get; set; }

        /// <summary>
        /// Вычисляет значение для входного вектора
        /// </summary>
        /// <param name="inputs">Входной вектор</param>
        /// <returns>Результат для данного вектора</returns>
        public override double Compute(double[] inputs)
        {
            double s = Threshold;

            for (int i = 0; i < SupportVectors.Length; i++)
                s += Weights[i] * Kernel.Function(SupportVectors[i], inputs);

            return s;
        }
    }
}
