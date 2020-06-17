using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuralLibrary;
using SVMLib;
using System;
using System.Collections.Generic;

namespace SVMLibTests
{
    [TestClass]
    public class SVMTests
    {
        [TestMethod]
        public void SVMTestXOR()
        {
            List<DataSet> dataset = new List<DataSet>();
            dataset.Add(new DataSet(-1, new double[] { -1, -1 }));
            dataset.Add(new DataSet( 1, new double[] { -1,  1 }));
            dataset.Add(new DataSet( 1, new double[] {  1, -1 }));
            dataset.Add(new DataSet(-1, new double[] {  1,  1 }));

            KernelSupportVectorMachine machine = new KernelSupportVectorMachine(
                new Polynomial(2), 2);

            var learn = new SequentialMinimalOptimization(machine, dataset.ToArray());

            double[] error = learn.Run();

            double[] output = machine.Compute(dataset.ToArray());
            double[] expected = { -1, 1, 1, -1 };

            CollectionAssert.AreEqual(expected, output);
        }

        [TestMethod]
        public void SVMTestData()
        {
            List<DataSet> dataset = new List<DataSet>();
            FillOnes(dataset);
            FillZeros(dataset);

            KernelSupportVectorMachine machine = new KernelSupportVectorMachine(
                new Polynomial(2), 25);

            var learn = new SequentialMinimalOptimization(machine, dataset.ToArray());

            double[] error = learn.Run();

            double[] output = machine.Compute(dataset.ToArray());


            double[] expected = new double[dataset.Count];
            for (int i = 0; i < dataset.Count; i++)
            {
                output[i] = Math.Round(output[i]);
                expected[i] = dataset[i].Expected;
            }

            CollectionAssert.AreEqual(expected, output);
        }

        private void FillOnes(List<DataSet> dataset)
        {
            dataset.Add(new DataSet(1, new double[]{
                1, 0, 0, 0, 0,
                1, 0, 0, 0, 0,
                1, 0, 0, 0, 0,
                1, 0, 0, 0, 0,
                1, 0, 0, 0, 0
            }));
            dataset.Add(new DataSet(1, new double[]{
                0, 1, 0, 0, 0,
                0, 1, 0, 0, 0,
                0, 1, 0, 0, 0,
                0, 1, 0, 0, 0,
                0, 1, 0, 0, 0
            }));
            dataset.Add(new DataSet(1, new double[]{
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0
            }));
            dataset.Add(new DataSet(1, new double[]{
                0, 0, 0, 1, 0,
                0, 0, 0, 1, 0,
                0, 0, 0, 1, 0,
                0, 0, 0, 1, 0,
                0, 0, 0, 1, 0
            }));
            dataset.Add(new DataSet(1, new double[]{
                0, 0, 0, 0, 1,
                0, 0, 0, 0, 1,
                0, 0, 0, 0, 1,
                0, 0, 0, 0, 1,
                0, 0, 0, 0, 1
            }));

            dataset.Add(new DataSet(1, new double[]{
                0, 1, 0, 0, 0,
                1, 1, 0, 0, 0,
                0, 1, 0, 0, 0,
                0, 1, 0, 0, 0,
                0, 1, 0, 0, 0
            }));
            dataset.Add(new DataSet(1, new double[]{
                0, 0, 1, 0, 0,
                0, 1, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0
            }));
            dataset.Add(new DataSet(1, new double[]{
                0, 0, 0, 1, 0,
                0, 0, 1, 1, 0,
                0, 0, 0, 1, 0,
                0, 0, 0, 1, 0,
                0, 0, 0, 1, 0
            }));
            dataset.Add(new DataSet(1, new double[]{
                0, 0, 0, 0, 1,
                0, 0, 0, 1, 1,
                0, 0, 0, 0, 1,
                0, 0, 0, 0, 1,
                0, 0, 0, 0, 1
            }));

            dataset.Add(new DataSet(1, new double[]{
                0, 1, 0, 0, 0,
                1, 1, 0, 0, 0,
                0, 1, 0, 0, 0,
                0, 1, 0, 0, 0,
                1, 1, 1, 0, 0
            }));
            dataset.Add(new DataSet(1, new double[]{
                0, 0, 1, 0, 0,
                0, 1, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 1, 1, 1, 0
            }));
            dataset.Add(new DataSet(1, new double[]{
                0, 0, 0, 1, 0,
                0, 0, 1, 1, 0,
                0, 0, 0, 1, 0,
                0, 0, 0, 1, 0,
                0, 0, 1, 1, 1
            }));
        }

        private void FillZeros(List<DataSet> dataset)
        {
            dataset.Add(new DataSet(-1, new double[]{
                0, 1, 0, 0, 0,
                1, 0, 1, 0, 0,
                1, 0, 1, 0, 0,
                1, 0, 1, 0, 0,
                0, 1, 0, 0, 0
            }));
            dataset.Add(new DataSet(-1, new double[]{
                0, 0, 1, 0, 0,
                0, 1, 0, 1, 0,
                0, 1, 0, 1, 0,
                0, 1, 0, 1, 0,
                0, 0, 1, 0, 0
            }));
            dataset.Add(new DataSet(-1, new double[]{
                0, 0, 0, 1, 0,
                0, 0, 1, 0, 1,
                0, 0, 1, 0, 1,
                0, 0, 1, 0, 1,
                0, 0, 0, 1, 0
            }));

            dataset.Add(new DataSet(-1, new double[]{
                0, 1, 1, 0, 0,
                1, 0, 0, 1, 0,
                1, 0, 0, 1, 0,
                1, 0, 0, 1, 0,
                0, 1, 1, 0, 0
            }));
            dataset.Add(new DataSet(-1, new double[]{
                0, 0, 1, 1, 0,
                0, 1, 0, 0, 1,
                0, 1, 0, 0, 1,
                0, 1, 0, 0, 1,
                0, 0, 1, 1, 0
            }));

            dataset.Add(new DataSet(-1, new double[]{
                0, 1, 1, 1, 0,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                0, 1, 1, 1, 0
            }));

            dataset.Add(new DataSet(-1, new double[]{
                1, 1, 1, 0, 0,
                1, 0, 1, 0, 0,
                1, 0, 1, 0, 0,
                1, 0, 1, 0, 0,
                1, 1, 1, 0, 0
            }));
            dataset.Add(new DataSet(-1, new double[]{
                0, 1, 1, 1, 0,
                0, 1, 0, 1, 0,
                0, 1, 0, 1, 0,
                0, 1, 0, 1, 0,
                0, 1, 1, 1, 0
            }));
            dataset.Add(new DataSet(-1, new double[]{
                0, 0, 1, 1, 1,
                0, 0, 1, 0, 1,
                0, 0, 1, 0, 1,
                0, 0, 1, 0, 1,
                0, 0, 1, 1, 1
            }));

            dataset.Add(new DataSet(-1, new double[]{
                1, 1, 1, 1, 0,
                1, 0, 0, 1, 0,
                1, 0, 0, 1, 0,
                1, 0, 0, 1, 0,
                1, 1, 1, 1, 0
            }));
            dataset.Add(new DataSet(-1, new double[]{
                0, 1, 1, 1, 1,
                0, 1, 0, 0, 1,
                0, 1, 0, 0, 1,
                0, 1, 0, 0, 1,
                0, 1, 1, 1, 1
            }));

            dataset.Add(new DataSet(-1, new double[]{
                1, 1, 1, 1, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 1, 1, 1, 1
            }));
        }
    }
}
