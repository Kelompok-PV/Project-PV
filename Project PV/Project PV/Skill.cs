using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PV
{
    public abstract class Skill
    {
        public string name { get; set; }
        public skillEffect effect { get; set; }
        public int damage { get; set; }
        public Image skillIcon { get; set; }
    }
    class Healing : Skill
    {

    }

    public enum skillEffect
    {
        poison,
        bleed,
        targeted
    }
}
