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

        public MenuState(GameStateManager gsm)
        {
            this.gsm = gsm;
            startBtn = new Rectangle(271,373,200,50);
            font = new Rectangle(241,36,300,100);
        }

        public override void init()
        {
            throw new NotImplementedException();
        }

        public override void draw(Graphics g)
        {
            object O = Properties.Resources.ResourceManager.GetObject("background");
            Image img = (Image)O;
            g.DrawImage(img, 0, 0, 777, 492);
            object O2 = Properties.Resources.ResourceManager.GetObject("button");
            img = (Image)O2;
            g.DrawImage(img,startBtn);
            O2 = Properties.Resources.ResourceManager.GetObject("font");
            img = (Image)O2;
            g.DrawImage(img, font);
            //g.FillRectangle(new SolidBrush(Color.Red),font);
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
    }
}
