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

        Form1 form;
        public GameStateManager()
        {
            gameStates = new GameState[10];
            this.stage = Stage.mainMenu;
            //this.stage = Stage.battleState;
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
                gameStates[(int)stage] = new BattleState(this);
            }
            else if (stage == Stage.sanitarium)
            {
                gameStates[(int)stage] = new Sanitarium(this);
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
        public void key_keydown(object sender, KeyEventArgs e)
        {
            gameStates[(int)stage].key_keydown(sender, e);
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
        completeStage,
        sanitarium
    }
}
