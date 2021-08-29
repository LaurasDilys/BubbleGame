using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace BubbleGame
{
    /// <summary>
    /// 
    /// </summary>
    public class Game
    {
        private Random random = new Random();
        private int score;
        private int iterator;
        private List<Shape> shapes = new List<Shape>();

        /// <summary>
        /// This method draws .....
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="graphics"></param>
        public void Draw(int width, int height, Graphics graphics)
        {
            iterator++;

            List<Shape> refreshedShapes = new List<Shape>();

            Refresh(graphics, refreshedShapes);
            Generate(refreshedShapes, width, height);
            Score(graphics);

            shapes = refreshedShapes;
        }

        public void Click(int x, int y)
        {
            foreach (var s in shapes)
            {
                if (s.IsClicked(x, y))
                {
                    if (s is Bomb)
                    {
                        BombDetonated((Bomb)s);
                        return;
                    }

                    s.IsDeleted = true;
                    score++;
                }
            }
        }

        private void BombDetonated(Bomb bomb)
        {
            //When the bomb is detonated,
            //the player gains points for every shape,
            //not including the Bomb
            score += shapes.Count - 1;

            foreach (var s in shapes)
            {
                s.IsDeleted = true;
            }
        }

        private void Score(Graphics graphics)
        {
            graphics.DrawString($"Score {score}", new Font(FontFamily.GenericMonospace, 10), Brushes.Blue, 10, 10);
        }

        private void Generate(List<Shape> refreshedShapes, int width, int height)
        {
            //if (refreshedShapes.Count < 12)
            //{
            //    while (random.Next(20) < 3)
            //    {
            //        refreshedShapes.Add(new Bubble(width, height));
            //    }

            //    while (random.Next(20) < 1)
            //    {
            //        refreshedShapes.Add(new Baloon(width, height));
            //    }
            //}
            //else
            //{
            //    if (random.Next(10) < 1 &&
            //        !refreshedShapes.Any(s => s is Bomb))
            //    {
            //        refreshedShapes.Add(new Bomb(width, height));
            //    }
            //}

            if (!refreshedShapes.Any(s => s is Bomb))
            {
                refreshedShapes.Add(new Bomb(width, height));
            }
        }

        private void Refresh(Graphics graphics, List<Shape> refreshedShapes)
        {
            foreach (var s in shapes)
            {
                var bubble = s.Draw(graphics, iterator);
                if (bubble != null)
                {
                    refreshedShapes.Add(bubble);
                }
            }
        }
    }
}
