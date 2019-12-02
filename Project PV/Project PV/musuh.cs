using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PV
{
    class musuh
    {
        public int hp { get; set; }
        public List<Skill> skill { get; set; }
        public string tipe { get; set; }
        public string tipe_gerak { get; set; }
        public int tipe_gerak_ke { get; set; }

        public musuh(int hp, List<Skill> skill, string tipe, string tipe_gerak, int tipe_gerak_ke)
        {
            this.hp = hp;
            this.skill = skill;
            this.tipe = tipe;
            this.tipe_gerak = tipe_gerak;
            this.tipe_gerak_ke = tipe_gerak_ke;
        }
    }

    class yeti : musuh
    {
        public yeti(int hp, List<Skill> skill, string tipe, string tipe_gerak, int tipe_gerak_ke)
            : base(100,skill,"yeti","idle",1)
        {
            skill = new List<Skill>();
            skill.Add(new yeti1());
            skill.Add(new yeti2());
            skill.Add(new yeti3());
            skill.Add(new yeti4());
        }
    }
}

