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
    class MenuState : GameState
    {
        public Rectangle startBtn { get; set; }
        public Rectangle font { get; set; }
        public GameStateManager gsm { get; set; }
        public Graphics g2;
        private int frame;
        public Font title { get; set; }
        public MenuState(GameStateManager gsm)
        {
            this.gsm = gsm;
            startBtn = new Rectangle(548, 524, 200,50);
            font = new Rectangle(430,80,500,150);
            Config.font.AddFontFile("Resources\\DwarvenAxe BB W00 Regular.ttf");
            title = new Font(Config.font.Families[0],80,FontStyle.Regular);
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

            string darkest = "Darkest";
            RectangleF rect = Config.rect;
            rect.Location = new PointF(318, 80);
            StringFormat format = StringFormat.GenericTypographic;
            float dpi = g.DpiY;

            Pen pen = new Pen(new SolidBrush(Color.Red), 2);
            g.DrawString(darkest, title, new SolidBrush(Color.Black), new Point(300, 80));
            g.DrawPath(pen, GetStringPath(darkest, dpi, rect, title, format));

            string dungeon = "Dungeon";
            RectangleF rect2 = Config.rect;
            rect2.Location = new PointF(718, 80);
            float dpi1 = g.DpiY;

            g.DrawString(dungeon, title, new SolidBrush(Color.Black), new Point(700, 80));
            g.DrawPath(pen, GetStringPath(dungeon, dpi1, rect2, title, format));

            O2 = Properties.Resources.ResourceManager.GetObject("torch__" + frame + "_");
            img = (Image)O2;
            g2.DrawImage(img, 580, 80, 150, 150);

            
        }

        public override void mouse_click(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(string.Format("x: {0} - y:{1}",e.X,e.Y));
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
            
        }

		private GraphicsPath GetStringPath(string s, float dpi, RectangleF rect, Font font, StringFormat format)
		{
			GraphicsPath path = new GraphicsPath();
			// Convert font size into appropriate coordinates
			float emSize = dpi * font.SizeInPoints / 70;
			path.AddString(s, font.FontFamily, (int)font.Style, emSize, rect, format);

            return path;
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
