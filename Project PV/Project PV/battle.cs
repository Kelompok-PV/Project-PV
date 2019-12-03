using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PV
{
    class battle : GameState
    {
        public Image background{ get; set; }
        public List<musuh> musuh { get; set; }
        public karakter player { get; set; }
        GameStateManager gsm;

        public List<int> locSkill { get; set; }

        string aktif = "inv";
        public battle(GameStateManager gsm)
        {
            this.gsm = gsm;
            player = gsm.player.currentCharacters[0];
            musuh = new List<musuh>();
            musuh.Add(new yeti());

            Random r = new Random();
            int ind = r.Next(4) + 1;
            object bcg = Properties.Resources.ResourceManager.GetObject("courtyard_area___" + ind + "_");
            background = (Image)bcg;

            imgpPlayer = (Image)Properties.Resources.ResourceManager.GetObject("panel_player2");
            imgpInv = (Image)Properties.Resources.ResourceManager.GetObject("panel_inventory");

            locSkill = new List<int>();
            locSkill.Add(310);
            locSkill.Add(365);
            locSkill.Add(420);
            locSkill.Add(476);
        }
        Image imgpPlayer;
        Image imgpInv;
        public override void draw(Graphics g)
        {

            g.DrawImage(background, 0, 0, 1300, 450);

            player.getImage(g);
            player.hero_move_now++;

            musuh[0].getImage(g,700);
            musuh[0].tipe_gerak_ke++;


            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("side_decor"), 0, 420, 120, 270);
            g.DrawImage(imgpPlayer, 70 + 22, 420, 528, 100);
            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject(player.hero + "_icon"), 135, 440, 68, 68);

            for (int i = 0; i < 4; i++)
            {
                g.DrawImage(player.skills[i].icon, 308 + 55 * i, 447, 52, 52);
            }
            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("ability_move"), 308 + 55 * 4, 447, 52, 52);
            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("ability_pass"), 308 + 55 * 5, 447, 10, 52);


            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("panel_stat"), 70 + 50, 520, 500, 170);
            g.DrawImage(imgpInv, 70 + 550, 420, 550, 270);
            //MessageBox.Show((Image)imgpInv+"");
            Font font = new Font("Arial", 15.0f);
            if (aktif == "inv")
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("gold"), (float)(640 + j * 61.5), 440 + i * 120, 50, 110);
                        g.DrawString("11", font, new SolidBrush(Color.White), (float)(640 + j * 61.5), 445 + i * 120);
                    }
                }
            }
            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("side_decor"), 1285, 420, -120, 270);


            g.DrawString("ACC        " , new Font("Arial", 12, FontStyle.Regular), new SolidBrush(Color.White),145,587);
            g.DrawString("CRIT       " , new Font("Arial", 12, FontStyle.Regular), new SolidBrush(Color.White),145,602);
            g.DrawString("DMG        " , new Font("Arial", 12, FontStyle.Regular), new SolidBrush(Color.White),145,617);
            g.DrawString("DODGE      " , new Font("Arial", 12, FontStyle.Regular), new SolidBrush(Color.White),145,632);
            g.DrawString("PROT       " , new Font("Arial", 12, FontStyle.Regular), new SolidBrush(Color.White),145,647);

            g.DrawString(acc, new Font("Arial", 12, FontStyle.Regular), new SolidBrush(Color.White),   210, 587);
            g.DrawString(crit, new Font("Arial", 12, FontStyle.Regular), new SolidBrush(Color.White),  210, 602);
            g.DrawString(dmg_min+"-" +dmg_max, new Font("Arial", 12, FontStyle.Regular), new SolidBrush(Color.White),   210, 617);
            g.DrawString(dodge, new Font("Arial", 12, FontStyle.Regular), new SolidBrush(Color.White), 210, 632);
            g.DrawString(prot, new Font("Arial", 12, FontStyle.Regular), new SolidBrush(Color.White),  210, 647);
        }

        string dmg_min =   "10";
        string dmg_max =   "10";
        string acc =   "10";
        string crit =  "10";
        string dodge = "0";
        string prot =  "10";

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
            //MessageBox.Show(e.X+""+e.Y);
            int x = e.X;
            int y = e.Y;
            Rectangle mouse = new Rectangle(x, y, 1, 1);
            for (int i = 0; i < locSkill.Count; i++)
            {
                Rectangle skill = new Rectangle(locSkill[i], 448, 45, 45);
                if (mouse.IntersectsWith(skill))
                {
                    dmg_min = player.skills[i].status_skill.dmg_min+"";
                    dmg_max = player.skills[i].status_skill.dmg_max+"";
                    acc = player.skills[i].status_skill.acc + "";
                    crit = player.skills[i].status_skill.crit + "%";
                    prot = player.skills[i].status_skill.def + "";
                }
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
