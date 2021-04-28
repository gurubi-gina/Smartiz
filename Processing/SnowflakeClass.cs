using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processing
{
    public class SnowflakeClass : DrawableObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Size { get; }
        public double Velocity { get; set; }
        public int Opacity { get; set; }

        public SnowflakeClass(double X, double Y, double Size, double Velocity, int Opacity)
        {
            this.X = X;
            this.Y = Y;
            this.Size = Size;
            this.Velocity = Velocity;
            this.Opacity = Opacity;
        }

        public override void Draw()
        {
            SmartizSketch.StrokeWeight(1);
            SmartizSketch.Stroke(255, 255, 255, Math.Max(0, Opacity));
            SmartizSketch.NoFill();
            SmartizSketch.Line(X, Y, X, Y - 2 * Size);
            SmartizSketch.Line(X, Y, X + 2 * Size, Y - 1.5 * Size);
            SmartizSketch.Line(X, Y, X + 2 * Size, Y + 1.5 * Size);
            SmartizSketch.Line(X, Y, X, Y + 2 * Size);
            SmartizSketch.Line(X, Y, X - 2 * Size, Y - 1.5 * Size);
            SmartizSketch.Line(X, Y, X - 2 * Size, Y + 1.5 * Size);

            SmartizSketch.Circle(X, Y - 2.5 * Size, Size);
            SmartizSketch.Circle(X + 2 * Size, Y - 1.5 * Size, Size);
            SmartizSketch.Circle(X + 2 * Size, Y + 1.5 * Size, Size);
            SmartizSketch.Circle(X, Y + 2.5 * Size, Size);
            SmartizSketch.Circle(X - 2 * Size, Y - 1.5 * Size, Size);
            SmartizSketch.Circle(X - 2 * Size, Y + 1.5 * Size, Size);

            SmartizSketch.Circle(X, Y, 2.5 * Size);
            SmartizSketch.Circle(X, Y, 1.5 * Size);

            SmartizSketch.Circle(X, Y - 2.5 * Size, 0.75 * Size);
            SmartizSketch.Circle(X + 2 * Size, Y - 1.5 * Size, 0.75 * Size);
            SmartizSketch.Circle(X + 2 * Size, Y + 1.5 * Size, 0.75 * Size);
            SmartizSketch.Circle(X, Y + 2.5 * Size, 0.75 * Size);
            SmartizSketch.Circle(X - 2 * Size, Y - 1.5 * Size, 0.75 * Size);
            SmartizSketch.Circle(X - 2 * Size, Y + 1.5 * Size, 0.75 * Size);

            SmartizSketch.Circle(X, Y, Size);
        }

        public void Move()
        {
            X = Math.Sin(20 * Y) + X;
            Y += Velocity;
        }

        public void Melt()
        {
            Opacity -= 60;
            Velocity -= 0.5;
        }

        public bool IsMelted()
        {
            return Opacity < 255;
        }

        public void Refresh()
        {
            Y = -100;
            X += SmartizSketch.Random(-30, 30);
            Opacity = 255;
        }
    }
}