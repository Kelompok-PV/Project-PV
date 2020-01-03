using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PV
{
    
    class Blacksmith : GameState
    {
        GameStateManager gsm { get; set; }
        public Font title { get; set; }
        public Font subtitle { get; set; }
        public Font paragraph { get; set; }
        public Rectangle font { get; set; }

        List<string> text = new List<string>();
        List<PointF> ptext = new List<PointF>();
        public Blacksmith(GameStateManager gsm)
        {
            this.gsm = gsm;
            font = new Rectangle(430, 80, 500, 150);
            Config.font.AddFontFile("Resources\\DwarvenAxe BB W00 Regular.ttf");
            title = new Font(Config.font.Families[0], 50, FontStyle.Regular);
            subtitle = new Font(Config.font.Families[0], 20, FontStyle.Regular);

            text.Add("Blacksmith"); text.Add("Drag a hero from the roster here.");
            ptext.Add(new Point(120, 50)); ptext.Add(new Point(700, 55));

            background = (Image)O1;
            icon = (Image)O2;
            character = (Image)O3;
            qpost = (Image)O4;
            close = (Image)O5;
        }
        object O1 = Project_PV.Properties.Resources.blacksmith_character_background;
        Image background;

        object O2 = Project_PV.Properties.Resources.blacksmith_icon;
        Image icon;

        object O3 = Project_PV.Properties.Resources.blacksmith_character;
        Image character;

        object O4 = Project_PV.Properties.Resources.remove_quirk_positive;
        Image qpost;

        object O5 = Project_PV.Properties.Resources.progression_close;
        Image close;

        StringFormat format = StringFormat.GenericTypographic;

        public override void draw(Graphics g)
        {
            g.DrawImage(background, 0, 0, 1300, 700);
            g.DrawImage(icon, 10, 20, 100, 100);

            float dpi = g.DpiY;

            Pen pen = new Pen(new SolidBrush(Color.Yellow));
            g.DrawString(text[0], title, new SolidBrush(Color.Yellow), ptext[0]);
            g.DrawString(text[1], subtitle, new SolidBrush(Color.Gray), ptext[1]);

            
            g.DrawImage(character, 20, 100, 750, 620);
            g.DrawImage(qpost, 25, 115, 70, 70);  
            g.DrawImage(close, 1230, 10, 50, 50);
        }

        public override void init()
        {
            throw new NotImplementedException();
        }

        public override void key_keydown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void key_KeyUp(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void mouse_click(object sender, MouseEventArgs e)
        {
            Rectangle cursor = new Rectangle(e.X, e.Y, 10, 10);
            Rectangle back = new Rectangle(1230, 10, 50, 50);
            if (cursor.IntersectsWith(back))
            {
                gsm.stage = Stage.mainMenu;
                gsm.loadState(gsm.stage);
            }
            
        }

        public override void update()
        {
            
        }

        public override void mouse_hover(object sender, MouseEventArgs e)
        {
            
        }

        public override void mouse_leave(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        
    }
}
