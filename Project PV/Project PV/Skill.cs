using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Project_PV
{
    public class Skill
    {
        public string nama { get; set; }
        public efek[] skill_efek { get; set; }
        public int[] rank{ get; set; }
        public int accuracy { get; set; }
        public int crit_mod { get; set; }
        public int[] target{ get; set; }
        public status status_skill{ get; set; }
        public int efek_kena { get; set; }
        public Image icon { get; set; }
        public int max_damage { get; set; }
        public int min_damage { get; set; }

        public Skill(string nama, efek[] skill_efek, int[] rank, int[] target, status status_skill, int efek_kena)
        {
            this.nama = nama;
            this.skill_efek = skill_efek;
            this.rank = rank;
            this.target = target;
            this.status_skill = status_skill;
            this.efek_kena = efek_kena;
        }
        public Skill()
        {

        }
        
    }
    public class noxius_blast : Skill
    {
        public noxius_blast()
           : base("Noxius Blast", new efek[1], new int[4], new int[4], new status(), 10)
        {

            rank[0] = 1; rank[1] = 1; rank[2] = 1; rank[3] = 0;
            target[0] = 1; target[1] = 1; target[2] = 0; target[3] = 0;
            status_skill = new status(2, 4, 20, 70, 0, -1);
            skill_efek[0] = efek.blight;
            icon = Properties.Resources.plague_doctor_ability_noxious_blast;
        }
    }

    public class incision : Skill
    {
        public incision()
           : base("Incision", new efek[1], new int[4], new int[4], new status(), 10)
        {
            rank[0] = 0; rank[1] = 1; rank[2] = 1; rank[3] = 1;
            target[0] = 1; target[1] = 1; target[2] = 0; target[3] = 0;
            status_skill = new status(0, 1, 20, 60, 0, -1);
            skill_efek[0] = efek.blight;
            icon = Properties.Resources.plague_doctor_ability_incision;
        }
    }

    public class battlefield_medicine : Skill
    {
        public battlefield_medicine()
           : base("Battlefield Medicine", new efek[1], new int[4], new int[4], new status(), 10)
        {
            rank[0] = 1; rank[1] = 1; rank[2] = 0; rank[3] = 0;
            target[0] = 1; target[1] = 1; target[2] = 1; target[3] = 1;
            status_skill = new status(1, 2, 20, 100, 0, -1);
            skill_efek[0] = efek.blight;
            icon = Properties.Resources.plague_doctor_ability_battlefield_medicine;
        }
    }

    public class bliding_gas : Skill
    {
        public bliding_gas()
           : base("Bliding Gas", new efek[1], new int[4], new int[4], new status(), 100)
        {
            rank[0] = 1; rank[1] = 1; rank[2] = 0; rank[3] = 0;
            target[0] = 0; target[1] = 0; target[2] = 1; target[3] = 1;
            status_skill = new status(3, 4, 20, 70, 0, 3);
            skill_efek[0] = efek.stun;
            icon = Properties.Resources.plague_doctor_ability_blinding_gas;
        }
    }

    public class divine_grace : Skill
    {
        public divine_grace()
           : base("Divine Grace", new efek[1], new int[4], new int[4], new status(), 100)
        {
            rank[0] = 1; rank[1] = 1; rank[2] = 0; rank[3] = 0;
            target[0] = 1; target[1] = 1; target[2] = 1; target[3] = 1;
            status_skill = new status(4, 5, 20, 100, 0, -1);
            //skill_efek[0] = efek.stun; 
            icon = Properties.Resources.vestal_ability_divine_grace;
        }
    }

    public class divine_comfort : Skill
    {
        public divine_comfort()
           : base("Divine Comfort", new efek[1], new int[4], new int[4], new status(), 100)
        {
            rank[0] = 1; rank[1] = 1; rank[2] = 1; rank[3] = 0;
            target[0] = 1; target[1] = 1; target[2] = 1; target[3] = 1;
            status_skill = new status(1, 3, 20, 100, 0, -1);
            //skill_efek[0] = efek.stun; 
            icon = Properties.Resources.vestal_ability_divine_comfort;
        }
    }

    public class dazzling_light : Skill
    {
        public dazzling_light()
           : base("Dazzling Light", new efek[1], new int[4], new int[4], new status(), 100)
        {
            rank[0] = 1; rank[1] = 1; rank[2] = 1; rank[3] = 0;
            target[0] = 1; target[1] = 1; target[2] = 1; target[3] = 0;
            status_skill = new status(1, 2, 20, 65, 0, -1);
            skill_efek[0] = efek.stun;
            icon = Properties.Resources.vestal_ability_dazzling_light;
        }
    }

    public class judgement : Skill
    {
        public judgement()
           : base("Judgement", new efek[1], new int[4], new int[4], new status(), 100)
        {
            rank[0] = 1; rank[1] = 1; rank[2] = 0; rank[3] = 0;
            target[0] = 1; target[1] = 1; target[2] = 1; target[3] = 1;
            status_skill = new status(1, 3, 20, 55, 0, -1);
            //skill_efek[0] = efek.stun; 
            icon = Properties.Resources.vestal_ability_judgement;
        }
    }

    public class smite : Skill
    {
        public smite()
           : base("Smite", new efek[1], new int[4], new int[4], new status(), 0)
        {
            rank[0] = 0; rank[1] = 0; rank[2] = 1; rank[3] = 1;
            target[0] = 1; target[1] = 1; target[2] = 0; target[3] = 0;
            status_skill = new status(6, 8, 0, 70, 0, -1);
            skill_efek[0] = efek.stun; 
            icon = Properties.Resources.crusader_ability_smite;
        }
    }

    public class zealous_accusation : Skill
    {
        public zealous_accusation()
           : base("Divine Comfort", new efek[1], new int[4], new int[4], new status(), 100)
        {
            rank[0] = 0; rank[1] = 0; rank[2] = 1; rank[3] = 1;
            target[0] = 1; target[1] = 1; target[2] = 0; target[3] = 0;
            status_skill = new status(3, 4, 0, 60, 0, -1);
            skill_efek[0] = efek.stun;
            icon = Properties.Resources.crusader_ability_zealous_accusation;
        }
    }

    public class holy_lance : Skill
    {
        public holy_lance()
           : base("Holy Lance", new efek[1], new int[4], new int[4], new status(), 100)
        {
            rank[0] = 1; rank[1] = 1; rank[2] = 0; rank[3] = 0;
            target[0] = 0; target[1] = 1; target[2] = 1; target[3] = 1;
            status_skill = new status(3, 4, 22, 55, 0, -1);
            //skill_efek[0] = efek.stun; 
            icon = Properties.Resources.crusader_ability_holy_lance;
        }
    }
    public class inspiring_cry : Skill
    {
        public inspiring_cry()
           : base("Inspiring Cry", new efek[1], new int[4], new int[4], new status(), 0)
        {
            rank[0] = 1; rank[1] = 1; rank[2] = 1; rank[3] = 1;
            target[0] = 1; target[1] = 1; target[2] = 1; target[3] = 1;
            status_skill = new status(0, 1, 0, 100, 0, -1);
            skill_efek[0] = efek.stress;
            icon = Properties.Resources.crusader_ability_inspiring_cry;
        }
    }

    public class pierce : Skill
    {
        public pierce()
           : base("Pierce", new efek[1], new int[4], new int[4], new status(), 0)
        {
            rank[0] = 0; rank[1] = 1; rank[2] = 1; rank[3] = 1;
            target[0] = 1; target[1] = 1; target[2] = 1; target[3] = 1;
            status_skill = new status(5, 7, 20, 60, 0, -1);
            skill_efek[0] = efek.armor;
            icon = Properties.Resources.shieldbreaker_ability_pierce;
        }
    }

    public class adders_kiss : Skill
    {
        public adders_kiss()
           : base("Adder's Kiss", new efek[1], new int[4], new int[4], new status(), 0)
        {
            rank[0] = 0; rank[1] = 0; rank[2] = 0; rank[3] = 1;
            target[0] = 1; target[1] = 1; target[2] = 0; target[3] = 0;
            status_skill = new status(4, 6, 20, 60, 0, -1);
            skill_efek[0] = efek.blight;
            icon = Properties.Resources.shieldbreaker_ability_adder_kiss;
        }
    }

    public class captivate : Skill
    {
        public captivate()
           : base("Captivate", new efek[1], new int[4], new int[4], new status(), 0)
        {
            rank[0] = 0; rank[1] = 1; rank[2] = 1; rank[3] = 0;
            target[0] = 0; target[1] = 1; target[2] = 1; target[3] = 0;
            status_skill = new status(2, 4, 20, 60, 0, -1);
            skill_efek[0] = efek.marked;
            icon = Properties.Resources.shieldbreaker_ability_captivate;
        }
    }

    public class impale : Skill
    {
        public impale()
           : base("Impale", new efek[1], new int[4], new int[4], new status(), 0)
        {
            rank[0] = 0; rank[1] = 0; rank[2] = 0; rank[3] = 1;
            target[0] = 1; target[1] = 1; target[2] = 1; target[3] = 1;
            status_skill = new status(4, 6, 22, 60, 0, -1);
            //skill_efek[0] = efek.; 
            icon = Properties.Resources.shieldbreaker_ability_impale;
        }
    }

    public class yeti1 : Skill
    {
        public yeti1()
           : base("yeti1", new efek[1], new int[4], new int[4], new status(), 100)
        {
            rank[0] = 1; rank[1] = 1; rank[2] = 0; rank[3] = 0;
            target[0] = 0; target[1] = 0; target[2] = 1; target[3] = 1;
            status_skill = new status(3, 4, 20, 70, 0, 3);
            skill_efek[0] = efek.stun; 
            icon = Properties.Resources.yeti_attack___1_;
        }
    }
    public class yeti2 : Skill
    {
        public yeti2()
           : base("yeti2", new efek[1], new int[4], new int[4], new status(), 100)
        {
            rank[0] = 1; rank[1] = 1; rank[2] = 0; rank[3] = 0;
            target[0] = 0; target[1] = 0; target[2] = 1; target[3] = 1;
            status_skill = new status(3, 4, 20, 70, 0, 3);
            skill_efek[0] = efek.stun;
            icon = Properties.Resources.yeti_attack___2_;
        }
    }
    public class yeti3 : Skill
    {
        public yeti3()
           : base("yeti3", new efek[1], new int[4], new int[4], new status(), 100)
        {
            rank[0] = 1; rank[1] = 1; rank[2] = 0; rank[3] = 0;
            target[0] = 0; target[1] = 0; target[2] = 1; target[3] = 1;
            status_skill = new status(3, 4, 20, 70, 0, 3);
            skill_efek[0] = efek.stun;
            icon = Properties.Resources.yeti_attack___3_;
        }
    }
    public class yeti4 : Skill
    {
        public yeti4()
           : base("yeti4", new efek[1], new int[4], new int[4], new status(), 100)
        {
            rank[0] = 1; rank[1] = 1; rank[2] = 0; rank[3] = 0;
            target[0] = 0; target[1] = 0; target[2] = 1; target[3] = 1;
            status_skill = new status(3, 4, 20, 70, 0, 3);
            skill_efek[0] = efek.stun;
            icon = Properties.Resources.yeti_attack___4_;
        }
    }
    public class Boarman1 : Skill
    {
        public Boarman1()
        {
            nama = "boarman1";
            rank = new int[3];
            rank[0] = 1;
            rank[1] = 2;
            rank[2] = 3;
            target = new int[2];
            target[0] = 1;
            target[1] = 2;
            accuracy = 70;
            crit_mod = 50;
            max_damage = 5;
            min_damage = 3;
        }
    }
    public class Boarman2 : Skill
    {
        public Boarman2()
        {
            nama = "boarman2";
            rank = new int[3];
            rank[0] = 1;
            rank[1] = 2;
            rank[2] = 3;
            target = new int[3];
            target[0] = 1;
            target[1] = 2;
            target[2] = 3;
            accuracy = 70;
            crit_mod = 25;
            max_damage = 4;
            min_damage = 2;
        }
    }
    public class Boarman3 : Skill
    {
        public Boarman3()
        {
            nama = "boarman3";
            rank = new int[3];
            rank[0] = 1;
            rank[1] = 2;
            rank[2] = 3;
            target = new int[4];
            target[0] = 1;
            target[1] = 2;
            target[2] = 3;
            accuracy = 70;
            crit_mod = 25;
            max_damage = 4;
            min_damage = 2;
        }
    }
    public enum efek
    {
        blight ,
        bleed ,
        stun,
        marked,
        stress,
        armor
    }
}
