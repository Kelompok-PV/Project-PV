using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PV
{
    
    class Quest : GameState
    {
        private Player player;
        private GameStateManager gsm;
        List<Selected_karacter> karacters;
        object frameObj;
        Bitmap frameBit;
        List<int> yRoster;
        public Quest(GameStateManager gsm)
        {
            yRoster = new List<int>();
            this.gsm = gsm;
            player = gsm.getPlayer();
            karacters = new List<Selected_karacter>();

            int coorX = 559; int coorY = 573;
            for (int i = 0; i < 4; i++)
            {
                karacters.Add(new Selected_karacter(coorX, coorY, i+1));
                coorX += 57;
            }

            frameObj = Properties.Resources.rosterelement_res1;
            frameBit = (Bitmap)frameObj;
            yRoster.Add(130);

            for (int i = 0; i < player.myCharacter.Count; i++)
            {
                yRoster[i] += 85;
                rosterField.Add(new Rectangle(xRoster + 10, yRoster[i], 260, 80));
                roster_bool.Add(false);
                yRoster.Add(yRoster[i]);
            }

            battleRect[0] = new Rectangle(892, 68, 190, 97);
            battleRect[1] = new Rectangle(704, 156, 190, 97);
            battleRect[2] = new Rectangle(492, 261, 190, 97);

            player.currentCharacters = new List<karakter>();
        }
        int xRoster = 1105;
        public override void draw(Graphics g)
        {
            //background
            object O1 = Properties.Resources.ResourceManager.GetObject("quest_select_back");
            Image img1 = (Image)O1;
            g.DrawImage(img1, 0, 0, 1300, 730);

            //option quest
            Font font = new Font(Config.font.Families[0], 12, FontStyle.Regular);

            O1 = Properties.Resources.ResourceManager.GetObject("dungeon_progressionbar");
            img1 = (Image)O1;
            g.DrawImage(img1, 700, 169, 141, 42);
            g.DrawString("Ruins",font, new SolidBrush(Color.FromArgb(202, 179, 112)),703,162);

            O1 = Properties.Resources.ResourceManager.GetObject("dungeon_progressionbar");
            img1 = (Image)O1;
            g.DrawImage(img1, 670, 380, 141, 42);
            g.DrawString("Weald", font, new SolidBrush(Color.FromArgb(202, 179, 112)), 673, 373);

            O1 = Properties.Resources.ResourceManager.GetObject("dungeon_progressionbar");
            img1 = (Image)O1;
            g.DrawImage(img1, 489, 275, 141, 42);
            g.DrawString("Warrens", font, new SolidBrush(Color.FromArgb(202, 179, 112)), 492, 268);

            O1 = Properties.Resources.ResourceManager.GetObject("dungeon_progressionbar");
            img1 = (Image)O1;
            g.DrawImage(img1, 891, 93, 141, 42);
            g.DrawString("Darkest Dungeon", font, new SolidBrush(Color.FromArgb(202, 179, 112)), 894, 85);

            //panel selected roster
            O1 = Properties.Resources.ResourceManager.GetObject("embark_party_background");
            img1 = (Image)O1;
            g.DrawImage(img1, 547, 562, 250, 65);

            O1 = Properties.Resources.ResourceManager.GetObject("hero_slot_background");
            img1 = (Image)O1;
            for (int i = 0; i < karacters.Count; i++)
            {
                g.DrawImage(img1, karacters[i].x, karacters[i].y, 52, 52);

                try
                {
                    g.DrawImage(karacters[i].GetKarakter().getIcon(), karacters[i].x, karacters[i].y, 52, 52);
                }
                catch (Exception)
                {

                }
            }

            //panel embark
            O1 = Properties.Resources.ResourceManager.GetObject("progression_bar");
            img1 = (Image)O1;
            g.DrawImage(img1, 0, 622, 1300, 90);

            O1 = Properties.Resources.ResourceManager.GetObject("progression_forward");
            img1 = (Image)O1;
            g.DrawImage(img1, 580, 638, 200, 33);

            Font font1 = new Font(Config.font.Families[0], 28, FontStyle.Regular);
            g.DrawString("Provison", font1, new SolidBrush(Color.FromArgb(180, 33, 13)), 630, 635);

            O1 = Properties.Resources.ResourceManager.GetObject("currency_gold_large_icon");
            img1 = (Image)O1;
            g.DrawImage(img1, 109, 605, 66, 66);

            g.DrawString(player.gold.ToString(), font1, new SolidBrush(Color.FromArgb(202, 179, 112)), 179, 637);

            //roster
            for (int i = 0; i < player.myCharacter.Count; i++)
            {
                g.FillRectangle(new SolidBrush(Color.Black), xRoster + 10, yRoster[i], 260, 80);
                g.DrawImage(frameBit, xRoster, yRoster[i], 309, 82);
                g.DrawImage(player.myCharacter[i].getIcon(), 1117, yRoster[i] + 10, 50, 50);
                
                font = new Font(Config.font.Families[0], 16, FontStyle.Regular);
                g.DrawString(player.myCharacter[i].nama, font, new SolidBrush(Color.FromArgb(250, 231, 162)), 1117 + 55, yRoster[i] + 5);

            }

            if (selected && index!=-1)
            {
                g.DrawImage(player.myCharacter[index].getIcon(), x,y, 50, 50);
            }

            for (int i = 0; i < battleRect.Length; i++)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(180, Color.Black)), battleRect[i]);
            }


        }
        List<Rectangle> rosterField = new List<Rectangle>();
        List<bool> roster_bool = new List<bool>();
        int index = -1;
        public override void init()
        {
            
        }

        public override void key_keydown(object sender, KeyEventArgs e)
        {
            
        }

        public override void key_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
        int x, y;
        Rectangle[] battleRect = new Rectangle[3];
        public override void mouse_click(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(string.Format("{0},{1}",e.X,e.Y));
            Rectangle cursor = new Rectangle(e.X, e.Y, 10, 10);
            if (!selected)
            {
                for (int i = 0; i < rosterField.Count; i++)
                {
                    if (rosterField[i].IntersectsWith(cursor) && !roster_bool[i])
                    {
                        index = i;
                        selected = true;
                        roster_bool[i] = true;
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
                        player.currentCharacters.Add(karacters[i].GetKarakter());
                        index = -1;
                        break;
                    }
                }
            }

            for (int i = 0; i < battleRect.Length; i++)
            {
                if (battleRect[i].IntersectsWith(cursor))
                {
                    if (i == 0)
                    {
                        gsm.dif = Stage.easyState;
                    }
                    if (i == 1)
                    {
                        gsm.dif = Stage.mediumState;
                    }
                    if (i == 2)
                    {
                        gsm.dif = Stage.hardState;
                    }
                    gsm.stage = Stage.provision;
                    gsm.loadState(gsm.stage);
                }
            }
            
        }
        bool selected = false;
        Rectangle cursor;
        public override void mouse_hover(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            Config.form1.Invalidate();
        }

        public override void mouse_leave(object sender, MouseEventArgs e)
        {
            
        }

        public override void update()
        {
            
        }

    }
    
    class Selected_karacter
    {
        public int x { get; set; }
        public int y { get; set; }
        public int index { get; set; }
        public karakter name { get; set; }
        public Selected_karacter(int x, int y, int index)
        {
            this.x = x;
            this.y = y;
            this.index = index;
        }

        public void setKaracter(karakter karakter)
        {
            this.name = karakter;
        }

        public karakter GetKarakter()
        {
            return name;
        }

        public Rectangle getSelect()
        {
            return new Rectangle(x, y, 52, 52);
        }
    }
}
