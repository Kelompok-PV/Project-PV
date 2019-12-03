﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PV
{
    class BattleAreaState : GameState
    {
        karakter player = new ninja("ninnin");
        object background = Properties.Resources.ResourceManager.GetObject("courtyard_battleArea_");
        Image imgBack;
        public GameStateManager gsm { get; set; }
        public BattleAreaState(GameStateManager gsm)
        {
            this.gsm = gsm;
            imgBack = (Image)background;

        }

        public override void draw(Graphics g)
        {

            g.DrawImage(imgBack, 0, 0, 1300, 450);

            player.getImage(g);
            player.hero_move_now++;
        }

        public override void init()
        {

        }

        public override void key_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.D && player.x < 1150)
            {
                player.x += 10;
                player.hero_move = "run";
            }
            if (e.KeyData == Keys.A && player.x > 200)
            {
                player.x -= 10;
                player.hero_move = "run";
            }
        }

        public override void key_KeyUp(object sender, KeyEventArgs e)
        {
            player.hero_move_now = 1;
            player.hero_move = "idle";
        }

        public override void mouse_click(object sender, MouseEventArgs e)
        {

        }

        public override void update()
        {
            
        }

        public override void mouse_hover(object sender, MouseEventArgs e)
        {
            
        }

        public override void mouse_leave(object sender, MouseEventArgs e)
        {
           
        }

        
    }
}
