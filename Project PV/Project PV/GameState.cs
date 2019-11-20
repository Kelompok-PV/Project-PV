using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PV
{
    abstract class GameState
    {
        public abstract void init();
        public abstract void draw(Graphics g);
        public abstract void mouse_click(object sender, MouseEventArgs e);
        public abstract void update();
        
        public abstract void key_keydown(object sender, KeyEventArgs e);
    }
}
