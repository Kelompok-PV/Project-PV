using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PV
{
    public abstract class Inventory
    {
        public int x { get; set; }
        public int y { get; set; }
        public string name { get; set; }

    }
    class LargeFood : Inventory
    {

    }
}
