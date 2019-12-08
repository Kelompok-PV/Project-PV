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
        public int[] target{ get; set; }
        public status status_skill{ get; set; }
        public int efek_kena { get; set; }
        public Image icon { get; set; }

        public Skill(string nama, efek[] skill_efek, int[] rank, int[] target, status status_skill, int efek_kena)
        {
            this.nama = nama;
            this.skill_efek = skill_efek;
            this.rank = rank;
            this.target = target;
            this.status_skill = status_skill;
            this.efek_kena = efek_kena;
        }

    }
    public class noxius_blast : Skill
    {
        public noxius_blast()
           : base("noxius_blast",new efek[1],new int[4],new int[4],new status(),10)
        {

            rank[0]   = 1; rank[1]   = 1; rank[2]   = 1; rank[3] = 0;
            target[0] = 1; target[1] = 1; target[2] = 0; target[3] = 0;
            status_skill = new status(2,4,20,70,0,-1);
            skill_efek[0] = efek.blight;
            icon = Properties.Resources.skill___1_;
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
            skill_efek[0] = efek.blight; icon = Properties.Resources.skill___2_;
        }
    }
    public class battlefield_medicine : Skill
    {
        public battlefield_medicine()
           : base("battlefield medicine", new efek[1], new int[4], new int[4], new status(), 10)
        {
            rank[0] = 1; rank[1] = 1; rank[2] = 0; rank[3] = 0;
            target[0] = 1; target[1] = 1; target[2] = 1; target[3] = 1;
            status_skill = new status(1, 2, 20, 100, 0, -1);
            skill_efek[0] = efek.blight; icon = Properties.Resources.skill___3_;
        }
    }
    public class bliding_gas: Skill
    {
        public bliding_gas()
           : base("Bliding Gas", new efek[1], new int[4], new int[4], new status(), 100)
        {
            rank[0] = 1; rank[1] = 1; rank[2] = 0; rank[3] = 0;
            target[0] = 0; target[1] = 0; target[2] = 1; target[3] = 1;
            status_skill = new status(3, 4, 20, 70, 0, 3);
            skill_efek[0] = efek.stun; icon = Properties.Resources.skill___4_;
        }
    }

    public class smite : Skill
    {
        public smite()
           : base("Smite", new efek[1], new int[4], new int[4], new status(), 0)
        {
            rank[0] = 0; rank[1] = 0; rank[2] = 1; rank[3] = 1;
            target[0] = 1; target[1] = 1; target[2] = 0; target[3] = 0;
            status_skill = new status(6, 8, 0, 70, 0,-1);
            skill_efek[0] = efek.stun; icon = Properties.Resources.skill___3_;
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
    public enum efek
    {
        blight ,
        bleed ,
        stun,
        marked
    }
}
