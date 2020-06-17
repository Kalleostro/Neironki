using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SVMForm
{
    public partial class SVMGraphic : Form
    {
        public GraphicsData SVMData { get; set; }

        public SVMGraphic()
        {
            InitializeComponent();
            SVMData = new GraphicsData();
        }

        public void DrawFucntion()
        {
            var data = SVMData.Data.Last();

            Graphic.Series["ErrorLine"].Points.AddXY(data.Key, data.Value);
        }
    }

    public class GraphicsData
    {
        public Dictionary<int, double> Data { get; private set; }

        public GraphicsData()
        {
            Data = new Dictionary<int, double>();
        }

        public void Add(int epoch, double changes)
        {
            Data.Add(epoch, changes);
        }
    }
}
