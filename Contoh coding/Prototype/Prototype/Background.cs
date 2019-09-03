using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Background
    {
        public Bitmap image { get; set; }
        public Bitmap subImage { get; set; }
        public Rectangle rectangle { get; set; }
        public Rectangle srcRect { get; set; }
        public Graphics g { get; set; }
        public GraphicsUnit units { get; set; }
        public string location { get; set; }

        //koordinat gambar utama
        public int x { get; set; } = 0;
        public int y { get; set; } = 0;

        //koordinat gambar kedua
        public int left { get; set; } = -2045;
        public int right { get; set; } = 2045;
        public Background(string location)
        {
            this.location = location;
            if (!location.Equals("back.gif"))
            {
                // Create image.
                image = new Bitmap("assets\\" + location);

                // Create rectangle for displaying image.
                rectangle = new Rectangle(0,0, 2048, 630);

               
            }
            else
            {
                image = new Bitmap("assets\\" + location);
            }
            
        }

        public void Draw(Graphics g)
        {
            Graphics g2 = g;
            if (!location.Equals("Back2.gif"))
            {
                if (x >= 2045)
                {
                    x = 0;
                    left = -2045;
                }
                else if (x <= -2045)
                {
                    x = 0;
                    right = 2045;
                }

                // Create rectangle for source image.
                srcRect = new Rectangle(x, y, 2048, 630);
                units = GraphicsUnit.Pixel;
                g.DrawImage(image, rectangle, srcRect, units);

                if (x >= 850)
                {
                    g.DrawString("Masuk Left", new Font("arial", 22, FontStyle.Bold), new SolidBrush(Color.Pink), 0, 66);
                    srcRect = new Rectangle(left, y, 2048, 630);
                    units = GraphicsUnit.Pixel;
                    g2.DrawImage(image, rectangle, srcRect, units);
                }
                else if (x < 0)
                {
                    srcRect = new Rectangle(right, y, 2048, 630);
                    units = GraphicsUnit.Pixel;
                    g2.DrawImage(image, rectangle, srcRect, units);
                }

            }
            else
            {
                g.DrawImage(image, 0, 0, 1200, 720);
            }

            g.DrawString("X : " + x, new Font("arial", 22, FontStyle.Bold), new SolidBrush(Color.White), 0, 0);
            g.DrawString("Left : " + left, new Font("arial", 22, FontStyle.Bold), new SolidBrush(Color.White), 0, 22);
            g.DrawString("Right : " + right, new Font("arial", 22, FontStyle.Bold), new SolidBrush(Color.White), 0, 44);

            //g.DrawString("Player index : "+Player.index, new Font("arial", 22, FontStyle.Bold), new SolidBrush(Color.Pink), 0, 88);
        }
    }
}
