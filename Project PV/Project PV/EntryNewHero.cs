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
        Rectangle closeRect;
        private Player player;
        Bitmap frame;
        List<newHero> newHeroes;
        Random rand = new Random();
        public EntryNewHero(GameStateManager gsm)
        {
            this.gsm = gsm;
            background = Properties.Resources.stage_coach_character_background;
            iconMer_img = Properties.Resources.stage_coach_icon;
            characterCoach = Properties.Resources.stage_coach_character;
            backBtn = Properties.Resources.progression_close;
            closeRect = new Rectangle(1232, 33, 30, 30);
            player = gsm.getPlayer();

            newHeroes = new List<newHero>();
            int temp = rand.Next(2, 3);
            int xRoster = 700;
            int yRoster = 28;
            frame = Properties.Resources.rosterelement_res1;
            for (int i = 0; i < temp; i++)
            {
                newHeroes.Add(new newHero(xRoster, yRoster));
                yRoster += 75;

                karakter karakter;
                int type = rand.Next(4);
                switch (type)
                {
                    case 0:
                        karakter = new ninja("Ninjaa", 50, new equip[5], 30, 100);
                        break;
                    case 1:
                        karakter = new aladin("Aladeen", 50, new equip[5], 30, 100);
                        break;
                    case 2:
                        karakter = new druid("Druid", 50, new equip[5], 30, 100);
                        break;
                    default:
                        karakter = new archer("Archer", 50, new equip[5], 30, 100);
                        break;
                }
                newHeroes[i].karakter = karakter;
            }
        }
        bool loading = false;
        int alpha = 0;
        public override void draw(Graphics g)
        {
            g.DrawImage(background, 0, 0, 1300, 730);
            g.DrawString("Stage Coach",new Font(Config.font.Families[0],25,FontStyle.Regular),
                        new SolidBrush(Color.FromArgb(250, 231, 162)), 128, 50);
            g.DrawImage(iconMer_img, 22, 28,90,90);
            g.DrawImage(characterCoach, 30, 166,505,478);
            g.DrawImage(backBtn, 1232, 33, 30, 30);

            for (int i = 0; i < newHeroes.Count; i++)
            {
                g.DrawImage(frame, newHeroes[i].x, newHeroes[i].y, 500, 70);

                
                g.DrawImage(newHeroes[i].karakter.getIcon(), newHeroes[i].x+100, newHeroes[i].y, 50, 50);
            }

            //loading
            if (loading)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(alpha,Color.Black)), 0, 0, 1300, 730);
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

        public override void mouse_click(object sender, MouseEventArgs e)
        {
            MessageBox.Show("x: " + e.X + " y: " + e.Y);
            Rectangle cursor = new Rectangle(e.X, e.Y, 10, 10);

            if (cursor.IntersectsWith(closeRect))
            {
                loading = true;
                alpha = 128;

            }
        }

        public override void mouse_hover(object sender, MouseEventArgs e)
        {
            
        }

        public override void mouse_leave(object sender, MouseEventArgs e)
        {
            
        }
        int delay = 0;
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
        public newHero(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Rectangle getHit()
        {
            return new Rectangle(x, y, 500, 70);
        }

        public karakter GetKarakter()
        {
            return karakter;
        }
    }
}
