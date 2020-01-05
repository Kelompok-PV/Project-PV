using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace Project_PV
{

    [Serializable]
    abstract class Inventory
    {
        public int x { get; set; }
        public int y { get; set; }
        public string name { get; set; }
        public int jumlah { get; set; }
        public int harga { get; set; }
        public int id { get; set; }
        public string desc { get; set; }
        public List<int> MyProperty { get; set; }

        
        public Image gambar { get; set; }
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

        public void getImage(Graphics g,float x,int y)
        {
            object O = Properties.Resources.ResourceManager.GetObject("inventory"+this.id);
            Image img = (Image)O;
            g.DrawImage(img,x,y,50,110);
        }

        void getEffect(Inventory inv,karakter karakterPilih)
        {
            if (inv is LargeFood)
            {
                karakterPilih.hp += 40;
            }
            else if (inv is SmallFood)
            {
                karakterPilih.hp += 20;
            }
            else if (inv is Torch)
            {
                karakterPilih.hero_stress.stress_point -= 5;
            }
            else if (inv is Bandage)
            {
                karakterPilih.hp += 10;
            }
            else if (inv is Gold)
            {
                karakterPilih.hero_stress.stress_point -= 10;
            }
            else if (inv is Jewel)
            {
                karakterPilih.hero_stress.stress_point -= 12;
            }
            else if (inv is Key)
            {
                //karakterPilih.hero_buff = efek.heal;
                karakterPilih.hero_stress.stress_point -= 5;
            }
            else if (inv is Shovel)
            {
                //karakterPilih.hero_buff = efek.none;
            }
            else if (inv is TheCure)
            {
                //karakterPilih.hero_buff = efek.none;
                karakterPilih.hp += 5;
            }
            else if (inv is PotentSalve)
            {
                //karakterPilih.hero_buff = efek.heal;
            }

            if (karakterPilih.hero_stress.stress_point <= 0)
            {
                if (karakterPilih.hero_stress.stress_level==stress_stage.depresi)
                {
                    karakterPilih.hero_stress.stress_point = 100 + karakterPilih.hero_stress.stress_point;
                    karakterPilih.hero_stress.stress_level = stress_stage.normal;
                }
                else
                {
                    karakterPilih.hero_stress.stress_point=0;
                }
            }
            if (karakterPilih.hp >= karakterPilih.maxHp)
            {
                karakterPilih.hp = karakterPilih.maxHp;
            }
        }
    }
    
    class LargeFood : Inventory
    {
        public LargeFood(int x, int y, int jumlah) : base(x, y, "Large Food", jumlah, 75, 1, "+40 HP")
        {
            gambar = (Image)Properties.Resources.inv_provision__3;
        }

        public LargeFood(int x, int y, int jumlah, int id, string desc) 
            : base(x, y, "Large Food", jumlah, 0, 1, desc)
        {
        }

    }
    
    class SmallFood : Inventory
    {
        public SmallFood(int x, int y, int jumlah) : base(x, y, "Small Food", jumlah, 75, 2, "+20 HP")
        {
            gambar = (Image)Properties.Resources.inv_provision__1;
        }

        public SmallFood(int x, int y, int jumlah, int id, string desc) 
            : base(x, y, "Small Food", jumlah, 0, 2, desc)
        {
        }
    }
    
    class Torch : Inventory
    {
        public Torch(int x, int y, int jumlah) : base(x, y, "Torch", jumlah, 75, 3, "-5 Stress Point")
        {
            gambar = (Image)Properties.Resources.inv_supply_torch;
        }

        public Torch(int x, int y, int jumlah, int id, string desc) 
            : base(x, y, "Torch", jumlah, 0, 3, desc)
        {
        }
    }
    
    class Bandage : Inventory
    {
        public Bandage(int x, int y, int jumlah) : base(x, y, "Bandage", jumlah, 150, 4, "+10 HP")
        {
            gambar = (Image)Properties.Resources.inv_supply_bandage;
        }

        public Bandage(int x, int y, int jumlah, int id, string desc) 
            : base(x, y, "Bandage", jumlah, 0, 4, desc)
        {
        }
    }
    
    class Gold : Inventory
    {
        public Gold(int x, int y, int jumlah) : base(x, y, "Gold", jumlah, 200, 5, "-10 Stress Point")
        {
            gambar = (Image)Properties.Resources.inv_gold__3;
        }

        public Gold(int x, int y, int jumlah, int id, string desc) 
            : base(x, y, "Gold", jumlah, 0, 5, desc)
        {
        }
    }
    
    class Jewel : Inventory
    {
        public Jewel(int x, int y, int jumlah) : base(x, y, "Jewel", jumlah, 250, 6, "-12 Stress Point")
        {
            gambar = (Image)Properties.Resources.inv_gem_emerald;
        }

        public Jewel(int x, int y, int jumlah, int id, string desc) 
            : base(x, y, "Jewel", jumlah, 0, 6, desc)
        {
        }
    }
    
    class Key : Inventory
    {
        public Key(int x, int y, int jumlah) : base(x, y, "Key", jumlah, 200, 7, "Buff efek heal \n -5 Stress Point")
        {
            gambar = (Image)Properties.Resources.inv_supply_skeleton_key;
        }

        public Key(int x, int y, int jumlah, int id, string desc) 
            : base(x, y, "Key", jumlah, 0, 7, desc)
        {
        }
    }
    
    class Shovel : Inventory
    {
        public Shovel(int x, int y, int jumlah) : base(x, y, "Shovel", jumlah, 250, 8, "Clear Buff")
        {
            gambar = (Image)Properties.Resources.inv_supply_shovel;
        }

        public Shovel(int x, int y, int jumlah, int id, string desc) 
            : base(x, y, "Shovel", jumlah, 0, 8, desc)
        {
        }
    }
    
    class TheCure : Inventory
    {
        public TheCure(int x, int y, int jumlah) : base(x, y, "TheCure", jumlah, 0, 9, "Clear Buff \n +5 HP")
        {
            gambar = (Image)Properties.Resources.inv_estate_the_cure;
        }

        public TheCure(int x, int y, int jumlah, int id, string desc) 
            : base(x, y, "TheCure", jumlah, 0, 9, desc)
        {
        }
    }
    
    class PotentSalve : Inventory
    {
        public PotentSalve(int x, int y, int jumlah) : base(x, y, "Potent Salve", jumlah, 300, 10, "Buff efek heal")
        {
            gambar = (Image)Properties.Resources.inv_provision__0;
        }

        public PotentSalve(int x, int y, string name, int jumlah, int id, string desc) 
            : base(x, y, "Potent Salve", jumlah, 0, 10, desc)
        {
        }
    }

    //public enum efek
    //{
    //    blight,
    //    bleed,
    //    stun,
    //    marked,
    //    armor,
    //    stress,
    //    heal
    //}

}
