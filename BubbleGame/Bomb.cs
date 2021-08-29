using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BubbleGame
{
    public class Bomb : Shape
    {
        private double speed;
        private readonly double speedVariation;
        private readonly int offsetOfX;
        private readonly int offsetOfY;
        private readonly int formWidth;
        private readonly int formHeight;

        public Bomb(int formWidth, int formHeight)
        {
            this.formWidth = formWidth;
            this.formHeight = formHeight;

            Width = 50;
            speed = 1;
            speedVariation = (double)random.Next(3, 6) / 100;

            offsetOfX = random.Next(500, 2000);
            offsetOfY = random.Next(0, 200);
            Y += offsetOfY;
        }

        public override void DrawShape(Graphics graphics)
        {
            graphics.FillEllipse(Brushes.Black, this.X, this.Y, this.Width, this.Width);
        }

        public override void DrawDeletedShape(Graphics graphics)
        {
            graphics.FillEllipse(Brushes.Red, this.X - Width / 2, this.Y - Width / 2, this.Width * 2, this.Width * 2);
            graphics.FillEllipse(Brushes.Yellow, this.X, this.Y, this.Width, this.Width);
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


                if (this.Y < formHeight && this.X < formWidth)
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
            X = (int)(Math.Sqrt((double)y / offsetOfX) * offsetOfX);
        }

        public override void UpdateY(int iterator)
        {
            speed = (speed + 0.5) * (1 + speedVariation);
            Y += (int)speed;
        }
    }
}
