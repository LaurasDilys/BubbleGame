using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BubbleGame
{
    public class Bubble : Shape
    {
        private Random random = new Random();

        public Bubble(int formWidth, int formHeight) : base(formWidth, formHeight)
        {
        }
    }
}
