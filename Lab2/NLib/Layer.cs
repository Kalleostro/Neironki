using System;
using System.Collections.Generic;

namespace NeuroLib
{
    /// <summary>
    /// Класс слоя нейроной сети
    /// </summary>
    public class Layer
    {
        /// <summary>
        /// Нейроны на данном слое
        /// </summary>
        public List<Neuron> Neurons { get; private set; }
        /// <summary>
        /// Количество нейроннов на данном слое
        /// </summary>
        public int Count => Neurons?.Count ?? 0;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="neurons">Нейроны на данном слое</param>
        /// <param name="type">Тип нейронов на данном слое</param>
        public Layer(List<Neuron> neurons, TypeOfNeuron type = TypeOfNeuron.Intermediate)
        {
            if (neurons == null)
                throw new Exception("Нет нейронов.");

            foreach (Neuron neuron in neurons)
                if (neuron.NeuronType != type)
                    throw new Exception("Ошибка типа нейрона.");

            Neurons = neurons;
        }
        /// <summary>
        /// Возращает выходные сигналы всех нейронов на данном слое
        /// </summary>
        /// <returns>Список выходных сигналов слоя</returns>
        public List<double> GetSignals()
        {
            List<double> results = new List<double>();

            foreach (Neuron neuron in Neurons)
                results.Add(neuron.Output);

            return results;
        }
    }
}
