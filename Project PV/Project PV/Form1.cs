using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Diagnostics;
using System.Media;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml;

namespace Project_PV
{
    public partial class Form1 : Form
    {
        GameStateManager manager;
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            Config.form1 = this;
        }
        Random rand = new Random();
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g = e.Graphics;
            Config.rect = this.ClientRectangle;
            manager.draw(g);

        }
        int gold;
        string nama;
        string hero;
        int min_damage;
        int max_damage;
        int maxHp;
        int hp;
        int speed;
        int level;
        string stress_level;
        stress_stage status;
        int stress_point;
        List<efek> buff_list = new List<efek>();
        List<int> buff_turn_list = new List<int>();
        string buff_temp;
        efek[] arrTemp = { efek.none,efek.armor, efek.bleed, efek.blight, efek.heal, efek.marked, efek.stress, efek.stun };
        private void Form1_Load(object sender, EventArgs e)
        {
            //axWindowsMediaPlayer1.Hide();
            //sfx_player.Hide();
            Config.font.AddFontFile("Resources\\DwarvenAxe BB W00 Regular.ttf");

            manager = new GameStateManager();
            try
            {
                manager.player.myCharacter.Clear();
                XmlTextReader reader = new XmlTextReader("player.xml");
                reader.ReadStartElement("root");
                while (reader.IsStartElement("player"))
                {
                    reader.ReadStartElement("player");
                    gold = Convert.ToInt32(reader.ReadElementString("gold"));
                    nama = reader.ReadElementString("nama");
                    hero = reader.ReadElementString("hero");
                    min_damage = Convert.ToInt32(reader.ReadElementString("min_damage"));
                    max_damage = Convert.ToInt32(reader.ReadElementString("max_damage"));
                    maxHp = Convert.ToInt32(reader.ReadElementString("maxHp"));
                    hp = Convert.ToInt32(reader.ReadElementString("hp"));
                    speed = Convert.ToInt32(reader.ReadElementString("speed"));
                    level = Convert.ToInt32(reader.ReadElementString("level"));
                    stress_level = reader.ReadElementString("hero_stress_level");
                    buff_list.Clear();
                    buff_turn_list.Clear();
                    
                    
                    
                    if(stress_level == "normal")
                    {
                        status = stress_stage.normal;
                    }
                    else
                    {
                        status = stress_stage.depresi;
                    }
                    stress_point = Convert.ToInt32(reader.ReadElementString("hero_stress_point"));

                    if(hero == "ninja")
                    {
                        karakter hero = new ninja(nama);
                        overRideHero(hero);
                    }
                    else if (hero == "archer")
                    {
                        karakter hero = new archer(nama);
                        overRideHero(hero);
                    }
                    else if (hero == "aladin")
                    {
                        karakter hero = new aladin(nama);
                        overRideHero(hero);
                    }
                    else if (hero == "tonyStark")
                    {
                        karakter hero = new Tony(nama);
                        overRideHero(hero);
                    }
                    else if (hero == "druid")
                    {
                        karakter hero = new druid(nama);
                        overRideHero(hero);
                    }
                    else if (hero == "iceWoman")
                    {
                        karakter hero = new IceWoman(nama);
                        overRideHero(hero);
                    }
                    else if (hero == "hercules")
                    {
                        karakter hero = new Hercules(nama);
                        overRideHero(hero);
                    }
                    else if (hero == "giantLady")
                    {
                        karakter hero = new giantLady(nama);
                        overRideHero(hero);
                    }
                    
                    reader.ReadEndElement();
                }
                manager.player.gold = gold;
                reader.ReadEndElement();
                reader.Close();

                XmlTextReader buffReader = new XmlTextReader("buff.xml");
                buffReader.ReadStartElement("root");
                while (buffReader.IsStartElement("buff"))
                {
                    buffReader.ReadStartElement("buff");
                    buff_temp = buffReader.ReadElementString("hero_buff");
                    for (int i = 0; i < arrTemp.Length; i++)
                    {
                        if (arrTemp[i].ToString() == buff_temp)
                        {
                            manager.player.myCharacter[manager.player.myCharacter.Count - 1].hero_buff = arrTemp[i];
                        }
                    }
                    string turn_temp = buffReader.ReadElementString("hero_buff_turn");
                    manager.player.myCharacter[manager.player.myCharacter.Count - 1].hero_buff_turn = Convert.ToInt32(turn_temp);

                    buffReader.ReadEndElement();
                }
                buffReader.ReadEndElement();
                buffReader.Close();

            }
            catch (Exception)
            {
                //MessageBox.Show("load error");
                manager.player.myCharacter.Add(new ninja("Hatory"));
                manager.player.myCharacter.Add(new aladin("aladin"));
                manager.player.currentCharacters.Add(manager.player.myCharacter[0]);
                manager.player.currentCharacters.Add(manager.player.myCharacter[1]);
            }

        }

        private void overRideHero(karakter hero)
        {
            manager.player.myCharacter.Add(hero);
            manager.player.myCharacter[manager.player.myCharacter.Count - 1].min_damage = min_damage;
            manager.player.myCharacter[manager.player.myCharacter.Count - 1].max_damage = max_damage;
            manager.player.myCharacter[manager.player.myCharacter.Count - 1].maxHp = maxHp;
            manager.player.myCharacter[manager.player.myCharacter.Count - 1].hp = hp;
            manager.player.myCharacter[manager.player.myCharacter.Count - 1].speed = speed;
            manager.player.myCharacter[manager.player.myCharacter.Count - 1].level = level;
            manager.player.myCharacter[manager.player.myCharacter.Count - 1].hero_stress.stress_level = status;
            manager.player.myCharacter[manager.player.myCharacter.Count - 1].hero_stress.stress_point = stress_point;
        }

        //private int FPS = 60;
        private long targetTime = 1000 / 60;
        private void timer1_Tick(object sender, EventArgs e)
        {
            long start;
            long elapsed;
            long wait;

            start = nanoTime();
            manager.update();
            Invalidate();
            elapsed = nanoTime() - start;

            //targettime = 1000/ FPS = 1000 / 60 = ... (miliseconds / frame)
            //calculate wait for accuracy
            wait = targetTime - elapsed / 1000000;
            //anticipate lag
            if (wait < 0) wait = 5;

            try
            {
                timer1.Interval = (int)wait;
            }
            catch (Exception)
            {

                
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("x: "+e.X+" y: "+e.Y);
            //Cursor.Current = new Cursor(Project_PV.Properties.Resources.arrow.GetHicon());
            manager.mouse_click(sender, e);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            manager.key_keydown(sender, e);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            manager.Form1_KeyUp(sender, e);
        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {
            //Cursor.Current = new Cursor(Project_PV.Properties.Resources.arrow.GetHicon());
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //Cursor.Current = new Cursor(Project_PV.Properties.Resources.arrow.GetHicon());
            manager.mouse_hover(sender,e);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Current = new Cursor(Project_PV.Properties.Resources.arrow.GetHicon());
        }
        
        private long nanoTime()
        {
            long nano = 10000L * Stopwatch.GetTimestamp();
            nano /= TimeSpan.TicksPerMillisecond;
            nano *= 100L;
            return nano;
        }
        IFormatter formatter = new BinaryFormatter();
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            XmlTextWriter writer = new XmlTextWriter("player.xml", Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartElement("root");                               //<root>
            for (int i = 0; i < manager.player.myCharacter.Count; i++)
            {
                writer.WriteStartElement("player");
                writer.WriteElementString("gold", manager.player.gold.ToString());
                writer.WriteElementString("nama", manager.player.myCharacter[i].nama.ToString());
                writer.WriteElementString("hero", manager.player.myCharacter[i].hero.ToString());
                writer.WriteElementString("min_damage", manager.player.myCharacter[i].min_damage.ToString());
                writer.WriteElementString("max_damage", manager.player.myCharacter[i].max_damage.ToString());
                writer.WriteElementString("maxHp", manager.player.myCharacter[i].maxHp.ToString());
                writer.WriteElementString("hp", manager.player.myCharacter[i].hp.ToString());
                writer.WriteElementString("speed", manager.player.myCharacter[i].speed.ToString());
                writer.WriteElementString("level", manager.player.myCharacter[i].level.ToString());
                writer.WriteElementString("hero_stress_level", manager.player.myCharacter[i].hero_stress.stress_level.ToString());
                writer.WriteElementString("hero_stress_point", manager.player.myCharacter[i].hero_stress.stress_point.ToString());
                
                
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.Close();

            XmlTextWriter buffWriter = new XmlTextWriter("buff.xml", Encoding.UTF8);
            buffWriter.Formatting = Formatting.Indented;
            buffWriter.WriteStartElement("root");
            for (int i = 0; i < manager.player.myCharacter.Count; i++)
            {
                buffWriter.WriteStartElement("buff");
                buffWriter.WriteElementString("hero_buff", manager.player.myCharacter[i].hero_buff.ToString());
                buffWriter.WriteElementString("hero_buff_turn", manager.player.myCharacter[i].hero_buff_turn.ToString());

                buffWriter.WriteEndElement();
            }
            buffWriter.WriteEndElement();
            buffWriter.Close();
        }
    }
}
