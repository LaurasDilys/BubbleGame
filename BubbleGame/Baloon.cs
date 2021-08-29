using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BubbleGame
{
    public class Baloon: Shape
    {
        public Baloon(int formWidth, int formHeight) : base(formWidth, formHeight)
        { 
        }

        public override void DrawShape(Graphics graphics)
        {
            graphics.FillEllipse(Brushes.Aqua, this.X, this.Y, this.Width, this.Width * 2);
        }

        public override void DrawDeletedShape(Graphics graphics)
        {
            graphics.FillEllipse(Brushes.Red, this.X, this.Y, this.Width, this.Width * 2);
        }
    }
}
