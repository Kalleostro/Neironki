namespace NeuroLib
{
    public class HebbRule : Learning
    {
        public HebbRule(Network network)
            : base(network)
        {
        }
        /// <summary>
        /// Коррекция весов нейрона
        /// </summary>
        /// <param name="neuron">Нейрон</param>
        /// <param name="error">Ошибка</param>
        private void UpdateWeights(Neuron neuron, double error)
        {
            if (neuron.NeuronType == TypeOfNeuron.Input) return;
            if (error != 0)
                neuron.Delta = error * neuron.ActivationFunc(neuron.Output);
            else
                neuron.Delta = 0;
            for (int i = 0; i < neuron.Weights.Count; i++)
            {
                var weight = neuron.Weights[i];
                var input = neuron.Inputs[i];
                var newWeigth = weight + input * neuron.Delta;
                neuron.Weights[i] = newWeigth;
            }
        }
        /// <summary>
        /// Обучение по правилу Хебба
        /// </summary>
        /// <param name="expectedOutput">Ожидаемое значение</param>
        /// <param name="inputSignals">Входные сигналы</param>
        /// <returns></returns>
        /// <summary>
        public override double Learn(double expectedOutput, params double[] inputSignals)
        {
            double actualOutput = Network.FeedForwardSignals(inputSignals).Output;

            double difference = actualOutput - expectedOutput;

            for (int j = Network.Layers.Count - 1; j >= 0; j--)
            {
                Layer currentLayer = Network.Layers[j];

                for (int i = 0; i < currentLayer.Count; i++)
                {
                    Neuron neuron = currentLayer.Neurons[i];
                    double error = expectedOutput - neuron.Output;
                    UpdateWeights(neuron, error);
                }
            }

            return difference * difference / 2;
        }
    }
}
