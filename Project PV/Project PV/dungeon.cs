using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PV
{
    class dungeon : GameState
    {
        public List<BattleAreaState> Area_besar { get; set; }
        public List<BattleState> Area_panjang{ get; set; }
        public bool isAreaBesar { get; set; }
        public int ke{ get; set; }
        public bool kebalik{ get; set; }
        public dungeon(GameStateManager gsm,int panjang)
        {
            Area_besar = new List<BattleAreaState>();
            Area_panjang = new List<BattleState>();
            ke = 0;
            isAreaBesar = true;
            kebalik = false;
            for (int i = 0; i < panjang; i++)
            {
                if (i != 0)
                {
                    Area_panjang.Add(new BattleState(gsm));
                }
                Area_besar.Add(new BattleAreaState(gsm));
            }
        }

        public override void draw(Graphics g)
        {
            if (isAreaBesar)
            {
                Area_besar[ke].draw(g);
            }
            else
            {
                Area_panjang[ke - 1].draw(g);
            }
        }

        public override void init()
        {
            
        }

        public override void key_keydown(object sender, KeyEventArgs e)
        {
            if (isAreaBesar)
            {
                Area_besar[ke].key_keydown(sender, e);
            }
            else
            {
                Area_panjang[ke - 1].key_keydown(sender, e);
            }
        }

        public override void key_KeyUp(object sender, KeyEventArgs e)
        {
            if (isAreaBesar)
            {
                Area_besar[ke].key_KeyUp(sender, e);
            }
            else
            {
                Area_panjang[ke - 1].key_KeyUp(sender, e);
            }
        }

        public override void mouse_click(object sender, MouseEventArgs e)
        {
            if (isAreaBesar)
            {
                Area_besar[ke].mouse_click(sender, e);
            }
            else
            {
                Area_panjang[ke - 1].mouse_click(sender, e);
            }
        }

        public override void mouse_hover(object sender, MouseEventArgs e)
        {
            if (isAreaBesar)
            {
                Area_besar[ke].mouse_hover(sender, e);
            }
            else
            {
                Area_panjang[ke - 1].mouse_hover(sender, e);
            }

        }

        public override void mouse_leave(object sender, MouseEventArgs e)
        {
            if (isAreaBesar)
            {
                Area_besar[ke].mouse_leave(sender, e);
            }
            else
            {
                Area_panjang[ke - 1].mouse_leave(sender, e);
            }
        }

        public override void update()
        {
            if (isAreaBesar)
            {
                Area_besar[ke].update();
            }
            else
            {
                Area_panjang[ke - 1].update();
            }
        }
    }
}
