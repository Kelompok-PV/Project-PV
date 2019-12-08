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
        public List<Skill> skill { get; set; }
        public string tipe { get; set; }
        public string tipe_gerak { get; set; }
        public int tipe_gerak_ke { get; set; }
        public int x { get; set; }

        public musuh(int hp, List<Skill> skill, string tipe, string tipe_gerak, int tipe_gerak_ke,int x)
        {
            this.hp = hp;
            this.skill = skill;
            this.tipe = tipe;
            this.tipe_gerak = tipe_gerak;
            this.tipe_gerak_ke = tipe_gerak_ke;
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
                tipe_gerak_ke = 1;
                gambar(g);
            }
        }
        public void gambar(Graphics g)
        {
            object O = Properties.Resources.ResourceManager.GetObject(tipe + "_" + tipe_gerak + "___" + tipe_gerak_ke+ "_");
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
            object O = Properties.Resources.ResourceManager.GetObject(tipe + "_" + tipe_gerak + "___" + tipe_gerak_ke + "_");
            Image img = (Image)O;
            g.DrawImage(img, x - zoom / 2, 250 - zoom, 100 + zoom, 150 + zoom);
        }
    }

    class yeti : musuh
    {
        public yeti(int x)
            : base(20,new List<Skill>(),"yeti","idle",1,x)
        {
            skill.Add(new yeti1());
            skill.Add(new yeti2());
            skill.Add(new yeti3());
            skill.Add(new yeti4());
        }
    }
}

