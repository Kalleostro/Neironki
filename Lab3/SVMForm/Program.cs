using NeuroL2App;
using NeuroLib;
using SVMLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SVMForm
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SVMApp());
            }
            else
            {
                string datasetPath = args[0];
                string testPath = args[1];
                string outputPath = args[2];

                List<Data> dataSets = new List<Data>();
                FillDataset(dataSets, datasetPath);

                var machine = new VectorMachine(new Polynomial(2), 25);
                var learn = new SequentialOptimization(machine, dataSets.ToArray());
                _ = learn.Run();

                dataSets.Clear();
                List<string> paths = FillDataset(dataSets, testPath);

                double[] output = machine.Compute(dataSets.ToArray());

                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    for (int i = 0; i < output.Length; i++)
                    {
                        writer.WriteLine(paths[i] + ':' + output[i]);
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
                        dataSet.Add(bitmap.ToDataSet(expected == 0 ? -1 : 1));
                        paths.Add(path);
                    }
                }
            }
            return paths;
        }
    }
}
