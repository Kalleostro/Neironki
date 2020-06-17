using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NeuroL2App;
using SVMLib;
using Data = NeuroLib.Data;

namespace SVMForm
{
    public partial class SVMApp : System.Windows.Forms.Form
    {
        private bool isTrained = false;

        private List<Data> dataSets;
        private VectorMachine machine;
        private SVMGraphic graphicsForm;

        public SVMApp()
        {
            InitializeComponent();
            dataSets = new List<Data>();
        }

        private void LoadDataSetButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                dataSets.Clear();
                string file = openFile.FileName;
                UseBtn.Visible = true;
                LoadDataSetButton.Visible = false;
                using (StreamReader reader = new StreamReader(file))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        double expected = double.Parse(line.Substring(0, 1));
                        string path = line.Substring(2);
                        using (Bitmap bitmap = new Bitmap(path))
                        {
                            dataSets.Add(bitmap.ToDataSet(expected == 0 ? -1 : 1));
                        }
                    }
                }

                machine = new VectorMachine(new Polynomial(2), 25);
                var learn = new SequentialOptimization(machine, dataSets.ToArray());
                double[] changes = learn.Run();

                graphicsForm = new SVMGraphic();
                graphicsForm.Show();
                for (int i = 0; i < changes.Length; i++)
                {
                    graphicsForm.SVMData.Add(i, changes[i]);
                    graphicsForm.DrawFucntion();
                }


                isTrained = true;
            }
        }

        private void UseBtn_Click(object sender, EventArgs e)
        {
            if (!isTrained)
            {
                MessageBox.Show("Машина не обучена.");
                return;
            }

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                using (Bitmap bitmap = new Bitmap(openFile.FileName))
                {
                    Data dataset = bitmap.ToDataSet(0);

                    double output = machine.Compute(dataset.InputsSignals);
                    int res = output > 0 ? 1 : 0;
                    MessageBox.Show("Вероятно, это " + res.ToString());
                }
            }
        }
    }
}
