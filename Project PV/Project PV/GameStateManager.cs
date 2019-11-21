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
            gameStates = new GameState[11];
            //this.stage = Stage.sanitarium;
            this.stage = Stage.blacksmith;
            //this.stage = Stage.battleState;
            //gameStates = new GameState[8];
            //this.stage = Stage.title;
            //this.stage = Stage.battleState;
            //this.stage = Stage.battleState;
            gameStates = new GameState[20];
            this.stage = Stage.title;
            //this.stage = Stage.battleState;
            //this.stage = Stage.battleState;
			//this.stage = Stage.battleState;
			// this.stage = Stage.battleState;
			//this.stage = Stage.mainMenu;
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
            else if (stage == Stage.blacksmith)
            {
                gameStates[(int)stage] = new Blacksmith(this);
            }

			else if(stage == Stage.abbey)
			{
				gameStates[(int)stage] = new Abbey(this);
			}
			else if(stage == Stage.guild)
			{
				gameStates[(int)stage] = new Guild(this);
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

        public void mouse_hover(object sender, MouseEventArgs e)
        {
            gameStates[(int)stage].mouse_hover(sender, e);
        }

        public void mouse_leave(object sender, MouseEventArgs e)
        {
            gameStates[(int)stage].mouse_leave(sender, e);
        }

        public void key_keydown(object sender, KeyEventArgs e)
        {
            gameStates[(int)stage].key_keydown(sender, e);
        }
        public void update()
        {
            gameStates[(int)stage].update();
        }
        public void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            gameStates[(int)stage].key_KeyUp(sender, e);
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
        sanitarium,
        blacksmith,
		abbey,
		guild
    }
}
