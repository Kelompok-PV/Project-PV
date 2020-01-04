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
        dungeon thisDungeon;
        public BattleState(GameStateManager gsm,dungeon dgn)
        {
            player = gsm.player.currentCharacters;
            thisDungeon = dgn;
            battleInv = dgn.battleInv;
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

            //random barang jatuh
            for (int i = 0; i < 5; i++)
            {
                int typeInv = rand.Next(10);
                if (typeInv == 0) { int jumlah = rand.Next(1, 8); inv_found[i] = new LargeFood(walk_and_found[i], 334, jumlah); inv_found_rect[i] = new Rectangle(walk_and_found[i], 334, 50, 50); }
                else if (typeInv == 1) { int jumlah = rand.Next(1, 8); inv_found[i] = new LargeFood(walk_and_found[i], 334, jumlah); inv_found_rect[i] = new Rectangle(walk_and_found[i], 334, 50, 50); }
                else if (typeInv == 2) { int jumlah = rand.Next(1, 8); inv_found[i] = new SmallFood(walk_and_found[i], 334, jumlah); inv_found_rect[i] = new Rectangle(walk_and_found[i], 334, 50, 50); }
                else if (typeInv == 3) { int jumlah = rand.Next(1, 8); inv_found[i] = new Torch(walk_and_found[i], 334, jumlah); inv_found_rect[i] = new Rectangle(walk_and_found[i], 334, 50, 50); }
                else if (typeInv == 4) { int jumlah = rand.Next(1, 8); inv_found[i] = new Bandage(walk_and_found[i], 334, jumlah); inv_found_rect[i] = new Rectangle(walk_and_found[i], 334, 50, 50); }
                else if (typeInv == 5) { int jumlah = rand.Next(1, 8); inv_found[i] = new Gold(walk_and_found[i], 334, jumlah); inv_found_rect[i] = new Rectangle(walk_and_found[i], 334, 50, 50); }
                else if (typeInv == 6) { int jumlah = rand.Next(1, 8); inv_found[i] = new Jewel(walk_and_found[i], 334, jumlah); inv_found_rect[i] = new Rectangle(walk_and_found[i], 334, 50, 50); }
                else if (typeInv == 7) { int jumlah = rand.Next(1, 8); inv_found[i] = new Key(walk_and_found[i], 334, jumlah); inv_found_rect[i] = new Rectangle(walk_and_found[i], 334, 50, 50); }
                else if (typeInv == 8) { int jumlah = rand.Next(1, 8); inv_found[i] = new Shovel(walk_and_found[i], 334, jumlah); inv_found_rect[i] = new Rectangle(walk_and_found[i], 334, 50, 50); }
                else if (typeInv == 9) { int jumlah = rand.Next(1, 8); inv_found[i] = new TheCure(walk_and_found[i], 334, jumlah); inv_found_rect[i] = new Rectangle(walk_and_found[i], 334, 50, 50); }
            }
        }

        int[] walk_and_found = { 1292, 2584, 3876, 5168, 6460 };
        bool[] inv_grab = { false, false, false, false, false};
        Inventory[] inv_found = new Inventory[5];
        Rectangle[] inv_found_rect = new Rectangle[5];
        Random rand = new Random();
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
                                g.DrawString(battleInv[(i * 8) + j].jumlah + "", font, new SolidBrush(Color.White), (float)(640 + j * 61.5), 445 + i * 120);
                            }
                        }
                            
                        
                    }
                }
            }
            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("side_decor"), 1285, 420, -120, 270);

            //barang jatuh di jalan
            for (int i = 0; i < inv_found.Length; i++)
            {
                if (!inv_grab[i])
                {
                    Image img = Properties.Resources.inv_provision__3;
                    g.FillRectangle(new SolidBrush(Color.Red), inv_found_rect[i]);
                    g.DrawImage(img, inv_found_rect[i]);
                }
            }
        }
        string aktif = "inv";
        int opacity = 0;

        bool kiri = false;
        public void readInventory()
        {
            battleInv = thisDungeon.battleInv;
        }
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

            Rectangle cursor = new Rectangle(e.X, e.Y, 10, 10);
            for (int i = 0; i < inv_found_rect.Length; i++)
            {
                if (cursor.IntersectsWith(inv_found_rect[i]))
                {
                    if (!inv_grab[i])
                    {
                        //TODO masukan kedalam inventori player
                        Inventory[] inv = new Inventory[16];
                        //inv = gsm.player.inventoryAktif;
                        for (int j = 0; j < inv.Length; j++)
                        {
                            if (inv[j] != null && (inv_found[i].name == inv[j].name))
                            {
                                inv[j].jumlah += inv_found[i].jumlah;
                            }
                            else
                            {
                                if (inv.Length < 16)
                                {
                                    inv[inv.Length - 1] = inv_found[i];
                                }
                                else
                                {
                                    MessageBox.Show("Inventory full");
                                }
                            }
                        }
                        //gsm.player.inventoryAktif = inv;
                        inv_grab[i] = true;
                        MessageBox.Show(string.Format("Selamat anda dapat hadiah {0} sebanyak {1}", inv_found[i].name, inv_found[i].jumlah));
                    }
                }
                
               
            }
        }
        public override void key_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.D&&x>-2000)
            {
                x -= 10;
                player[0].hero_move = "run";
                //buat x barang jatuh
                for (int i = 0; i < inv_found.Length; i++)
                {
                    inv_found[i].x -= 10;
                    inv_found_rect[i].X -= 10;
                }
            }
            else if(e.KeyData == Keys.D&&player[0].x<1050)
            {
                player[0].x += 10;
                player[0].hero_move = "run";
                //buat x barang jatuh
                for (int i = 0; i < inv_found.Length; i++)
                {
                    inv_found[i].x += 10;
                    inv_found_rect[i].X += 10;
                }
            }
            if (e.KeyData == Keys.A && player[0].x > 300)
            {
                player[0].x -= 10;
                player[0].hero_move = "run";
                //buat x barang jatuh
                for (int i = 0; i < inv_found.Length; i++)
                {
                    inv_found[i].x -= 10;
                    inv_found_rect[i].X -= 10;
                }
            }
            else if (e.KeyData == Keys.A&&x<0)
            {
                x += 10;
                player[0].hero_move = "run";
                //buat x barang jatuh
                for (int i = 0; i < inv_found.Length; i++)
                {
                    inv_found[i].x += 10;
                    inv_found_rect[i].X += 10;
                }
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
                thisDungeon.battleInv = battleInv;
                gsm.dungeon.myLoc = location.area;
                
                if (gsm.dungeon.Area_besar[gsm.dungeon.ke].battle == false)
                {
                    gsm.dungeon.myLoc = location.battle;
                    gsm.dungeon.btl = new battle(gsm,gsm.dungeon.Area_besar[gsm.dungeon.ke].imgBack,thisDungeon);
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
