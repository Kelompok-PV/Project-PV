using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Project_PV
{
    public abstract class Inventory
    {
        public int x { get; set; }
        public int y { get; set; }
        public string name { get; set; }
        public int jumlah { get; set; }
        public int id { get; set; }
        public string desc { get; set; }
        public List<int> MyProperty { get; set; }

        protected Inventory(int x, int y, string name, int jumlah, int id, string desc)
        {
            this.x = x;
            this.y = y;
            this.name = name;
            this.jumlah = jumlah;
            this.id = id;
            this.desc = desc;
        }

        public void getImage(Graphics g)
        {
            object O = Properties.Resources.ResourceManager.GetObject("inventory"+this.id);
            Image img = (Image)O;
            g.DrawImage(img,0,0,50,50);
        }

        public void getEffect(Inventory inv,karakter karakterPilih)
        {
            if (inv is LargeFood)
            {
                karakterPilih.hp += 10;
            }
            else if (inv is SmallFood)
            {

            }
            else if (inv is Torch)
            {

            }
            else if (inv is Bandage)
            {

            }
            else if (inv is Gold)
            {

            }
            else if (inv is Jewel)
            {

            }
            else if (inv is Key)
            {

            }
            else if (inv is Shovel)
            {

            }
            else if (inv is TheCure)
            {

            }
            else if (inv is PotentSalve)
            {


            }
        }
    }
    class LargeFood : Inventory
    {
        public LargeFood(int x, int y, int jumlah, int id, string desc) 
            : base(x, y, "Large Food", jumlah, 1, desc)
        {
        }
    }
    class SmallFood : Inventory
    {
        public SmallFood(int x, int y, int jumlah, int id, string desc) 
            : base(x, y, "Small Food", jumlah, 2, desc)
        {
            
        }
    }
    class Torch : Inventory
    {
        public Torch(int x, int y, int jumlah, int id, string desc) 
            : base(x, y, "Torch", jumlah, 3, desc)
        {
        }
    }
    class Bandage : Inventory
    {
        public Bandage(int x, int y, int jumlah, int id, string desc) 
            : base(x, y, "Bandage", jumlah, 4, desc)
        {
        }
    }
    class Gold : Inventory
    {
        public Gold(int x, int y, int jumlah, int id, string desc) 
            : base(x, y, "Gold", jumlah, 5, desc)
        {
        }
    }
    class Jewel : Inventory
    {
        public Jewel(int x, int y, int jumlah, int id, string desc) 
            : base(x, y, "Jewel", jumlah, 6, desc)
        {
        }
    }
    class Key : Inventory
    {
        public Key(int x, int y, int jumlah, int id, string desc) 
            : base(x, y, "Key", jumlah, 7, desc)
        {
        }
    }
    class Shovel : Inventory
    {
        public Shovel(int x, int y, int jumlah, int id, string desc) 
            : base(x, y, "Shovel", jumlah, 8, desc)
        {
        }
    }
    class TheCure : Inventory
    {
        public TheCure(int x, int y, int jumlah, int id, string desc) 
            : base(x, y, "TheCure", jumlah, 9, desc)
        {
        }
    }
    class PotentSalve : Inventory
    {
        public PotentSalve(int x, int y, string name, int jumlah, int id, string desc) 
            : base(x, y, "Potent Salve", jumlah, 10, desc)
        {
        }
    }


}
