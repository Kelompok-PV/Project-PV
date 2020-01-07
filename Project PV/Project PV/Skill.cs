using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Project_PV
{

    [Serializable]
    abstract class Skill
    {
        
        public string nama { get; set; }
        public efek skill_efek { get; set; }
        public int[] rank { get; set; }
        public int accuracy { get; set; }
        public int crit_mod { get; set; }
        public int[] target { get; set; }
        public status status_skill { get; set; }
        public int efek_kena { get; set; }
        public Image icon { get; set; }
        public int max_damage { get; set; }
        public int min_damage { get; set; }
        public int acc { get; set; }

        public Skill(string nama, efek skill_efek, int[] rank, int[] target, status status_skill, int efek_kena)
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

        public virtual void getDamageSkill(int targetSkill, List<karakter> karakters)
        {

        }

        public virtual void getDamageSkill(int targetSkill, List<musuh> musuhs)
        {

        }

    }

    class noxius_blast : Skill
    {
        public noxius_blast()
           : base("Noxius Blast", new efek(), new int[4], new int[4], new status(), 10)
        {

            rank[0] = 1; rank[1] = 1; rank[2] = 1; rank[3] = 0;
            target[0] = 1; target[1] = 1; target[2] = 0; target[3] = 0;
            status_skill = new status(2, 4, 20, 70, 0, -1);
            skill_efek = efek.blight;
            icon = Properties.Resources.plague_doctor_ability_noxious_blast;
        }

        Random rand = new Random();
        public override void getDamageSkill(int targetSkill, List<musuh> musuhs)
        {

            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= status_skill.acc)
            {
                int randdodge = rand.Next(0, 100);
                if (musuhs[targetSkill].dodge < randdodge)
                {

                    if (randakurasi <= status_skill.acc)
                    {
                        int randomDodge = rand.Next(0, 100);
                        if (musuhs[targetSkill].dodge < randomDodge)
                        {
                            int damage = rand.Next(status_skill.dmg_min, status_skill.dmg_max);
                            musuhs[targetSkill].hp -= damage;
                            musuhs[targetSkill].musuh_buff.Add(skill_efek);
                        }
                    }

                }
            }
        }
    }
    class incision : Skill
    {
        public incision()
            : base("Incision", new efek(), new int[4], new int[4], new status(), 10)
        {
            rank[0] = 0; rank[1] = 1; rank[2] = 1; rank[3] = 1;
            target[0] = 1; target[1] = 1; target[2] = 0; target[3] = 0;
            status_skill = new status(0, 1, 20, 60, 0, -1);
            skill_efek = efek.blight;
            icon = Properties.Resources.plague_doctor_ability_incision;
        }

        public override void getDamageSkill(int targetSkill, List<musuh> musuhs)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= status_skill.acc)
            {
                int randdodge = rand.Next(0, 100);
                if (musuhs[targetSkill].dodge < randdodge)
                {
                    int damage = rand.Next(status_skill.dmg_min, status_skill.dmg_max);
                    musuhs[targetSkill].hp -= damage;
                    musuhs[targetSkill].musuh_buff.Add(skill_efek);
                }
            }
        }
    }

    class battlefield_medicine : Skill
    {
        public battlefield_medicine()
            : base("Battlefield Medicine", new efek(), new int[4], new int[4], new status(), 10)
        {
            rank[0] = 1; rank[1] = 1; rank[2] = 0; rank[3] = 0;
            target[0] = 1; target[1] = 1; target[2] = 1; target[3] = 1;
            status_skill = new status(1, 2, 20, 100, 0, -1);
            skill_efek = efek.blight;
            icon = Properties.Resources.plague_doctor_ability_battlefield_medicine;
        }
        public override void getDamageSkill(int targetSkill, List<musuh> musuhs)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= status_skill.acc)
            {
                int randdodge = rand.Next(0, 100);
                if (musuhs[targetSkill].dodge < randdodge)
                {
                    int damage = rand.Next(status_skill.dmg_min, status_skill.dmg_max);
                    musuhs[targetSkill].hp -= damage;
                    musuhs[targetSkill].musuh_buff.Add(skill_efek);
                }
            }
        }
    }

    class bliding_gas : Skill
    {
        public bliding_gas()
            : base("Bliding Gas", new efek(), new int[4], new int[4], new status(), 100)
        {
            rank[0] = 1; rank[1] = 1; rank[2] = 0; rank[3] = 0;
            target[0] = 0; target[1] = 0; target[2] = 1; target[3] = 1;
            status_skill = new status(3, 4, 20, 70, 0, 3);
            skill_efek = efek.stun;
            icon = Properties.Resources.plague_doctor_ability_blinding_gas;
        }
        public override void getDamageSkill(int targetSkill, List<musuh> musuhs)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= status_skill.acc)
            {
                int randdodge = rand.Next(0, 100);
                for (int i = 0; i < target.Length; i++)
                {
                    if (musuhs[target[i]].dodge < randdodge)
                    {
                        int damage = rand.Next(status_skill.dmg_min, status_skill.dmg_max);
                        for (int j = 2; j < target.Length; j++)
                        {
                            musuhs[target[j]].hp -= damage;
                            musuhs[target[j]].musuh_buff.Add(skill_efek);
                        }
                    }
                }
            }
        }
    }

    class divine_grace : Skill
    {
        public divine_grace()
            : base("Divine Grace", new efek(), new int[4], new int[4], new status(), 100)
        {
            rank[0] = 1; rank[1] = 1; rank[2] = 0; rank[3] = 0;
            target[0] = 1; target[1] = 1; target[2] = 1; target[3] = 1;
            status_skill = new status(4, 5, 20, 100, 0, -1);
            skill_efek = efek.heal;
            icon = Properties.Resources.vestal_ability_divine_grace;
        }
        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int damage = rand.Next(status_skill.dmg_min, status_skill.dmg_max);
            karakters[targetSkill].hp += damage;
            karakters[targetSkill].hero_buff = skill_efek;
        }
    }

    class divine_comfort : Skill
    {
        public divine_comfort()
            : base("Divine Comfort", new efek(), new int[4], new int[4], new status(), 100)
        {
            rank[0] = 1; rank[1] = 1; rank[2] = 1; rank[3] = 0;
            target[0] = 1; target[1] = 1; target[2] = 1; target[3] = 1;
            status_skill = new status(1, 3, 20, 100, 0, -1);
            skill_efek = efek.heal;
            icon = Properties.Resources.vestal_ability_divine_comfort;
        }
        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            for (int i = 0; i < karakters.Count; i++)
            {
                int damage = rand.Next(status_skill.dmg_min, status_skill.dmg_max);
                karakters[i].hp += damage;
            }
        }
    }

    class dazzling_light : Skill
    {
        public dazzling_light()
            : base("Dazzling Light", new efek(), new int[4], new int[4], new status(), 100)
        {
            rank[0] = 1; rank[1] = 1; rank[2] = 1; rank[3] = 0;
            target[0] = 1; target[1] = 1; target[2] = 1; target[3] = 0;
            status_skill = new status(1, 2, 20, 65, 0, -1);
            skill_efek = efek.stun;
            icon = Properties.Resources.vestal_ability_dazzling_light;
        }
        public override void getDamageSkill(int targetSkill, List<musuh> musuhs)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= status_skill.acc)
            {
                int randdodge = rand.Next(0, 100);
                if (musuhs[targetSkill].dodge < randdodge)
                {
                    int damage = rand.Next(status_skill.dmg_min, status_skill.dmg_max);
                    musuhs[targetSkill].hp -= damage;
                    musuhs[targetSkill].musuh_buff.Add(skill_efek);
                }
            }
        }
    }

    class judgement : Skill
    {
        public judgement()
            : base("Judgement", new efek(), new int[4], new int[4], new status(), 100)
        {
            rank[0] = 1; rank[1] = 1; rank[2] = 0; rank[3] = 0;
            target[0] = 1; target[1] = 1; target[2] = 1; target[3] = 1;
            status_skill = new status(1, 3, 20, 55, 0, -1);
            //skill_efek = efek.stun; 
            icon = Properties.Resources.vestal_ability_judgement;
        }
        public override void getDamageSkill(int targetSkill, List<musuh> musuhs)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= status_skill.acc)
            {
                int randdodge = rand.Next(0, 100);
                if (musuhs[targetSkill].dodge < randdodge)
                {
                    int damage = rand.Next(status_skill.dmg_min, status_skill.dmg_max);
                    musuhs[targetSkill].hp -= damage;
                }
            }
        }
    }

    class smite : Skill
    {
        public smite()
            : base("Smite", new efek(), new int[4], new int[4], new status(), 0)
        {
            rank[0] = 0; rank[1] = 0; rank[2] = 1; rank[3] = 1;
            target[0] = 1; target[1] = 1; target[2] = 0; target[3] = 0;
            status_skill = new status(6, 8, 0, 70, 0, -1);
            skill_efek = efek.stun;
            icon = Properties.Resources.crusader_ability_smite;
        }
        public override void getDamageSkill(int targetSkill, List<musuh> musuhs)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= status_skill.acc)
            {
                int randdodge = rand.Next(0, 100);
                for (int i = 0; i < 2; i++)
                {
                    if (musuhs[target[i]].dodge < randdodge)
                    {
                        int damage = rand.Next(status_skill.dmg_min, status_skill.dmg_max);
                        for (int j = 0; j < 2; j++)
                        {
                            musuhs[target[j]].hp -= damage;
                            musuhs[target[j]].musuh_buff.Add(skill_efek);
                        }
                    }
                }
            }
        }
    }

    class zealous_accusation : Skill
    {
        public zealous_accusation()
            : base("Zealous Accusation", new efek(), new int[4], new int[4], new status(), 100)
        {
            rank[0] = 0; rank[1] = 0; rank[2] = 1; rank[3] = 1;
            target[0] = 1; target[1] = 1; target[2] = 0; target[3] = 0;
            status_skill = new status(3, 4, 0, 60, 0, -1);
            skill_efek = efek.stun;
            icon = Properties.Resources.crusader_ability_zealous_accusation;
        }
        public override void getDamageSkill(int targetSkill, List<musuh> musuhs)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= status_skill.acc)
            {
                int randdodge = rand.Next(0, 100);
                if (musuhs[targetSkill].dodge < randdodge)
                {
                    int damage = rand.Next(status_skill.dmg_min, status_skill.dmg_max);
                    musuhs[targetSkill].hp -= damage;
                    musuhs[targetSkill].musuh_buff.Add(skill_efek);
                }
            }
        }
    }

    class holy_lance : Skill
    {
        public holy_lance()
            : base("Holy Lance", new efek(), new int[4], new int[4], new status(), 100)
        {
            rank[0] = 1; rank[1] = 1; rank[2] = 0; rank[3] = 0;
            target[0] = 0; target[1] = 1; target[2] = 1; target[3] = 1;
            status_skill = new status(3, 4, 22, 55, 0, -1);
            //skill_efek = efek.stun; 
            icon = Properties.Resources.crusader_ability_holy_lance;
        }
        public override void getDamageSkill(int targetSkill, List<musuh> musuhs)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= status_skill.acc)
            {
                int randdodge = rand.Next(0, 100);
                if (musuhs[targetSkill].dodge < randdodge)
                {
                    int damage = rand.Next(status_skill.dmg_min, status_skill.dmg_max);
                    musuhs[targetSkill].hp -= damage;
                }
            }
        }
    }

    class inspiring_cry : Skill
    {
        public inspiring_cry()
            : base("Inspiring Cry", new efek(), new int[4], new int[4], new status(), 0)
        {
            rank[0] = 1; rank[1] = 1; rank[2] = 1; rank[3] = 1;
            target[0] = 1; target[1] = 1; target[2] = 1; target[3] = 1;
            status_skill = new status(0, 1, 0, 100, 0, -1);
            skill_efek = efek.stress;
            icon = Properties.Resources.crusader_ability_inspiring_cry;
        }
        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int damage = rand.Next(status_skill.dmg_min, status_skill.dmg_max);
            karakters[targetSkill].hp += damage;
            karakters[targetSkill].hero_stress.stress_point -= 5;
        }
    }

    class pierce : Skill
    {
        public pierce()
            : base("Pierce", new efek(), new int[4], new int[4], new status(), 0)
        {
            rank[0] = 0; rank[1] = 1; rank[2] = 1; rank[3] = 1;
            target[0] = 1; target[1] = 1; target[2] = 1; target[3] = 1;
            status_skill = new status(5, 7, 20, 60, 0, -1);
            icon = Properties.Resources.shieldbreaker_ability_pierce;
        }
        public override void getDamageSkill(int targetSkill, List<musuh> musuhs)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= status_skill.acc)
            {
<<<<<<< HEAD
                Random rand = new Random();
                int randakurasi = rand.Next(0, 40);
                if (randakurasi <= status_skill.acc)
                {
                    int randdodge = rand.Next(0, 80);
                    if (musuhs[targetSkill].dodge < randdodge)
                    {
                        int damage = rand.Next(status_skill.dmg_min, status_skill.dmg_max);
                        musuhs[targetSkill].hp -= damage;
                    }
=======
                int randdodge = rand.Next(0, 100);
                if (musuhs[targetSkill].dodge < randdodge)
                {
                    int damage = rand.Next(status_skill.dmg_min, status_skill.dmg_max);
                    musuhs[targetSkill].hp -= damage;
>>>>>>> 4106bd0cbb7a49230bfaaa0755593c90a71d2900
                }
            }
        }
    }
    class adders_kiss : Skill
    {
        public adders_kiss()
            : base("Adder's Kiss", new efek(), new int[4], new int[4], new status(), 0)
        {
            rank[0] = 0; rank[1] = 0; rank[2] = 0; rank[3] = 1;
            target[0] = 1; target[1] = 1; target[2] = 0; target[3] = 0;
            status_skill = new status(4, 6, 20, 60, 0, -1);
            skill_efek = efek.blight;
            icon = Properties.Resources.shieldbreaker_ability_adder_kiss;
        }
        public override void getDamageSkill(int targetSkill, List<musuh> musuhs)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= status_skill.acc)
            {
<<<<<<< HEAD
                Random rand = new Random();
                int randakurasi = rand.Next(0, 40);
                if (randakurasi <= status_skill.acc)
                {
                    int randdodge = rand.Next(0, 60);
                    if (musuhs[targetSkill].dodge < randdodge)
                    {
                        int damage = rand.Next(status_skill.dmg_min, status_skill.dmg_max);
                        musuhs[targetSkill].hp -= damage;
                        musuhs[targetSkill].musuh_buff.Add(skill_efek);
                    }
=======
                int randdodge = rand.Next(0, 100);
                if (musuhs[targetSkill].dodge < randdodge)
                {
                    int damage = rand.Next(status_skill.dmg_min, status_skill.dmg_max);
                    musuhs[targetSkill].hp -= damage;
                    musuhs[targetSkill].musuh_buff.Add(skill_efek);
>>>>>>> 4106bd0cbb7a49230bfaaa0755593c90a71d2900
                }
            }
        }
    }
    class captivate : Skill
    {
        public captivate()
            : base("Captivate", new efek(), new int[4], new int[4], new status(), 0)
        {
            rank[0] = 0; rank[1] = 1; rank[2] = 1; rank[3] = 0;
            target[0] = 0; target[1] = 1; target[2] = 1; target[3] = 0;
            status_skill = new status(2, 4, 20, 60, 0, -1);
            skill_efek = efek.blight;
            icon = Properties.Resources.shieldbreaker_ability_captivate;
        }
        public override void getDamageSkill(int targetSkill, List<musuh> musuhs)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= status_skill.acc)
            {
<<<<<<< HEAD
                Random rand = new Random();
                int randakurasi = rand.Next(0, 40);
                if (randakurasi <= status_skill.acc)
                {
                    int randdodge = rand.Next(0, 60);
                    if (musuhs[targetSkill].dodge < randdodge)
                    {
                        int damage = rand.Next(status_skill.dmg_min, status_skill.dmg_max);
                        musuhs[targetSkill].hp -= damage;
                        musuhs[targetSkill].musuh_buff.Add(skill_efek);
                    }
=======
                int randdodge = rand.Next(0, 100);
                if (musuhs[targetSkill].dodge < randdodge)
                {
                    int damage = rand.Next(status_skill.dmg_min, status_skill.dmg_max);
                    musuhs[targetSkill].hp -= damage;
                    musuhs[targetSkill].musuh_buff.Add(skill_efek);
>>>>>>> 4106bd0cbb7a49230bfaaa0755593c90a71d2900
                }
            }
        }
    }
    class impale : Skill
    {
        public impale()
            : base("Impale", new efek(), new int[4], new int[4], new status(), 0)
        {
            rank[0] = 0; rank[1] = 0; rank[2] = 0; rank[3] = 1;
            target[0] = 1; target[1] = 1; target[2] = 1; target[3] = 1;
            status_skill = new status(4, 6, 22, 60, 0, -1);
            //skill_efek = efek.; 
            icon = Properties.Resources.shieldbreaker_ability_impale;
        }

        public override void getDamageSkill(int targetSkill, List<musuh> musuhs)
        {
            int pointer = 0;
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= status_skill.acc)
            {
<<<<<<< HEAD
                int pointer = 0;
                Random rand = new Random();
                int randakurasi = rand.Next(0, 40);
                if (randakurasi <= status_skill.acc)
                {
                    int randdodge = rand.Next(0, 60);
                    for (int i = 0; i < target.Length; i++)
=======
                int randdodge = rand.Next(0, 100);
                for (int i = 0; i < target.Length; i++)
                {
                    if (target[i] == 1)
>>>>>>> 4106bd0cbb7a49230bfaaa0755593c90a71d2900
                    {
                        pointer = i;
                        if (i < musuhs.Count && musuhs[pointer].dodge < randdodge)
                        {
                            int damage = rand.Next(status_skill.dmg_min, status_skill.dmg_max);
                            for (int j = 0; j < target.Length; j++)
                            {
                                try
                                {
                                    if (target[j] == 1)
                                    {
                                        musuhs[j].hp -= damage;
                                    }
                                }
                                catch (Exception)
                                {

                                }
                            }
                        }
                    }
                }
            }
        }
    }
    class yeti1 : Skill
    {
        public yeti1()
        : base("yeti1", new efek(), new int[4], new int[4], new status(), 100)
        {
<<<<<<< HEAD
            public yeti1()
            : base("yeti1", new efek(), new int[4], new int[4], new status(), 100)
            {
                rank[0] = 1; rank[1] = 1; rank[2] = 0; rank[3] = 0;
                target[0] = 0; target[1] = 0; target[2] = 1; target[3] = 1;
                status_skill = new status(3, 4, 20, 70, 0, 3);
                skill_efek = efek.stun;
                rank = new int[1];
                rank[0] = 4;
                target = new int[4];
                target[0] = 0;
                target[1] = 1;
                target[2] = 2;
                target[3] = 3;
                accuracy = 42;
                crit_mod = 0;
                max_damage = 4;
                min_damage = 2;
                acc = 70;
                icon = Properties.Resources.yeti_skill1___1_;
            }
            public override void getDamageSkill(int targetSkill, List<karakter> karakters)
=======
            rank[0] = 1; rank[1] = 1; rank[2] = 0; rank[3] = 0;
            target[0] = 0; target[1] = 0; target[2] = 1; target[3] = 1;
            status_skill = new status(3, 4, 20, 70, 0, 3);
            skill_efek = efek.stun;
            rank = new int[1];
            rank[0] = 4;
            target = new int[4];
            target[0] = 0;
            target[1] = 1;
            target[2] = 2;
            target[3] = 3;
            accuracy = 42;
            crit_mod = 0;
            max_damage = 4;
            min_damage = 2;
            acc = 70;
            icon = Properties.Resources.yeti_attack___1_;
        }
        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
>>>>>>> 4106bd0cbb7a49230bfaaa0755593c90a71d2900
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    int damage = rand.Next(min_damage, max_damage);
                    karakters[targetSkill].hp -= damage;
                }
            }
        }
    }
    class yeti2 : Skill
    {
        public yeti2()
            : base("yeti2", new efek(), new int[4], new int[4], new status(), 100)
        {
<<<<<<< HEAD
            public yeti2()
               : base("yeti2", new efek(), new int[4], new int[4], new status(), 100)
            {
                rank[0] = 1; rank[1] = 1; rank[2] = 0; rank[3] = 0;
                target[0] = 0; target[1] = 0; target[2] = 1; target[3] = 1;
                status_skill = new status(3, 4, 20, 70, 0, 3);
                skill_efek = efek.stun;
                icon = Properties.Resources.yeti_skill2___1_;
                accuracy = 70;
                crit_mod = 25;
                max_damage = 8;
                min_damage = 4;
                acc = 75;
            }
            public override void getDamageSkill(int targetSkill, List<karakter> karakters)
=======
            rank[0] = 1; rank[1] = 1; rank[2] = 0; rank[3] = 0;
            target[0] = 0; target[1] = 0; target[2] = 1; target[3] = 1;
            status_skill = new status(3, 4, 20, 70, 0, 3);
            skill_efek = efek.stun;
            icon = Properties.Resources.yeti_attack___2_;
            accuracy = 70;
            crit_mod = 25;
            max_damage = 8;
            min_damage = 4;
            acc = 75;
        }
        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
>>>>>>> 4106bd0cbb7a49230bfaaa0755593c90a71d2900
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    int damage = rand.Next(min_damage, max_damage);
                    karakters[targetSkill].hp -= damage;
                }
            }
        }
    }
    class yeti3 : Skill
    {
        public yeti3()
            : base("yeti3", new efek(), new int[4], new int[4], new status(), 100)
        {
            rank[0] = 1; rank[1] = 1; rank[2] = 0; rank[3] = 0;
            target[0] = 0; target[1] = 0; target[2] = 1; target[3] = 1;
            status_skill = new status(3, 4, 20, 70, 0, 3);
            skill_efek = efek.stun;
            icon = Properties.Resources.yeti_attack___3_;
            accuracy = 70;
            crit_mod = 25;
            max_damage = 4;
            min_damage = 2;
            acc = 60;
        }
        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
<<<<<<< HEAD
            public yeti3()
               : base("yeti3", new efek(), new int[4], new int[4], new status(), 100)
            {
                rank[0] = 1; rank[1] = 1; rank[2] = 0; rank[3] = 0;
                target[0] = 0; target[1] = 0; target[2] = 1; target[3] = 1;
                status_skill = new status(3, 4, 20, 70, 0, 3);
                skill_efek = efek.stun;
                icon = Properties.Resources.yeti_skill3___1_;
                accuracy = 70;
                crit_mod = 25;
                max_damage = 4;
                min_damage = 2;
                acc = 60;
            }
            public override void getDamageSkill(int targetSkill, List<karakter> karakters)
=======
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
>>>>>>> 4106bd0cbb7a49230bfaaa0755593c90a71d2900
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    karakters[targetSkill].hero_buff = skill_efek;
                    int damage = rand.Next(min_damage, max_damage);
                    karakters[targetSkill].hp -= damage;
                }
            }
        }
    }
    class yeti4 : Skill
    {
        public yeti4()
            : base("yeti4", new efek(), new int[4], new int[4], new status(), 100)
        {
            rank[0] = 1; rank[1] = 1; rank[2] = 0; rank[3] = 0;
            target[0] = 0; target[1] = 0; target[2] = 1; target[3] = 1;
            status_skill = new status(3, 4, 20, 70, 0, 3);
            skill_efek = efek.stun;
            icon = Properties.Resources.yeti_attack___4_;
            accuracy = 70;
            crit_mod = 50;
            max_damage = 5;
            min_damage = 3;
            acc = 60;
        }
        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    karakters[targetSkill].hero_buff = skill_efek;
                    int damage = rand.Next(min_damage, max_damage);
                    karakters[targetSkill].hp -= damage;
                }
            }
        }
    }
    class Boarman1 : Skill
    {
        public Boarman1()
        {
            nama = "boarman1";
            rank = new int[3];
            rank[0] = 0;
            rank[1] = 1;
            rank[2] = 2;
            target = new int[2];
            //kena damage 1 sampai 2
            target[0] = 0;
            target[1] = 1;
            accuracy = 70;
            crit_mod = 50;
            max_damage = 5;
            min_damage = 3;
            acc = 70;
        }

        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    for (int i = 0; i < karakters.Count; i++)
                    {
                        karakters[i].hero_stress.stress_point += 5;
                        karakters[i].hero_buff = skill_efek;
                        karakters[i].hp -= min_damage; //karna pasti damage nya 1
                    }
                }
            }
        }
    }
    class Boarman2 : Skill
    {
        public Boarman2()
        {
            nama = "boarman2";
            rank = new int[3];
            rank[0] = 0;
            rank[1] = 1;
            rank[2] = 2;
            target = new int[3];
            target[0] = 0;
            target[1] = 1;
            target[2] = 2;
            accuracy = 70;
            crit_mod = 25;
            max_damage = 4;
            min_damage = 2;
            acc = 60;
        }
        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    int damage = rand.Next(min_damage, max_damage);
                    karakters[targetSkill].hp -= damage;
                }
            }
        }
    }
    class Boarman3 : Skill
    {
        public Boarman3()
        {
            nama = "boarman3";
            rank = new int[3];
            rank[0] = 0;
            rank[1] = 1;
            rank[2] = 2;
            target = new int[4];
            target[0] = 0;
            target[1] = 1;
            target[2] = 2;
            target[3] = 3;
            accuracy = 70;
            crit_mod = 25;
            max_damage = 8;
            min_damage = 4;
            skill_efek = new efek();
            skill_efek = efek.bleed;
            acc = 65;
        }

        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    karakters[targetSkill].hero_buff = skill_efek;
                    int damage = rand.Next(min_damage, max_damage);
                    karakters[targetSkill].hp -= damage;
                }
            }
        }
    }
    class Boarman4 : Skill
    {
        public Boarman4()
        {
            nama = "boarman4";
            rank = new int[1];
            rank[0] = 4;
            target = new int[4];
            target[0] = 0;
            target[1] = 1;
            target[2] = 2;
            target[3] = 3;
            accuracy = 42;
            crit_mod = 0;
            max_damage = 4;
            min_damage = 2;
            acc = 65;
        }
        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    int damage = rand.Next(min_damage, max_damage);
                    karakters[targetSkill].hp -= damage;
                }
            }
        }
    }
    class FlameEater1 : Skill
    {
        public FlameEater1()
        {
            nama = "FlameEater1";
            rank = new int[2];
            rank[0] = 0;
            rank[1] = 1;
            //target 1 sampai 4
            target = new int[4];
            target[0] = 0;
            target[1] = 1;
            target[2] = 2;
            target[3] = 3;
            accuracy = 82;
            crit_mod = 0;
            max_damage = 1;
            min_damage = 1;
            skill_efek = new efek();
            skill_efek = efek.bleed;
            acc = 70;
        }

        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    for (int i = 0; i < karakters.Count; i++)
                    {
                        karakters[i].hero_stress.stress_point += 5;
                        karakters[i].hero_buff = skill_efek;
                        karakters[i].hp -= min_damage; //karna pasti damage nya 1
                    }
                }
            }
        }
    }

    class FlameEater2 : Skill
    {
        public FlameEater2()
        {
            nama = "FlameEater2";
            rank = new int[4];
            rank[0] = 0;
            rank[1] = 1;
            rank[2] = 2;
            rank[3] = 3;
            target = new int[4];
            target[0] = 0;
            target[1] = 1;
            target[2] = 2;
            target[3] = 3;
            accuracy = 82;
            crit_mod = 12;
            max_damage = 4;
            min_damage = 2;
            skill_efek = new efek();
            skill_efek = efek.bleed;
            acc = 65;
        }
        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    karakters[targetSkill].hero_stress.stress_point += 5;
                    karakters[targetSkill].hero_buff = skill_efek;
                    int damage = rand.Next(min_damage, max_damage);
                    karakters[targetSkill].hp -= damage;
                }
            }
        }
    }
    class FlameEater3 : Skill
    {
        public FlameEater3()
        {
            nama = "FlameEater3";
            rank = new int[1];
            rank[0] = 0;
            target = new int[1];
            target[0] = 0;
            accuracy = 82;
            crit_mod = 20;
            max_damage = 11;
            min_damage = 4;
            acc = 60;
        }

        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    int damage = rand.Next(min_damage, max_damage);
                    karakters[targetSkill].hp -= damage;
                }
            }
        }
    }
    class FlameEater4 : Skill
    {
        public FlameEater4()
        {
            nama = "FlameEater4";
            rank = new int[2];
            rank[0] = 1;
            rank[1] = 2;
            target = new int[2];
            target[0] = 1;
            target[1] = 2;
            accuracy = 82;
            crit_mod = 20;
            max_damage = 7;
            min_damage = 3;
            acc = 70;
        }
        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    int damage = rand.Next(min_damage, max_damage);
                    karakters[targetSkill].hp -= damage;
                }
            }
        }
    }
    class Gargoyle1 : Skill
    {
        public Gargoyle1()
        {
            nama = "Gargoyle1";
            rank = new int[3];
            rank[0] = 0;
            rank[1] = 1;
            rank[2] = 2;
            target = new int[2];
            target[0] = 0;
            target[1] = 1;
            accuracy = 85;
            crit_mod = 20;
            max_damage = 11;
            min_damage = 6;
            acc = 70;
        }
        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    int damage = rand.Next(min_damage, max_damage);
                    for (int i = 0; i < target.Length; i++)
                    {
                        karakters[target[i]].hp -= damage;
                    }
                }
            }
        }
    }
    class Gargoyle2 : Skill
    {
        public Gargoyle2()
        {
            nama = "Gargoyle2";
            rank = new int[2];
            rank[0] = 0;
            rank[1] = 1;
            target = new int[3];
            target[0] = 0;
            target[1] = 1;
            target[2] = 2;
            accuracy = 85;
            crit_mod = 15;
            max_damage = 9;
            min_damage = 4;
            acc = 65;
        }
        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    int damage = rand.Next(min_damage, max_damage);
                    karakters[targetSkill].hp -= damage;
                }
            }
        }
    }
    class Gargoyle3 : Skill
    {
        public Gargoyle3()
        {
            nama = "Gargoyle3";
            rank = new int[3];
            rank[0] = 0; rank[1] = 1; rank[2] = 2;
            target = new int[4];
            target[0] = 0; target[1] = 1; target[2] = 2; target[3] = 3;
            accuracy = 85;
            crit_mod = 15;
            max_damage = 15;
            min_damage = 7;
            skill_efek = new efek();
            skill_efek = efek.bleed;
            acc = 65;
        }
        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    int damage = rand.Next(min_damage, max_damage);
                    karakters[targetSkill].hp -= damage;
                    karakters[targetSkill].hero_buff = skill_efek;
                }
            }
        }
    }
    class Gargoyle4 : Skill
    {
        public Gargoyle4()
        {
            nama = "Gargoyle4";
            rank = new int[1];
            rank[0] = 4;
            target = new int[4];
            target[0] = 0; target[1] = 1; target[2] = 2; target[3] = 3;
            accuracy = 70;
            crit_mod = 0;
            max_damage = 9;
            min_damage = 4;
            acc = 70;
        }
        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    int damage = rand.Next(min_damage, max_damage);
                    karakters[targetSkill].hp -= damage;
                }
            }
        }
    }
    class GiantGoblin1 : Skill
    {
        public GiantGoblin1()
        {
            nama = "GiantGoblin1";
            rank = new int[4];
            rank[0] = 0; rank[1] = 1; rank[2] = 2; rank[3] = 3;
            target = new int[4];
            target[0] = 0; target[1] = 1; target[2] = 2; target[3] = 3;
            accuracy = 80;
            crit_mod = 10;
            max_damage = 1;
            min_damage = 1;
            skill_efek = new efek();
            skill_efek = efek.bleed;
            acc = 65;
        }
        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    for (int i = 0; i < karakters.Count; i++)
                    {
                        karakters[i].hp -= 1;
                        karakters[i].hero_buff = skill_efek;
                    }
                }
            }
        }
    }
    class GiantGoblin2 : Skill
    {
        public GiantGoblin2()
        {
            nama = "GiantGoblin2";
            rank = new int[4];
            rank[0] = 0; rank[1] = 1; rank[2] = 2; rank[3] = 3;
            target = new int[4];
            target[0] = 0; target[1] = 1; target[2] = 2; target[3] = 3;
            accuracy = 80;
            crit_mod = 10;
            max_damage = 1;
            min_damage = 1;
            skill_efek = new efek();
            skill_efek = efek.bleed;
            acc = 70;
        }
        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    for (int i = 0; i < karakters.Count; i++)
                    {
                        karakters[i].hp -= 1;
                        karakters[i].hero_buff = skill_efek;
                        karakters[i].hero_stress.stress_point += 10;
                    }
                }
            }
        }
    }
    class GiantGoblin3 : Skill
    {
        public GiantGoblin3()
        {
            nama = "GiantGoblin3";
            rank = new int[4];
            rank[0] = 0; rank[1] = 1; rank[2] = 2; rank[3] = 3;
            target = new int[4];
            target[0] = 0; target[1] = 1; target[2] = 2; target[3] = 3;
            accuracy = 80;
            crit_mod = 10;
            max_damage = 4;
            min_damage = 2;
            acc = 70;
        }
        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    karakters[targetSkill].hero_stress.stress_point += 10;
                    int damage = rand.Next(min_damage, max_damage);
                    karakters[targetSkill].hp -= damage;
                }
            }
        }
    }
    class GiantGoblin4 : Skill
    {
        public GiantGoblin4()
        {
            nama = "GiantGoblin4";
            rank = new int[4];
            rank[0] = 0; rank[1] = 1; rank[2] = 2; rank[3] = 3;
            target = new int[4];
            target[0] = 0; target[1] = 1; target[2] = 2; target[3] = 3;
            accuracy = 80;
            crit_mod = 10;
            max_damage = 1;
            min_damage = 1;
            skill_efek = new efek();
            skill_efek = efek.stun;
            acc = 65;
        }
        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    for (int i = 0; i < karakters.Count; i++)
                    {
                        karakters[i].hp -= 1;
                        karakters[i].hero_buff = skill_efek;
                        karakters[i].hero_stress.stress_point += 10;
                    }
                }
            }
        }
    }
    class Larry1 : Skill
    {
        public Larry1()
        {
            nama = "Larry1";
            rank = new int[4];
            rank[0] = 0; rank[1] = 1; rank[2] = 2; rank[3] = 3;
            target = new int[4];
            target[0] = 0; target[1] = 1; target[2] = 2; target[3] = 3;
            accuracy = 80;
            crit_mod = 10;
            max_damage = 3;
            min_damage = 3;
            skill_efek = new efek();
            skill_efek = efek.bleed;
            acc = 60;
        }
        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    for (int i = 0; i < karakters.Count; i++)
                    {
                        karakters[i].hp -= 3;
                        karakters[i].hero_buff = skill_efek;
                    }
                }
            }
        }
    }
    class Larry2 : Skill
    {
        public Larry2()
        {
            nama = "Larry2";
            rank = new int[4];
            rank[0] = 0; rank[1] = 1; rank[2] = 2; rank[3] = 3;
            target = new int[4];
            target[0] = 0; target[1] = 1; target[2] = 2; target[3] = 3;
            accuracy = 80;
            crit_mod = 10;
            max_damage = 3;
            min_damage = 3;
            skill_efek = new efek();
            skill_efek = efek.blight;
            acc = 70;
        }
        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    for (int i = 0; i < karakters.Count; i++)
                    {
                        karakters[i].hp -= 3;
                        karakters[i].hero_buff = skill_efek;
                        karakters[i].hero_buff_turn = 5;
                    }
                }
            }
        }
    }
    class Larry3 : Skill
    {
        public Larry3()
        {
            nama = "Larry3";
            rank = new int[4];
            rank[0] = 0; rank[1] = 1; rank[2] = 2; rank[3] = 3;
            target = new int[4];
            target[0] = 0; target[1] = 1; target[2] = 2; target[3] = 3;
            accuracy = 80;
            crit_mod = 10;
            max_damage = 3;
            min_damage = 3;
            acc = 60;
        }
        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    for (int i = 0; i < karakters.Count; i++)
                    {
                        karakters[i].hp -= 3;
                        karakters[i].hero_stress.stress_point += 15;
                    }
                }
            }
        }
    }
    class Larry4 : Skill
    {
        public Larry4()
        {
            nama = "Larry4";
            rank = new int[4];
            rank[0] = 0; rank[1] = 1; rank[2] = 2; rank[3] = 3;
            target = new int[4];
            target[0] = 0; target[1] = 1; target[2] = 2; target[3] = 3;
            accuracy = 80;
            crit_mod = 10;
            max_damage = 4;
            min_damage = 2;
            acc = 65;
        }
        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    int damage = rand.Next(min_damage, max_damage);
                    karakters[targetSkill].hp -= damage;
                    karakters[targetSkill].hero_stress.stress_point += 15;
                }
            }
        }
    }
    class Skeleton_soldier1 : Skill
    {
        public Skeleton_soldier1()
        {
            nama = "Skeleton_soldier1";
            rank = new int[3];
            rank[0] = 0; rank[1] = 1; rank[2] = 2;
            target = new int[2];
            target[0] = 0; target[1] = 1;
            accuracy = 70;
            crit_mod = 10;
            max_damage = 5;
            min_damage = 2;
            acc = 65;
        }
        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    int damage = rand.Next(min_damage, max_damage);
                    karakters[targetSkill].hp -= damage;
                }
            }
        }
    }
    class Skeleton_soldier2 : Skill
    {
        public Skeleton_soldier2()
        {
            nama = "Skeleton_soldier2";
            rank = new int[1];
            rank[0] = 4;
            target = new int[2];
            target[0] = 0; target[1] = 1;
            accuracy = 60;
            crit_mod = 10;
            max_damage = 5;
            min_damage = 2;
            acc = 60;
        }
        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    int damage = rand.Next(min_damage, max_damage);
                    karakters[targetSkill].hp -= damage;
                }
            }
        }
    }
    class Skeleton_soldier3 : Skill
    {
        public Skeleton_soldier3()
        {
            nama = "Skeleton_soldier3";
            rank = new int[1];
            rank[0] = 2;
            target = new int[3];
            target[0] = 0; target[1] = 1; target[2] = 2;
            accuracy = 60;
            crit_mod = 10;
            max_damage = 7;
            min_damage = 3;
            acc = 65;
        }
        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    int damage = rand.Next(min_damage, max_damage);
                    karakters[targetSkill].hp -= damage;
                }
            }
        }
    }
    class Skeleton_soldier4 : Skill
    {
        public Skeleton_soldier4()
        {
            nama = "Skeleton_soldier4";
            rank = new int[2];
            rank[0] = 2; rank[1] = 3;
            target = new int[2];
            target[0] = 2; target[1] = 3;
            accuracy = 60;
            crit_mod = 10;
            max_damage = 7;
            min_damage = 3;
            acc = 60;
        }
        public override void getDamageSkill(int targetSkill, List<karakter> karakters)
        {
            Random rand = new Random();
            int randakurasi = rand.Next(0, 100);
            if (randakurasi <= acc)
            {
                int randdodge = rand.Next(0, 100);
                if (karakters[targetSkill].dodge < randdodge)
                {
                    int damage = rand.Next(min_damage, max_damage);
                    karakters[targetSkill].hp -= damage;
                }
            }
        }
    }
    public enum efek
    {
        none,
        blight,
        bleed,
        stun,
        marked,
        armor,
        stress,
        heal
    }
    
 }

