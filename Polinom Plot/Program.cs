using Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polinom_plot
{
    public class Program : SmartizSketch
    {

        public double A;
        public double B;
        public double C;
        public double Y;

        public List<double> X_coordinates = new List<double>();
        public List<double> Y_coordinates = new List<double>();

        [STAThread]
        static void Main()
        {
            new Program().Start();
        }

        public override void Setup()
        {
            Size(600, 600);
            Background(0);
        }

        public override void DrawFrame()
        {
            int Spacing = 30;

            Stroke(100);
            StrokeWeight(1);

            for (int i = 0; i <= Width; i += Spacing)
            {
                Line(i + Spacing, 0, i + Spacing, Height);
            }

            for (int j = 0; j <= Height; j += Spacing)
            {
                Line(0, j + Spacing, Width, j + Spacing);
            }

            Stroke(255);
            StrokeWeight(1);
            Line(Width / 2, 0, Width / 2, Height);
            Line(0, Height / 2, Width, Height / 2);

            DrawParabola();
        }

        public void DrawParabola()
        {
            A = 1;
            B = 0;
            C = 0;

            double PX;
            double PY;

            for (int X = -Width / 2; X < Width / 2; X++)
            {
                Y = A * X * X + B * X + C;
                PX = Width / 2 + X;
                PY = Height / 2 - Y;
                Stroke(0, 255, 0);
                Point(int.Parse(PX.ToString()), int.Parse(PY.ToString()));


                // Y_coordinates.Add(A * X * X + B * X + C);
                //  Point(X, int.Parse(Y.ToString()));
            }
        }
    }
}