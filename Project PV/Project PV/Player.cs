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
        public Inventory[,] inventoryAktif { get; set; }
    }
    public enum skillEffect
    {
        poison,
        bleed,
        targeted
    }
}
