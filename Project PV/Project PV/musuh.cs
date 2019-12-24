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

        public musuh(int x)
        {
            this.x = x;
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
            try
            {
                gambarAttack(g, zoom);
                //tipe_gerak_ke++;
            }
            catch (Exception)
            {
                //tipe_gerak_ke--;
                gambarAttack(g, zoom);
            }
        }
        public void gambarAttack(Graphics g, int zoom)
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
            this.speed = 5;
        }
    }
    class Boarman : musuh
    {
        public Boarman(int x) : base(x)
        {
            skill = new List<Skill>();
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

