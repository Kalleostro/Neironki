using System;

namespace NeuroLib
{
    public class ActFuncSigm : Neuron
    {
        public ActFuncSigm() : base() { }

        /// <summary>
        /// Функция активации логистическая
        /// </summary>
        /// <param name="x">Сумма</param>
        /// <returns>Значение после активации</returns>
        public override double ActivationFunction(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }

        /// <summary>
        /// Производная функция активации сигмоида
        /// </summary>
        /// <param name="x">Сумма</param>
        /// <returns>Значение после активации</returns>
        public override double ActivationFunc(double x)
        {
            double sigmoid = ActivationFunction(x);
            return sigmoid / (1 - sigmoid);
        }
    }
}
