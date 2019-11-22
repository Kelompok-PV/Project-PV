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
    class MainMenu : GameState
    {
        public GameStateManager gsm { get; set; }
        private double xCloud;
        Rectangle sanitarium, guild, blackSmith, abbey;
        private bool[] arrDraw;
        private List<coordinate> coordinates;
        private List<Rectangle> listBuilding;
        private Player player;
        private bool loading;
        public Graphics g2 { get; set; }
        public MainMenu(GameStateManager gsm)
        {
            this.gsm = gsm;
            loading = false;
            player = gsm.getPlayer();
            xCloud = 1100;
            listBuilding = new List<Rectangle>();
            coordinates = new List<coordinate>();
            arrDraw = new bool[4];

            for (int i = 0; i < 4; i++)
            {
                arrDraw[i] = false;
            }

            sanitarium = new Rectangle(526, 328, 80, 106);
            listBuilding.Add(sanitarium);
            coordinates.Add(new coordinate(450, 258, "sanitarium","treat quirks and disease"));

            guild = new Rectangle(819, 377, 94, 139);
            listBuilding.Add(guild);
            coordinates.Add(new coordinate(878, 281, "guild", "treat quirks and disease"));

            blackSmith = new Rectangle(931, 501, 136, 79);
            listBuilding.Add(blackSmith);
            coordinates.Add(new coordinate(939, 381, "blackSmith", "treat quirks and disease"));

            abbey = new Rectangle(632, 225, 168, 137);
            listBuilding.Add(abbey);
            coordinates.Add(new coordinate(741, 196, "abbey", "treat quirks and disease"));

        }

        int yload = 730;
        public override void draw(Graphics g)
        {
            g2 = g;
            object O1 = Properties.Resources.ResourceManager.GetObject("town_full1");
            Image img1 = (Image)O1;
            g2.DrawImage(img1, 0, 0, 1300, 700);

            O1 = Properties.Resources.ResourceManager.GetObject("town_cloud");
            img1 = (Image)O1;
            g2.DrawImage(img1, (int)xCloud, 40, 433, 124);

            for (int i = 0; i < arrDraw.Length; i++)
            {
                if (arrDraw[i])
                {
                    Font title = new Font(Config.font.Families[0], 30, FontStyle.Regular);
                    Font subtitle = new Font(Config.font.Families[0], 15, FontStyle.Regular);
                    string s = coordinates[i].buildingTitle;
                    string sub = coordinates[i].subtitle;
                    Point point = new Point(coordinates[i].x, coordinates[i].y);

                    O1 = Properties.Resources.ResourceManager.GetObject("blg_name_background");
                    img1 = (Image)O1;
                    g.DrawImage(img1, point.X-20, point.Y-50, 154, 162);
                    g.DrawString(s, title, new SolidBrush(Color.FromArgb(250, 231, 162)), point);
                    g.DrawString(sub, subtitle, new SolidBrush(Color.White), point.X,point.Y+30);
                }
            }

            //panel embark
            O1 = Properties.Resources.ResourceManager.GetObject("progression_bar");
            img1 = (Image)O1;
            g.DrawImage(img1, 0, 622, 1300, 90);

            O1 = Properties.Resources.ResourceManager.GetObject("progression_forward");
            img1 = (Image)O1;
            g.DrawImage(img1, 580, 638, 200, 33);

            Font font = new Font(Config.font.Families[0],28,FontStyle.Regular);
            g.DrawString("Embark", font, new SolidBrush(Color.FromArgb(180, 33, 13)), 630, 635);
            
            O1 = Properties.Resources.ResourceManager.GetObject("currency_gold_large_icon");
            img1 = (Image)O1;
            g.DrawImage(img1, 109, 605, 66, 66);

            g.DrawString(player.gold.ToString(), font, new SolidBrush(Color.FromArgb(202, 179, 112)), 179, 637);

            //loading
            g.FillRectangle(new SolidBrush(Color.Black), 0, yload, 1300, 730);
            
        }

        public override void init()
        {
            
        }

        public override void mouse_click(object sender, MouseEventArgs e)
        {
            MessageBox.Show("x: " + e.X + " y: " + e.Y);
            Rectangle cursor = new Rectangle(e.X,e.Y,10,10);
            Rectangle embark = new Rectangle(630, 635,200,33);

            for (int i = 0; i < listBuilding.Count; i++)
            {
                if (cursor.IntersectsWith(listBuilding[i]))
                {
                    arrDraw[i] = true;
                }
            }

            if (cursor.IntersectsWith(sanitarium))
            {
                MessageBox.Show("sanitarium");
            }
            else if (cursor.IntersectsWith(guild))
            {
				gsm.stage = Stage.guild;
				gsm.loadState(gsm.stage);
			}
            else if (cursor.IntersectsWith(abbey))
            {
				gsm.stage = Stage.abbey;
				gsm.loadState(gsm.stage);
			}
            else if (cursor.IntersectsWith(embark))
            {
                loading = true;
            }

            
        }

        public override void update()
        {
            xCloud-=1;
            if (loading)
            {
                yload-=10;
                if(yload <= 0)
                {
                    loading = false;
                }
            }
            
        }

        public override void key_keydown(object sender, KeyEventArgs e)
        {
            
        }

        public override void key_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        public override void mouse_hover(object sender, MouseEventArgs e)
        {
            Rectangle cursor = new Rectangle(e.X,e.Y,10,10);
            
            for (int i = 0; i < listBuilding.Count; i++)
            {
                if (cursor.IntersectsWith(listBuilding[i]))
                {
                    arrDraw[i] = true;
                }
                else
                {
                    arrDraw[i] = false ;
                }
            }

        }

        public override void mouse_leave(object sender, MouseEventArgs e)
        {

        }

    }
    class coordinate
    {
        public int x { get; set; }
        public int y { get; set; }
        public string buildingTitle { get; set; }
        public string subtitle { get; set; }

        public coordinate(int x, int y, string buildingTitle,string subtitle)
        {
            this.x = x;
            this.y = y;
            this.buildingTitle = buildingTitle;
            this.subtitle = subtitle;
        }
    }
}
