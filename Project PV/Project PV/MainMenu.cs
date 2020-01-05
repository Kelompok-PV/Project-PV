using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PV
{
    
    class MainMenu : GameState
    {
        public GameStateManager gsm { get; set; }
        private double xCloud;
        Rectangle sanitarium, guild, blackSmith, abbey,shop;
        private bool[] arrDraw;
        private List<coordinate> coordinates;
        private List<Rectangle> listBuilding;
        private Player player;
        private bool loading;
        private List<rosterList> roster;

        Rectangle frameBuy;
        Rectangle playerPanel;
        public MainMenu(GameStateManager gsm)
        {
            this.gsm = gsm;
            loading = false;
            player = gsm.getPlayer();
            roster = new List<rosterList>();
            xCloud = 1100;
            listBuilding = new List<Rectangle>();
            coordinates = new List<coordinate>();
            arrDraw = new bool[5];

            for (int i = 0; i < 5; i++)
            {
                arrDraw[i] = false;
            }

            sanitarium = new Rectangle(526, 328, 80, 106);
            listBuilding.Add(sanitarium);
            coordinates.Add(new coordinate(450, 258, "sanitarium","treat quirks and disease"));

            guild = new Rectangle(819, 377, 94, 139);
            listBuilding.Add(guild);
            coordinates.Add(new coordinate(878-100, 281, "guild", "treat quirks and disease"));

            blackSmith = new Rectangle(931, 501, 136, 79);
            listBuilding.Add(blackSmith);
            coordinates.Add(new coordinate(939, 381, "blackSmith", "treat quirks and disease"));

            abbey = new Rectangle(632, 225, 168, 137);
            listBuilding.Add(abbey);
            coordinates.Add(new coordinate(741, 196, "abbey", "treat quirks and disease"));

            shop = new Rectangle(167, 511, 272 - 167, 603 - 511);
            listBuilding.Add(shop);
            coordinates.Add(new coordinate(167+8, 511-50, "Shop Hero", "recruit new heroes"));

            //frame roster
            frameObj = Properties.Resources.rosterelement_res1;
            frameBit = (Bitmap)frameObj;
            yRoster.Add(130);
            for (int i = 0; i < player.myCharacter.Count; i++)
            {
                yRoster[i] += 85;
                yRoster.Add(yRoster[i]);
                roster.Add(new rosterList(xRoster + 10, yRoster[i], player.myCharacter[i]));
            }

            frameStats = Properties.Resources.characterpanel_frames;

            frameBuy = new Rectangle(xBuy, 240, widthBuy, 388);
            playerPanel = new Rectangle(0, 622, 1300, 90);
        }

        Object frameObj;
        Bitmap frameBit;
        int opacity = 0;
        int xRoster = 1105;
        
        List<int> yRoster = new List<int>();
        Rectangle cloud;

        int xBuy = 650;
        int widthBuy = 50;
        Bitmap frameStats;

        object O1;
        Image img1;
        Bitmap close = Properties.Resources.progression_close;
        public override void draw(Graphics g)
        {
            O1 = Properties.Resources.ResourceManager.GetObject("town_full_2");
            img1 = (Image)O1;
            g.DrawImage(img1, 0, 0, 1300, 700);

            O1 = Properties.Resources.ResourceManager.GetObject("town_cloud");
            img1 = (Image)O1;
            g.DrawImage(img1, (int)xCloud, 40, 433, 124);
            cloud = new Rectangle((int)xCloud,40,433,124);
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
                    g.DrawImage(img1, point.X - 20, point.Y - 50, 154, 162);
                    g.DrawString(s, title, new SolidBrush(Color.FromArgb(250, 231, 162)), point);
                    g.DrawString(sub, subtitle, new SolidBrush(Color.White), point.X, point.Y + 40);
                }
            }

            //panel embark
            O1 = Properties.Resources.ResourceManager.GetObject("progression_bar");
            img1 = (Image)O1;
            g.DrawImage(img1, 0, 622, 1300, 90);

            O1 = Properties.Resources.ResourceManager.GetObject("progression_forward");
            img1 = (Image)O1;
            g.DrawImage(img1, 580, 638, 200, 33);

            Font font = new Font(Config.font.Families[0], 28, FontStyle.Regular);
            g.DrawString("Embark", font, new SolidBrush(Color.FromArgb(180, 33, 13)), 630, 635);

            O1 = Properties.Resources.ResourceManager.GetObject("currency_gold_large_icon");
            img1 = (Image)O1;
            g.DrawImage(img1, 109, 605, 66, 66);

            g.DrawString(player.gold.ToString(), font, new SolidBrush(Color.FromArgb(202, 179, 112)), 179, 637);

            
            //roster
            for (int i = 0; i < player.myCharacter.Count; i++)
            {
                g.FillRectangle(new SolidBrush(Color.Black), xRoster+10, yRoster[i], 260, 80);
                g.DrawImage(frameBit, xRoster, yRoster[i],309, 82);
                g.DrawImage(player.myCharacter[i].getIcon(), 1117, yRoster[i]+10, 50, 50);
                font = new Font(Config.font.Families[0], 16, FontStyle.Regular);
                g.DrawString(player.myCharacter[i].nama, font, new SolidBrush(Color.FromArgb(250, 231, 162)), 1117+55, yRoster[i]+5);
            }

            //loading
            g.FillRectangle(new SolidBrush(Color.FromArgb(opacity, Color.Black)), 0, 0, 1300, 730);

            //open
            if (open)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(200, Color.Black)), 0, 0, 1300, 730);
                g.FillRectangle(new SolidBrush(Color.Black), xBuy, 240, widthBuy, 388);
                g.DrawRectangle(new Pen(Color.Gold), xBuy, 240, widthBuy, 388);
                g.DrawImage(frameStats, xBuy, 240, widthBuy, 388);

                //transition
                if (!transition)
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(200, Color.Black)), 0, 0, 1300, 730);
                    g.FillRectangle(new SolidBrush(Color.Black), xBuy, 240, widthBuy, 388);
                    g.DrawRectangle(new Pen(Color.Gold), xBuy, 240, widthBuy, 388);
                    g.DrawImage(frameStats, xBuy, 240, widthBuy, 388);
                    g.DrawImage(close, closeRect);

                    Font titleName = new Font(Config.font.Families[0], 25, FontStyle.Regular);
                    Font name = new Font(Config.font.Families[0], 16, FontStyle.Regular);
                    g.DrawString(roster[indexHero].karakter.nama, titleName, new SolidBrush(Color.FromArgb(250, 231, 162)), 360, 258);
                    titleName = new Font(Config.font.Families[0], 14, FontStyle.Regular);
                    g.DrawString(roster[indexHero].karakter.type, titleName, new SolidBrush(Color.FromArgb(250, 231, 162)), 360, 258 + 50);
                    g.DrawString("Base Stats", name, new SolidBrush(Color.FromArgb(250, 231, 162)), 533, 415);
                    Font font1 = new Font("ARIAL", 10, FontStyle.Regular);
                    Point desc = new Point(449, 442);
                    g.DrawString("Max HP  " + roster[indexHero].karakter.maxHp, font1, new SolidBrush(Color.White), desc.X, desc.Y);
                    g.DrawString("Dodge   " + roster[indexHero].karakter.dodge, font1, new SolidBrush(Color.White), desc.X + 75, desc.Y);
                    g.DrawString("Damage  " + roster[indexHero].karakter.max_damage, font1, new SolidBrush(Color.White), desc.X + 150, desc.Y);

                    //idle
                    try
                    {
                        g.DrawImage(roster[indexHero].karakter.getIdle(), 335, 452, 100, 150);
                        roster[indexHero].karakter.hero_move_now++;
                    }
                    catch (Exception)
                    {
                        roster[indexHero].karakter.hero_move_now = 1;
                        g.DrawImage(roster[indexHero].karakter.getIdle(), 335, 452, 100, 150);
                    }
                }
            }

            
        }

        bool transition = false;
        int indexHero = -1;
        bool open = false;
        public override void init()
        {
            
        }
        Rectangle closeRect;
        public override void mouse_click(object sender, MouseEventArgs e)
        {
            Rectangle cursor = new Rectangle(e.X,e.Y,10,10);
            Rectangle embark = new Rectangle(630, 635,200,33);
            //MessageBox.Show(string.Format("{0},{1}",e.X.ToString(), e.Y.ToString()));
            closeRect = new Rectangle(987, 260,25,25);

            if (!open && !loading)
            {
                if (cursor.IntersectsWith(sanitarium))
                {
                    Stage temp = gsm.stage;
                    gsm.unloadState(temp);

                    gsm.stage = Stage.sanitarium;
                    gsm.loadState(gsm.stage);
                }
                else if (cursor.IntersectsWith(blackSmith))
                {
                    Stage temp = gsm.stage;
                    gsm.unloadState(temp);

                    gsm.stage = Stage.blacksmith;
                    gsm.loadState(gsm.stage);
                }
                else if (cursor.IntersectsWith(guild))
                {
                    Stage temp = gsm.stage;
                    gsm.unloadState(temp);

                    gsm.stage = Stage.guild;
                    gsm.loadState(gsm.stage);
                }
                else if (cursor.IntersectsWith(abbey))
                {
                    Stage temp = gsm.stage;
                    gsm.unloadState(temp);

                    gsm.stage = Stage.abbey;
                    gsm.loadState(gsm.stage);
                }
                else if (cursor.IntersectsWith(embark))
                {
                    choice = choice.provision;
                    loading = true;
                    opacity = 128;

                }
                else if (cursor.IntersectsWith(shop))
                {
                    choice = choice.stage_coach;
                    loading = true;
                    opacity = 128;
                }
                else
                {
                    for (int i = 0; i < roster.Count; i++)
                    {
                        if (roster[i].getKaracter().IntersectsWith(cursor))
                        {
                            //base stats
                            indexHero = i;
                            open = true;
                            transition = true;
                        }
                    }
                }
            }
            else
            {
                if (cursor.IntersectsWith(closeRect) && open)
                {
                    disposeBuy = true;
                }
            }
            
        }

        private choice choice;
        int delay = 0;
        private void loadingScreen()
        {
            if (choice == choice.stage_coach)
            {
                Stage temp = gsm.stage;
                gsm.unloadState(temp);

                gsm.stage = Stage.entryNewHero;
                gsm.loadState(gsm.stage);
            }
            else if (choice == choice.provision)
            {
                Stage temp = gsm.stage;
                gsm.unloadState(temp);

                gsm.stage = Stage.quest;
                gsm.loadState(gsm.stage);
            }


        }
        int openTrans = 0;
        bool disposeBuy = false;
        public override void update()
        {
            xCloud-=1;
            if (loading)
            {
                opacity += 10;
                if (opacity >=255)
                {
                    delay++;
                    opacity = 255;
                    if (delay >= 10)
                    {
                        loading = false;
                        loadingScreen();
                    }
                    
                }
            }

            //if (open)
            //{
            //    openTrans++;
            //    if(openTrans >= 20)
            //    {
            //        transition = false;
            //    }
            //}

            if (disposeBuy)
            {
                if (widthBuy <= 10)
                {
                    widthBuy = 10;
                    open = false;
                    disposeBuy = false;
                    transition = false;
                    Config.form1.Invalidate();
                }
                else
                {
                    widthBuy -= 50;
                    xBuy += 25;
                    transition = true;
                    Rectangle temp = new Rectangle(frameBuy.X, frameBuy.Y, frameBuy.Width + 50, frameBuy.Height);
                    Config.form1.Invalidate(temp);
                    Config.form1.Invalidate(playerPanel);
                }

            }
            else if (transition)
            {
                if (widthBuy >= 697)
                {
                    widthBuy = 697;
                    transition = false;
                    Config.form1.Invalidate();
                }
                else
                {
                    widthBuy += 50;
                    xBuy -= 25;
                    Config.form1.Invalidate(frameBuy);
                }

            }

            frameBuy = new Rectangle(xBuy, 240, widthBuy, 388);
            playerPanel = new Rectangle(0, 622, 1300, 90);

            //Config.form1.Invalidate();
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

            if (!open && !loading)
            {
                for (int i = 0; i < listBuilding.Count; i++)
                {
                    if (cursor.IntersectsWith(listBuilding[i]))
                    {
                        arrDraw[i] = true;
                    }
                    else
                    {
                        arrDraw[i] = false;
                    }
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
    
    class rosterList
    {
        public int x { get; set; }
        public int y { get; set; }
        public karakter karakter { get; set; }

        public rosterList(int x, int y, karakter karakter)
        {
            this.x = x;
            this.y = y;
            this.karakter = karakter;
        }

        public Rectangle getKaracter()
        {
            return new Rectangle(x,y,260,80);
        }
    }

    enum choice
    {
        provision,
        stage_coach
    }
}
