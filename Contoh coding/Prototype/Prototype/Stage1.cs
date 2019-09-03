using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype
{
    class Stage1 : GameState
    {
        public Background background { get; set; }
        public Player player { get; set; }

        private Timer jump,fall;
        public Stage1()
        {
            background = new Background("Underworld 1.png");
            player = new Player();
            jump = new Timer();
            fall = new Timer();
            jump.Enabled = false;
            jump.Interval = 1;
            jump.Tick += new System.EventHandler(jump_tick);
            fall.Enabled = false;
            fall.Interval = 1;
            fall.Tick += new System.EventHandler(fall_tick);
        }

        public override void Draw(Graphics g)
        {
            background.Draw(g);
            player.Draw(g);
        }

        public override void KeyPressed(object sender, KeyEventArgs e)
        {
            
            if(e.KeyData == Keys.D)
            {
                if(background.right != 2045)
                {
                    background.x += 10;
                    background.right+= 10;
                }
                else
                {
                    background.x += 10;
                    background.left += 10;
                }

                if(player.status == Status.idle)
                {
                    player.index = 0;
                    player.setAvatar(player.status = Status.run);
                }

                if (player.status == Status.run)
                {
                    //pergerakan
                    int temp = player.index;
                    temp++;
                    player.setIndex(temp);
                }

            }
            else if (e.KeyData == Keys.A)
            {
                if (background.left != -2045)
                {
                    background.x -= 10;
                    background.left -= 10;
                }
                else
                {
                    background.x -= 10;
                    background.right -= 10;    
                }

                if (player.status == Status.idle)
                {
                    player.index = 0;
                    player.setAvatar(player.status = Status.run);
                }

                if (player.status == Status.run)
                {
                    //pergerakan
                    int temp = player.index;
                    temp--;
                    player.setIndex(temp);
                }
            }
            else if (e.KeyData == Keys.W)
            {
                jump.Enabled = true;
                player.index = 0;
                player.setAvatar(player.status = Status.jump);
            }
        }

        public void jump_tick(object sender, EventArgs e)
        {
            if(player.posY > 0)
            {
                player.posY -=10;
            }
            else
            {
                jump.Enabled = false;
                fall.Enabled = true;
            }
            
        }

        public void fall_tick(object sender, EventArgs e)
        {
            if (player.posY <= 200)
            {
                player.posY += 10;
            }
            else
            {
                fall.Enabled = false;
                player.index = 0;
                player.setAvatar(player.status = Status.idle);
            }

        }

        public override void KeyReleased(object sender, KeyEventArgs e)
        {
            player.setIndex(0);
            if(player.status != Status.jump)
            {
                player.setAvatar(player.status = Status.idle);
            }
            
        }
    }
}
