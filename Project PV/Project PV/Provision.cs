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

        List<Inventory> lisinv = new List<Inventory>();

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

            
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    lisrec.Add(new Rectangle(620 + j * 60, 85 + i * 112, 55, 100));
                    posisi.Add(620 + j * 60); //posx inv
                    posisi.Add(85 + i * 112); //posy inv
                }
            }
            lisinv.Add(new LargeFood(posisi[0], posisi[1], 2));
            lisinv.Add(new SmallFood(posisi[2], posisi[3], 1));
            lisinv.Add(new Torch(posisi[4], posisi[5], 3));
            lisinv.Add(new Bandage(posisi[6], posisi[7], 4));
            lisinv.Add(new Gold(posisi[8], posisi[9], 1));
            lisinv.Add(new Jewel(posisi[10], posisi[11], 1));
            lisinv.Add(new Key(posisi[12], posisi[13], 1));
            lisinv.Add(new Shovel(posisi[14], posisi[15], 1));
            lisinv.Add(new TheCure(posisi[16], posisi[17], 1));
            lisinv.Add(new PotentSalve(posisi[18], posisi[19], 1));

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

        int ctr = 0;
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
                    g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("inv_provision__" + 0), 620 + j * 60, 85 + i * 112, 55, 100);
                    g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("currency_gold_icon"), 630 + j * 60, 182 + i * 112, 15, 15);
                    g.DrawString(lisinv[ctr].harga + "", price, new SolidBrush(Color.FromArgb(202, 179, 112)), 642 + j * 60, 184 + i * 112);
                    g.DrawString(lisinv[ctr].jumlah + "", font, new SolidBrush(Color.FromArgb(202, 179, 112)), (float)(622 + j * 61.5), 88 + i * 112);
                    ctr++;
                    if (ctr == 10)
                    {
                        ctr = 0;
                    }   
                }
            }


            //panel bawah
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("inv_provision__1"), (float)(550 + j * 61), 342 + i * 112, 53, 100);
                    g.DrawString("8", font, new SolidBrush(Color.FromArgb(202, 179, 112)), (float)(552 + j * 61.5), 345 + i * 112);
                    
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

            O5 = Properties.Resources.ResourceManager.GetObject("currency_gold_large_icon");
            img1 = (Image)O5;

            g.DrawImage(img1, 109, 605, 66, 66);

            //gold
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
        bool kena = false;
        int index = 0;
        public override void mouse_click(object sender, MouseEventArgs e)
        {
            Rectangle cursor = new Rectangle(e.X, e.Y, 10, 10);
            for (int i = 0; i < lisrec.Count; i++)
            {
                if (cursor.IntersectsWith(lisrec[i]))
                {
                    kena = true;
                    index = i; 
                }
            }
            if (kena)
            {
                if (lisinv[index].jumlah == 0)
                {
                    MessageBox.Show("Habis");
                }
                else
                {
                    player.gold -= lisinv[index].harga;
                    lisinv[index].jumlah -= 1;
                    MessageBox.Show(lisinv[index].name);
                }
                    kena = false;
            }

            if (cursor.IntersectsWith(go))
            {
                gsm.stage = Stage.dungeon;
                gsm.loadState(gsm.stage);
            }
        }

        public override void mouse_hover(object sender, MouseEventArgs e)
        {
         
        }

        public override void mouse_leave(object sender, MouseEventArgs e)
        {
            
        }

        public override void update()
        {
       
        }
    }
}
