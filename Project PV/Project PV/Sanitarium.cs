using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PV
{
    class Sanitarium : GameState
    {
        public karakter player { get; set; }
        GameStateManager gsm { get; set; }
        public Font title { get; set; }
        public Font subtitle { get; set; }
        public Font paragraph { get; set; }
        public Rectangle font { get; set; }

        List<string> text = new List<string>();
        List<PointF> ptext = new List<PointF>();

        public Sanitarium(GameStateManager gsm)
        {
            this.gsm = gsm;
            font = new Rectangle(430, 80, 500, 150);
            Config.font.AddFontFile("Resources\\DwarvenAxe BB W00 Regular.ttf");
            title = new Font(Config.font.Families[0], 50, FontStyle.Regular);
            subtitle = new Font(Config.font.Families[0], 20, FontStyle.Regular);
            paragraph = new Font(Config.font.Families[0], 15, FontStyle.Regular);
            
            text.Add("Sanitarium"); text.Add("Treatment Ward"); text.Add("Medical Ward");
            text.Add("Treat Quirks and other \n problematic behaviors."); text.Add("Treat Diseases, humorous, \n and other physical maladies");
            ptext.Add(new Point(120, 30)); ptext.Add(new PointF(670, 60)); ptext.Add(new PointF(680, 265));
            ptext.Add(new Point(650, 90)); ptext.Add(new PointF(650, 300));

            background = (Image)O1;
            icon = (Image)O2;
            character = (Image)O3;
            qpost = (Image)O4;
            close = (Image)O5;
        }
        object O1 = Project_PV.Properties.Resources.sanitarium_character_background;
        Image background ;

        object O2 = Project_PV.Properties.Resources.sanitarium_icon;
        Image icon;

        object O3 = Project_PV.Properties.Resources.sanitarium_character;
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

            for (int i = 1; i < text.Count; i++)
            {
                if (i <= 2)
                {
                    g.DrawString(text[i], subtitle, new SolidBrush(Color.Yellow), ptext[i]);
                }
                else
                {
                    g.DrawString(text[i], paragraph, new SolidBrush(Color.Gray), ptext[i]);
                }
            }
            g.DrawImage(character, -40, 100, 750, 620);
            g.DrawImage(qpost, 25, 115, 70, 70);
            g.DrawImage(close, 1230, 10, 50, 50);
        }

        private GraphicsPath GetStringPath(string s, float dpi, RectangleF rect, Font font, StringFormat format)
        {
            GraphicsPath path = new GraphicsPath();
            // Convert font size into appropriate coordinates
            float emSize = dpi * font.SizeInPoints / 70;
            path.AddString(s, font.FontFamily, (int)font.Style, emSize, rect, format);

            return path;
        }

        public override void init()
        {
            throw new NotImplementedException();
        }

        public override void key_keydown(object sender, KeyEventArgs e)
        {

        }

        Rectangle back = new Rectangle(1230, 10, 50, 50);
        public override void mouse_click(object sender, MouseEventArgs e)
        {
            Rectangle cursor = new Rectangle(e.X, e.Y, 10, 10);
            if (cursor.IntersectsWith(back))
            {
                gsm.player.currentCharacters[0] = this.player;
                gsm.unloadState(gsm.stage);
                gsm.stage = Stage.mainMenu;
                gsm.loadState(gsm.stage);
            }
        }

        public override void update()
        {
            
        }

        public override void key_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        public override void mouse_hover(object sender, MouseEventArgs e)
        {
            
        }

        public override void mouse_leave(object sender, MouseEventArgs e)
        {
            
        }

        
    }
}
