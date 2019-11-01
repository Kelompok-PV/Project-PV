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
        Inventory insi=new LargeFood();
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            insi.getImage(g);
        }
    }
}
