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
        public BattleState(GameStateManager gsm)
        {
            Random r = new Random();
            this.gsm = gsm;
            gambar = new List<int>();
            gambar.Add(r.Next(24) + 1);
            gambar.Add(r.Next(24) + 1);
            gambar.Add(r.Next(24) + 1);
            gambar.Add(r.Next(24) + 1);
            gambar.Add(r.Next(24) + 1);
            imgBg1 = (Image)background1;
            imgBg2 = (Image)background2;
            imgBg3 = (Image)background3;
            imgLast = (Image)last;
            imgDoor= (Image)door;
            x = 0;
        }

        public override void init()
        {
            throw new NotImplementedException();
        }
        object background1 = Properties.Resources.ResourceManager.GetObject("courtyard_background___1_");
        object background2 = Properties.Resources.ResourceManager.GetObject("courtyard_background___2_");
        object background3 = Properties.Resources.ResourceManager.GetObject("courtyard_background___3_");
        object last = Properties.Resources.ResourceManager.GetObject("courtyard_last"); 
        object door = Properties.Resources.ResourceManager.GetObject("courtyard_door"); 
        Image imgLast;
        Image imgDoor;
        Image imgBg1;
        Image imgBg2;
        Image imgBg3;
        public override void draw(Graphics g)
        {
            
            g.DrawImage(imgBg2, x, 20, 360, 400);
            g.DrawImage(imgLast, x+220, 20, -220,400);
            g.DrawImage(imgBg1, x, 0, 360, 100);
            g.DrawImage(imgBg3, x, 320, 360, 100);
            
            g.DrawImage(imgBg2, x+140, 20, 360, 400);
            g.DrawImage(imgDoor, x+140, 20, 360, 400);
            g.DrawImage(imgBg1, x + 140, 0, 360, 100);
            g.DrawImage(imgBg3, x + 140, 320, 360, 100);
            for (int i = 0; i < gambar.Count; i++)
            {
                object O = Properties.Resources.ResourceManager.GetObject("courtyard_random___"+gambar[i]+"_");
                Image img = (Image)O;
                g.DrawImage(imgBg2, x + 340 + i * 360, 20, 360, 400);
                g.DrawImage(img, x + 340 + i * 360, 20, 360, 400);
                g.DrawImage(imgBg1, x + 340 + i * 360, 0, 360, 100);
                g.DrawImage(imgBg3, x + 340 + i * 360, 320, 360, 100);
            }
            
            g.DrawImage(imgBg2, x + 340 + 5 * 360, 20, 360, 400);
            g.DrawImage(imgDoor, x + 340 + 5 * 360, 20, 360, 400);
            g.DrawImage(imgBg1, x + 340 + 5 * 360, 0, 360, 100);
            g.DrawImage(imgBg3, x + 340 + 5 * 360, 320, 360, 100);
        }

        public override void mouse_click(object sender, MouseEventArgs e)
        {

        }
        public override void key_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.D)
            {
                x -= 100;
            }
            if (e.KeyData == Keys.A)
            {
                x += 100;
            }
            if (e.KeyData == Keys.Space)
            {
                MessageBox.Show(x+"");
            }
        }
    }
}
