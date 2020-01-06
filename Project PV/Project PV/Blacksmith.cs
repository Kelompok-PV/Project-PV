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
        //public karakter player { get; set; }
        GameStateManager gsm { get; set; }
        public Font title { get; set; }
        public Font subtitle { get; set; }
        public Font paragraph { get; set; }
        public Rectangle font { get; set; }

        List<string> text = new List<string>();
        List<PointF> ptext = new List<PointF>();

        object frameObj;
        Bitmap frameBit;
        Bitmap frameStats;
        List<int> yRoster;
        private Player player;
        List<Rectangle> rosterField = new List<Rectangle>();
        List<Selected_karacter> karacters;

        int cx = 630, cy = 35;
        Rectangle yes;
        Rectangle no;
        public Blacksmith(GameStateManager gsm)
        {
            this.gsm = gsm;
            yRoster = new List<int>();
            player = gsm.getPlayer();
            karacters = new List<Selected_karacter>();
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

            frameStats = Properties.Resources.back_e2;
            yes = new Rectangle();
            no = new Rectangle();
            // add panel locked slot
            for (int i = 0; i < 1; i++)
            {
                //unlockset.Add(new unlockoverlay(cx, cy));
                karacters.Add(new Selected_karacter(cx , cy, i + 1));
                //statusabbey.Add(-1);
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

        bool selected = false;
        int index = -1;
        int indexHero = -1;
        int indexsimp = -1;
        int simp = -1;
        bool cek = false;
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

            for(int i = 0; i < player.myCharacter.Count; i++)
            {
                g.FillRectangle(new SolidBrush(Color.Black), xRoster + 10, yRoster[i], 260, 80);
                g.DrawImage(frameBit, xRoster, yRoster[i], 309, 82);
                g.DrawImage(player.myCharacter[i].getIcon(), 1117, yRoster[i] + 10, 50, 50);
                g.DrawString(player.myCharacter[i].nama, subtitle, new SolidBrush(Color.FromArgb(250, 231, 162)), 1117 + 55, yRoster[i] + 5);
            }
            if (selected && index != -1)
            {
                g.DrawImage(player.myCharacter[index].getIcon(), x, y, 50, 50);
            }
            for (int i = 0; i < karacters.Count; i++)
            {

                try
                {
                    // gambar karakter pada tempat e ketika di taruh

                    g.DrawImage(karacters[i].GetKarakter().getIcon(), karacters[i].x, karacters[i].y, 75, 75);
                    simp = i;

                }
                catch (Exception)
                {
                }
            }

            string type = "";
            // gambar panel persetujuan
            if (simp != -1)
            {

                if (simp < 2)
                {
                    type = "Treatment";
                }
                else if (simp >= 2 && simp < 4)
                {
                    type = "Medical";
                }

                g.FillRectangle(new SolidBrush(Color.FromArgb(200, Color.Black)), 0, 0, 1300, 730);
                g.FillRectangle(new SolidBrush(Color.Black), 250, 240, 750, 388);
                g.DrawRectangle(new Pen(Color.Gold), 250, 240, 750, 388);
                g.DrawImage(frameStats, 260, 242, 740, 368);
                Font titleName = new Font(Config.font.Families[0], 30, FontStyle.Regular);
                Font name = new Font(Config.font.Families[0], 16, FontStyle.Regular);
                Font stress = new Font(Config.font.Families[0], 20, FontStyle.Regular);
                g.DrawString("Lets Upgrade for Your Hero: " + type, titleName, new SolidBrush(Color.Yellow), 350, 258);
                titleName = new Font(Config.font.Families[0], 25, FontStyle.Regular);
                g.DrawString("Your Choice?", titleName, new SolidBrush(Color.FromArgb(250, 231, 162)), 750, 360);
                g.DrawString(player.currentCharacters[indexsimp].nama, titleName, new SolidBrush(Color.FromArgb(250, 231, 162)), 360, 360);
                    g.DrawString("Weapon = ", titleName, new SolidBrush(Color.FromArgb(250, 231, 162)), 550, 360);
                for (int i = 0; i < player.currentCharacters[indexsimp].hero_equip.Length; i++)
                {
                    if(player.currentCharacters[indexsimp].hero_equip[i] != null)
                    {
                        if (player.currentCharacters[indexsimp].hero_equip[i].jenis.Equals("weapon"))
                        {
                            g.DrawString(player.currentCharacters[indexsimp].hero_equip[i].nama + "", stress, new SolidBrush(Color.FromArgb(250, 231, 162)), 580, 400);
                        }
                    }
                    else
                    {

                    }
                }

                
                    //if (player.currentCharacters[indexsimp].hp < player.currentCharacters[indexsimp].maxHp)
                    //{
                    //    g.DrawString("Pay Cash = ", titleName, new SolidBrush(Color.FromArgb(250, 231, 162)), 550, 420);
                    //    g.DrawString("100", titleName, new SolidBrush(Color.FromArgb(250, 231, 162)), 550, 450);
                    //}
                    g.DrawString("Armor = ", titleName, new SolidBrush(Color.FromArgb(250, 231, 162)), 550, 420);
                    g.DrawString(player.currentCharacters[indexsimp].hero_equip  + "", stress, new SolidBrush(Color.FromArgb(250, 231, 162)), 580, 450);
                    //if (player.currentCharacters[indexsimp].hero_buff != efek.none)
                    //{
                    //    g.DrawString("Pay Cash = ", titleName, new SolidBrush(Color.FromArgb(250, 231, 162)), 550, 360);
                    //    g.DrawString("100", titleName, new SolidBrush(Color.FromArgb(250, 231, 162)), 570, 360);
                    //}
                
                titleName = new Font(Config.font.Families[0], 20, FontStyle.Regular);
                g.DrawString("Yes", titleName, new SolidBrush(Color.FromArgb(250, 231, 162)), 780, 395);
                yes = new Rectangle(780, 395, 20, 20);
                g.DrawString("No", titleName, new SolidBrush(Color.FromArgb(250, 231, 162)), 830, 395);
                no = new Rectangle(830, 395, 20, 20);
                Font font1 = new Font("ARIAL", 10, FontStyle.Regular);

                //idle di dalam status
                try
                {
                    g.DrawImage(player.currentCharacters[indexsimp].getIdle(), 335, 400, 150, 200);
                    player.currentCharacters[indexsimp].hero_move_now++;
                }
                catch (Exception)
                {
                    player.currentCharacters[indexsimp].hero_move_now = 1;
                    g.DrawImage(player.currentCharacters[indexsimp].getIdle(), 335, 400, 150, 200);
                }
            }
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
                //gsm.player.currentCharacters[0] = this.player;
                gsm.unloadState(gsm.stage);
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
                        indexHero = i;
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
                        if (player.currentCharacters.Count > i)
                        {
                            player.currentCharacters[i] = karacters[i].GetKarakter();
                            indexsimp = i;
                        }
                        else
                        {
                            player.currentCharacters.Add(karacters[i].GetKarakter());
                            indexsimp = player.currentCharacters.Count - 1;
                        }
                        index = -1;
                        break;
                    }
                }


            }

        }

        public override void update()
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
            throw new NotImplementedException();
        }

        
    }
}
