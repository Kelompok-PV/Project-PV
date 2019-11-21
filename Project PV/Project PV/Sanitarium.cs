using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PV
{
    class Sanitarium : GameState
    {
        GameStateManager gsm { get; set; }

        public Sanitarium(GameStateManager gsm)
        {
            this.gsm = gsm;
        }

        public override void draw(Graphics g)
        {
            object O1 = Project_PV.Properties.Resources.sanitarium_character_background;
            Image background = (Image)O1;
            g.DrawImage(background, 0, 0, 1300, 700);

            object O2 = Project_PV.Properties.Resources.sanitarium_icon;
            Image icon = (Image)O2;
            g.DrawImage(icon, 10, 20, 100, 100);

            String drawString = "Sanitarium";
            Font drawFont = new Font("Arial", 20);

            SolidBrush drawBrush = new SolidBrush(Color.White);

            object O3 = Project_PV.Properties.Resources.sanitarium_character;
            Image character = (Image)O3;
            g.DrawImage(character, 0, 80, 800, 670);

            g.DrawString(drawString, drawFont, drawBrush, 90, 80);
        }

        public override void init()
        {
            throw new NotImplementedException();
        }

        public override void key_keydown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void mouse_click(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void update()
        {
            
        }
    }
}
