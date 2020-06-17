using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroLib
{
    /// <summary>
    /// Класс топологии сети
    /// </summary>
    public class Topology
    {
        /// <summary>
        /// Количество входных слоев
        /// </summary>
        public int InputCount { get; private set; }
        /// <summary>
        /// Количество выходных слоев
        /// </summary>
        public int OutputCount { get; private set; }
        /// <summary>
        /// Коэфициент скорости обучения
        /// </summary>
        public double LearningRate { get; private set; }
        /// <summary>
        /// Скрытые слои
        /// </summary>
        public List<int> HiddenLayers { get; private set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="inputCount">Количество входных слоев</param>
        /// <param name="outputCount">Количество выходных слоев</param>
        /// <param name="learningRate">Коэфициент обучения</param>
        /// <param name="hiddenLayers">Скрытые слои</param>
        public Topology(int inputCount, int outputCount, double learningRate, params int[] hiddenLayers)
        {
            InputCount = inputCount;
            OutputCount = outputCount;
            LearningRate = learningRate;
            HiddenLayers = new List<int>();
            HiddenLayers.AddRange(hiddenLayers);
        }
    }
}
