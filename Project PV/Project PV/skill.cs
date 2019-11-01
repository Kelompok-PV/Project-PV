using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PV
{
    public class Skill
    {
        public string nama { get; set; }
        public efek[] skill_efek { get; set; }
        public int[] posisi_skill{ get; set; }
        public status status_skill{ get; set; }

        
    }
    public enum efek
    {
        bless,
        targeted,
        poison,

    }
}
