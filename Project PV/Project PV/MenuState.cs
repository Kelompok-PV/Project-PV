using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PV
{
    class MenuState : GameState
    {
        public Rectangle startBtn { get; set; }
        public Rectangle font { get; set; }
        public GameStateManager gsm { get; set; }
        public Graphics g2;
        private int frame;
        public MenuState(GameStateManager gsm)
        {
            this.gsm = gsm;
            startBtn = new Rectangle(548, 524, 200,50);
            font = new Rectangle(430,80,500,150);
            
            frame = 1;
        }

        public override void init()
        {
            throw new NotImplementedException();
        }

        public override void draw(Graphics g)
        {
            this.g2 = g;
            object O = Properties.Resources.ResourceManager.GetObject("background");
            Image img = (Image)O;
            g2.DrawImage(img, 0, 0, 1300, 700);
            object O2 = Properties.Resources.ResourceManager.GetObject("button");
            img = (Image)O2;
            g2.DrawImage(img, startBtn);

            O2 = Properties.Resources.ResourceManager.GetObject("darkest");
            Image img1 = (Image)O2;
            g2.DrawImage(img1, 446, 60, 150, 100);

            O2 = Properties.Resources.ResourceManager.GetObject("torch__" + frame + "_");
            img1 = (Image)O2;
            g2.DrawImage(img1, 580, 80, 150, 150);

           
        }

        public override void mouse_click(object sender, MouseEventArgs e)
        {
            Rectangle cursor = new Rectangle(e.X,e.Y,10,10);
            if (cursor.IntersectsWith(startBtn))
            {
                gsm.stage = Stage.mainMenu;
                gsm.loadState(gsm.stage);
            }
        }

        public override void update()
        {
            if (frame == 16)
            {
                frame = 0;
            }
            frame++;
        }

        public override void key_keydown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void key_KeyUp(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
