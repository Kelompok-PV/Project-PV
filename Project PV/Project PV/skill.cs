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
        public int[] rank{ get; set; }
        public int[] target{ get; set; }
        public status status_skill{ get; set; }

        
    }
    public enum efek
    {
        blight ,
        bleed ,
        stun,
        marked
    }
}
