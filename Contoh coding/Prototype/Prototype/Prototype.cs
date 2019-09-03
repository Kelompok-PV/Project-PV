using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype
{
    public partial class Prototype : Form
    {
        private GameStateManager gsm;
        public Image image { get; set; }
        public Graphics g { get; set; }
        public int count { get; set; } = 0;

        int fps;
        int deltaTime;

        public Prototype()
        {
            InitializeComponent();
            gsm = new GameStateManager();
            this.DoubleBuffered = true;

            fps = 30;
            deltaTime = 1000 / fps;
            gameLoop.Interval = deltaTime;
        }


        private void Prototype_KeyDown(object sender, KeyEventArgs e)
        {
            gsm.KeyPressed(sender, e);
            
        }

        private void Prototype_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            gsm.Draw(g);
            g.DrawString("Frame "+deltaTime, new Font("arial", 22, FontStyle.Bold), new SolidBrush(Color.Pink), 0, 88);
            
        }

        private void GameLoop_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Prototype_KeyUp(object sender, KeyEventArgs e)
        {
            gsm.KeyReleased(sender, e);
        }

    }
}
