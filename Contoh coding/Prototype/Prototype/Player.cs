using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype
{
    class Player
    {
        public List<Bitmap> Avatar { get; set; } = new List<Bitmap>();
        public List<Bitmap> Idle { get; set; } = new List<Bitmap>();
        public List<Bitmap> Run { get; set; } = new List<Bitmap>();
        public List<Bitmap> Jump { get; set; } = new List<Bitmap>();
        public Status status { get; set; }

        public int index { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }
        public Player()
        {
            index = 0;
            posX = 0;
            posY = 200;
            status = Status.run;

            addIdle();
            addRun();
            addJump();

            //load sprite biar bisa ditampilkan
            setAvatar(status);
        }

        public void setIndex(int index)
        {
            this.index = index;
            if(index == Avatar.Count-1)
            {
                this.index = 0;
            }
            else if(index == -1)
            {
                this.index = Avatar.Count-1;
            }
            else
            {
                this.index = index;
            }
        }

        public void addIdle()
        {
            Idle.Add(new Bitmap("assets\\char\\Idle\\Idle (1).png"));
            Idle.Add(new Bitmap("assets\\char\\Idle\\Idle (2).png"));
            Idle.Add(new Bitmap("assets\\char\\Idle\\Idle (3).png"));
            Idle.Add(new Bitmap("assets\\char\\Idle\\Idle (4).png"));
            Idle.Add(new Bitmap("assets\\char\\Idle\\Idle (5).png"));
            Idle.Add(new Bitmap("assets\\char\\Idle\\Idle (6).png"));
            Idle.Add(new Bitmap("assets\\char\\Idle\\Idle (7).png"));
            Idle.Add(new Bitmap("assets\\char\\Idle\\Idle (8).png"));
            Idle.Add(new Bitmap("assets\\char\\Idle\\Idle (9).png"));
        }

        public void addRun()
        {
            Run.Add(new Bitmap("assets\\char\\Run (1).png"));
            Run.Add(new Bitmap("assets\\char\\Run (2).png"));
            Run.Add(new Bitmap("assets\\char\\Run (3).png"));
            Run.Add(new Bitmap("assets\\char\\Run (4).png"));
            Run.Add(new Bitmap("assets\\char\\Run (5).png"));
            Run.Add(new Bitmap("assets\\char\\Run (6).png"));
            Run.Add(new Bitmap("assets\\char\\Run (7).png"));
            Run.Add(new Bitmap("assets\\char\\Run (8).png"));
        }

        public void addJump()
        {
            Jump.Add(new Bitmap("assets\\char\\Jump\\Jump (1).png"));
            Jump.Add(new Bitmap("assets\\char\\Jump\\Jump (2).png"));
            Jump.Add(new Bitmap("assets\\char\\Jump\\Jump (3).png"));
            Jump.Add(new Bitmap("assets\\char\\Jump\\Jump (4).png"));
            Jump.Add(new Bitmap("assets\\char\\Jump\\Jump (5).png"));
            Jump.Add(new Bitmap("assets\\char\\Jump\\Jump (6).png"));
            Jump.Add(new Bitmap("assets\\char\\Jump\\Jump (7).png"));
            Jump.Add(new Bitmap("assets\\char\\Jump\\Jump (8).png"));
            Jump.Add(new Bitmap("assets\\char\\Jump\\Jump (9).png"));
            Jump.Add(new Bitmap("assets\\char\\Jump\\Jump (10).png"));
        }

        public void setAvatar(Status status)
        {
            Avatar.Clear();
            if (status == Status.idle)
            {
                for (int i = 0; i < Idle.Count; i++)
                {
                    Avatar.Add(new Bitmap(Idle[i]));
                }
            }
            else if (status == Status.run)
            {
                for (int i = 0; i < Run.Count; i++)
                {
                    Avatar.Add(new Bitmap(Run[i]));
                }
            }
            else if (status == Status.jump)
            {
                for (int i = 0; i < Jump.Count; i++)
                {
                    Avatar.Add(new Bitmap(Jump[i]));
                }
            }
        }

        public void Draw(Graphics g)
        {
            if(index > Avatar.Count-1 && status != Status.run)
            {
                index = 0;
            }

            //g.DrawImage(Avatar[index], 0, posY, 300, 300);

            if(status == Status.idle || status == Status.jump)
            {
                index++;
            }
            
        }
    }
    public enum Status
    {
        idle,
        run,
        jump
    }
}
