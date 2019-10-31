using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PV
{
    class Player
    {
        public int gold { get; set; }
        public string name { get; set; }
        public List<karakter> myCharacter { get; set; }
        public karakter[] currentCharacters { get; set; }
        public Inventory[] inventoryAktif { get; set; }


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


