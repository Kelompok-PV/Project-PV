using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Project_PV
{
    public partial class Form1 : Form
    {
        GameStateManager manager;
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            Config.form1 = this;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Config.rect = this.ClientRectangle;
            manager.draw(g);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                axWindowsMediaPlayer1.URL = "E:\\GitHub\\Project-PV\\Project PV\\assets\\tst.mp3";
                axWindowsMediaPlayer1.Hide();
                axWindowsMediaPlayer1.Ctlcontrols.play();
                axWindowsMediaPlayer1.settings.setMode("loop", true);
            }
            catch (Exception)
            {

                
            }
            
            Config.font.AddFontFile("Resources\\DwarvenAxe BB W00 Regular.ttf");
            manager = new GameStateManager();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            manager.update();
            Invalidate();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("x: "+e.X+" y: "+e.Y);
            //Cursor.Current = new Cursor(Project_PV.Properties.Resources.arrow.GetHicon());
            manager.mouse_click(sender, e);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            manager.key_keydown(sender, e);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            manager.Form1_KeyUp(sender, e);
        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {
            //Cursor.Current = new Cursor(Project_PV.Properties.Resources.arrow.GetHicon());
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //Cursor.Current = new Cursor(Project_PV.Properties.Resources.arrow.GetHicon());
            manager.mouse_hover(sender,e);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Current = new Cursor(Project_PV.Properties.Resources.arrow.GetHicon());
        }
    }
}
