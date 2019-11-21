using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PV
{
     class GameStateManager
    {
        public GameState[] gameStates { get; set; }
        public Stage stage { get; set; }
        

        public GameStateManager()
        {
            gameStates = new GameState[8];
            this.stage = Stage.mainMenu;
            loadState(this.stage);
        }

        public void loadState(Stage stage)
        {
            if(stage == Stage.title)
            {
                gameStates[(int)stage] = new MenuState(this);
            }
            else if (stage == Stage.mainMenu)
            {
                gameStates[(int)stage] = new MainMenu(this);
            }
            else if (stage == Stage.battleState)
            {
                gameStates[(int)stage] = new MainMenu(this);
            }
        }

        public void draw(Graphics g)
        {
            gameStates[(int)stage].draw(g);
        }

        public void mouse_click(object sender, MouseEventArgs e)
        {
            gameStates[(int)stage].mouse_click(sender,e);
        }

        public void update()
        {
            gameStates[(int)stage].update();
        }
    }

    public enum Stage
    {
        title,
        mainMenu,
        loadState,
        easyState,
        mediumState,
        hardState,
        battleState,
        gameOver,
        completeStage
    }
}
