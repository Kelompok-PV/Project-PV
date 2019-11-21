using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PV
{
    class MainMenu : GameState
    {
        public GameStateManager gsm { get; set; }
        private double xCloud, yCloud;
        private Rectangle sanitarium, guild, blackSmith, abbey;
        private List<Rectangle> listRec;
        public MainMenu(GameStateManager gsm)
        {
            this.gsm = gsm;
            xCloud = 1100;
            yCloud = 40;
            listRec = new List<Rectangle>();

        }

        public override void draw(Graphics g)
        {
            object O1 = Properties.Resources.ResourceManager.GetObject("town_full1");
            Image img1 = (Image)O1;
            g.DrawImage(img1, 0, 0, 1300, 700);

            O1 = Properties.Resources.ResourceManager.GetObject("town_cloud");
            img1 = (Image)O1;
            g.DrawImage(img1, (int)xCloud, 40, 433, 124);

            //for (int i = 0; i < listRec.Count; i++)
            //{
            //    g.FillRectangle(new SolidBrush(Color.Red),listRec[i]);
            //}
        }

        public override void init()
        {
            throw new NotImplementedException();
        }

        public override void mouse_click(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("x: " + e.X + " y: " + e.Y);
            Rectangle cursor = new Rectangle(e.X,e.Y,10,10);

            sanitarium = new Rectangle(526,328,80,106);

            guild = new Rectangle(819, 377, 94, 139);

            blackSmith = new Rectangle(931, 501, 136, 79);

            abbey = new Rectangle(632, 225, 168, 137);

            if (cursor.IntersectsWith(blackSmith))
            {
                MessageBox.Show("BlackSmith");
            }
            else if (cursor.IntersectsWith(sanitarium))
            {
                MessageBox.Show("sanitarium");
            }
            else if (cursor.IntersectsWith(guild))
            {
                MessageBox.Show("guild");
            }
            else if (cursor.IntersectsWith(abbey))
            {
                MessageBox.Show("abbey");
            }

            listRec.Clear();
            listRec.Add(sanitarium);
            listRec.Add(guild);
            listRec.Add(abbey);
            listRec.Add(blackSmith);
        }

        public override void update()
        {
            xCloud-=1;
        }

        public override void key_keydown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
