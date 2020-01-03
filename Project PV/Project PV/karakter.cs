using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PV
{
    abstract class karakter
    {
        public string nama { get; set; }
        public int level { get; set; }
        public int hp { get; set; }
        public int maxHp { get; set; }
        public List<Skill> skills { get; set; }
        public stress hero_stress { get; set; }
        public string hero { get; set; }//hero-hero_move-hero_move_now hero_move_noww++;
        public string hero_move { get; set; }
        public int hero_move_now { get; set; }
        public List<efek> hero_buff { get; set; }
        public List<int> hero_buff_turn{ get; set; }
        public equip[] hero_equip { get; set; }
        public int x { get; set; }
        public string type { get; set; }
        public int dodge { get; set; }
        public int min_damage { get; set; }
        public int max_damage { get; set; }
        public int speed { get; set; }
        public bool marked { get; set; }

        protected karakter(string nama,string type ,int hp, string hero, string hero_move, int hero_move_now, equip[] hero_equip, int dodge,int maxHp,int min_dmg,int damage,int speed)
        {
            this.nama = nama;
            this.hp = hp;
            this.hero = hero;
            this.hero_move = hero_move;
            this.hero_move_now = hero_move_now;
            this.hero_equip = hero_equip;
            this.dodge = dodge;
            this.type = type;
            x = 300;
            this.maxHp = maxHp;
            this.max_damage = damage;
            this.speed=speed;;
        }

        protected karakter(string nama)
        {
            this.nama = nama;
            hero_buff = new List<efek>();
            hero_buff_turn = new List<int>();
            this.hero_stress = new stress();
            this.hero_stress.stress_level = 0;
            this.hero_stress.stress_point = 0;
            marked = false;
        }

        public void turn_efek()
        {

        }

        public void getImage(Graphics g)
        {
            try
            {
                gambar(g);
            }catch(Exception)
            {
                hero_move_now = 1;
                gambar(g);
            }
        }
        public void getImageAttack(Graphics g,int zoom)
        {
            try
            {
                gambarAttack(g, zoom);
                hero_move_now++;
            }
            catch (Exception)
            {
                hero_move_now--;
                gambarAttack(g,zoom);
            }
        }
        public void gambar(Graphics g)
        {
            object O = Properties.Resources.ResourceManager.GetObject(hero + "_" + hero_move + "___" + hero_move_now + "_");
            Image img = (Image)O;
            g.DrawImage(img, x , 250 , 100 , 150 );
        }
        public void gambarAttack(Graphics g,int zoom)
        {
            object O = Properties.Resources.ResourceManager.GetObject(hero + "_" + hero_move + "___" + hero_move_now + "_");
            Image img = (Image)O;
            g.DrawImage(img, x-zoom/2, 250 - zoom, 100 + zoom, 150 + zoom);
        }

        //butuh buat shop hero
        public Image getIdle()
        {
            object O;
            try
            {
                O = Properties.Resources.ResourceManager.GetObject(hero + "_" + hero_move + "___" + hero_move_now + "_");
            }
            catch (Exception)
            {
                //beda satu _ 
                O = Properties.Resources.ResourceManager.GetObject(hero + "_" + hero_move + "__" + hero_move_now + "_");
            }
            
            Image img = (Image)O;
            return img;
        }
        
        public Image getIcon()
        {
            object icon = Properties.Resources.ResourceManager.GetObject(string.Format("{0}_icon",hero));
            Bitmap iconImg = (Bitmap)icon;
            return iconImg;
        }
    }
    class ninja : karakter
    {
        //jarak jauh
        public ninja(string nama) : base(nama)
        {
            this.level = 1;
            this.min_damage = 5;
            this.max_damage = 10;
            this.maxHp = 33;
            this.dodge = 20;
            this.hero_equip = new equip[5];
            this.hp = 33;
            this.type = "Range";
            this.hero_move = "idle";
            this.speed = 20;
            this.nama = nama;
            this.hero = "ninja";
            skills = new List<Skill>();
            skills.Add(new pierce());
            skills.Add(new adders_kiss());
            skills.Add(new captivate());
            skills.Add(new impale());
        }
    }
    //jarak jauh
    class archer : karakter
    {
        public archer(string nama) : base(nama)
        {
            this.level = 1;
            skills = new List<Skill>();
            skills.Add(new pierce());
            skills.Add(new adders_kiss());
            skills.Add(new captivate());
            skills.Add(new impale());
            this.hero_equip = new equip[5];
            this.type = "Range";
            this.hero = "archer";
            this.hero_move = "idle";
            this.nama = nama;
            this.maxHp = 20;
            this.dodge = 28;
            this.min_damage = 5;
            this.max_damage = 10;
            this.hp = 20;
            speed = 3;
			this.hero_equip[0].nama = "Long Bow";
			this.hero_equip[1].nama = "Traveler Robe";
			this.hero_equip[0].stat_plus.dmg_max += 8;
			this.hero_equip[1].stat_plus.acc += 6;
        }
    }
    class aladin : karakter
    {
        public aladin(string nama) : base(nama)
        {
            this.level = 1;
            skills = new List<Skill>();
            skills.Add(new noxius_blast());
            skills.Add(new incision());
            skills.Add(new divine_comfort());
            skills.Add(new bliding_gas());
            this.hero_equip = new equip[5];
            this.type = "Doctor";
            this.hero = "aladin";
            this.hero_move = "idle";
            this.nama = nama;
            this.maxHp = 22;
            this.dodge = 15;
            this.min_damage = 4;
            this.max_damage = 7;
            this.hp = 22;
            speed = 1;
			this.hero_equip[0].nama = "Good Magic Wand";
			this.hero_equip[1].nama = "Tranquil Robe";
			this.hero_equip[0].stat_plus.dmg_min += 7;
			this.hero_equip[1].stat_plus.def += 7;
        }
    }
    class Tony : karakter
    {
        public Tony(string nama) : base(nama)
        {
            this.level = 1;
            skills = new List<Skill>();
            skills.Add(new noxius_blast());
            skills.Add(new incision());
            skills.Add(new battlefield_medicine());
            skills.Add(new bliding_gas());
            this.hero_equip = new equip[5];
            this.type = "Doctor";
            this.hero = "tonyStark";
            this.hero_move = "idle";
            this.nama = nama;
            this.maxHp = 24;
            this.dodge = 0;
            this.min_damage = 4;
            this.max_damage = 8;
            this.hp = maxHp;
            speed = 4;
			this.hero_equip[0].nama = "Tony's googles";
			this.hero_equip[1].nama = "Iron Suit";
			this.hero_equip[0].stat_plus.def += 6;
        }
    }
    class druid : karakter
    {
        //healer
        public druid(string nama) : base(nama)
        {
            this.level = 1;
            skills = new List<Skill>();
            skills.Add(new divine_grace());
            skills.Add(new divine_comfort());
            skills.Add(new dazzling_light());
            skills.Add(new judgement());
            this.hero_equip = new equip[5];
            this.type = "Healer";
            this.hero = "druid";
            this.hero_move = "idle";
            this.nama = nama;
            this.maxHp = 24;
            this.dodge = 15;
            this.min_damage = 4;
            this.max_damage = 8;
            this.hp = 24;
            speed = 4;
			this.hero_equip[0].nama = "Great Elf Staff";
			this.hero_equip[1].nama = "Mythic Robe";
			this.hero_equip[0].stat_plus.acc += 5;
			this.hero_equip[1].stat_plus.def += 5;
        }
    }
    class IceWoman : karakter
    {
        //healer
        public IceWoman(string nama) : base(nama)
        {
            this.level = 1;
            skills = new List<Skill>();
            skills.Add(new divine_grace());
            skills.Add(new divine_comfort());
            skills.Add(new dazzling_light());
            skills.Add(new judgement());
            this.hero_equip = new equip[5];
            this.type = "Healer";
            this.hero = "iceWoman";
            this.hero_move = "idle";
            this.nama = nama;
            this.maxHp = 20;
            this.dodge = 10;
            this.min_damage = 4;
            this.max_damage = 8;
            this.hp = maxHp;
            speed = 8;
			this.hero_equip[0].nama = "Lunar Magic Wand";
			this.hero_equip[1].nama = "Ice Queen Cloak";
			this.hero_equip[0].stat_plus.def += 6;
			this.hero_equip[1].stat_plus.dmg_max += 3;
		}
    }
    class Hercules : karakter
    {
        public Hercules(string nama) : base(nama)
        {
            this.nama = nama;
            level = 1;
            skills = new List<Skill>();
            skills.Add(new smite());
            skills.Add(new zealous_accusation());
            skills.Add(new holy_lance());
            skills.Add(new inspiring_cry());
            this.hero_equip = new equip[5];
            this.type = "Melee";
            this.hero = "hercules";
            this.hero_move = "idle";
            this.nama = nama;
            this.maxHp = 31;
            this.dodge = 5;
            this.min_damage = 5;
            this.max_damage = 9;
            this.hp = maxHp;
            speed = 3;
			this.hero_equip[0].nama = "Skull Crusher";
			this.hero_equip[1].nama = "Beast Sallet";
			this.hero_equip[0].stat_plus.dmg_max += 7;
			this.hero_equip[1].stat_plus.def += 8;
        }
    }
    class giantLady : karakter
    {
        public giantLady(string nama) : base(nama)
        {
            this.nama = nama;
            level = 1;
            skills = new List<Skill>();
            skills.Add(new smite());
            skills.Add(new zealous_accusation());
            skills.Add(new holy_lance());
            skills.Add(new inspiring_cry());
            this.hero_equip = new equip[5];
            this.type = "Melee";
            this.hero = "giantLady";
            this.hero_move = "idle";
            this.nama = nama;
            this.maxHp = 26;
            this.dodge = 10;
            this.min_damage = 6;
            this.max_damage = 12;
            this.hp = maxHp;
            speed = 3;
			this.hero_equip[0].nama = "Hatchet";
			this.hero_equip[1].nama = "Leather Armor";
			this.hero_equip[0].stat_plus.dmg_min += 5;
			this.hero_equip[1].stat_plus.def += 9;
        }
    }



    public enum buff
    {
        poison,
        bleed
    }
}
