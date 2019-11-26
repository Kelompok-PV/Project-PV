﻿using System;
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
        int x, y;
        Graphics g2;
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            Config.g = this.CreateGraphics();
            
        }
        Random rand = new Random();
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g2 = e.Graphics;
            Config.rect = this.ClientRectangle;
            manager.draw(g2);

            int temp = rand.Next(2);
            if(temp == 0)
            {
                g.FillRectangle(new SolidBrush(Color.Red), test);
                g.FillRectangle(new SolidBrush(Color.Blue), 300, 300, 400, 400);
            }
            else
            {
                g.FillRectangle(new SolidBrush(Color.Black), test);
                g.FillRectangle(new SolidBrush(Color.Green), 300, 300, 400, 400);
            }
            
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
        Rectangle test = new Rectangle(500, 500, 500, 500);
        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor.Current = new Cursor(Project_PV.Properties.Resources.arrow.GetHicon());
            manager.update();
            
            Invalidate(test);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("x: "+e.X+" y: "+e.Y);
            Cursor.Current = new Cursor(Project_PV.Properties.Resources.arrow.GetHicon());
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
            Cursor.Current = new Cursor(Project_PV.Properties.Resources.arrow.GetHicon());
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = new Cursor(Project_PV.Properties.Resources.arrow.GetHicon());
            manager.mouse_hover(sender,e);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Current = new Cursor(Project_PV.Properties.Resources.arrow.GetHicon());
        }
        private void drawCircle(int x, int y)
        {

            Config.g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("side_decor"), 0, 420, 120, 270);
            Config.g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("panel_player2"), 70 + 22, 420, 528, 100);
            Config.g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("panel_stat"), 70 + 50, 520, 500, 170);
            Config.g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("panel_inventory"), 70 + 550, 420, 550, 270);
            Config.g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("side_decor"), 1285, 420, -120, 270);
        }
    }
}
