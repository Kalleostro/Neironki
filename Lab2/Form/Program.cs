using NeuroLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NeuroL2App
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form());
            }
            else
            {
                string datasetPath = args[0];
                string outputPath = args[1];

                List<Data> dataSets = new List<Data>();
                List<string> paths = FillDataset(dataSets, datasetPath);

                Topology topology = new Topology(25, 1, 0.1, 15);

                Network backPropNetwork = new Network(topology);
                backPropNetwork.learningStrategy = new BP(backPropNetwork);
                backPropNetwork.CreateLayers<ActFuncSigm>();

                Network HebbNetwork = new Network(topology);
                HebbNetwork.learningStrategy = new HebbRule(HebbNetwork);
                HebbNetwork.CreateLayers<ActFuncSigm>();

                backPropNetwork.Learn(dataSets, 1000);
                HebbNetwork.Learn(dataSets, 1000);

                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    for (int i = 0; i < dataSets.Count; i++)
                    {
                        double backPropRes = backPropNetwork.FeedForwardSignals(dataSets[i].InputsSignals).Output;
                        double HebbRes = HebbNetwork.FeedForwardSignals(dataSets[i].InputsSignals).Output - 0.1;

                        WriteResult(writer, paths[i], backPropRes, HebbRes);
                        WriteResult(Console.Out, paths[i], backPropRes, HebbRes);
                    }
                }
            }
        }

        private static List<string> FillDataset(List<Data> dataSet, string datasetPath)
        {
            List<string> paths = new List<string>();
            using (StreamReader reader = new StreamReader(datasetPath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    double expected = double.Parse(line.Substring(0, 1));
                    string path = line.Substring(2);
                    using (Bitmap bitmap = new Bitmap(path))
                    {
                        dataSet.Add(bitmap.ToDataSet(expected));
                        paths.Add(path);
                    }
                }
            }
            return paths;
        }

        private static void WriteResult(TextWriter writer, string path, double backPropRes, double HebbRes)
        {
            writer.WriteLine(path + ':');
            writer.WriteLine("BackProp: " + backPropRes);
            writer.WriteLine("Hebb: " + HebbRes);
        }
    }
}
