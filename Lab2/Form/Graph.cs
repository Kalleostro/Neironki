using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NeuroL2App
{
    public partial class Graph : System.Windows.Forms.Form
    {
        public GraphicsData widrowHoffData { get; set; }
        public GraphicsData backPropData { get; set; }

        public Graph()
        {
            InitializeComponent();
            widrowHoffData = new GraphicsData();
            backPropData = new GraphicsData();
        }

        public void DrawFucntion()
        {
            var data = backPropData.Data.Last();

            Graphic.Series["BP"].Points.AddXY(data.Key, data.Value);

            data = widrowHoffData.Data.Last();

            Graphic.Series["Hebb's Rule"].Points.AddXY(data.Key, data.Value);
        }
    }

    public class GraphicsData
    {
        public Dictionary<int, double> Data { get; private set; }

        public GraphicsData()
        {
            Data = new Dictionary<int, double>();
        }

        public void Add(int epoch, double dif)
        {
            Data.Add(epoch, dif);
        }
    }
}
