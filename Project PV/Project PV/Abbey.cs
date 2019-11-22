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
	class Abbey : GameState
	{
		List<unlockoverlay> unlockset = new List<unlockoverlay>();
		int cx = 830, cy = 50;
		public Font title { get; set; }
		GameStateManager gsm { get; set; }

		public Abbey(GameStateManager gsm)
		{
			this.gsm = gsm;
			Config.font.AddFontFile("Resources\\DwarvenAxe BB W00 Regular.ttf");
			title = new Font(Config.font.Families[0], 80, FontStyle.Regular);
			
		}
		

		public override void draw(Graphics g)
		{
			object O1 = Project_PV.Properties.Resources.abbey_character_background;
			Image background = (Image)O1;
			g.DrawImage(background, 0, 0, 1300, 700);
			object O2 = Project_PV.Properties.Resources.abbey_icon;
			Image icon = (Image)O2;
			g.DrawImage(icon, 30, 20, 100, 100);
			object O3 = Project_PV.Properties.Resources.abbey_character;
			Image chara = (Image)O3;
			g.DrawImage(chara, 50, 200, 500, 400);
			object O5 = Project_PV.Properties.Resources.progression_close;
			Image arrow = (Image)O5;
			g.DrawImage(arrow, 50, 120,50, 50);
			for (int i = 0; i < 9; i++)
			{
				unlockset.Add(new unlockoverlay(cx, cy));
				if (i % 3 == 0)
				{
					cy += 200;
					cx = 830;
				}
				else
				{
					cx += 130;
				}
				g.DrawImage(unlockset[i].Overlay,unlockset[i].X, unlockset[i].Y, 200, 200);
				
				
			}
			string abbey = "Abbey";
			RectangleF rect = Config.rect;
			rect.Location = new PointF(140, 20);
			StringFormat format = StringFormat.GenericTypographic;
			float dpi = g.DpiY;

			Pen pen = new Pen(new SolidBrush(Color.Red), 2);
			g.DrawString(abbey, title, new SolidBrush(Color.Black), new Point(142, 20));
			g.DrawPath(pen, GetStringPath(abbey, dpi, rect, title, format));

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
			Rectangle cursor = new Rectangle(e.X, e.Y, 10, 10);
			Rectangle back = new Rectangle(50, 120, 50, 50);
			if (cursor.IntersectsWith(back))
			{
				gsm.stage = Stage.mainMenu;
				gsm.loadState(gsm.stage);
			}

			for (int i = 0; i < 9; i++)
			{
				if (cursor.IntersectsWith(unlockset[i].Shadow))
				{
					MessageBox.Show("hero masih kekunci");
				}
			}
		}

		public override void update()
		{}

        public override void key_KeyUp(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void mouse_hover(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void mouse_leave(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
		private GraphicsPath GetStringPath(string s, float dpi, RectangleF rect, Font font, StringFormat format)
		{
			GraphicsPath path = new GraphicsPath();
			// Convert font size into appropriate coordinates
			float emSize = dpi * font.SizeInPoints / 70;
			path.AddString(s, font.FontFamily, (int)font.Style, emSize, rect, format);

			return path;
		}
	}

	class unlockoverlay
	{
		int x;
		int y;
		Image overlay;
		Rectangle shadow;
		public unlockoverlay(int x, int y)
		{
			this.X = x;
			this.Y = y;
			object O4 = Project_PV.Properties.Resources.abbey_locked_hero_slot_overlay;
			Image unlock = (Image)O4;
			Overlay = unlock;
			shadow = new Rectangle(x, y, 200, 200);
		}

		public int X { get => x; set => x = value; }
		public int Y { get => y; set => y = value; }
		public Image Overlay { get => overlay; set => overlay = value; }
		public Rectangle Shadow { get => shadow; set => shadow = value; }
	}
}
