using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroLib
{
    /// <summary>
    /// Класс нейроной сети
    /// </summary>
    public class Network
    {
        public Learning learningStrategy { get; set; }

        /// <summary>
        /// Топология сети
        /// </summary>
        public Topology Topology { get; private set; }
        /// <summary>
        /// Слои сети
        /// </summary>
        public List<Layer> Layers { get; private set; }

        /// <summary>
        /// Количество эпох
        /// </summary>
        public int CountOfEpoch { get; private set; }

        private double sumError;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="topology">Топология сети</param>
        public Network(Topology topology)
        {
            Topology = topology;
            Layers = new List<Layer>();
        }

        public void CreateLayers<T>()
            where T : Neuron, new()
        {
            CreateInputLayer<T>();
            CreateHiddenLayers<T>();
            CreateOutputLayer<T>();
        }

        /// <summary>
        /// Передача сигналов по нейроной сети
        /// </summary>
        /// <param name="inputSignals">Входные значение на нейроны входного слоя</param>
        /// <returns>Выходной нейрон</returns>
        public Neuron FeedForwardSignals(params double[] inputSignals)
        {
            SendSignalsToInputNeurons(inputSignals);

            for(int i = 1; i < Layers.Count; i++ )
            {
                List<double> previousSignals = Layers[i - 1].GetSignals();

                foreach (Neuron neuron in Layers[i].Neurons)
                    neuron.FeedForwardSignals(previousSignals);
            }

            if(Topology.OutputCount == 1)
            {
                return Layers.Last().Neurons[0];
            }
            else
            {
                return Layers.Last().Neurons.OrderByDescending(n => n.Output).First();
            }

        }
        /// <summary>
        /// обучить
        /// </summary>
        /// <param name="dataset">Набор вх данных</param>
        /// <param name="epoch">Эпоха</param>
        /// <returns></returns>
        public double Learn(List<Data> dataset, int epoch)
        {
            double error = 0;

            for (int i = 0; i < epoch; i++)
            {
                foreach(var data in dataset)
                {
                    error += learningStrategy.Learn(data.Expected, data.InputsSignals);
                }
            }

            sumError += error;
            CountOfEpoch += epoch;

            return sumError / CountOfEpoch;
        }

        /// <summary>
        /// Подать сигналы на слой
        /// </summary>
        /// <param name="inputs">Входные сигналы</param>
        public void SendSignalsToInputNeurons(params double[] inputSignals)
        {
            if (inputSignals.Length != Topology.InputCount)
                throw new Exception("Число сигналов должно быть равно числу нейронов");

            for(int i = 0; i < inputSignals.Length; i++)
            {
                List<double> signal = new List<double>() { inputSignals[i] };
                Neuron neuron = Layers[0].Neurons[i];

                neuron.FeedForwardSignals(signal);
            }
        }

        /// <summary>
        /// Создание входного слоя
        /// </summary>
        private void CreateInputLayer<T>()
            where T : Neuron, new()
        {
            List<Neuron> inputNeurons = new List<Neuron>();
            for (int i = 0; i < Topology.InputCount; i++)
            {
                Neuron neuron = new T();
                neuron.InitializeNeuron(1, TypeOfNeuron.Input);
                inputNeurons.Add(neuron);
            }

            Layer inputLayer = new Layer(inputNeurons, TypeOfNeuron.Input);
            Layers.Add(inputLayer);
        }

        /// <summary>
        /// Создание скрытого слоя
        /// </summary>
        private void CreateHiddenLayers<T>()
            where T : Neuron, new()
        {
            for (int i = 0; i < Topology.HiddenLayers.Count; i++)
            {
                List<Neuron> hiddenNeurons = new List<Neuron>();
                Layer lastLayer = Layers.Last();
                for (int j = 0; j < Topology.HiddenLayers[i]; j++)
                {
                    Neuron neuron = new T();
                    neuron.InitializeNeuron(lastLayer.Count, TypeOfNeuron.Intermediate);
                    hiddenNeurons.Add(neuron);
                }
                Layer hiddenLayer = new Layer(hiddenNeurons, TypeOfNeuron.Intermediate);
                Layers.Add(hiddenLayer);
            }
        }

        /// <summary>
        /// Создание выходного слоя
        /// </summary>
        private void CreateOutputLayer<T>()
            where T : Neuron, new()
        {
            List<Neuron> outputNeurons = new List<Neuron>();
            Layer lastLayer = Layers.Last();

            for (int i = 0; i < Topology.OutputCount; i++)
            {
                Neuron neuron = new T();
                neuron.InitializeNeuron(lastLayer.Count, TypeOfNeuron.Output);
                outputNeurons.Add(neuron);
            }

            Layer outputLayer = new Layer(outputNeurons, TypeOfNeuron.Output);
            Layers.Add(outputLayer);
        }
    }
}
