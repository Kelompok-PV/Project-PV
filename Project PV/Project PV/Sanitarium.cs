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

        int cx = 960, cy = 50;
        Rectangle yes;
        Rectangle no;
        public Sanitarium(GameStateManager gsm)
        {
            this.gsm = gsm;
            yRoster = new List<int>();
            player = gsm.getPlayer();
            karacters = new List<Selected_karacter>();
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
            lockslothero = (Image)O6;
            frameStats = Properties.Resources.back_e2;
            yes = new Rectangle();
            no = new Rectangle();
            // add panel locked slot
            for (int i = 0; i < 3; i++)
            {
                //unlockset.Add(new unlockoverlay(cx, cy));
                karacters.Add(new Selected_karacter(cx - 65, cy + 65, i + 1));
                //statusabbey.Add(-1);
                cx += 130;

            }
            cy += 210;
            cx = 960;
            for (int i = 0; i < 3; i++)
            {
                //unlockset.Add(new unlockoverlay(cx, cy));
                karacters.Add(new Selected_karacter(cx - 65, cy + 65, i + 1));
                //statusabbey.Add(-1);
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

        object O6 = Project_PV.Properties.Resources.sanitarium_locked_hero_slot_overlay;
        Image lockslothero;

        StringFormat format = StringFormat.GenericTypographic;

        bool selected = false;
        int index = -1;
        int indexHero = -1;
        int indexsimp = -1;
        int simp = -1;
        bool bisa = false;
        public override void draw(Graphics g)
        {
            g.DrawImage(background, 0, 0, 1300, 700);
            g.DrawImage(icon, 10, 20, 100, 100);
            float dpi = g.DpiY;


            for (int i = 0; i < 2; i++)
            {
                g.DrawImage(lockslothero, 995, 75 + i * 210, 140, 140);
            }
            for (int i = 0; i < 2; i++)
            {
                g.DrawImage(lockslothero, 1120, 75 + i * 210, 140, 140);
            }
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

            for (int i = 0; i < player.myCharacter.Count; i++)
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
                    if(i == 0 || i == 3)
                    {
                        g.DrawImage(karacters[i].GetKarakter().getIcon(), karacters[i].x, karacters[i].y, 90, 90);
                        simp = i;
                        break;
                    }
                    else 
                    {
                        simp = -1;
                    }

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
                g.DrawString("Lets Heal for Your Hero: " + type, titleName, new SolidBrush(Color.Yellow), 350, 258);
                titleName = new Font(Config.font.Families[0], 25, FontStyle.Regular);
                g.DrawString("Your Choice?", titleName, new SolidBrush(Color.FromArgb(250, 231, 162)), 750, 360);
                g.DrawString(player.currentCharacters[indexsimp].nama, titleName, new SolidBrush(Color.FromArgb(250, 231, 162)), 360, 360);
                if (simp >= 2 && simp < 4)
                {
                    g.DrawString("HP Status = ", titleName, new SolidBrush(Color.FromArgb(250, 231, 162)), 550, 360);
                    g.DrawString(player.currentCharacters[indexsimp].hp + "", stress, new SolidBrush(Color.FromArgb(250, 231, 162)), 580, 400);
                    if(player.currentCharacters[indexsimp].hp < player.currentCharacters[indexsimp].maxHp)
                    {
                        g.DrawString("Pay Cash = ", titleName, new SolidBrush(Color.FromArgb(250, 231, 162)), 550, 420);
                        g.DrawString("100", titleName, new SolidBrush(Color.FromArgb(250, 231, 162)), 550, 450);
                    }
                }
                else if (simp < 2)
                {
                    g.DrawString("Buff = ", titleName, new SolidBrush(Color.FromArgb(250, 231, 162)), 550, 360);
                    g.DrawString(player.currentCharacters[indexsimp].hero_buff + "", stress, new SolidBrush(Color.FromArgb(250, 231, 162)), 580, 400);
                    if (player.currentCharacters[indexsimp].hero_buff != efek.none)
                    {
                        g.DrawString("Pay Cash = ", titleName, new SolidBrush(Color.FromArgb(250, 231, 162)), 550, 360);
                        g.DrawString("100", titleName, new SolidBrush(Color.FromArgb(250, 231, 162)), 570, 360);
                    }
                }
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
            bool close = false;
            if (cursor.IntersectsWith(yes))
            {

                if (simp < 2)
                {
                    if (player.currentCharacters[indexsimp].hero_buff == efek.none)
                    {
                        MessageBox.Show("Tidak ada buff musuh yang menempel!");
                        close = true;

                    }
                    else
                    {
                        player.currentCharacters[indexsimp].hero_buff = efek.none;
                        player.gold -= 100;
                        close = true;
                    }
                }
                else if (simp >= 2 && simp < 4)
                {
                    int tmp = player.currentCharacters[indexsimp].maxHp;
                    if (player.currentCharacters[indexsimp].hp == tmp)
                    {
                        MessageBox.Show("HP hero ini penuh");
                        close = true;
                    }
                    else
                    {
                        player.currentCharacters[indexsimp].hp = tmp;
                        player.gold -= 100;
                        close = true;
                    }
                }
                Config.form1.Invalidate();

            }
            else if (cursor.IntersectsWith(no))
            {
                close = true;
            }
            if (close == true)
            {
                int tmpx = karacters[simp].x;
                int tmpy = karacters[simp].y;
                int tmindex = karacters[simp].index;
                karacters[simp] = new Selected_karacter(tmpx, tmpy, tmindex);
                simp = -1;
                Config.form1.Invalidate();
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
}
