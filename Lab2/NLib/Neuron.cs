using System;
using System.Collections.Generic;

namespace NeuroLib
{
    /// <summary>
    /// Класс нейрона
    /// </summary>
    public abstract class Neuron
    {
        /// <summary>
        /// Веса приходящих синапсов
        /// </summary>
        public List<double> Weights { get; protected set; }
        /// <summary>
        /// Входные сигналы нейронов
        /// </summary>
        public List<double> Inputs { get; protected set; }
        /// <summary>
        /// Тип нейрона
        /// </summary>
        public TypeOfNeuron NeuronType { get; protected set; }
        /// <summary>
        /// Значение выходного синапса нейрона
        /// </summary>
        public double Output { get; protected set; }
        /// <summary>
        /// Значение дельты
        /// </summary>
        public double Delta { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Neuron() { }

        /// <summary>
        /// Инициализация нейрона
        /// </summary>
        /// <param name="inputCount">Число входных сигналов</param>
        /// <param name="type">Тип нейрона</param>
        public void InitializeNeuron(int inputCount, TypeOfNeuron type = TypeOfNeuron.Intermediate)
        {
            NeuronType = type;
            Weights = new List<double>();
            Inputs = new List<double>();
            InitializeRandomWeights(inputCount);
        }

        /// <summary>
        /// Инициализация весов рандомными значениями 
        /// </summary>
        /// <param name="inputCount">Количество входных сигналов</param>
        private void InitializeRandomWeights(int inputCount)
        {
            Random random = new Random();

            for (int i = 0; i < inputCount; i++)
            {
                if (NeuronType == TypeOfNeuron.Input)
                {
                    Weights.Add(1);
                }
                else
                {
                    Weights.Add(random.NextDouble());
                }

                Inputs.Add(0);
            }
        }
        /// <summary>
        /// Подаются сигналы и активируется функция
        /// </summary>
        /// <param name="inputSignals">Входные сигналы</param>
        /// <returns>Выходное значение нейрона нейрона</returns>
        public double FeedForwardSignals(List<double> inputSignals)
        {
            if (Weights.Count != inputSignals.Count)
                throw new Exception("Неверное количество входящих сигналов");

            for (int i = 0; i < inputSignals.Count; i++)
            {
                Inputs[i] = inputSignals[i];
            }

            double sum = 0;

            for(int i = 0; i < inputSignals.Count; i++)
            {
                sum += inputSignals[i] * Weights[i];
            }

            if (NeuronType != TypeOfNeuron.Input)
                Output = ActivationFunction(sum);
            else
                Output = sum;

            return Output;
        }
        /// <summary>
        /// функция активации
        /// </summary>
        /// <param name="x"> сумма </param>
        /// <returns></returns>
        public abstract double ActivationFunction(double x);
        public abstract double ActivationFunc(double x);

        /// <summary>
        /// Переопределение метода ToString которые повзращает строку с выходным значением синапса нейрона
        /// </summary>
        /// <returns>Выходное значением синапса нейрона</returns>
        public override string ToString()
        {
            return Output.ToString();
        }
    }

    public enum TypeOfNeuron
    {
        Input = 0,
        Intermediate,
        Output
    }
}
