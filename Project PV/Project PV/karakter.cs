﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PV
{
    class karakter
    {
        public int level { get; set; }
        public List<Skill> skills { get; set; }
        public stress stress_level { get; set; }
        public stress stress_level { get; set; }
        public int hero { get; set; }
        public int hero_move { get; set; }
        public int hero_move_now { get; set; }
        public buff hero_buff { get; set; }
        public equip[] hero_equip { get; set; }
        public string nama { get; set; }
        public string type { get; set; }
        enum buff
        {
            poison,
            bleed
        }
    }
}
