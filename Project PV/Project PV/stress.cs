using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PV
{
    class stress
    {
        public int stress_point { get; set; }
        public stress_stage stress_level { get; set; }
        enum stress_stage
        {
            normal,
            depresi
        }
    }
}
