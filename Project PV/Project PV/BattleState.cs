using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PV
{
    
    class BattleState : GameState
    {
        public GameStateManager gsm { get; set; }
        public List<int> gambar { get; set; }
        public int x { get; set; }
        public List<karakter> player { get; set; }

        public List<Inventory> battleInv { get; set; }
        public BattleState(GameStateManager gsm)
        {
            player = gsm.player.currentCharacters;

            battleInv = gsm.player.inventoryAktif;
            player = gsm.player.currentCharacters;
            Random r = new Random();
            this.gsm = gsm;
            gambar = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                gambar.Add(r.Next(5) + 1);
            }
            imgLast = (Image)last;
            imgDoor = (Image)door;
            x = 0;
            imgpPlayer = (Image)Properties.Resources.ResourceManager.GetObject("panel_player2");
            imgpInv = (Image)Properties.Resources.ResourceManager.GetObject("panel_inventory");
            //drawInventory();
        }

        public override void init()
        {
            throw new NotImplementedException();
        }
        //{
            object last = Properties.Resources.ResourceManager.GetObject("courtyard_lastfix");
            object door = Properties.Resources.ResourceManager.GetObject("courtyard_doorfix");
            Image imgLast;
            Image imgDoor;
            object O = Properties.Resources.ResourceManager.GetObject("lala");
            Image imgpPlayer;
            Image imgpInv;
        //}
        public override void draw(Graphics g)
        {
            g.ScaleTransform(zoom, zoom);
            g.TranslateTransform(-ox, -oy);

            //last left
            if (x>-450)
            {
                g.DrawImage(imgLast, x + 220, 0, -220, 430);
            }
            //door right
            if (x > -600)
            {
                g.DrawImage(imgDoor, x + 140, 0, 450, 430);
            }
            if (gsm.dungeon.kebalik)
            {
                for (int i = gambar.Count-1; i >=0 ; i--)
                {
                    int tampi = 4 - i;
                    int tmpx = x + 585 + tampi * 449;
                    if (x >= -1000 - (tampi * 449) && tmpx < 1300)
                    {
                        object background_random = Properties.Resources.ResourceManager.GetObject("courtyard_randomfix___" + gambar[i] + "_");
                        Image img = (Image)background_random;
                        g.DrawImage(img, x + 585 + tampi * 449, 0, 450, 430);
                    }
                }
            }
            else
            {
                for (int i = 0; i < gambar.Count; i++)
                {
                    int tmpx = x + 585 + i * 449;
                    if (x >= -1100 - (i * 449) && tmpx < 1300)
                    {
                        object background_random = Properties.Resources.ResourceManager.GetObject("courtyard_randomfix___" + gambar[i] + "_");
                        Image img = (Image)background_random;
                        g.DrawImage(img, x + 585 + i * 449, 0, 450, 430);
                    }
                }
            }
            

            if (x<-1800)
            {
                g.DrawImage(imgLast, x + 950 + 5 * 450, 0, 450, 430);
            }

            if (x<-1500)
            {
                g.DrawImage(imgDoor, x + 580 + 5 * 450, 0, 450, 430);
            }
            

            player[0].getImage(g);
            player[0].hero_move_now++;

            if (zoomin==true)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(opacity, 0, 0, 0)), 0, 0, 1300, 700);
            }

            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("side_decor"), 0, 420, 120, 270);
            g.DrawImage(imgpPlayer, 70 + 22, 420, 528, 100);
            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject(player[0].hero + "_icon"), 135, 440, 68, 68);

            for (int i = 0; i < 4; i++)
            {
                g.DrawImage(player[0].skills[i].icon, 308+55*i, 447, 52, 52);
            }
            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("ability_move"), 308 + 55 * 4, 447, 52, 52);
            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("ability_pass"), 308 + 55 * 5, 447, 10, 52);
            

            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("panel_stat"), 70 + 50, 520, 500, 170);
            g.DrawImage(imgpInv, 70 + 550, 420, 550, 270);
            //MessageBox.Show((Image)imgpInv+"");
            Font font = new Font("Arial", 15.0f);
            if (aktif=="inv")
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if((i * 8) + j < battleInv.Count)
                        {
                            if (battleInv[(i * 8) + j] is Inventory)
                            {

                                g.DrawImage(battleInv[(i * 8) + j].gambar, (float)(640 + j * 61.5), 440 + i * 120, 50, 110);
                                g.DrawString("11", font, new SolidBrush(Color.White), (float)(640 + j * 61.5), 445 + i * 120);
                            }
                        }
                            
                        
                    }
                }
            }
            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("side_decor"), 1285, 420, -120, 270);
            
        }
        string aktif = "inv";
        int opacity = 0;

        bool kiri = false;

        public override void mouse_click(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(x+"");
            Rectangle mouse = new Rectangle(e.X, e.Y, 1, 1);

            if (mouse.IntersectsWith(new Rectangle(x + 250, 150, 200, 250))&&player[0].x==300 )
            {
                c = new Point(500 / 2, 300 / 2);
                zoomin = true;
                if (gsm.dungeon.kebalik)
                {
                    kiri = false;
                }
                else
                {
                    kiri = true;
                }
            }

            if (mouse.IntersectsWith(new Rectangle(x + 700 + 5 * 450, 20, 450, 450)) && player[0].x > 900)
            {
                c = new Point(1000 / 2, 300 / 2);
                zoomin = true;
                if (gsm.dungeon.kebalik)
                {
                    kiri = true;
                }
                else
                {
                    kiri = false;
                }
            }

            if (mouse.IntersectsWith(new Rectangle(1130, 550, 50, 50)))
            {
                imgpInv = (Image)Properties.Resources.ResourceManager.GetObject("panel_map");
                aktif = "map";
            }
            if (mouse.IntersectsWith(new Rectangle(1130, 610, 50, 50)))
            {
                imgpInv = (Image)Properties.Resources.ResourceManager.GetObject("panel_inventory");
                aktif = "inv";
            }
        }
        public override void key_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.D&&x>-2000)
            {
                x -= 10;
                player[0].hero_move = "run";
            }
            else if(e.KeyData == Keys.D&&player[0].x<1050)
            {
                player[0].x += 10;
                player[0].hero_move = "run";
            }
            if (e.KeyData == Keys.A && player[0].x > 300)
            {
                player[0].x -= 10;
                player[0].hero_move = "run";
            }
            else if (e.KeyData == Keys.A&&x<0)
            {
                x += 10;
                player[0].hero_move = "run";
            }
        }
        float zoom = 1;
        Point c;
        float ox = 0;
        float oy = 0;
        bool zoomin = false;
        public override void update()
        {
            if (zoom < 2 && zoomin == true)
            {
                opacity += 25;
                ox = c.X * (zoom - 1f);
                oy = c.Y * (zoom - 1f);
                zoom = (float)(zoom + 0.1);
            }

            if (zoom >= 2)
            {
                if (kiri)
                {
                    gsm.dungeon.ke--;
                }
                gsm.dungeon.myLoc = location.area;
                if (gsm.dungeon.Area_besar[gsm.dungeon.ke].battle == false)
                {
                    gsm.dungeon.myLoc = location.battle;
                    gsm.dungeon.btl = new battle(gsm,gsm.dungeon.Area_besar[gsm.dungeon.ke].imgBack);
                }
            }
        }
        public void reset()
        {
            x = 0;
            player[0].x = 300;
            zoomin = false;
            opacity = 0;
            ox = 0;
            oy = 0;
            zoom = 1;
        }
        public override void key_KeyUp(object sender, KeyEventArgs e)
        {
            player[0].hero_move_now = 1;
            player[0].hero_move = "idle";
        }

        public override void mouse_hover(object sender, MouseEventArgs e)
        {
            
        }

        public override void mouse_leave(object sender, MouseEventArgs e)
        {
            
        }

        private void drawInventory()
        {
            //Config.g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("side_decor"), 0, 420, 120, 270);
            //Config.g.DrawImage(imgpPlayer, 70 + 22, 420, 528, 100);
            //Config.g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("panel_stat"), 70 + 50, 520, 500, 170);
            //Config.g.DrawImage(imgpInv, 70 + 550, 420, 550, 270);
            //Config.g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("side_decor"), 1285, 420, -120, 270);
        }
    }
}
