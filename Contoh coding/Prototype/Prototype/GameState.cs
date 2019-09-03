using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype
{
    public abstract class GameState
    {
        public abstract void KeyPressed(object sender, KeyEventArgs e);
        public abstract void KeyReleased(object sender, KeyEventArgs e);
        public abstract void Draw(Graphics g);
    }
}
