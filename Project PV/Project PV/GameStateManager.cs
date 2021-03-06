﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace Project_PV
{
    
     class GameStateManager
    {
        public GameState[] gameStates { get; set; }
        public Stage stage { get; set; }
        public Stage dif { get; set; }
        public Player player { get; set; }
        public dungeon dungeon { get; set; }
        //SoundPlayer townMusic;

        public GameStateManager()
        {
            player = new Player();


            this.stage = Stage.title;
            player.myCharacter.Add(new ninja("Hatory"));
            player.myCharacter.Add(new aladin("aladin"));
            player.currentCharacters.Add(player.myCharacter[0]);
            player.currentCharacters.Add(player.myCharacter[1]);
            player.inventoryAktif.Add(new SmallFood(0, 0, 2));
            player.gold = 3000;
            gameStates = new GameState[20];
            loadState(this.stage);

            //townMusic = new SoundPlayer(Properties.Resources.town);
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
                //townMusic.PlayLooping();

            }
            else if (stage == Stage.easyState)
            {
                //townMusic.Stop();
                dungeon = new dungeon(this, 2);
                gameStates[(int)stage] = dungeon;
            }
            else if (stage == Stage.mediumState)
            {
                //townMusic.Stop();
                dungeon = new dungeon(this, 4);
                gameStates[(int)stage] = dungeon;
            }
            else if (stage == Stage.hardState)
            {
                //townMusic.Stop();
                dungeon = new dungeon(this, 6);
                gameStates[(int)stage] = dungeon;
            }
            else if (stage == Stage.sanitarium)
            {
                //Sanitarium bs = new Sanitarium(this);
                //bs.player = player.currentCharacters[0];
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
            else if(stage == Stage.quest)
            {
                gameStates[(int)stage] = new Quest(this);
            }
            else if(stage == Stage.entryNewHero)
            {
                gameStates[(int)stage] = new EntryNewHero(this);
            }
            else if (stage == Stage.provision)
            {
                gameStates[(int)stage] = new Provision(this);
            }
        }

        public void unloadState(Stage stage)
        {
            gameStates[(int)stage] = null;
        }

        public Player getPlayer()
        {
            return this.player;
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
        entryNewHero,
        quest,
        easyState,
        mediumState,
        hardState,
        dungeon,
        gameOver,
        completeStage,
        sanitarium,
        blacksmith,
		abbey,
		guild,
        provision
    }
}
