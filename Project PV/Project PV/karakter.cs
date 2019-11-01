using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PV
{
    public class karakter
    {
        public int level { get; set; }
        public int hp { get; set; }
        public List<Skill> skills { get; set; }
        public stress hero_stress { get; set; }
        public int hero { get; set; }//hero-hero_move-hero_move_now hero_move_noww++;
        public int hero_move { get; set; }
        public int hero_move_now { get; set; }
        public buff hero_buff { get; set; }
        public equip[] hero_equip { get; set; }
        public string nama { get; set; }
        public string type { get; set; }
        public List<string> dialog { get; set; }
        public int dodge { get; set; }
        public int speed { get; set; }
    }
    public enum buff
    {
        poison,
        bleed
    }
}
