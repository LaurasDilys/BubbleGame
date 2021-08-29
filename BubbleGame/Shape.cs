using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BubbleGame
{
    public abstract class Shape
    {
        private protected Random random = new Random();
        
        //
        public Shape() { }
        //

        public Shape(int formWidth, int formHeight)
        {
            Width = random.Next(20, 100);
            StartX = random.Next(formWidth);
            Y = formHeight;
            Speed = random.Next(5, 20);
            FluctuationOffset = random.Next(0, 10);
            FluctuationAmplitude = random.Next(0, 60);
        }

        public bool IsClicked(int x, int y)
        {
            return x > this.X && x < this.X + this.Width &&
                   y > this.Y && y < this.Y + this.Width;
        }

        public virtual Shape Draw(Graphics graphics, int iterator)
        {
            this.UpdateY(iterator);
            this.UpdateX(iterator);

            if (this.IsDeleted)
            {
                this.DrawDeletedShape(graphics);
            }
            else
            {
                if (this.Y + this.Width > 0)
                {
                    this.DrawShape(graphics);
                    return this;
                }
            }

            return null;
        }

        public virtual void DrawDeletedShape(Graphics graphics)
        {
            graphics.FillEllipse(Brushes.Red, this.X, this.Y, this.Width, this.Width);
        }

        public virtual void DrawShape(Graphics graphics)
        {
            graphics.DrawEllipse(Pens.Black, this.X, this.Y, this.Width, this.Width);
        }

        public virtual void UpdateY(int iterator)
        {
            this.Y -= this.Speed;
        }

        public virtual void UpdateX(int iterator)
        {
            this.X = (int)(this.StartX - this.FluctuationAmplitude * Math.Sin((float)iterator / 10 + this.FluctuationOffset));
        }

        public int StartX { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Width { get; set; }

        public int Speed { get; set; }

        public int FluctuationAmplitude { get; set; }

        public int FluctuationOffset { get; set; }

        public bool IsDeleted { get; set; }
    }
}
