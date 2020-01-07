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
        public List<int> locSkill { get; set; }
        public BattleState(GameStateManager gsm,dungeon dgn)
        {
            locSkill = new List<int>();
            locSkill.Add(310);
            locSkill.Add(365);
            locSkill.Add(420);
            locSkill.Add(476);

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
            for (int i = 0; i < 3; i++)
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

            inv = gsm.player.inventoryAktif;

            dmg_min = player[pilihHero].skills[pilih_attack].status_skill.dmg_min + "";
            dmg_max = player[pilihHero].skills[pilih_attack].status_skill.dmg_max + "";
            acc = player[pilihHero].skills[pilih_attack].status_skill.acc + "";
            crit = player[pilihHero].skills[pilih_attack].status_skill.crit + "%";
            prot = player[pilihHero].skills[pilih_attack].status_skill.def + "";
        }

        int[] walk_and_found = { 1292, 1500, 2000};
        bool[] inv_grab = { false, false, false};
        Inventory[] inv_found = new Inventory[3];
        Rectangle[] inv_found_rect = new Rectangle[3];
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

            //barang jatuh di jalan
            for (int i = 0; i < inv_found.Length; i++)
            {
                if (!inv_grab[i])
                {
                    Image img = inv_found[i].gambar;
                    g.FillRectangle(new SolidBrush(Color.Red), inv_found_rect[i]);
                    g.DrawImage(img, inv_found_rect[i]);
                }
            }

            for (int i = player.Count - 1; i >= 0; i--)
            {
                player[i].getImage(g);
                player[i].hero_move_now++;
            }

            

            if (zoomin==true)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(opacity, 0, 0, 0)), 0, 0, 1300, 700);
            }

            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("side_decor"), 0, 420, 120, 270);
            g.DrawImage(imgpPlayer, 70 + 22, 420, 528, 100);
            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject(player[pilihHero].hero + "_icon"), 135, 440, 68, 68);

            for (int i = 0; i < 4; i++)
            {
                g.DrawImage(player[pilihHero].skills[i].icon, 308 + 55 * i, 447, 52, 52);
            }
            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("ability_move"), 308 + 55 * 4, 447, 52, 52);
            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("ability_pass"), 308 + 55 * 5, 447, 10, 52);

            g.DrawImage((Image)Properties.Resources.pilihSkill, 308 + 55 * pilih_attack, 447, 52, 52);

            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("panel_stat"), 70 + 50, 520, 500, 170);
            g.DrawImage(imgpInv, 70 + 550, 420, 550, 270);

            if (player[pilihHero].hero_equip[0].type != "zonk")
            {
                g.DrawImage(player[pilihHero].hero_equip[0].img, 310, 562, 45, 105);
            }
            if (player[pilihHero].hero_equip[1].type != "zonk")
            {
                g.DrawImage(player[pilihHero].hero_equip[1].img, 373, 562, 45, 105);
            }

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

            

            drawStatus(g);
        }

        string dmg_min = "10";
        string dmg_max = "10";
        string acc = "10";
        string crit = "10";
        string dodge = "0";
        string prot = "10";

        public void drawStatus(Graphics g)
        {

            Font font = new Font("Arial", 15.0f);
            System.Drawing.Brush br = new SolidBrush(System.Drawing.Color.White);

            g.DrawString("ACC        ", new Font("Arial", 12, FontStyle.Regular), br, 145, 587);
            g.DrawString("CRIT       ", new Font("Arial", 12, FontStyle.Regular), br, 145, 602);
            g.DrawString("DMG        ", new Font("Arial", 12, FontStyle.Regular), br, 145, 617);
            g.DrawString("DODGE      ", new Font("Arial", 12, FontStyle.Regular), br, 145, 632);
            g.DrawString("PROT       ", new Font("Arial", 12, FontStyle.Regular), br, 145, 647);

            g.DrawString(acc, new Font("Arial", 12, FontStyle.Regular), br, 210, 587);
            g.DrawString(crit, new Font("Arial", 12, FontStyle.Regular), br, 210, 602);
            g.DrawString(dmg_min + "-" + dmg_max, new Font("Arial", 12, FontStyle.Regular), br, 210, 617);
            g.DrawString(dodge, new Font("Arial", 12, FontStyle.Regular), br, 210, 632);
            g.DrawString(prot, new Font("Arial", 12, FontStyle.Regular), br, 210, 647);

            g.DrawString(player[pilihHero].hp + "/" + player[pilihHero].maxHp, new Font("Arial", 12, FontStyle.Regular), new SolidBrush(System.Drawing.Color.DarkRed), 178, 530);
            g.DrawString(player[pilihHero].hero_stress.stress_point + "/" + 200, new Font("Arial", 12, FontStyle.Regular), br, 178, 550);
            g.DrawString(player[pilihHero].nama, new Font("Arial", 15, FontStyle.Regular), br, 200, 445);
            g.DrawString(player[pilihHero].type, new Font("Arial", 13, FontStyle.Regular), br, 200, 475);
        }

        int pilihHero = 0;
        int pilihInv = -1;
        int pilih_attack = 0;

        string aktif = "inv";
        int opacity = 0;

        bool kiri = false;
        List<Inventory> inv = new List<Inventory>();
        public void readInventory()
        {
            battleInv = thisDungeon.battleInv;
        }
        public override void mouse_click(object sender, MouseEventArgs e)
        {
<<<<<<< HEAD

=======
>>>>>>> 4106bd0cbb7a49230bfaaa0755593c90a71d2900
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

            int index = -1;
            Rectangle cursor = new Rectangle(e.X, e.Y, 10, 10);
            for (int i = 0; i < inv_found_rect.Length; i++)
            {
                if (cursor.IntersectsWith(inv_found_rect[i]) && !inv_grab[i])
                {
                    index = i;
                }
            }

            for (int j = 0; j < inv.Count; j++)
            {
                if(index != -1)
                {
                    if (!inv_grab[index] && (inv_found[index].name == inv[j].name))
                    {
                        inv[j].jumlah += inv_found[index].jumlah;
                        inv_grab[index] = true;
                        MessageBox.Show(string.Format("Selamat anda dapat hadiah {0} sebanyak {1}", inv_found[index].name, inv_found[index].jumlah));
                        index = -1;
                    }
                    else
                    {
                        if (inv.Count < 16)
                        {
                            inv.Add(inv_found[index]);
                            inv_grab[index] = true;
                            MessageBox.Show(string.Format("Selamat anda dapat hadiah {0} sebanyak {1}", inv_found[index].name, inv_found[index].jumlah));
                            index = -1;
                        }
                        else
                        {
                            MessageBox.Show("Inventory full");
                            index = -1;
                        }
                    }
                    gsm.player.inventoryAktif = inv;
                }
            }



            for (int i = 0; i < locSkill.Count; i++)
            {
                Rectangle skill = new Rectangle(locSkill[i], 448, 45, 45);
                if (mouse.IntersectsWith(skill))
                {
                    pilih_attack = i;
                    dmg_min = player[pilihHero].skills[i].status_skill.dmg_min + "";
                    dmg_max = player[pilihHero].skills[i].status_skill.dmg_max + "";
                    acc = player[pilihHero].skills[i].status_skill.acc + "";
                    crit = player[pilihHero].skills[i].status_skill.crit + "%";
                    prot = player[pilihHero].skills[i].status_skill.def + "";
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i * 8) + j < battleInv.Count)
                    {
                        if (battleInv[(i * 8) + j] is Inventory)
                        {
                            Rectangle recInv = new Rectangle((int)(640 + j * 61.5), 440 + i * 120, 50, 110);
                            if (recInv.IntersectsWith(mouse))
                            {
                                pilihInv = (i * 8) + j;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < player.Count; i++)
            {
                Rectangle recPlayer = new Rectangle(player[i].x, 250, 100, 150);
                if (recPlayer.IntersectsWith(mouse))
                {
                    if (pilihInv != -1 && battleInv[pilihInv].item == itemUse.bisa)
                    {
                        battleInv[pilihInv].getEffect(battleInv[pilihInv], player[i]);
                        battleInv[pilihInv].jumlah--;
                        if (battleInv[pilihInv].jumlah <= 0)
                        {
                            battleInv.RemoveAt(pilihInv);
                        }
                        pilihInv = -1;
                    }
                    else
                    {
                        pilihHero = i;

                        dmg_min = player[pilihHero].skills[pilih_attack].status_skill.dmg_min + "";
                        dmg_max = player[pilihHero].skills[pilih_attack].status_skill.dmg_max + "";
                        acc = player[pilihHero].skills[pilih_attack].status_skill.acc + "";
                        crit = player[pilihHero].skills[pilih_attack].status_skill.crit + "%";
                        prot = player[pilihHero].skills[pilih_attack].status_skill.def + "";
                    }
                }
            }
        }
        public override void key_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.D && player[0].x < 500)
            {
                for (int i = 0; i < player.Count; i++)
                {
                    if (i == 0)
                    {
                        player[i].x += 10;
                        player[i].hero_move = "run";
                    }
                    else if (player[i].x + 100 < player[i - 1].x)
                    {
                        player[i].x += 10;
                        player[i].hero_move = "run";
                    }
                }
            }
            else if (e.KeyData == Keys.D&&x>-2000)
            {
                x -= 10;
                for (int i = 0; i < player.Count; i++)
                {
                    player[i].hero_move = "run";
                }
                //buat x barang jatuh
                for (int i = 0; i < inv_found.Length; i++)
                {
                    inv_found[i].x -= 10;
                    inv_found_rect[i].X -= 10;
                }
            }
            else if(e.KeyData == Keys.D&&player[0].x<1050)
            {
                for (int i = 0; i < player.Count; i++)
                {
                    player[i].x += 10;
                    player[i].hero_move = "run";
                }
            }
            if (e.KeyData == Keys.A && player[0].x > 10)
            {
                for (int i = 0; i < player.Count; i++)
                {
                    if (i == 0)
                    {
                        player[i].x -= 10;
                        player[i].hero_move = "run";
                    }
                    else if (player[i].x > 10)
                    {
                        player[i].x -= 10;
                        player[i].hero_move = "run";
                    }
                }
            }
            else if (e.KeyData == Keys.A&&x<0)
            {
                x += 10;
                for (int i = 0; i < player.Count; i++)
                {
                    player[0].hero_move = "run";
                }
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
            for (int i = 0; i < player.Count; i++)
            {
                player[i].x = 300;
            }
            zoomin = false;
            opacity = 0;
            ox = 0;
            oy = 0;
            zoom = 1;
        }
        public override void key_KeyUp(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < player.Count; i++)
            {
                player[i].hero_move_now = 1;
                player[i].hero_move = "idle";
            }
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
