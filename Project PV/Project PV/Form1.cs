using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PV
{
    public partial class Form1 : Form
    {
        GameStateManager manager;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            manager.draw(g);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            manager = new GameStateManager();
            timer1.Interval = 100;   
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //player.hero_move_now++;
            manager.update();
            Invalidate();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("x: "+e.X+" y: "+e.Y);
            manager.mouse_click(sender, e);
        }
        
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            manager.key_keydown(sender, e);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }
    }
}
