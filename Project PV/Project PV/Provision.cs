using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PV
{
    
    class Provision : GameState
    {
        GameStateManager gsm { get; set; }
        public Font title { get; set; }
        public Font ket { get; set; }
        public Rectangle font { get; set; }

        private Player player;

        List<int> posisi = new List<int>();

        List<Rectangle> lisrec = new List<Rectangle>();

        List<Rectangle> lisrecsell = new List<Rectangle>();

        List<Inventory> lisinv = new List<Inventory>();

        List<Inventory> myinv = new List<Inventory>();
        
        List<Image> img = new List<Image>();

        List<bool> hover = new List<bool>();
        public Provision(GameStateManager gsm)
        {
            this.gsm = gsm;
            player = gsm.getPlayer();
            font = new Rectangle(430, 80, 500, 150);
            Config.font.AddFontFile("Resources\\DwarvenAxe BB W00 Regular.ttf");
            title = new Font(Config.font.Families[0], 35, FontStyle.Regular);
            ket = new Font("Arial", 10, FontStyle.Regular);

            backgroundblur = (Image)O1;
            icon = (Image)O2;
            background = (Image)O3;
            character = (Image)O4;
            grid = (Image)O6;
            detail = (Image)O7;

            //gambar item
            cure = (Image)O8;
            salve = (Image)O9;
            sfood = (Image)O10;
            lfood = (Image)O11;
            bandage = (Image)O12;
            jewel = (Image)O13;
            shovel = (Image)O14;
            skelkey = (Image)O15;
            torch = (Image)O16;
            gold = (Image)O17;

            
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    lisrec.Add(new Rectangle(620 + j * 60, 85 + i * 112, 55, 100));
                    lisrecsell.Add(new Rectangle((550 + j * 61), 342 + i * 112, 53, 100));
                    posisi.Add(620 + j * 60); //posx inv
                    posisi.Add(85 + i * 112); //posy inv
                    hover.Add(false);  
                }
            }

            for (int i = 0; i < 10; i++)
            {
                pointer[i] = -1;
            }

            lisinv.Add(new LargeFood(posisi[0], posisi[1], 0));
            lisinv.Add(new SmallFood(posisi[2], posisi[3], 0));
            lisinv.Add(new Torch(posisi[4], posisi[5], 0));
            lisinv.Add(new Bandage(posisi[6], posisi[7], 0));
            lisinv.Add(new Gold(posisi[8], posisi[9], 0));
            lisinv.Add(new Jewel(posisi[10], posisi[11], 0));
            lisinv.Add(new Key(posisi[12], posisi[13], 0));
            lisinv.Add(new Shovel(posisi[14], posisi[15], 0));
            lisinv.Add(new TheCure(posisi[16], posisi[17], 0));
            lisinv.Add(new PotentSalve(posisi[18], posisi[19], 0));

            img.Add(lfood);
            img.Add(sfood);
            img.Add(torch);
            img.Add(bandage);
            img.Add(gold);
            img.Add(jewel);
            img.Add(skelkey);
            img.Add(shovel);
            img.Add(cure);
            img.Add(salve);

            go = new Rectangle(580, 638, 200, 33);
        }
        object O1 = Project_PV.Properties.Resources.provision_background;
        Image backgroundblur;

        object O2 = Project_PV.Properties.Resources.provision_icon;
        Image icon;

        object O3 = Project_PV.Properties.Resources.provision_character_background;
        Image background;

        object O4 = Project_PV.Properties.Resources.provision_character;
        Image character;

        object O5;
        Image img1;

        object O6 = Project_PV.Properties.Resources.inventory_grid_background_party;
        Image grid;

        object O7 = Project_PV.Properties.Resources.ability_none;
        Image detail;

        object O8 = Project_PV.Properties.Resources.inv_estate_the_cure;
        Image cure;
        object O9 = Project_PV.Properties.Resources.inv_provision__0;
        Image salve;
        object O10 = Project_PV.Properties.Resources.inv_provision__1;
        Image sfood;
        object O11 = Project_PV.Properties.Resources.inv_provision__3;
        Image lfood;
        object O12 = Project_PV.Properties.Resources.inv_supply_bandage;
        Image bandage;
        object O13 = Project_PV.Properties.Resources.inv_gem_emerald;
        Image jewel;
        object O14 = Project_PV.Properties.Resources.inv_supply_shovel;
        Image shovel;
        object O15 = Project_PV.Properties.Resources.inv_supply_skeleton_key;
        Image skelkey;
        object O16 = Project_PV.Properties.Resources.inv_supply_torch;
        Image torch;
        object O17 = Project_PV.Properties.Resources.inv_gold__3;
        Image gold;

        int ctr = 0;
        int ceteer = 0;
        bool pilih = false;
        int[] pointer = new int[10];

        int tanda = -1;
        Rectangle go;
        public override void draw(Graphics g)
        {
            g.DrawImage(backgroundblur, 0, 0, 1300, 700);
            g.DrawImage(background, 60, 70, 1000, 500);
            g.DrawImage(icon, 70, 80, 100, 100);
            g.DrawImage(character, 90, 145, 500, 500);
            g.DrawImage(grid, 500, 322, 550, 250);

            Pen pen = new Pen(new SolidBrush(Color.Yellow));
            g.DrawString("Provision", title, new SolidBrush(Color.Yellow), 170, 110);
            g.DrawString("[CLICK] Inventory to sell back", ket, new SolidBrush(Color.Gray), 655, 312);
            Font font = new Font(Config.font.Families[0], 20);
            Font price = new Font(Config.font.Families[0], 12);

            //panel atas
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    g.DrawImage(img[ctr], 620 + j * 60, 85 + i * 112, 55, 100);
                    
                    g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("currency_gold_icon"), 630 + j * 60, 182 + i * 112, 15, 15);
                    g.DrawString(lisinv[ctr].harga + "", price, new SolidBrush(Color.FromArgb(202, 179, 112)), 642 + j * 60, 184 + i * 112);
                    
                    ctr++;
                    if (ctr == 10)
                    {
                        ctr = 0;
                    }                  
                }
            }

            if (pilih)
            {
                //panel bawah
                for (int i = 0; i < 10; i++)
                {
                    if (pointer[i] == 0) {
                        tanda = i;
                        if (lisinv[tanda].jumlah > 0)
                        {
                            g.DrawImage(img[tanda], (float)(550 + pointer[tanda] * 61), 342 + ceteer * 112, 53, 100);
                            if (lisinv[tanda].jumlah > 1)
                            {
                                g.DrawString(lisinv[tanda].jumlah + "", font, new SolidBrush(Color.FromArgb(202, 179, 112)), (float)(552 + pointer[tanda] * 61.5), 345 + ceteer * 112);
                            }
                        }
                    }
                    if (pointer[i] == 1)
                    {
                        tanda = i;
                        if (lisinv[tanda].jumlah > 0)
                        {
                            g.DrawImage(img[tanda], (float)(550 + pointer[tanda] * 61), 342 + ceteer * 112, 53, 100);
                            if (lisinv[tanda].jumlah > 1)
                            {
                                g.DrawString(lisinv[tanda].jumlah + "", font, new SolidBrush(Color.FromArgb(202, 179, 112)), (float)(552 + pointer[tanda] * 61.5), 345 + ceteer * 112);
                            }
                        }
                    }
                    if (pointer[i] == 2)
                    {
                        tanda = i;
                        if (lisinv[tanda].jumlah > 0)
                        {
                            g.DrawImage(img[tanda], (float)(550 + pointer[tanda] * 61), 342 + ceteer * 112, 53, 100);
                            if (lisinv[tanda].jumlah > 1)
                            {
                                g.DrawString(lisinv[tanda].jumlah + "", font, new SolidBrush(Color.FromArgb(202, 179, 112)), (float)(552 + pointer[tanda] * 61.5), 345 + ceteer * 112);
                            }
                        }
                    }
                    if (pointer[i] == 3)
                    {
                        tanda = i;
                        if (lisinv[tanda].jumlah > 0)
                        {
                            g.DrawImage(img[tanda], (float)(550 + pointer[tanda] * 61), 342 + ceteer * 112, 53, 100);
                            if (lisinv[tanda].jumlah > 1)
                            {
                                g.DrawString(lisinv[tanda].jumlah + "", font, new SolidBrush(Color.FromArgb(202, 179, 112)), (float)(552 + pointer[tanda] * 61.5), 345 + ceteer * 112);
                            }
                        }
                    }
                    if (pointer[i] == 4)
                    {
                        tanda = i;
                        if (lisinv[tanda].jumlah > 0)
                        {
                            g.DrawImage(img[tanda], (float)(550 + pointer[tanda] * 61), 342 + ceteer * 112, 53, 100);
                            if (lisinv[tanda].jumlah > 1)
                            {
                                g.DrawString(lisinv[tanda].jumlah + "", font, new SolidBrush(Color.FromArgb(202, 179, 112)), (float)(552 + pointer[tanda] * 61.5), 345 + ceteer * 112);
                            }
                        }
                    }
                    if (pointer[i] == 5)
                    {
                        tanda = i;
                        if (lisinv[tanda].jumlah > 0)
                        {
                            g.DrawImage(img[tanda], (float)(550 + pointer[tanda] * 61), 342 + ceteer * 112, 53, 100);
                            if (lisinv[tanda].jumlah > 1)
                            {
                                g.DrawString(lisinv[tanda].jumlah + "", font, new SolidBrush(Color.FromArgb(202, 179, 112)), (float)(552 + pointer[tanda] * 61.5), 345 + ceteer * 112);
                            }
                        }
                    }
                    if (pointer[i] == 6)
                    {
                        tanda = i;
                        if (lisinv[tanda].jumlah > 0)
                        {
                            g.DrawImage(img[tanda], (float)(550 + pointer[tanda] * 61), 342 + ceteer * 112, 53, 100);
                            if (lisinv[tanda].jumlah > 1)
                            {
                                g.DrawString(lisinv[tanda].jumlah + "", font, new SolidBrush(Color.FromArgb(202, 179, 112)), (float)(552 + pointer[tanda] * 61.5), 345 + ceteer * 112);
                            }
                        }
                    }
                    if (pointer[i] == 7)
                    {
                        tanda = i;
                        if (lisinv[tanda].jumlah > 0)
                        {
                            g.DrawImage(img[tanda], (float)(550 + pointer[tanda] * 61), 342 + ceteer * 112, 53, 100);
                            if (lisinv[tanda].jumlah > 1)
                            {
                                g.DrawString(lisinv[tanda].jumlah + "", font, new SolidBrush(Color.FromArgb(202, 179, 112)), (float)(552 + pointer[tanda] * 61.5), 345 + ceteer * 112);
                            }
                        }
                    }
                    if (pointer[i] == 8)
                    {
                        tanda = i;
                        if (lisinv[tanda].jumlah > 0)
                        {
                            g.DrawImage(img[tanda], (float)(550 + 0 * 61), 342 + ceteer+1 * 112, 53, 100);
                            if (lisinv[tanda].jumlah > 1)
                            {
                                g.DrawString(lisinv[tanda].jumlah + "", font, new SolidBrush(Color.FromArgb(202, 179, 112)), (float)(552 + 0 * 61.5), 345 + ceteer+1 * 112);
                            }
                        }
                    }
                    if (pointer[i] == 9)
                    {
                        tanda = i;
                        if (lisinv[tanda].jumlah > 0)
                        {
                            g.DrawImage(img[tanda], (float)(550 + 1 * 61), 342 + ceteer+1 * 112, 53, 100);
                            if (lisinv[tanda].jumlah > 1)
                            {
                                g.DrawString(lisinv[tanda].jumlah + "", font, new SolidBrush(Color.FromArgb(202, 179, 112)), (float)(552 + 1 * 61.5), 345 + ceteer+1 * 112);
                            }
                        }
                    }
                    
                }
            }

            //panel paling bawah
            O5 = Properties.Resources.ResourceManager.GetObject("progression_bar");
            img1 = (Image)O5;
            g.DrawImage(img1, 0, 622, 1300, 90);

            O5 = Properties.Resources.ResourceManager.GetObject("progression_forward");
            img1 = (Image)O5;
            g.DrawImage(img1, 580, 638, 200, 33);

            Font fonts = new Font(Config.font.Families[0], 28, FontStyle.Regular);
            g.DrawString("Embark", fonts, new SolidBrush(Color.FromArgb(180, 33, 13)), 630, 635);


            for (int i = 0; i < hover.Count; i++)
            {
                if (hover[i])
                {
                    g.DrawImage(detail, lisinv[i].x+60, lisinv[i].y, 100, 100);
                    g.DrawString(lisinv[i].name, price, new SolidBrush(Color.FromArgb(202, 179, 112)), lisinv[i].x + 80, lisinv[i].y+20);
                }
            }

            //gold
            O5 = Properties.Resources.ResourceManager.GetObject("currency_gold_large_icon");
            img1 = (Image)O5;

            g.DrawImage(img1, 109, 605, 66, 66);
            g.DrawString(player.gold.ToString(), fonts, new SolidBrush(Color.FromArgb(202, 179, 112)), 179, 637);
        }

        public override void init()
        {
           
        }

        public override void key_keydown(object sender, KeyEventArgs e)
        {
          
        }

        public override void key_KeyUp(object sender, KeyEventArgs e)
        {
          
        }
        bool beli = false;
        bool jual = false;
        int index = 0;
        int index2 = 0;
        int plus = 0;
        int plus2 = 0;
        public override void mouse_click(object sender, MouseEventArgs e)
        {
            Rectangle cursor = new Rectangle(e.X, e.Y, 10, 10);
            for (int i = 0; i < lisrec.Count; i++)
            {
                if (cursor.IntersectsWith(lisrec[i]))
                {
                    beli = true;
                    index = i; 
                }
            }
            //for (int j = 0; j < lisrecsell.Count; j++)
            //{
            //    if (cursor.IntersectsWith(lisrecsell[j]))
            //    {
            //        jual = true;
            //        index2 = j;
            //        MessageBox.Show(myinv[index2].name);
            //    }

            //}
            if (beli)
            {
                if (lisinv[index].harga <= player.gold)
                {
                    lisinv[index].jumlah++;
                    if (pointer[index] == -1)
                    {
                        pointer[index] = plus;
                        plus++;
                    }
                    myinv.Clear();
                    for (int i = 0; i < lisinv.Count; i++)
                    {
                        if (lisinv[i].jumlah > 0)
                        {
                            myinv.Add(lisinv[i]);
                        }
                    }

                    player.gold -= lisinv[index].harga;
                    beli = false;
                    pilih = true;
                }
                else
                {
                    MessageBox.Show("Gold tidak mencukupi");
                }
            }
            //if (jual)
            //{
            //    if (lisinv[index2].jumlah > 0)
            //    {
            //        lisinv[index2].jumlah--;
            //        player.gold += lisinv[index2].harga;
            //    }
            //    jual = false;
                
            //}
            

            if (cursor.IntersectsWith(go))
            {
                gsm.player.gold = player.gold;
               
                gsm.player.inventoryAktif = myinv;
                
                gsm.stage = gsm.dif;
                gsm.loadState(gsm.stage);
            }
        }

        public override void mouse_hover(object sender, MouseEventArgs e)
        {
            Rectangle cursor = new Rectangle(e.X, e.Y, 1, 1);
            for (int i = 0; i < lisinv.Count; i++)
            {
                if (cursor.IntersectsWith(lisrec[i]))
                {
                    hover[i] = true;
                    //MessageBox.Show(hover[hoverr]+"");
                }
                else
                {
                    hover[i] = false;
                }
            }
        }

        public override void mouse_leave(object sender, MouseEventArgs e)
        {
            
        }

        public override void update()
        {
       
        }
    }
}
