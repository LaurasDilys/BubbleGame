using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BubbleGame
{
    // This one comes from the right side :)
    class BombVariation : Bomb
    {
        public BombVariation(int formWidth, int formHeight) : base(formWidth, formHeight)
        {
        }

        public override Shape Draw(Graphics graphics, int iterator)
        {
            if (this.IsDeleted)
            {
                this.DrawDeletedShape(graphics);
            }
            else
            {
                this.UpdateX(iterator);
                this.UpdateY(iterator);


                if (this.Y < formHeight && this.X > 0)
                {
                    this.DrawShape(graphics);
                    return this;
                }
            }

            return null;
        }

        public override void UpdateX(int iterator)
        {
            int y = Y - offsetOfY;
            X = formWidth - (int)(Math.Sqrt((double)y / offsetOfX) * offsetOfX);
        }
    }
}
