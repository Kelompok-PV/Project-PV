using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PV
{
	class Abbey : GameState
	{
		GameStateManager gsm { get; set; }
		public Abbey(GameStateManager gsm)
		{
			this.gsm = gsm;
		}
		public override void draw(Graphics g)
		{
			object O1 = Project_PV.Properties.Resources.abbey_character_background;
			Image background = (Image)O1;
			g.DrawImage(background, 0, 0, 1300, 700);
		}

		public override void init()
		{
			throw new NotImplementedException();
		}

		public override void key_keydown(object sender, KeyEventArgs e)
		{
			throw new NotImplementedException();
		}

		public override void mouse_click(object sender, MouseEventArgs e)
		{
			throw new NotImplementedException();
		}

		public override void update()
		{
			throw new NotImplementedException();
		}
	}
}
