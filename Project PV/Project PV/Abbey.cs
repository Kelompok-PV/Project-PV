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
		int cx =960, cy = 50,tx=600,ty1=100,ty2,ty3;
		public Font title { get; set; }
		public Font subtitle { get; set; }
		public Font content { get; set; }
		GameStateManager gsm { get; set; }
		List<Selected_karacter> karacters;
		object frameObj;
		Bitmap frameBit;
		List<int> yRoster;
		private Player player;
		List<Rectangle> rosterField = new List<Rectangle>();
		public Abbey(GameStateManager gsm)
		{
			this.gsm = gsm;
			yRoster = new List<int>();
			karacters = new List<Selected_karacter>();
			Config.font.AddFontFile("Resources\\DwarvenAxe BB W00 Regular.ttf");
			title = new Font(Config.font.Families[0], 50, FontStyle.Regular);
			subtitle = new Font(Config.font.Families[0],20, FontStyle.Regular);
			content = new Font("Times New Roman", 14, FontStyle.Regular);
			player = gsm.getPlayer();
			rect.Location = new PointF(140, 20);
            arrow = (Image)O5;
            chara = (Image)O3;
            icon = (Image)O2;
            background = (Image)O1;
			// add panel locked slot
            for (int i = 0; i < 2; i++)
            {
                unlockset.Add(new unlockoverlay(cx, cy));
               
                    cx += 130;
                
            }
			cy += 210;
			cx = 960;
			for (int i = 0; i < 2; i++)
			{
				unlockset.Add(new unlockoverlay(cx, cy));

				cx += 130;

			}
			cy += 210;
			cx = 960;
			for (int i = 0; i < 2; i++)
			{
				unlockset.Add(new unlockoverlay(cx, cy));

				cx += 130;

			}
			//rooster add
			frameObj = Properties.Resources.rosterelement_res1;
			frameBit = (Bitmap)frameObj;
			yRoster.Add(130);
			
			for (int i = 0; i < player.myCharacter.Count; i++)
			{
				yRoster[i] += 85;
				rosterField.Add(new Rectangle(xRoster + 10, yRoster[i], 260, 80));
				yRoster.Add(yRoster[i]);
			}
		}

		int xRoster = 1105;

		object O1 = Project_PV.Properties.Resources.abbey_character_background;
        Image background ;
        object O2 = Project_PV.Properties.Resources.abbey_icon;
        Image icon;
        object O3 = Project_PV.Properties.Resources.abbey_character;
        Image chara;
        object O5 = Project_PV.Properties.Resources.progression_close;
        Image arrow;

        string abbey = "Abbey";
        RectangleF rect = Config.rect;

        Pen pen = new Pen(new SolidBrush(Color.Red), 2);
        StringFormat format = StringFormat.GenericTypographic;

		object O1z ;
		Image img1;

		Font font = new Font(Config.font.Families[0], 12, FontStyle.Regular);

		public override void draw(Graphics g)
		{
			
			//background
			g.DrawImage(background, 0, 0, 1300, 730);
			//draw icon abbey
			g.DrawImage(icon, 30, 20, 100, 100);
			// draw chara abbey
			g.DrawImage(chara, 50, 200, 500, 400);
			// draw close
			g.DrawImage(arrow, 1230, 10,50, 50);
			//draw slot locked
            for (int i = 0; i < 6; i++)
            {
                g.DrawImage(unlockset[i].Overlay, unlockset[i].X, unlockset[i].Y, 200, 200);
            }
				
				
			
			float dpi = g.DpiY;
			// draw tulisan semua
			g.DrawString(abbey, title, new SolidBrush(Color.Yellow), new Point(142, 30));
			g.DrawString("Cloister", subtitle, new SolidBrush(Color.Yellow), new Point(640, 60));
			g.DrawString("Peace through meditation.", content, new SolidBrush(Color.White), new Point(640, 100));
			g.DrawString("Transept", subtitle, new SolidBrush(Color.Yellow), new Point(640,277));
			g.DrawString("Pray to higher power.", content, new SolidBrush(Color.White), new Point(640, 317));
			g.DrawString("Tenance Hall", subtitle, new SolidBrush(Color.Yellow), new Point(640, 493));
			g.DrawString("Flagellation brings", content, new SolidBrush(Color.White), new Point(640, 533));
			g.DrawString("absolution", content, new SolidBrush(Color.White), new Point(640, 553));
			//g.DrawPath(pen, GetStringPath(abbey, dpi, rect, title, format));

			//draw roster
			for (int i = 0; i < player.myCharacter.Count; i++)
			{
				g.FillRectangle(new SolidBrush(Color.Black), xRoster + 10, yRoster[i], 260, 80);
				g.DrawImage(frameBit, xRoster, yRoster[i], 309, 82);
				g.DrawImage(player.myCharacter[i].getIcon(), 1117, yRoster[i] + 10, 50, 50);
				font = new Font(Config.font.Families[0], 16, FontStyle.Regular);
				g.DrawString(player.myCharacter[i].nama, font, new SolidBrush(Color.FromArgb(250, 231, 162)), 1117 + 55, yRoster[i] + 5);
			}
			if (selected && index != -1)
			{
				g.DrawImage(player.myCharacter[index].getIcon(), x, y, 50, 50);
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

        public override void init()
		{
			throw new NotImplementedException();
		}

		public override void key_keydown(object sender, KeyEventArgs e)
		{
			throw new NotImplementedException();
		}
		Rectangle cursor;
		bool selected = false;
		int index = -1;
		public override void mouse_click(object sender, MouseEventArgs e)
		{
			 cursor= new Rectangle(e.X, e.Y, 10, 10);
			Rectangle back = new Rectangle(1230, 10, 50, 50);
			if (cursor.IntersectsWith(back))
			{
				gsm.stage = Stage.mainMenu;
				gsm.loadState(gsm.stage);
			}

			if (!selected)
			{
				for (int i = 0; i < rosterField.Count; i++)
				{
					if (rosterField[i].IntersectsWith(cursor))
					{
						index = i;
						selected = true;
						break;
					}
				}
			}

			if (selected)
			{
				for (int i = 0; i < karacters.Count; i++)
				{
					if (cursor.IntersectsWith(karacters[i].getSelect()))
					{
						selected = false;
						karacters[i].setKaracter(player.myCharacter[index]);
						player.currentCharacters[i] = karacters[i].GetKarakter();
						index = -1;
						break;
					}
				}


			}
		}
		

		public override void update()
		{
        
        }

        public override void key_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
		int x, y;
		public override void mouse_hover(object sender, MouseEventArgs e)
        {
			x = e.X;
			y = e.Y;
			Config.form1.Invalidate();
		}

        public override void mouse_leave(object sender, MouseEventArgs e)
        {
            
        }

    }
	
	class unlockoverlay
	{
		int x;
		int y;
		Image overlay;
       
		public unlockoverlay(int x, int y)
		{
			this.x = x;
			this.y = y;
			object O4 = Project_PV.Properties.Resources.abbey_locked_hero_slot_overlay;
			Image unlock = (Image)O4;
			overlay = unlock;
		}

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public Image Overlay { get => overlay; set => overlay = value; }

        private GraphicsPath GetStringPath(string s, float dpi, RectangleF rect, Font font, StringFormat format)
        {
            GraphicsPath path = new GraphicsPath();
            // Convert font size into appropriate coordinates
            float emSize = dpi * font.SizeInPoints / 70;
            path.AddString(s, font.FontFamily, (int)font.Style, emSize, rect, format);

            return path;
        }
    }


	

}

