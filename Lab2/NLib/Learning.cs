namespace NeuroLib
{
    public abstract class Learning
    {
        public Network Network { get; set; }

        public Learning(Network network)
        {
            Network = network;
        }

        /// <summary>
        /// Стратегия обучения
        /// </summary>
        /// <param name="expectedOutput">Ожидаемые выходные сигналы</param>
        /// <param name="inputSignals">Входные сигналы</param>
        /// <returns></returns>
        public abstract double Learn(double expectedOutput, params double[] inputSignals);
    }
}