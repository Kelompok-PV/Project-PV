using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Project_PV
{
    class musuh
    {
        public int hp { get; set; }
        public int maxHp { get; set; }
        public List<Skill> skill { get; set; }
        public string name { get; set; }
        public string musuh_move { get; set; }
        public int musuh_move_now { get; set; }
        public int x { get; set; }
        public int speed { get; set; }
        public int dodge { get; set; }
        public List<efek> musuh_buff { get; set; }
        public List<int> musuh_buff_turn { get; set; }
        public bool marked { get; set; }
        public musuh(int x)
        {
            this.x = x;
            musuh_buff = new List<efek>();
            musuh_buff_turn = new List<int>();
            marked = false;
        }

        public void getImage(Graphics g)
        {
            try
            {
                gambar(g);
            }
            catch (Exception)
            {
                musuh_move_now = 1;
                gambar(g);
            }
        }
        public void gambar(Graphics g)
        {
            object O = Properties.Resources.ResourceManager.GetObject(name + "_" + musuh_move + "___" + musuh_move_now+ "_");
            Image img = (Image)O;
            g.DrawImage(img, x, 250, 100, 150);
        }
        public void getImageAttack(Graphics g, int zoom)
        {
            object O = Properties.Resources.ResourceManager.GetObject(name + "_" + musuh_move + "___" + musuh_move_now + "_");
            Image img = (Image)O;
            g.DrawImage(img, x - zoom / 2, 250 - zoom, 100 + zoom, 150 + zoom);
        }
    }

    //SEMUA DODGE ..%
    class yeti : musuh
    {
        public yeti(int x)
            : base(x)
        {
            skill = new List<Skill>();
            //TODO skill musuh
            this.name = "yeti";
            this.musuh_move = "idle";
            this.maxHp = 15;
            this.dodge = 0;
            this.hp = maxHp;
            this.x = x;
            this.speed = 15;

            skill.Add(new yeti1());
            skill.Add(new yeti2());
            skill.Add(new yeti3());
            skill.Add(new yeti4());
        }
    }
    class Boarman : musuh
    {
        public Boarman(int x) : base(x)
        {
            skill = new List<Skill>();
            skill.Add(new Boarman1());
            skill.Add(new Boarman2());
            skill.Add(new Boarman3());
            skill.Add(new Boarman4());
            this.name = "Boarman";
            this.musuh_move = "idle";
            this.maxHp = 12;
            this.dodge = 10;
            this.hp = maxHp;
            this.x = x;
            this.speed = 3;
        }
    }
    class FlameEater : musuh
    {
        public FlameEater(int x) : base(x)
        {
            skill = new List<Skill>();
            skill.Add(new FlameEater1());
            skill.Add(new FlameEater2());
            skill.Add(new FlameEater3());
            skill.Add(new FlameEater4());
            this.name = "flame";
            this.musuh_move = "idle";
            this.maxHp = 35;
            this.dodge = 0;
            this.hp = maxHp;
            this.x = x;
            this.speed = 1;
        }
    }
    class Gargoyle : musuh
    {
        public Gargoyle(int x) : base(x)
        {
            skill = new List<Skill>();
            skill.Add(new Gargoyle1());
            skill.Add(new Gargoyle2());
            skill.Add(new Gargoyle3());
            skill.Add(new Gargoyle4());
            this.name = "Gargoyle";
            this.musuh_move = "idle";
            this.maxHp = 25;
            this.dodge = 25;
            this.hp = maxHp;
            this.x = x;
            this.speed = 5;
        }
    }
    class GiantGoblin : musuh
    {
        public GiantGoblin(int x) : base(x)
        {
            skill = new List<Skill>();
            skill.Add(new GiantGoblin1());
            skill.Add(new GiantGoblin2());
            skill.Add(new GiantGoblin3());
            skill.Add(new GiantGoblin4());
            this.name = "giant";
            this.musuh_move = "idle";
            this.maxHp = 25;
            this.dodge = 25;
            this.hp = maxHp;
            this.x = x;
            this.speed = 5;
        }
    }
    class Larry : musuh
    {
        public Larry(int x) : base(x)
        {
            skill = new List<Skill>();
            skill.Add(new Larry1());
            skill.Add(new Larry2());
            skill.Add(new Larry3());
            skill.Add(new Larry4());
            this.name = "Larry";
            this.musuh_move = "idle";
            this.maxHp = 8;
            this.dodge = 17;
            this.hp = maxHp;
            this.x = x;
            this.speed = 10;
        }
    }
    class Skeleton_soldier : musuh
    {
        public Skeleton_soldier(int x) : base(x)
        {
            skill = new List<Skill>();
            skill.Add(new Skeleton_soldier1());
            skill.Add(new Skeleton_soldier2());
            skill.Add(new Skeleton_soldier3());
            skill.Add(new Skeleton_soldier4());
            this.name = "Skeleton_soldier";
            this.musuh_move = "idle";
            this.maxHp = 8;
            this.dodge = 0;
            this.hp = maxHp;
            this.x = x;
            this.speed = 1;
        }
    }
    
}

