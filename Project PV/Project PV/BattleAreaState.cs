using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PV
{
    
    class BattleAreaState : GameState
    {
        public List<karakter> player { get; set; }
        object background = Properties.Resources.ResourceManager.GetObject("courtyard_battleArea_");
        public Image imgBack { get; set; }
        public bool battle { get; set; }
        public List<Inventory> battleInv { get; set; }
        public GameStateManager gsm { get; set; }
        dungeon thisDungeon;
        public List<int> locSkill { get; set; }
        public BattleAreaState(GameStateManager gsm,dungeon dgn)
        {
            locSkill = new List<int>();
            locSkill.Add(310);
            locSkill.Add(365);
            locSkill.Add(420);
            locSkill.Add(476);

            this.gsm = gsm;
            thisDungeon = dgn;
            Random r = new Random();
            int ind = r.Next(4) + 1;
            battle = false;
            battleInv = thisDungeon.battleInv;
            player = gsm.player.currentCharacters;

            object background = Properties.Resources.ResourceManager.GetObject("courtyard_area___"+ind+"_");
            imgBack = (Image)background;

            imgpPlayer = (Image)Properties.Resources.ResourceManager.GetObject("panel_player2");
            imgpInv = (Image)Properties.Resources.ResourceManager.GetObject("panel_inventory");

            dmg_min = player[pilihHero].skills[pilih_attack].status_skill.dmg_min + "";
            dmg_max = player[pilihHero].skills[pilih_attack].status_skill.dmg_max + "";
            acc = player[pilihHero].skills[pilih_attack].status_skill.acc + "";
            crit = player[pilihHero].skills[pilih_attack].status_skill.crit + "%";
            prot = player[pilihHero].skills[pilih_attack].status_skill.def + "";
        }
        public void readInventory()
        {
            battleInv = thisDungeon.battleInv;
        }
        Image imgpPlayer;
        Image imgpInv;
        string aktif = "inv";
        Font font = new Font("Arial", 15.0f);
        public override void draw(Graphics g)
        {

            g.DrawImage(imgBack, 0, 0, 1300, 450);

            for (int i = 0; i < player.Count; i++)
            {
                player[i].getImage(g);
                player[i].hero_move_now++;
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

            if (aktif == "inv")
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if ((i * 8) + j < battleInv.Count)
                        {
                            if (battleInv[(i * 8) + j] is Inventory)
                            {

                                g.DrawImage(battleInv[(i * 8) + j].gambar, (float)(640 + j * 61.5), 440 + i * 120, 50, 110);
                                g.DrawString(battleInv[(i * 8) + j].jumlah+"", font, new SolidBrush(Color.White), (float)(640 + j * 61.5), 445 + i * 120);
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

        public override void init()
        {

        }

        public override void key_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.D && player[0].x < 1150)
            {
                for (int i = 0; i < player.Count; i++)
                {
                    if (i == 0)
                    {
                        player[i].x += 10;
                        player[i].hero_move = "run";
                    }
                    else if (player[i].x +100< player[i - 1].x)
                    {
                        player[i].x += 10;
                        player[i].hero_move = "run";
                    }
                }
            }
            else if(e.KeyData == Keys.D && gsm.dungeon.ke<gsm.dungeon.Area_panjang.Count)
            {
                gsm.dungeon.ke++;
                gsm.dungeon.kebalik = false;
                gsm.dungeon.myLoc = location.jalan;
                gsm.dungeon.Area_panjang[gsm.dungeon.ke - 1].readInventory();
                gsm.dungeon.Area_panjang[gsm.dungeon.ke - 1].reset();
            }
            else if(e.KeyData == Keys.D)
            {
                DialogResult dr = MessageBox.Show("Yakin Keluar","Ke Desa",MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    for (int i = 0; i < gsm.player.currentCharacters.Count; i++)
                    {
                        if (gsm.player.currentCharacters[i].hp <= 0)
                        {
                            gsm.player.currentCharacters.RemoveAt(i);
                            i--;
                        }
                    }
                    for (int i = 0; i < thisDungeon.battleInv.Count; i++)
                    {
                        if(battleInv[i] is Gold)
                        {
                            gsm.player.gold += battleInv[i].jumlah;
                        }
                        if (battleInv[i] is Jewel)
                        {
                            gsm.player.gold += (battleInv[i].jumlah*50);
                        }
                    }
                    gsm.stage = Stage.mainMenu;
                    gsm.loadState(gsm.stage);
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
            else if (e.KeyData == Keys.A&&gsm.dungeon.ke!=0)
            {
                gsm.dungeon.kebalik = true;
                gsm.dungeon.myLoc = location.jalan;
                gsm.dungeon.Area_panjang[gsm.dungeon.ke - 1].readInventory();
                gsm.dungeon.Area_panjang[gsm.dungeon.ke - 1].reset();
            }
        }

        public override void key_KeyUp(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < player.Count; i++)
            {
                player[i].hero_move_now = 1;
                player[i].hero_move = "idle";
            }
        }
        int pilihHero = 0;
        int pilihInv = -1;
        int pilih_attack = 0;
        public override void mouse_click(object sender, MouseEventArgs e)
        {
            Rectangle mouse = new Rectangle(e.X, e.Y, 1, 1);
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

        public override void update()
        {
            thisDungeon.battleInv = battleInv;
        }

        public override void mouse_hover(object sender, MouseEventArgs e)
        {
            
        }

        public override void mouse_leave(object sender, MouseEventArgs e)
        {
           
        }

        
    }
}
