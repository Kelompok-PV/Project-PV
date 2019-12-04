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
        public int harga { get; set; }
        public int id { get; set; }
        public string desc { get; set; }
        public List<int> MyProperty { get; set; }

        protected Inventory(int x, int y, string name, int jumlah, int harga, int id, string desc)
        {
            this.x = x;
            this.y = y;
            this.name = name;
            this.jumlah = jumlah;
            this.harga = harga;
            this.id = id;
            this.desc = desc;
        }

        protected Inventory(int x, int y, int jumlah)
        {
            this.x = x;
            this.y = y;
            this.jumlah = jumlah;
        }

        public void getImage(Graphics g)
        {
            object O = Properties.Resources.ResourceManager.GetObject("inventory"+1);
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
        public LargeFood(int x, int y, int jumlah) : base(x, y, "Large Food", jumlah, 250, 1, "")
        {
        }

        public LargeFood(int x, int y, int jumlah, int id, string desc) 
            : base(x, y, "Large Food", jumlah, 250, 1, desc)
        {
        }

    }
    class SmallFood : Inventory
    {
        public SmallFood(int x, int y, int jumlah) : base(x, y, "Small Food", jumlah, 100, 2, "")
        {
        }

        public SmallFood(int x, int y, int jumlah, int id, string desc) 
            : base(x, y, "Small Food", jumlah, 0, 2, desc)
        {
        }
    }
    class Torch : Inventory
    {
        public Torch(int x, int y, int jumlah) : base(x, y, "Torch", jumlah, 50, 3, "")
        {
        }

        public Torch(int x, int y, int jumlah, int id, string desc) 
            : base(x, y, "Torch", jumlah, 0, 3, desc)
        {
        }
    }
    class Bandage : Inventory
    {
        public Bandage(int x, int y, int jumlah) : base(x, y, "Bandage", jumlah, 75, 4, "")
        {
        }

        public Bandage(int x, int y, int jumlah, int id, string desc) 
            : base(x, y, "Bandage", jumlah, 0, 4, desc)
        {
        }
    }
    class Gold : Inventory
    {
        public Gold(int x, int y, int jumlah) : base(x, y, "Gold", jumlah, 150, 5, "")
        {
        }

        public Gold(int x, int y, int jumlah, int id, string desc) 
            : base(x, y, "Gold", jumlah, 0, 5, desc)
        {
        }
    }
    class Jewel : Inventory
    {
        public Jewel(int x, int y, int jumlah) : base(x, y, "Jewel", jumlah, 125, 6, "")
        {
        }

        public Jewel(int x, int y, int jumlah, int id, string desc) 
            : base(x, y, "Jewel", jumlah, 0, 6, desc)
        {
        }
    }
    class Key : Inventory
    {
        public Key(int x, int y, int jumlah) : base(x, y, "Key", jumlah, 100, 7, "")
        {
        }

        public Key(int x, int y, int jumlah, int id, string desc) 
            : base(x, y, "Key", jumlah, 0, 7, desc)
        {
        }
    }
    class Shovel : Inventory
    {
        public Shovel(int x, int y, int jumlah) : base(x, y, "Shovel", jumlah, 275, 8, "")
        {
        }

        public Shovel(int x, int y, int jumlah, int id, string desc) 
            : base(x, y, "Shovel", jumlah, 0, 8, desc)
        {
        }
    }
    class TheCure : Inventory
    {
        public TheCure(int x, int y, int jumlah) : base(x, y, "TheCure", jumlah, 50, 9, "")
        {
        }

        public TheCure(int x, int y, int jumlah, int id, string desc) 
            : base(x, y, "TheCure", jumlah, 0, 9, desc)
        {
        }
    }
    class PotentSalve : Inventory
    {
        public PotentSalve(int x, int y, int jumlah) : base(x, y, "Potent Salve", jumlah, 300, 10, "")
        {
        }

        public PotentSalve(int x, int y, string name, int jumlah, int id, string desc) 
            : base(x, y, "Potent Salve", jumlah, 0, 10, desc)
        {
        }
    }


}
