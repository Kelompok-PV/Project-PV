﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PV
{
    class BattleState : GameState
    {
        public GameStateManager gsm { get; set; }
        public List<int> gambar { get; set; }
        public int x { get; set; }

        public karakter player { get; set; }
        public string url { get; set; }

        public BattleState(GameStateManager gsm)
        {
            //player = gsm.getPlayer();
            Random r = new Random();
            this.gsm = gsm;
            gambar = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                gambar.Add(r.Next(6) + 1);
            }
            imgBg1 = (Image)background1;
            imgBg2 = (Image)background2;
            imgBg3 = (Image)background3;
            imgLast = (Image)last;
            imgDoor = (Image)door;
            x = 0;
            imgpPlayer = (Image)Properties.Resources.ResourceManager.GetObject("panel_player2");
            imgpInv = (Image)Properties.Resources.ResourceManager.GetObject("panel_inventory");
        }

        public override void init()
        {
            throw new NotImplementedException();
        }
        object background1 = Properties.Resources.ResourceManager.GetObject("courtyard_backgroundcoba___1_");
        object background2 = Properties.Resources.ResourceManager.GetObject("courtyard_backgroundcoba___2_");
        object background3 = Properties.Resources.ResourceManager.GetObject("courtyard_backgroundcoba___3_");
        object last = Properties.Resources.ResourceManager.GetObject("courtyard_lastcoba");
        object door = Properties.Resources.ResourceManager.GetObject("courtyard_doorcoba");
        Image imgLast;
        Image imgDoor;
        Image imgBg1;
        Image imgBg2;
        Image imgBg3;
        object O = Properties.Resources.ResourceManager.GetObject("lala");
        Image img;


        Image imgpPlayer;
        Image imgpInv;

        public override void draw(Graphics g)
        {
            g.ScaleTransform(zoom, zoom);
            g.TranslateTransform(-ox, -oy);

            //last left
            if (x>-450)
            {
                g.DrawImage(imgBg2, x, 20, 450, 400);
                g.DrawImage(imgLast, x + 220, 20, -220, 400);
                g.DrawImage(imgBg1, x, 0, 450, 100);
                g.DrawImage(imgBg3, x, 330, 450, 100);
            }


            //door right
            if (x > -600)
            {
                g.DrawImage(imgBg2, x + 140, 20, 450, 400);
                g.DrawImage(imgDoor, x + 140, 20, 450, 400);
                g.DrawImage(imgBg1, x + 140, 0, 450, 100);
                g.DrawImage(imgBg3, x + 140, 330, 450, 100);
            }
            
            for (int i = 0; i < gambar.Count; i++)
            {
                int tmpx = x + 585 + i * 449;
                if (x>-1000-(i*449))
                {
                    object background_random = Properties.Resources.ResourceManager.GetObject("courtyard_randomcoba___" + gambar[i] + "_");
                    Image img = (Image)background_random;
                    g.DrawImage(imgBg2, x + 585 + i * 449, 20, 450, 400);
                    g.DrawImage(img, x + 585 + i * 449, 0, 450, 400);
                    g.DrawImage(imgBg1, x + 585 + i * 449, 0, 450, 100);
                    g.DrawImage(imgBg3, x + 585 + i * 449, 330, 450, 100);
                }
                
            }

            //last right
            g.DrawImage(imgBg2, x + 950 + 5 * 450, 20, 450, 400);
            g.DrawImage(imgLast, x + 950 + 5 * 450, 20, 450, 400);
            g.DrawImage(imgBg1, x + 950 + 5 * 450, 0, 450, 100);
            g.DrawImage(imgBg3, x + 950 + 5 * 450, 330, 450, 100);

            //door right
            g.DrawImage(imgBg2,  x + 580 + 5 * 450, 20, 450, 400);
            g.DrawImage(imgDoor, x + 580 + 5 * 450, 20, 450, 400);
            g.DrawImage(imgBg1,  x + 580 + 5 * 450, 0, 450, 100);
            g.DrawImage(imgBg3,  x + 580 + 5 * 450, 330, 450, 100);

            player.getImage(g);
            player.hero_move_now++;

            if (zoomin==true)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(opacity, 0, 0, 0)), 0, 0, 1300, 700);
            }

            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("side_decor"), 0, 420, 120, 270);
            g.DrawImage(imgpPlayer,  70+22,420,528,100);
            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("panel_stat"),     70+50,520,500,170);
            g.DrawImage(imgpInv,70+550,420,550,270);
            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("side_decor"), 1285, 420, -120, 270);
        }
        int opacity = 0;
        public override void mouse_click(object sender, MouseEventArgs e)
        {
            Rectangle mouse = new Rectangle(e.X, e.Y, 1, 1);
            if (mouse.IntersectsWith(new Rectangle(x + 250, 150, 200, 250)) )
            {
                c = new Point(500 / 2, 300 / 2);
                zoomin = true;
            }
            if (mouse.IntersectsWith(new Rectangle(x + 700 + 5 * 450, 20, 450, 450)))
            {
                c= new Point(1000 / 2, 300 / 2);
                zoomin = true;
            }
            if (mouse.IntersectsWith(new Rectangle(1130, 550, 50, 50)))
            {
                imgpInv = (Image)Properties.Resources.ResourceManager.GetObject("panel_map");
            }
            if (mouse.IntersectsWith(new Rectangle(1130, 610, 50, 50)))
            {
                imgpInv = (Image)Properties.Resources.ResourceManager.GetObject("panel_inventory");
            }
        }
        public override void key_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.D&&x>-2000)
            {
                x -= 10;
                player.hero_move = "run";
            }
            else if(e.KeyData == Keys.D&&player.x<1050)
            {
                player.x += 10;
                player.hero_move = "run";
            }
            if (e.KeyData == Keys.A && player.x > 300)
            {
                player.x -= 10;
                player.hero_move = "run";
            }
            else if (e.KeyData == Keys.A&&x<0)
            {
                x += 10;
                player.hero_move = "run";
            }
        }
        float zoom = 1;
        Point c;
        float ox = 0;
        float oy = 0;
        bool zoomin = false;
        public override void update()
        {
            if (zoom < 2 && zoomin == true)
            {
                opacity += 25;
                ox = c.X * (zoom - 1f);
                oy = c.Y * (zoom - 1f);
                zoom = (float)(zoom + 0.1);
            }

            if (zoom >= 2)
            {
                gsm.stage = Stage.battleAreaState;
                gsm.loadState(gsm.stage);
            }
        }

        public override void key_KeyUp(object sender, KeyEventArgs e)
        {
            player.hero_move_now = 1;
            player.hero_move = "idle";
        }

        public override void mouse_hover(object sender, MouseEventArgs e)
        {
            
        }

        public override void mouse_leave(object sender, MouseEventArgs e)
        {
            
        }

        
    }
}
