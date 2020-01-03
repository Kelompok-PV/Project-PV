using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PV
{
    public class equip
    {
        public string nama { get; set; }
        public string type { get; set; }
		public string jenis { get; set; }
        public Image img { get; set; }
      // public status stat_plus { get; set; }
	    public int acc { get; set; }
		public int def { get; set; }
		public int max_dmg { get; set; }
		public int min_dmg { get; set; }
		public int crit { get; set; }
		public equip ()
		{
			
		}
    }


	class melee_arm_1 : equip
	{
		public melee_arm_1() : base()
		{
			this.nama = "Iron Shield";
			this.type = "Melee";
			this.jenis = "armor";
			this.acc = 0;
			this.crit = 2;
			this.def = 4;
			this.max_dmg = 0;
			this.min_dmg = 0;
		}
	}

	class melee_arm_2 : equip
	{
		public melee_arm_2(): base()
		{
			this.nama = "Dragon Scale Armour";
			this.type = "Melee";
			this.jenis = "armor";
			this.acc = 0;
			this.crit = 4;
			this.def = 5;
			this.max_dmg = 2;
			this.min_dmg = 2;
			
		}
	}

	class  melee_weap_1 : equip
	{
		public melee_weap_1() : base()
		{
			this.nama = "Spike";
			this.type = "Melee";
			this.jenis = "weapon";
			this.acc =2;
			this.crit =3;
			this.def = 0;
			this.max_dmg = 4;
			this.min_dmg = 3;
		}
	}
	class melee_weap_2 : equip
	{
		public melee_weap_2() : base()
		{
			this.nama = "Thunder God Hammer";
			this.type = "Melee";
			this.jenis = "weapon";
			this.acc =1;
			this.crit = 5;
			this.def = 0;
			this.max_dmg = 4;
			this.min_dmg = 4;
		}
	}
	class range_arm_1 : equip
	{
		public range_arm_1() : base()
		{
			this.nama = "Thick Cloak";
			this.type = "Range";
			this.jenis = "armor";
			this.acc = 0;
			this.crit = 0;
			this.def = 6;
			this.max_dmg = 1;
			this.min_dmg = 2;
		}
	}
	class range_arm_2 : equip
	{
		public range_arm_2() : base()
		{
			this.nama = "Red Hunter Cloak";
			this.type = "Range";
			this.jenis = "armor";
			this.acc = 2;
			this.crit = 0;
			this.def = 5;
			this.max_dmg = 2;
			this.min_dmg = 2;
		}
	}
	class range_weap_1 : equip
	{
		public range_weap_1() : base()
		{
			this.nama = "Long Bow";
			this.type = "Range";
			this.jenis = "weapon";
			this.acc = 5;
			this.crit = 3;
			this.def = 0;
			this.max_dmg = 0;
			this.min_dmg = 0;
		}
	}
	class range_weap_2 : equip
	{
		public range_weap_2() : base()
		{
			this.nama = "Slingshot";
			this.type = "Range";
			this.jenis = "weapon";
			this.acc = 7;
			this.crit = 2;
			this.def = 0;
			this.max_dmg = 2;
			this.min_dmg = 2;
		}
	}
	class doctor_arm_1 : equip
	{
		public doctor_arm_1() : base()
		{
			this.nama = "Iron Mail";
			this.type = "Doctor";
			this.jenis = "armor";
			this.acc = 0;
			this.crit = 0;
			this.def = 6;
			this.max_dmg = 0;
			this.min_dmg = 3;
		}
	}
	class doctor_arm_2 : equip
	{
		public doctor_arm_2() : base()
		{
			this.nama = "Golden Robe";
			this.type = "Doctor";
			this.jenis = "armor";
			this.acc = 0;
			this.crit = 2;
			this.def = 4;
			this.max_dmg = 1;
			this.min_dmg = 2;
		}
	}
	class doctor_weap_1 : equip
	{
		public doctor_weap_1() : base()
		{
			this.nama = "Midas Gloves";
			this.type = "Doctor";
			this.jenis = "weapon";
			this.acc = 2;
			this.crit = 2;
			this.def = 1;
			this.max_dmg = 1;
			this.min_dmg = 2;
		}
	}
	class doctor_weap_2 : equip
	{
		public doctor_weap_2() : base()
		{
			this.nama = "Aladin's Rope";
			this.type = "Doctor";
			this.jenis = "weapon";
			this.acc = 3;
			this.crit = 3;
			this.def = 0;
			this.max_dmg = 2;
			this.min_dmg = 2;
		}
	}

	class healer_arm_1 : equip
	{
		public healer_arm_1() : base()
		{
			this.nama = "Ice Queen's Crown";
			this.type = "Healer";
			this.jenis = "armor";
			this.acc = 0;
			this.crit = 1;
			this.def = 5;
			this.max_dmg = 1;
			this.min_dmg = 1;
		}
	}
	class healer_arm_2 : equip
	{
		public healer_arm_2() : base()
		{
			this.nama = "Druid Hat";
			this.type = "Healer";
			this.jenis = "armor";
			this.acc = 1;
			this.crit = 1;
			this.def = 4;
			this.max_dmg = 1;
			this.min_dmg = 2;
		}
	}

	class healer_weap_1 : equip
	{
		public healer_weap_1() : base()
		{
			this.nama = "Druid Wand";
			this.type = "Healer";
			this.jenis = "weapon";
			this.acc = 3;
			this.crit = 1;
			this.def = 0;
			this.max_dmg = 1;
			this.min_dmg = 2;
		}
	}

	class healer_weap_2 : equip
	{
		public healer_weap_2() : base()
		{
			this.nama = "Great Sage staf";
			this.type = "Healer";
			this.jenis = "weapon";
			this.acc = 2;
			this.crit = 3;
			this.def = 1;
			this.max_dmg = 0;
			this.min_dmg = 3;
		}
	}
}
