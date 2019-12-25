using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace Project_PV
{
    class battle : GameState
    {
        public Image background{ get; set; }
        public List<musuh> musuh { get; set; }
        public List<karakter> player { get; set; }
        GameStateManager gsm;

        public List<int> locSkill { get; set; }


        string aktif = "inv";

        int pilih_attack = -1;
        bool serang = false;
        bool serang_musuh = false;
        bool delay_aktif = false;

        int pilihHero = 0;
        int pilihMusuh= 0;
        int zoom = 0;
        int zoom_bkg = 0;

        int timer_attack = 0;

        MediaPlayer myPlayer = new MediaPlayer();
        MediaPlayer sfx = new MediaPlayer();

        List<turn> turnAttack = new List<turn>();
        int turn_ke = 0;
        public battle(GameStateManager gsm,Image back)
        {
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            string FileName = string.Format("{0}Resources\\sound\\music\\combat\\battle.wav", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
            myPlayer.Open(new System.Uri(FileName));
            myPlayer.MediaEnded += new EventHandler(Media_Ended);
            myPlayer.Play();


            this.gsm = gsm;
            player = new List<karakter>(); ;
            player.Add(gsm.player.currentCharacters[0]);
            player.Add(gsm.player.currentCharacters[1]);

            musuh = new List<musuh>();
            for (int i = 0; i < 1; i++)
            {
                musuh.Add(new yeti(700+i*100));
                turnAttack.Add(new turn(0, i, musuh[i].speed));
            }


            locSkill = new List<int>();
            locSkill.Add(310);
            locSkill.Add(365);
            locSkill.Add(420);
            locSkill.Add(476);

            for (int i = 0; i < player.Count; i++)
            {
                player[i].x = 350 - 100 * i;
                turnAttack.Add(new turn(1, i, player[i].speed));
            }

            for (int i = 0; i < turnAttack.Count-1; i++)
            {
                for (int j = 0; j < turnAttack.Count - i-1; j++)
                {
                    if (turnAttack[j].speed < turnAttack[j + 1].speed)
                    {

                        turn temp = turnAttack[j];
                        turnAttack[j] = turnAttack[j + 1];
                        turnAttack[j + 1] = temp;
                    }
                }
            }



            background = back;
            imgpPlayer = (Image)Properties.Resources.ResourceManager.GetObject("panel_player2");
            imgpInv = (Image)Properties.Resources.ResourceManager.GetObject("panel_inventory");

            if (turnAttack[0].jenis == 1)
            {
                pilihHero = turnAttack[0].ke;
            }
        }
        Image imgpPlayer;
        Image imgpInv;

        private void Media_Ended(object sender, EventArgs e)
        {
            myPlayer.Position = TimeSpan.Zero;
            myPlayer.Play();
        }

        public override void draw(Graphics g)
        {
            if (!serang&&!serang_musuh)
            {
                g.DrawImage(background, 0, 0, 1300, 450);
            }
            else
            {
                g.DrawImage(background, 0 - zoom_bkg / 2, 0 - zoom_bkg, 1300 + zoom_bkg, 450 + zoom_bkg);
            }

            if (!serang && !serang_musuh)
            {
                musuh[0].getImage(g);
                musuh[0].musuh_move_now++;
            }
            else
            {
                musuh[0].getImageAttack(g, zoom);
            }

            if (!serang && !serang_musuh)
            {
                for (int i = 0; i < player.Count; i++)
                {
                    player[i].getImage(g);
                    player[i].hero_move_now++;
                }
            }
            else
            {
                for (int i = 0; i < player.Count; i++)
                {
                    if (pilihHero != i)
                    {
                        player[i].getImage(g);
                        player[i].hero_move_now++;
                    }
                }
                player[pilihHero].getImageAttack(g,zoom);
            }



            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("side_decor"), 0, 420, 120, 270);
            g.DrawImage(imgpPlayer, 70 + 22, 420, 528, 100);
            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject(player[0].hero + "_icon"), 135, 440, 68, 68);

            for (int i = 0; i < player[pilihHero].skills.Count; i++)
            {
                g.DrawImage(player[pilihHero].skills[i].icon, 308 + 55 * i, 447, 52, 52);
            }
            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("ability_move"), 308 + 55 * 4, 447, 52, 52);
            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("ability_pass"), 308 + 55 * 5, 447, 10, 52);


            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("panel_stat"), 70 + 50, 520, 500, 170);
            g.DrawImage(imgpInv, 70 + 550, 420, 550, 270);
            //MessageBox.Show((Image)imgpInv+"");
            Font font = new Font("Arial", 15.0f);

            System.Drawing.Brush br = new SolidBrush(System.Drawing.Color.White);
            if (aktif == "inv")
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("gold"), (float)(640 + j * 61.5), 440 + i * 120, 50, 110);
                        g.DrawString("11", font, br, (float)(640 + j * 61.5), 445 + i * 120);
                    }
                }
            }
            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("side_decor"), 1285, 420, -120, 270);

            g.DrawString("ACC        " , new Font("Arial", 12, FontStyle.Regular), br,145,587);
            g.DrawString("CRIT       " , new Font("Arial", 12, FontStyle.Regular), br,145,602);
            g.DrawString("DMG        " , new Font("Arial", 12, FontStyle.Regular), br,145,617);
            g.DrawString("DODGE      " , new Font("Arial", 12, FontStyle.Regular), br,145,632);
            g.DrawString("PROT       " , new Font("Arial", 12, FontStyle.Regular), br,145,647);

            g.DrawString(acc, new Font("Arial", 12, FontStyle.Regular), br,   210, 587);
            g.DrawString(crit, new Font("Arial", 12, FontStyle.Regular), br,  210, 602);
            g.DrawString(dmg_min+"-" +dmg_max, new Font("Arial", 12, FontStyle.Regular), br,   210, 617);
            g.DrawString(dodge, new Font("Arial", 12, FontStyle.Regular), br, 210, 632);
            g.DrawString(prot, new Font("Arial", 12, FontStyle.Regular), br,  210, 647);

            g.DrawString(player[pilihHero].hp+"/"+player[pilihHero].maxHp, new Font("Arial", 12, FontStyle.Regular), new SolidBrush(System.Drawing.Color.DarkRed), 178 ,530);
            g.DrawString(player[pilihHero].hero_stress.stress_point+"/"+200, new Font("Arial", 12, FontStyle.Regular), br, 178 ,550);
            
            g.DrawString(player[pilihHero].nama, new Font("Arial", 15, FontStyle.Regular), br, 200, 445);
            g.DrawString(player[pilihHero].type, new Font("Arial", 13, FontStyle.Regular), br, 200, 475);

            g.DrawString(musuh[0].hp+"", new Font("Arial", 13, FontStyle.Regular), br, 700, 400);
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
            //MessageBox.Show(e.X + "" + e.Y);
            int x = e.X;
            int y = e.Y;
            Rectangle mouse = new Rectangle(x, y, 1, 1);
            for (int i = 0; i < locSkill.Count; i++)
            {
                Rectangle skill = new Rectangle(locSkill[i], 448, 45, 45);
                if (mouse.IntersectsWith(skill))
                {
                    pilih_attack = i;
                    dmg_min = player[pilihHero].skills[i].status_skill.dmg_min+"";
                    dmg_max = player[pilihHero].skills[i].status_skill.dmg_max+"";
                    acc =  player[pilihHero].skills[i].status_skill.acc + "";
                    crit = player[pilihHero].skills[i].status_skill.crit + "%";
                    prot = player[pilihHero].skills[i].status_skill.def + "";
                }
            }
            //for (int i = 0; i < musuh.Count; i++)
            //{
            Rectangle recMusuh = new Rectangle(700, 250, 100, 150);
            if (mouse.IntersectsWith(recMusuh))
            {

                if (pilih_attack != -1 && serang == false && serang_musuh == false)
                {
                    Random r = new Random();
                    int dmg_atk = r.Next(player[pilihHero].skills[pilih_attack].status_skill.dmg_min, player[pilihHero].skills[pilih_attack].status_skill.dmg_max + 1);
                    musuh[0].hp -= dmg_atk;
                    serang = true;
                    player[pilihHero].x = 520;
                    player[pilihHero].hero_move = "skill" + (pilih_attack + 1);
                    player[pilihHero].hero_move_now = 1;
                    //sfx= new SoundPlayer(Properties.Resources.ninja_attack_1);
                    //sfx.LoadAsync();

                    sfx.Stop();
                    string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
                    string FileName = string.Format("{0}Resources\\char_share_imp_sword.wav", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
                    sfx.Open(new System.Uri(FileName));
                    sfx.Play();
                }
            }
            //}

            for (int i = 0; i < player.Count; i++)
            {
                Rectangle recPlayer = new Rectangle(player[i].x, 250, 100, 150);
                if (recPlayer.IntersectsWith(mouse))
                {
                    pilihHero = i;
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
            if (zoom <= 80 && (serang == true || serang_musuh == true))
            {
                zoom += 30;
                zoom_bkg += 70;
            }

            if (serang)
            {
                timer_attack++;
                player[pilihHero].x += 1;
            }

            if (serang_musuh)
            {
                timer_attack++;
                musuh[0].x -= 1;
            }
            if (timer_attack == 30 && serang == true)
            {
                timer_attack = 0;
                zoom = 0;
                zoom_bkg = 0;
                player[pilihHero].x = 350 - 100 * pilihHero;
                player[pilihHero].hero_move = "idle";
                player[pilihHero].hero_move_now = 1;
                serang = false;
                if (musuh[0].hp <= 0)
                {
                    gsm.dungeon.myLoc = location.area;
                    gsm.dungeon.Area_besar[gsm.dungeon.ke].battle = true;
                }
                gantiTurn();
            }

            if (timer_attack == 30 && serang_musuh == true)
            {
                timer_attack = 0;
                zoom = 0;
                zoom_bkg = 0;
                musuh[pilihMusuh].x = 700;
                musuh[pilihMusuh].musuh_move = "idle";
                musuh[pilihMusuh].musuh_move_now = 1;
                serang_musuh = false;
                player[pilihHero].x = 350 - 100 * pilihHero;
                gantiTurn();

              
            }

            if (delay_aktif)
            {
                timer_attack++;
                if (timer_attack == 30)
                {
                    Random r = new Random();
                    int pilih_attack_musuh = r.Next(0, 4);
                    int dmg_atk = r.Next(musuh[0].skill[pilih_attack_musuh].status_skill.dmg_min, musuh[0].skill[pilih_attack_musuh].status_skill.dmg_max + 1);
                    player[pilihHero].hp -= dmg_atk;
                    musuh[pilihMusuh].x = 650;
                    player[pilihHero].x = 350 - 100 * pilihHero;
                    musuh[pilihMusuh].musuh_move = "attack";
                    musuh[pilihMusuh].musuh_move_now = 1;
                    delay_aktif = false;
                    timer_attack = 0;
                    serang_musuh = true;
                    sfx.Stop();
                    string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
                    string FileName = string.Format("{0}Resources\\yeti_attack_sfx_1.wav", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
                    sfx.Open(new System.Uri(FileName));
                    sfx.Play();

                }
            }
        }

        public void gantiTurn()
        {
            try
            {
                turn_ke++;
                if (turnAttack[turn_ke].jenis == 1)
                {
                    pilihHero = turnAttack[turn_ke].ke;
                }
                else
                {
                    delay_aktif = true;
                }
            }
            catch (Exception)
            {

                turn_ke = 0;

                if (turnAttack[turn_ke].jenis == 1)
                {
                    pilihHero = turnAttack[turn_ke].ke;
                }
                else
                {
                    delay_aktif = true;
                }
            }
        }
    }

    public class turn
    {
        public int jenis { get; set; }
        public int ke { get; set; }
        public int speed { get; set; }
        public turn(int jenis, int ke,int speed)
        {
            this.jenis = jenis;
            this.ke = ke;
            this.speed = speed;
        }
    }
}
