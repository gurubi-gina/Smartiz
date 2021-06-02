using Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinom_Plot
{
    public class Rectangle : DrawableObject
    {
        public int Left;
        public int Top;
        public int Width;
        public int Height;

        public Rectangle(int left, int top, int width, int height)
        {
            this.Left = left;
            this.Top = top;
            this.Width = width;
            this.Height = height;
        }

        public override void Draw()
        {
            SmartizSketch.Fill(255);
            SmartizSketch.Rect(Left, Top, Width, Height);
        }
    }
}