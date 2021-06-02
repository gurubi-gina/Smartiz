using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinom_Plot
{
    public class Button
    {
        public Rectangle Bounds;

        public Button(int left, int top, int width, int height)
        {
            Bounds = new Rectangle(left, top, width, height);
        }
    }
}