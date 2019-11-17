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
        public Form1()
        {
            InitializeComponent();
        }
        karakter player = new ninja("ninnin", 50, new equip[5], new List<string>(), 5, 5);
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            player.getImage(g);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            player.hero_move_now++;
            Invalidate();
        }
    }
}
