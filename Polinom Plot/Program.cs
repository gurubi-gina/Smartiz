using Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polinom_Plot
{
    public class Program : SmartizSketch
    {
        [STAThread]
        static void Main()
        {
            new Program().Start();
        }

        public double A = 1;
        public double B = 0;
        public double C = 0;
        public double Y;

        int TposX = 20;
        int TposY = 60;
        int RposX;
        const int ButtonWidth = 20;
        const int ButtonHeight = 10;
        Button Button1;
        Button Button2;
        Button Button3;
        Button Button4;
        Button Button5;
        Button Button6;

        public override void Setup()
        {
            Size(800, 600);
            Background(0);
            RposX = TposX + 60;
            Button1 = new Button(RposX, TposY - 15, ButtonWidth, ButtonHeight);
            Button2 = new Button(RposX, TposY - 15 + ButtonHeight, ButtonWidth, ButtonHeight);
            //TODO: Create Button3,4,5,6
        }

        public override void DrawFrame()
        {
            Background(0);
            DrawCoordinateSystem();
            DrawDashboard();
            DrawParabola();
        }

        public void DrawDashboard()
        {
            //TODO: Write the code!
        }

        public void DrawButton(Button b)
        {
            NoFill();
            Stroke(255);
            Rect(b.Bounds.Left, b.Bounds.Top, b.Bounds.Width, b.Bounds.Height);
            Fill(255);
        }

        public bool IsOn(Button b)
        {
            return PMouseX >= b.Bounds.Left && PMouseX <= b.Bounds.Left + b.Bounds.Width && PMouseY >= b.Bounds.Top && PMouseY <= b.Bounds.Top + b.Bounds.Height;
        }

        public override void MouseClicked()
        {
            if (IsOn(Button1))
            {
                A = Math.Round(A + 0.1, 1);
            }
            else if (IsOn(Button2))
            {
                A = Math.Round(A - 0.1, 1);
            }
            //TODO: Write the other else ifs.
        }

        public void DrawCoordinateSystem()
        {
            int Step = 20;
            int TickWidth = 2;
            Stroke(255);
            StrokeWeight(1);
            Line(Width / 2, 0, Width / 2, Height);
            Line(0, Height / 2, Width, Height / 2);

            for (double i = 0; i < Width; i += Step)
            {
                Stroke(113, 114, 120, 10);
                Line(0, i, Width, i);
                Line(i, 0, i, Height);
                Stroke(255);
                Line(Width / 2 - TickWidth, i, Width / 2 + TickWidth, i);
                Line(i, Height / 2 - TickWidth, i, Height / 2 + TickWidth);
            }
        }

        public void DrawParabola()
        {
            double pointX;
            double pointY;
            double previousX = -10;
            double previousY = -10;

            for (double X = -Width / 2; X < Width / 2; X++)
            {
                Y = A * X * X + B * X + C;
                pointX = Width / 2 + X;
                pointY = Height / 2 - Y;

                Stroke(0, 255, 0);
                StrokeWeight(1);
                Point(pointX, pointY);
                Line(pointX, pointY, previousX, previousY);

                previousX = pointX;
                previousY = pointY;
            }
        }
    }
}