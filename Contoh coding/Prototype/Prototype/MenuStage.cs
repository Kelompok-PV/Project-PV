using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype
{
    class MenuStage : GameState
    {
        public int pilihan { get; set; }

        //background 
        public Background background { get; set; }

        //font
        public Font titleFont { get; set; }
        public SolidBrush titleBrush { get; set; }
        public FontFamily ff { get; set; }

        public string[] options =
        {
            "Start",
            "Load",
            "Exit"
        };

        //parent
        GameStateManager gsm;

        public MenuStage(GameStateManager gsm)
        {
            this.gsm = gsm;

            background = new Background("Back2.gif");

            titleBrush = new SolidBrush(Color.Pink);
            ff = new FontFamily("Century Gothic");
        }

        public override void Draw(Graphics g)
        {
            //draw background nya
            background.Draw(g);

            //draw pilihan nya
            titleFont = new Font(ff, 20);
            for (int i = 0; i < 3; i++)
            {
                if (i == pilihan)
                {
                    titleBrush.Color = Color.Pink;
                }
                else
                {
                    titleBrush.Color = Color.Yellow;

                }
                g.DrawString(options[i], titleFont, titleBrush, 500, 300 + i * 30);
            }
        }
        public override void KeyPressed(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Up)
            {
                pilihan--;
            }
            else if(e.KeyData == Keys.Down)
            {
                pilihan++;
            }
            else if (e.KeyData == Keys.Enter)
            {
                if(pilihan == 0)
                {
                    gsm.currentState = 1;
                    gsm.loadState(gsm.currentState);
                }
                else if(pilihan == 2)
                {
                    Application.Exit();
                }
            }
        }

        public override void KeyReleased(object sender, KeyEventArgs e){}

    }
}
