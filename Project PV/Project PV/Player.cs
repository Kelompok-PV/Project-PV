using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Project_PV
{
    
    class Player
    {
        public int gold { get; set; }
        public string name { get; set; }
        public List<karakter> myCharacter { get; set; }
        public List<karakter> currentCharacters { get; set; }
        public List<Inventory> inventoryAktif { get; set; }

        public Player()
        {
            gold = 0;
            name = "yomama";
            myCharacter = new List<karakter>();
            currentCharacters = new List<karakter>();
            inventoryAktif = new List<Inventory>();
        }

        //pas mulai game panggil ini
        private void fillInventory(List<Inventory> inputInventory)
        {
            int ctr = 0;
            int posX = 0;
            int posY = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    inputInventory[ctr].x = posX;
                    inputInventory[ctr].y = posY;
                    inventoryAktif[ctr] = inputInventory[ctr];
                    ctr++;
                    posX += 50;
                }
                posY += 100;
            }
        }
    }
    
}


