using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NeuroLib;

namespace NeuroL2App
{
    public partial class Form : System.Windows.Forms.Form
    {
        private bool isDataSetLoaded = false;
        private bool isTopologyCreate = false;

        private Topology topology;
        private Network backPropNetwork;
        private Network HebbNetwork;
        private Graph graphicsForm;
        private List<Data> dataSets;

        public Form()
        {
            InitializeComponent();
            dataSets = new List<Data>();
        }

        private void CreateTopologyButton_Click(object sender, EventArgs e)
        {
            if (isTopologyCreate) return;

            int input, output;
            double learningSpeed;
            string[] hiddensText;
            int[] hidden;

            if (!double.TryParse(LearningRateTextBox.Text, out learningSpeed))
            {
                MessageBox.Show("Ошибка вводимых значений.");
                return;
            }

            hiddensText = HidenLayersTextBox.Text.Split(new char[] { ',' });
            hidden = new int[hiddensText.Length];
            for (int i = 0; i < hiddensText.Length; i++)
            {
                if (!int.TryParse(hiddensText[i], out hidden[i]))
                {
                    MessageBox.Show("Ошибка вводимых значений."); das 
                    return;
                }
            }
            input = 25;
            output = 1;
            topology = new Topology(input, output, learningSpeed, hidden);
            backPropNetwork = new Network(topology);
            backPropNetwork.CreateLayers<ActFuncSigm>();
            backPropNetwork.learningStrategy = new BP(backPropNetwork);

            HebbNetwork = new Network(topology);
            HebbNetwork.CreateLayers<ActFuncSigm>();
            HebbNetwork.learningStrategy = new HebbRule(HebbNetwork);

            isTopologyCreate = true;
        }

        private void LearnOneEpoch_Click(object sender, EventArgs e)
        {
            LearnNeuronNetwork(1);
        }

        private void LearnNEpoch_Click(object sender, EventArgs e)
        {
            if (graphicsForm == null)
            {
                graphicsForm = new Graph();
                graphicsForm.Show();
            }

            int stage;

            if(!int.TryParse(CountOfEpochTextBox.Text,out stage))
            {
                MessageBox.Show("Ошибка. Неверные значения полей.");
                return;
            }

            LearnNeuronNetwork(stage);
        }

        private void LearnNeuronNetwork(int stage)
        {
            if(!isDataSetLoaded)
            {
                MessageBox.Show("Сперва загрузите выборку.");
                return;
            }

            if (!isTopologyCreate)
            {
                MessageBox.Show("Ошибка. Создайте сеть.");
                return;
            }

            double difference = backPropNetwork.Learn(dataSets, stage);
            graphicsForm.backPropData.Add(backPropNetwork.CountOfEpoch, difference);

            difference = HebbNetwork.Learn(dataSets, stage);
            graphicsForm.widrowHoffData.Add(HebbNetwork.CountOfEpoch, difference);

            graphicsForm.DrawFucntion();
        }

        private void LoadDataSetButton_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFile = new OpenFileDialog();

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string file = openFile.FileName;
                using (StreamReader reader = new StreamReader(file))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        double expected = double.Parse(line.Substring(0, 1));
                        string path = line.Substring(2);
                        using (Bitmap bitmap = new Bitmap(path))
                        {
                            dataSets.Add(bitmap.ToDataSet(expected));
                        }
                    }
                }

                isDataSetLoaded = true;
            }
        }   

        //private void ResetButton_Click(object sender, EventArgs e)
        //{
        //    isTopologyCreate = false;
        //    isDataSetLoaded = false;
        //    dataSets = new List<Data>();
        //    if (graphicsForm != null)
        //        graphicsForm.Close();
        //}

        private void UseNeuronSystemButton_Click(object sender, EventArgs e)
        {
            if (!isTopologyCreate)
            {
                MessageBox.Show("Нейронные сети не созданы.");
                return;
            }

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                using (Bitmap bitmap = new Bitmap(openFile.FileName))
                {
                    Data dataset = bitmap.ToDataSet(0);
                    double backPropRes = backPropNetwork.FeedForwardSignals(dataset.InputsSignals).Output;
                    double HebbRes = HebbNetwork.FeedForwardSignals(dataset.InputsSignals).Output - 0.1;

                    MessageBox.Show("Hebb: " + Math.Round((HebbRes), 4).ToString()
                        + ", скорее всего, " + Math.Round(HebbRes).ToString()
                        + Environment.NewLine
                        + "BP: " + Math.Round((backPropRes), 4).ToString()
                        + ", скорее всего, " + Math.Round(backPropRes).ToString());
                }
            }
        }
    }
}
