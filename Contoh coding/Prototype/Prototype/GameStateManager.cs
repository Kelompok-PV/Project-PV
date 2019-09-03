using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype
{
    class GameStateManager
    {
        public static int jumlahState { get; set; } = 2;
        public int currentState { get; set; }

        public int MenuState { get; set; } = 0;
        public int Stage1 { get; set; } = 1;

        public GameState[] GameState = new GameState[jumlahState];

        public GameStateManager()
        {
            currentState = 0;
            loadState(currentState);
        }

        public void loadState(int currentState)
        {
            if(currentState == MenuState)
            {
                GameState[currentState] = new MenuStage(this);
            }
            else if(currentState == Stage1)
            {
                GameState[currentState] = new Stage1();
            }
        }

        public void Draw(Graphics g)
        {
            GameState[currentState].Draw(g);
        }

        public void KeyPressed(object sender, KeyEventArgs e)
        {
            GameState[currentState].KeyPressed(sender,e);
        }

        public void KeyReleased(object sender, KeyEventArgs e)
        {
            GameState[currentState].KeyReleased(sender,e);
        }
    }
}
