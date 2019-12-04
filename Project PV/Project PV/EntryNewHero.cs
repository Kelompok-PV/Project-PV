using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PV
{
    class EntryNewHero : GameState
    {
        Bitmap background;
        Bitmap iconMer_img;
        Bitmap characterCoach;
        Bitmap backBtn;
        Rectangle backRect;
        private Player player;
        Bitmap frame;
        List<newHero> newHeroes;
        Random rand = new Random();

        Rectangle frameBuy;
        Rectangle playerPanel;
        public EntryNewHero(GameStateManager gsm)
        {
            this.gsm = gsm;
            background = Properties.Resources.stage_coach_character_background;
            iconMer_img = Properties.Resources.stage_coach_icon;
            characterCoach = Properties.Resources.stage_coach_character;
            backBtn = Properties.Resources.progression_close;
            backRect = new Rectangle(1232, 33, 30, 30);
            player = gsm.getPlayer();

            newHeroes = new List<newHero>();
            int temp = rand.Next(2, 3);
            int xRoster = 700;
            int yRoster = 28;
            frame = Properties.Resources.rosterelement_res1;
            for (int i = 0; i < temp; i++)
            {
                int priceRand = rand.Next(1000, 3000);
                newHeroes.Add(new newHero(xRoster, yRoster,priceRand));
                yRoster += 75;

                karakter karakter;
                int type = rand.Next(4);

                switch (type)
                {
                    case 0:
                        karakter = new ninja("Hatory");
                        break;
                    case 1:
                        karakter = new aladin("Aladeen");
                        break;
                    case 2:
                        karakter = new druid("Druid");
                        break;
                    default:
                        karakter = new archer("Archer");
                        break;
                }
                newHeroes[i].karakter = karakter;

            }

            frameStats = Properties.Resources.characterpanel_frames;

            frameBuy = new Rectangle(xBuy, 240, widthBuy, 388);
            playerPanel = new Rectangle(0, 622, 1300, 90);
        }
        bool loading = false;
        bool buy = false;
        bool disposeBuy = false;
        int alpha = 0;
        Font name = new Font(Config.font.Families[0], 16, FontStyle.Regular);
        Font price = new Font(Config.font.Families[0], 24, FontStyle.Regular);

        //untuk pop up
        int xBuy = 650;
        int widthBuy = 50;
        Bitmap frameStats;
        int index = -1;

        object O1;
        Image img1;
        Rectangle buyBtn = new Rectangle(747, 568, 100, 50);
        public override void draw(Graphics g)
        {
            g.DrawImage(background, 0, 0, 1300, 730);
            g.DrawString("Stage Coach",new Font(Config.font.Families[0],25,FontStyle.Regular),
                        new SolidBrush(Color.FromArgb(250, 231, 162)), 128, 50);
            g.DrawImage(iconMer_img, 22, 28,90,90);
            g.DrawImage(characterCoach, 30, 166,505,478);
            g.DrawImage(backBtn, 1232, 33, 30, 30);

            //panel embark
            O1 = Properties.Resources.ResourceManager.GetObject("progression_bar");
            img1 = (Image)O1;
            g.DrawImage(img1, 0, 622, 1300, 90);

            O1 = Properties.Resources.ResourceManager.GetObject("progression_forward");
            img1 = (Image)O1;
            g.DrawImage(img1, 580, 638, 200, 33);

            Font font = new Font(Config.font.Families[0], 28, FontStyle.Regular);

            O1 = Properties.Resources.ResourceManager.GetObject("currency_gold_large_icon");
            img1 = (Image)O1;
            g.DrawImage(img1, 109, 605, 66, 66);

            g.DrawString(player.gold.ToString(), font, new SolidBrush(Color.FromArgb(202, 179, 112)), 179, 637);

            for (int i = 0; i < newHeroes.Count; i++)
            {
                g.DrawImage(frame, newHeroes[i].x, newHeroes[i].y, 500, 70);
                g.DrawImage(newHeroes[i].karakter.getIcon(), newHeroes[i].x+100, newHeroes[i].y+10, 50, 50); //icon karakter
                g.DrawString(newHeroes[i].karakter.nama, name, new SolidBrush(Color.FromArgb(250, 231, 162)), newHeroes[i].x + 170, newHeroes[i].y + 10);
                g.DrawString(newHeroes[i].karakter.hero, name, new SolidBrush(Color.White), newHeroes[i].x + 170, newHeroes[i].y + 25);
                g.DrawString("Price "+ newHeroes[i].price, price, new SolidBrush(Color.FromArgb(250, 231, 162)), newHeroes[i].x + 300, newHeroes[i].y + 25);
            }

            //loading
            if (loading)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(alpha,Color.Black)), 0, 0, 1300, 730);
            }

            if (buy)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(200, Color.Black)), 0, 0, 1300, 730);
                g.FillRectangle(new SolidBrush(Color.Black), xBuy, 240, widthBuy, 388);
                g.DrawRectangle(new Pen(Color.Gold), xBuy, 240, widthBuy, 388);
                g.DrawImage(frameStats, xBuy, 240, widthBuy, 388);

                
                if (!transition)
                {
                    //base stats
                    Font titleName = new Font(Config.font.Families[0],25, FontStyle.Regular);
                    g.DrawString(newHeroes[index].karakter.nama, titleName, new SolidBrush(Color.FromArgb(250, 231, 162)), 360, 258);
                    titleName = new Font(Config.font.Families[0], 14, FontStyle.Regular);
                    g.DrawString(newHeroes[index].karakter.type, titleName, new SolidBrush(Color.FromArgb(250, 231, 162)), 360, 258+50);
                    g.DrawString("Base Stats", name, new SolidBrush(Color.FromArgb(250, 231, 162)), 533, 415);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(200, Color.Red)), buyBtn);
                    g.DrawString("Buy Hero", price, new SolidBrush(Color.FromArgb(250, 231, 162)), buyBtn.X+5,buyBtn.Y+5);
                    Font font1 = new Font("ARIAL",10,FontStyle.Regular);
                    Point desc = new Point(449, 442);
                    g.DrawString("Max HP  " + newHeroes[index].karakter.maxHp, font1, new SolidBrush(Color.White), desc.X, desc.Y);
                    g.DrawString("Dodge   " + newHeroes[index].karakter.dodge, font1, new SolidBrush(Color.White), desc.X+75, desc.Y);
                    g.DrawString("Damage  " + newHeroes[index].karakter.max_damage, font1, new SolidBrush(Color.White), desc.X+150, desc.Y);
                    O1 = Properties.Resources.progression_close;
                    img1 = (Bitmap)O1;
                    g.DrawImage(img1, closeRect);

                    //idle
                    try
                    {

                        g.DrawImage(newHeroes[index].karakter.getIdle(), 335, 452, 100, 150);
                        newHeroes[index].karakter.hero_move_now++;
                    }
                    catch (Exception)
                    {
                        newHeroes[index].karakter.hero_move_now = 1;
                        g.DrawImage(newHeroes[index].karakter.getIdle(), 335, 452, 100, 150);
                    }
                }
            }
        }

        private GameStateManager gsm;
        
        public override void init()
        {
            
        }

        public override void key_keydown(object sender, KeyEventArgs e)
        {
            
        }

        public override void key_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
        Rectangle closeRect;
        public override void mouse_click(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("x: " + e.X + " y: " + e.Y);
            Rectangle cursor = new Rectangle(e.X, e.Y, 10, 10);
            closeRect = new Rectangle(886, 569,40,40);

            if (buy)
            {
                if (cursor.IntersectsWith(buyBtn))
                {
                    player.gold -= newHeroes[index].price;
                    player.myCharacter.Add(newHeroes[index].karakter);
                    disposeBuy = true;
                }
                else if (cursor.IntersectsWith(closeRect))
                {
                    disposeBuy = true;
                }
            }
            else
            {
                if (cursor.IntersectsWith(backRect))
                {
                    loading = true;
                    alpha = 128;
                }
                else
                {
                    for (int i = 0; i < newHeroes.Count; i++)
                    {
                        if (cursor.IntersectsWith(newHeroes[i].getHit()))
                        {
                            if (player.gold >= newHeroes[i].price)
                            {
                                buy = true;
                                transition = true;
                                index = i;
                                break;
                            }
                            else
                            {

                            }
                        }
                    }
                }
               
            }
        }

        public override void mouse_hover(object sender, MouseEventArgs e)
        {
            
        }

        public override void mouse_leave(object sender, MouseEventArgs e)
        {
            
        }
        int delay = 0;
        bool transition;
        public override void update()
        {
            
            if (loading)
            {
                alpha += 10;
                if (alpha >= 255)
                {
                    alpha = 255;
                    delay++;
                    if (delay >= 10)
                    {
                        loadingScreen();
                    }
                }
            }
            if (disposeBuy)
            {
                if (widthBuy <= 10)
                {
                    widthBuy = 10;
                    buy = false;
                    disposeBuy = false;
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
            else if (buy)
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
        }

        private void loadingScreen()
        {
            loading = false;
            gsm.unloadState(gsm.stage);
            gsm.stage = Stage.mainMenu;
            gsm.loadState(gsm.stage);
        }
    }
    class newHero
    {
        public int x { get; set; }
        public int y { get; set; }
        public karakter karakter { get; set; }
        public int price { get; set; }
        public newHero(int x, int y,int price)
        {
            this.x = x;
            this.y = y;
            this.price = price;
        }

        public Rectangle getHit()
        {
            return new Rectangle(x, y, 500, 70);
        }

    }
}
