using NeuroLib;

namespace SVMLib
{
    /// <summary>
    /// Класс, описывающий машину опорных векторов
    /// </summary>
    public class SupportVectorMachine
    {
        private int inputCount;
        private double[][] supportVectors;
        private double[] weights;
        private double threshold;

        /// <summary>
        /// Создание новой SVM.
        /// </summary>
        public SupportVectorMachine(int inputs)
        {
            this.inputCount = inputs;
        }

        /// <summary>
        /// Получение количества входов.
        /// </summary>
        public int Inputs
        {
            get { return inputCount; }
        }

        /// <summary>
        /// Получение и установка векторов, используемых данной машиной.
        /// </summary>
        public double[][] SupportVectors
        {
            get { return supportVectors; }
            set { supportVectors = value; }
        }

        /// <summary>
        /// Получение и установка весов, используемых данной машиной.
        /// </summary>
        public double[] Weights
        {
            get { return weights; }
            set { weights = value; }
        }

        /// <summary>
        /// Получение и установка порога (смещения), используемых данной машиной.
        /// </summary>
        public double Threshold
        {
            get { return threshold; }
            set { threshold = value; }
        }

        /// <summary>
        /// Вычисляет заданные входы для получения соответствующих выходов.
        /// </summary>
        /// <param name="input">Входной вектор.</param>
        /// <returns>Выход для данного входа.</returns>
        public virtual double Compute(double[] input)
        {
            double s = threshold;
            for (int i = 0; i < supportVectors.Length; i++)
            {
                double p = 0;
                for (int j = 0; j < input.Length; j++)
                    p += supportVectors[i][j] * input[j];

                s += weights[i] * p;
            }

            return s;
        }

        /// <summary>
        /// Вычисляет заданные входы для получения соответствующих выходов.
        /// </summary>
        /// <param name="dataset">Входные вектора.</param>
        /// <returns>Выходы для данных входов.</returns>
        public double[] Compute(Data[] dataset)
        {
            double[] outputs = new double[dataset.Length];
            double[][] inputs = new double[dataset.Length][];

            for (int i = 0; i < dataset.Length; i++)
            {
                inputs[i] = new double[dataset[i].InputsSignals.Length];
                for (int j = 0; j < dataset[i].InputsSignals.Length; j++)
                    inputs[i][j] = dataset[i].InputsSignals[j];
            }

            for (int i = 0; i < inputs.Length; i++)
                outputs[i] = Compute(inputs[i]);

            return outputs;
        }
    }
}
