 musing System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PV
{
    public abstract class karakter
    {
        public string nama { get; set; }
        public int level { get; set; }
        public int hp { get; set; }
        public List<Skill> skills { get; set; }
        public stress hero_stress { get; set; }
        public string hero { get; set; }//hero-hero_move-hero_move_now hero_move_noww++;
        public string hero_move { get; set; }
        public int hero_move_now { get; set; }
        public buff hero_buff { get; set; }
        public equip[] hero_equip { get; set; }

        public string type { get; set; }
        public List<string> dialog { get; set; }
        public int dodge { get; set; }
        public int speed { get; set; }

        protected karakter(string nama,string type ,int hp, string hero, string hero_move, int hero_move_now, equip[] hero_equip, List<string> dialog, int dodge, int speed)
        {
            this.nama = nama;
            this.hp = hp;
            this.hero = hero;
            this.hero_move = hero_move;
            this.hero_move_now = hero_move_now;
            this.hero_equip = hero_equip;
            this.dialog = dialog;
            this.dodge = dodge;
            this.speed = speed;
            this.type = type;
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
        public void gambar(Graphics g)
        {
            object O = Properties.Resources.ResourceManager.GetObject(hero + "_" + hero_move + "___" + hero_move_now + "_");
            Image img = (Image)O;
            g.DrawImage(img, 0, 0, 100, 150);
        }
    }
    class ninja : karakter
    {
        public ninja(string nama, int hp, equip[] hero_equip, List<string> dialog, int dodge, int speed) 
            : base(nama, "ninja", hp, "ninja", "idle", 1, hero_equip, dialog, dodge, speed)
        {
        }
    }
    //class aladin : karakter
    //{
    //    public aladin(string nama, string type, int hp, string hero, string hero_move, int hero_move_now, equip[] hero_equip, List<string> dialog, int dodge, int speed) 
    //        : base(nama, type, hp, hero, "idle", 1, hero_equip, dialog, dodge, speed)
    //    {
    //    }
    //}
    //class archer : karakter
    //{
    //    public archer(string nama, string type, int hp, string hero, string hero_move, int hero_move_now, equip[] hero_equip, List<string> dialog, int dodge, int speed) 
    //        : base(nama, type, hp, hero, "idle", 1, hero_equip, dialog, dodge, speed)
    //    {
    //    }
    //}
    //class assasin : karakter
    //{
    //    public assasin(string nama, string type, int hp, string hero, string hero_move, int hero_move_now, equip[] hero_equip, List<string> dialog, int dodge, int speed) 
    //        : base(nama, type, hp, hero, "idle", 1, hero_equip, dialog, dodge, speed)
    //    {
    //    }
    //}
    //class druid : karakter
    //{
    //    public druid(string nama, string type, int hp, string hero, string hero_move, int hero_move_now, equip[] hero_equip, List<string> dialog, int dodge, int speed) 
    //        : base(nama, type, hp, hero, "idle", 1, hero_equip, dialog, dodge, speed)
    //    {
    //    }
    //}
    //class ghostPerson : karakter
    //{
    //    public ghostPerson(string nama, string type, int hp, string hero, string hero_move, int hero_move_now, equip[] hero_equip, List<string> dialog, int dodge, int speed) 
    //        : base(nama, type, hp, hero, "idle", 1, hero_equip, dialog, dodge, speed)
    //    {
    //    }
    //}
    //class giantLady : karakter
    //{
    //    public giantLady(string nama, string type, int hp, string hero, string hero_move, int hero_move_now, equip[] hero_equip, List<string> dialog, int dodge, int speed) 
    //        : base(nama, type, hp, hero, "idle", 1, hero_equip, dialog, dodge, speed)
    //    {
    //    }
    //}
    //class herbalist : karakter
    //{
    //    public herbalist(string nama, string type, int hp, string hero, string hero_move, int hero_move_now, equip[] hero_equip, List<string> dialog, int dodge, int speed) 
    //        : base(nama, type, hp, hero, "idle", 1, hero_equip, dialog, dodge, speed)
    //    {
    //    }
    //}
    public enum buff
    {
        poison,
        bleed
    }
}
