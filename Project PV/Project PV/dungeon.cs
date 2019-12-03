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
        public battle btl { get; set; }
        public int ke{ get; set; }
        public bool kebalik{ get; set; }
        public location myLoc { get; set; }
        public dungeon(GameStateManager gsm,int panjang)
        {
            Area_besar = new List<BattleAreaState>();
            Area_panjang = new List<BattleState>();
            ke = 0;
            kebalik = false;
            myLoc = location.battle;

            btl = new battle(gsm);
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
            
            if (myLoc==location.area)
            {
                Area_besar[ke].draw(g);
            }
            else if (myLoc == location.jalan)
            {
                Area_panjang[ke - 1].draw(g);
            }
            else if (myLoc == location.battle)
            {
                btl.draw(g);
            }
        }

        public override void init()
        {
            
        }

        public override void key_keydown(object sender, KeyEventArgs e)
        {
            if (myLoc == location.area)
            {
                Area_besar[ke].key_keydown(sender,e);
            }
            else if (myLoc == location.jalan)
            {
                Area_panjang[ke - 1].key_keydown(sender, e);
            }
            else if (myLoc == location.battle)
            {
                btl.key_keydown(sender, e);
            }
        }

        public override void key_KeyUp(object sender, KeyEventArgs e)
        {
            if (myLoc == location.area)
            {
                Area_besar[ke].key_KeyUp(sender, e);
            }
            else if (myLoc == location.jalan)
            {
                Area_panjang[ke - 1].key_KeyUp(sender, e);
            }
            else if (myLoc == location.battle)
            {
                btl.key_KeyUp(sender, e);
            }
        }

        public override void mouse_click(object sender, MouseEventArgs e)
        {
            if (myLoc == location.area)
            {
                Area_besar[ke].mouse_click(sender, e);
            }
            else if (myLoc == location.jalan)
            {
                Area_panjang[ke - 1].mouse_click(sender, e);
            }
            else if (myLoc == location.battle)
            {
                btl.mouse_click(sender, e);
            }
        }

        public override void mouse_hover(object sender, MouseEventArgs e)
        {
            if (myLoc == location.area)
            {
                Area_besar[ke].mouse_hover(sender, e);
            }
            else if (myLoc == location.jalan)
            {
                Area_panjang[ke - 1].mouse_hover(sender, e);
            }
            else if (myLoc == location.battle)
            {
                btl.mouse_hover(sender, e);
            }

        }

        public override void mouse_leave(object sender, MouseEventArgs e)
        {
            if (myLoc == location.area)
            {
                Area_besar[ke].mouse_leave(sender, e);
            }
            else if (myLoc == location.jalan)
            {
                Area_panjang[ke - 1].mouse_leave(sender, e);
            }
            else if (myLoc == location.battle)
            {
                btl.mouse_leave(sender, e);
            }
        }

        public override void update()
        {
            if (myLoc == location.area)
            {
                Area_besar[ke].update();
            }
            else if (myLoc == location.jalan)
            {
                Area_panjang[ke - 1].update();
            }
            else if (myLoc == location.battle)
            {
                btl.update();
            }
        }
    }
    enum location
    {
        jalan,
        area,
        battle
    }
}

