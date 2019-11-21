using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PV
{
    class MainMenu : GameState
    {
        public GameStateManager gsm { get; set; }

        public MainMenu(GameStateManager gsm)
        {
            this.gsm = gsm;
        }

        public override void draw(Graphics g)
        {
            object O1 = Properties.Resources.ResourceManager.GetObject("town_bg");
            Image img1 = (Image)O1;
            g.DrawImage(img1, 0,0, 1300, 700);

            object O = Properties.Resources.ResourceManager.GetObject("town_backdrop");
            Image img = (Image)O;
            g.DrawImage(img, 0, 0, 1300, 700);

            
        }

        public override void init()
        {
            throw new NotImplementedException();
        }

        public override void mouse_click(object sender, MouseEventArgs e)
        {
            
           
            
        }

        public override void update()
        {
            
        }

        public override void key_keydown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
