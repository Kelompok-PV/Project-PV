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
using System.Diagnostics;
using System.Media;

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
        Random rand = new Random();
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g = e.Graphics;
            Config.rect = this.ClientRectangle;
            manager.draw(g);

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Hide();
            sfx_player.Hide();
            Config.font.AddFontFile("Resources\\DwarvenAxe BB W00 Regular.ttf");
            manager = new GameStateManager();
        }
        //private int FPS = 60;
        private long targetTime = 1000 / 60;
        private void timer1_Tick(object sender, EventArgs e)
        {
            long start;
            long elapsed;
            long wait;

            start = nanoTime();
            manager.update();
            Invalidate();
            elapsed = nanoTime() - start;

            //targettime = 1000/ FPS = 1000 / 60 = ... (miliseconds / frame)
            //calculate wait for accuracy
            wait = targetTime - elapsed / 1000000;
            //anticipate lag
            if (wait < 0) wait = 5;

            try
            {
                timer1.Interval = (int)wait;
            }
            catch (Exception)
            {

                throw;
            }
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
        
        private long nanoTime()
        {
            long nano = 10000L * Stopwatch.GetTimestamp();
            nano /= TimeSpan.TicksPerMillisecond;
            nano *= 100L;
            return nano;
        }
    }
}
