using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ActorMovie
{
    /// <summary>
    /// 版本1
    /// </summary>
    public partial class Form1 : Form
    {
        public Player[] Users{ get; set; }
        int control = 0;
        public Form1()
        {
            InitializeComponent();
            this.Users = new Player[3];
            this.Users[0]=new Player();
            this.Users[0].People=new Bitmap(@"11.png");
            this.Users[0].People.SetResolution(96,96);
            this.Users[0].IsActive=1;
            this.Users[1]=new Player();
            this.Users[1].People=new Bitmap(@"22.png");
            this.Users[1].People.SetResolution(96,96);
            this.Users[1].IsActive=1;
            this.Users[2]=new Player();
            this.Users[2].People=new Bitmap(@"33.png");
            this.Users[2].People.SetResolution(96,96);
            this.Users[2].IsActive=1;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Player.KeyControl(Users,e);
            Draw();
        }

        private void Draw()
        {
            control += 1;
            Graphics g = pictureBox1.CreateGraphics();
            BufferedGraphicsContext currentContext = BufferedGraphicsManager.Current;
            BufferedGraphics myBuffer = currentContext.Allocate(g, this.DisplayRectangle);
            Graphics g1 = myBuffer.Graphics;
            Player.Draw(Users,g1);
            myBuffer.Render();
            myBuffer.Dispose();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Player.KeyUp(Users, e);
            Draw();
        }

        private void btnSpeed_Click(object sender, EventArgs e)
        {
            foreach (var x in Users)
            {
                if (x.Speed == 15)
                    x.Speed = 30;
                else
                    x.Speed =15;
            }
        }
    }
}
