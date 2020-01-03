using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PV
{
    
    class status
    {
        public int dmg_min { get; set; }
        public int dmg_max { get; set; }
        public int crit { get; set; }
        public int acc { get; set; }
        public int def { get; set; }
        public int jumlah { get; set; }
        public status()
        {
        }
            public status(int dmg_min, int dmg_max, int crit, int acc, int def, int jumlah)
        {
            this.dmg_min = dmg_min;
            this.dmg_max = dmg_max;
            this.crit = crit;
            this.acc = acc;
            this.def = def;
            this.jumlah = jumlah;
        }
    }
}
