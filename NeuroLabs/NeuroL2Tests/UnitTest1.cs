using Microsoft.VisualStudio.TestTools.UnitTesting;
using Raven.Client.Http;
using System;
using System.Collections.Generic;
using System.Data;

namespace NeuroLib.Tests
{
    [TestClass()]
    public class NeuronL2Tests
    {
        [TestMethod()]
        public void BackPropagationTest()
        {
            List<Data> dataset = new List<Data>();
            //FillOnes(dataset);
            //FillZeros(dataset);
            FillFour(dataset);

            Topology topology = new Topology(25, 1, 0.1, 15);

            Network neuralNetwork = new Network(topology);
            Learning strategy = new BP(neuralNetwork);
            neuralNetwork.learningStrategy = strategy;

            neuralNetwork.CreateLayers<ActFuncSigm>();
            var difference = neuralNetwork.Learn(dataset, 10000);

            List<double> results = new List<double>();
            foreach (var data in dataset)
            {
                var res = neuralNetwork.FeedForwardSignals(data.InputsSignals).Output;
                results.Add(res);
            }

            for (int i = 0; i < results.Count; i++)
            {
                double expected = Math.Round(dataset[i].Expected, 0);
                double actual = Math.Round(results[i], 0);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod()]
        public void HebbTest()
        {
            List<Data> dataset = new List<Data>();
            //FillOnes(dataset);
            //FillZeros(dataset);
            FillFour(dataset);

            Topology topology = new Topology(25, 1, 0.1, 5);

            Network neuralNetwork = new Network(topology);
            Learning strategy = new HebbRule(neuralNetwork);
            neuralNetwork.learningStrategy = strategy;

            neuralNetwork.CreateLayers<ActFuncSigm>();
            double difference = neuralNetwork.Learn(dataset, 10000);

            List<double> results = new List<double>();
            foreach (var data in dataset)
            {
                var res = neuralNetwork.FeedForwardSignals(data.InputsSignals).Output;
                results.Add(res);
            }

            for (int i = 0; i < results.Count; i++)
            {
                double expected = Math.Round(dataset[i].Expected, 0);
                double actual = Math.Round(results[i] - 0.1, 0);
                Assert.AreEqual(expected, actual);
            }
        }

        private void FillFour(List<Data> dataset)
        {
            dataset.Add(new Data(1, new double[]{
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0
            }));
            dataset.Add(new Data(1, new double[]{
                0, 0, 1, 0, 0,
                0, 1, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 1, 1, 1, 0
            }));

            dataset.Add(new Data(0, new double[]{
                0, 0, 1, 0, 0,
                0, 1, 0, 1, 0,
                0, 1, 0, 1, 0,
                0, 1, 0, 1, 0,
                0, 0, 1, 0, 0
            }));
            dataset.Add(new Data(0, new double[]{
                0, 1, 1, 0, 0,
                1, 0, 0, 1, 0,
                1, 0, 0, 1, 0,
                1, 0, 0, 1, 0,
                0, 1, 1, 0, 0
            }));
        }

        private void FillOnes(List<Data> dataset)
        {
            dataset.Add(new Data(1, new double[]{
                1, 0, 0, 0, 0,
                1, 0, 0, 0, 0,
                1, 0, 0, 0, 0,
                1, 0, 0, 0, 0,
                1, 0, 0, 0, 0
            }));
            dataset.Add(new Data(1, new double[]{
                0, 1, 0, 0, 0,
                0, 1, 0, 0, 0,
                0, 1, 0, 0, 0,
                0, 1, 0, 0, 0,
                0, 1, 0, 0, 0
            }));
            dataset.Add(new Data(1, new double[]{
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0
            }));
            dataset.Add(new Data(1, new double[]{
                0, 0, 0, 1, 0,
                0, 0, 0, 1, 0,
                0, 0, 0, 1, 0,
                0, 0, 0, 1, 0,
                0, 0, 0, 1, 0
            }));
            dataset.Add(new Data(1, new double[]{
                0, 0, 0, 0, 1,
                0, 0, 0, 0, 1,
                0, 0, 0, 0, 1,
                0, 0, 0, 0, 1,
                0, 0, 0, 0, 1
            }));

            dataset.Add(new Data(1, new double[]{
                0, 1, 0, 0, 0,
                1, 1, 0, 0, 0,
                0, 1, 0, 0, 0,
                0, 1, 0, 0, 0,
                0, 1, 0, 0, 0
            }));
            dataset.Add(new Data(1, new double[]{
                0, 0, 1, 0, 0,
                0, 1, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0
            }));
            dataset.Add(new Data(1, new double[]{
                0, 0, 0, 1, 0,
                0, 0, 1, 1, 0,
                0, 0, 0, 1, 0,
                0, 0, 0, 1, 0,
                0, 0, 0, 1, 0
            }));
            dataset.Add(new Data(1, new double[]{
                0, 0, 0, 0, 1,
                0, 0, 0, 1, 1,
                0, 0, 0, 0, 1,
                0, 0, 0, 0, 1,
                0, 0, 0, 0, 1
            }));

            dataset.Add(new Data(1, new double[]{
                0, 1, 0, 0, 0,
                1, 1, 0, 0, 0,
                0, 1, 0, 0, 0,
                0, 1, 0, 0, 0,
                1, 1, 1, 0, 0
            }));
            dataset.Add(new Data(1, new double[]{
                0, 0, 1, 0, 0,
                0, 1, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 1, 1, 1, 0
            }));
            dataset.Add(new Data(1, new double[]{
                0, 0, 0, 1, 0,
                0, 0, 1, 1, 0,
                0, 0, 0, 1, 0,
                0, 0, 0, 1, 0,
                0, 0, 1, 1, 1
            }));
        }

        private void FillZeros(List<Data> dataset)
        {
            dataset.Add(new Data(0, new double[]{
                0, 1, 0, 0, 0,
                1, 0, 1, 0, 0,
                1, 0, 1, 0, 0,
                1, 0, 1, 0, 0,
                0, 1, 0, 0, 0
            }));
            dataset.Add(new Data(0, new double[]{
                0, 0, 1, 0, 0,
                0, 1, 0, 1, 0,
                0, 1, 0, 1, 0,
                0, 1, 0, 1, 0,
                0, 0, 1, 0, 0
            }));
            dataset.Add(new Data(0, new double[]{
                0, 0, 0, 1, 0,
                0, 0, 1, 0, 1,
                0, 0, 1, 0, 1,
                0, 0, 1, 0, 1,
                0, 0, 0, 1, 0
            }));

            dataset.Add(new Data(0, new double[]{
                0, 1, 1, 0, 0,
                1, 0, 0, 1, 0,
                1, 0, 0, 1, 0,
                1, 0, 0, 1, 0,
                0, 1, 1, 0, 0
            }));
            dataset.Add(new Data(0, new double[]{
                0, 0, 1, 1, 0,
                0, 1, 0, 0, 1,
                0, 1, 0, 0, 1,
                0, 1, 0, 0, 1,
                0, 0, 1, 1, 0
            }));

            dataset.Add(new Data(0, new double[]{
                0, 1, 1, 1, 0,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                0, 1, 1, 1, 0
            }));

            dataset.Add(new Data(0, new double[]{
                1, 1, 1, 0, 0,
                1, 0, 1, 0, 0,
                1, 0, 1, 0, 0,
                1, 0, 1, 0, 0,
                1, 1, 1, 0, 0
            }));
            dataset.Add(new Data(0, new double[]{
                0, 1, 1, 1, 0,
                0, 1, 0, 1, 0,
                0, 1, 0, 1, 0,
                0, 1, 0, 1, 0,
                0, 1, 1, 1, 0
            }));
            dataset.Add(new Data(0, new double[]{
                0, 0, 1, 1, 1,
                0, 0, 1, 0, 1,
                0, 0, 1, 0, 1,
                0, 0, 1, 0, 1,
                0, 0, 1, 1, 1
            }));

            dataset.Add(new Data(0, new double[]{
                1, 1, 1, 1, 0,
                1, 0, 0, 1, 0,
                1, 0, 0, 1, 0,
                1, 0, 0, 1, 0,
                1, 1, 1, 1, 0
            }));
            dataset.Add(new Data(0, new double[]{
                0, 1, 1, 1, 1,
                0, 1, 0, 0, 1,
                0, 1, 0, 0, 1,
                0, 1, 0, 0, 1,
                0, 1, 1, 1, 1
            }));

            dataset.Add(new Data(0, new double[]{
                1, 1, 1, 1, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 1, 1, 1, 1
            }));
        }
    }
}