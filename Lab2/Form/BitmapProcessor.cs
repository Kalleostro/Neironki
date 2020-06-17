using NeuroLib;
using System.Drawing;

namespace NeuroL2App
{
    public static class BitmapProcessor
    {
        public static Data ToDataSet(this Bitmap bitmap, double expected)
        {
            double[] inputs = new double[25];
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    Color color = bitmap.GetPixel(j, i);

                    if (color.R == 0 && color.G == 0 && color.B == 0)
                        inputs[i * bitmap.Height + j] = 1;
                    else
                        inputs[i * bitmap.Height + j] = 0;
                }
            }

            return new Data(expected, inputs);
        }
    }
}
