using System;
using System.Windows.Forms;

namespace BubbleGame
{
    public partial class Form1 : Form
    {
        private Timer timer = new Timer();

        private readonly Game game = new Game();     

        public Form1()
        {         
            InitializeComponent();

            this.DoubleBuffered = true;

            timer.Interval = 50;
            timer.Tick += Tick;
            timer.Start();
        }

        private void Tick(Object sender, EventArgs e)
        {
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            this.game.Draw(this.Width, this.Height, e.Graphics);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            this.game.Click(e.X, e.Y);
        }
    }
}
