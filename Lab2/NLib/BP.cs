using System.Linq;

namespace NeuroLib
{
    public class BP : Learning
    {
        public BP(Network network) 
            : base(network)
        {

        }

        /// <summary>
        /// Метод обратного распростарнения ошибки
        /// </summary>
        /// <param name="expectedOutput">Ожидаемое значение</param>
        /// <param name="inputSignals">Входные сигналы</param>
        /// <returns>Квадрат ошибки</returns>
        public override double Learn(double expectedOutput, params double[] inputSignals)
        {
            double actualOutput = Network.FeedForwardSignals(inputSignals).Output;

            double difference = expectedOutput - actualOutput;

            foreach (Neuron neuron in Network.Layers.Last().Neurons)
                UpdateWeights(neuron, difference);

            for (int j = Network.Layers.Count - 2; j >= 0; j--)
            {
                Layer currentLayer = Network.Layers[j];
                Layer previousLayer = Network.Layers[j + 1];

                for (int i = 0; i < currentLayer.Count; i++)
                {
                    Neuron neuron = currentLayer.Neurons[i];

                    for (int k = 0; k < previousLayer.Count; k++)
                    {
                        Neuron previousNeuron = previousLayer.Neurons[k];

                        double error = previousNeuron.Weights[i] * previousNeuron.Delta * Network.Topology.LearningRate;
                        UpdateWeights(neuron, error);
                    }
                }
            }

            return difference * difference;
        }

        /// <summary>
        /// Изменение весов нейрона.
        /// </summary>
        /// <param name="neuron">Нейрон, веса которого будут изменяться.</param>
        /// <param name="error">Значение оЗначениешибки.</param>
        private void UpdateWeights(Neuron neuron, double error)
        {
            if (neuron.NeuronType == TypeOfNeuron.Input) return;

            neuron.Delta = error * neuron.ActivationFunc(neuron.Output);

            for (int i = 0; i < neuron.Weights.Count; i++)
            {
                var weight = neuron.Weights[i];
                var input = neuron.Inputs[i];

                var newWeigth = weight + input * neuron.Delta * Network.Topology.LearningRate;
                neuron.Weights[i] = newWeigth;
            }
        }
    }
}
