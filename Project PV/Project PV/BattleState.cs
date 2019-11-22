using System;
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
        karakter player = new ninja("ninnin", 50, new equip[5], new List<string>(), 5, 5);
        public string url { get; set; }

        public BattleState(GameStateManager gsm)
        {
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
        public override void draw(Graphics g)
        {
            g.ScaleTransform(zoom, zoom);
            g.TranslateTransform(-ox, -oy);

            //last left
            g.DrawImage(imgBg2, x, 20, 450, 450);
            g.DrawImage(imgLast, x + 220, 20, -220, 450);
            g.DrawImage(imgBg1, x, 0, 450, 100);
            g.DrawImage(imgBg3, x, 380, 450, 100);

            //door right
            g.DrawImage(imgBg2, x + 140, 20, 450, 450);
            g.DrawImage(imgDoor, x + 140, 20, 450, 450);
            g.DrawImage(imgBg1, x + 140, 0, 450, 100);
            g.DrawImage(imgBg3, x + 140, 380, 450, 100);
            g.FillRectangle(new SolidBrush(Color.Red), x + 250, 150, 200, 250);
            for (int i = 0; i < gambar.Count; i++)
            {
                object background_random = Properties.Resources.ResourceManager.GetObject("courtyard_randomcoba___"+gambar[i]+"_");
                Image img = (Image)background_random;
                g.DrawImage(imgBg2, x + 585 + i * 360, 20, 450, 450);
                g.DrawImage(img, x + 585 + i * 360, 0, 450, 450);
                g.DrawImage(imgBg1, x + 585 + i * 360, 0, 450, 100);
                g.DrawImage(imgBg3, x + 585 + i * 360, 380, 450, 100);
            }
            //last right
            g.DrawImage(imgBg2, x + 800 + 5 * 360, 20, 450, 450);
            g.DrawImage(imgLast, x + 800 + 5 * 360, 20, 450, 450);
            g.DrawImage(imgBg1, x + 800 + 5 * 360, 0, 450, 100);
            g.DrawImage(imgBg3, x + 800 + 5 * 360, 380, 450, 100);

            //door right
            g.DrawImage(imgBg2, x + 585 + 5 * 360, 20, 450, 450);
            g.DrawImage(imgDoor, x + 585 + 5 * 360, 20, 450, 450);
            g.DrawImage(imgBg1, x + 585 + 5 * 360, 0, 450, 100);
            g.DrawImage(imgBg3, x + 585 + 5 * 360, 380, 450, 100);
            g.FillRectangle(new SolidBrush(Color.Red), x + 700 + 5 * 360, 150, 200, 250);

            player.getImage(g);
            player.hero_move_now++;

            g.FillRectangle(new SolidBrush(Color.FromArgb(opacity, 0, 0, 0)), 0, 0, 1300, 700);
        }
        int opacity = 0;
        public override void mouse_click(object sender, MouseEventArgs e)
        {
            Rectangle recDoorL = new Rectangle(x + 250, 150, 200, 250);
            Rectangle recDoorR = new Rectangle(x + 585 + 5 * 360, 20, 450, 450);
            Rectangle mouse = new Rectangle(e.X, e.Y, 1, 1);
            if (mouse.IntersectsWith(recDoorL) )
            {
                c = new Point(500 / 2, 300 / 2);
                zoomin = true;
            }
            if (mouse.IntersectsWith(recDoorR))
            {
                c= new Point(1000 / 2, 300 / 2);
                zoomin = true;
            }
        }
        public override void key_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.D&&x>-1700)
            {
                x -= 10;
                player.hero_move = "run";
            }
            else if(e.KeyData == Keys.D&&player.x<850)
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
    }
}
