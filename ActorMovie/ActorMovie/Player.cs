using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ActorMovie
{
    public class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Face { get; set; }
        public Bitmap People { get; set; }
        //全局的变量，所有对象共有的
        public static int CurrentPlayer = 0;
        public int IsActive { get; set; }
        //记录当前动画真帧
        public int AnmFrame { get; set; }
        //记录上次移动的时间
        public long LastWalkTime { get; set; }
        public long WalkInterval { get; set; }
        public int Speed { get; set; }
        public Player()
        {
            this.IsActive = 0;
            this.Face = 1;
            this.AnmFrame = 0;
            this.LastWalkTime = 0;
            this.WalkInterval = 150;
            this.Speed = 15;
        }
        public static void KeyControl(Player[] player,KeyEventArgs e)
        {
            Player p = player[CurrentPlayer];
            if (e.KeyCode==Keys.NumPad5)
            {
                KeyChangePlayer(player);
            }
            if (e.KeyCode == Keys.NumPad8&&p.Face!=3)
            {
                p.Face = 3;
                //p.Y -= 5;
            }
            else if (e.KeyCode == Keys.NumPad2&&p.Face != 1)
            {
                p.Face = 1;
                //p.Y = p.Y + 5;
            }
            else if (e.KeyCode == Keys.NumPad4 && p.Face != 4)
            {
                p.Face = 4;
               // p.X -= 5;
            }
            else if (e.KeyCode == Keys.NumPad6 && p.Face != 2)
            {
                p.Face = 2;
                //p.X += 5;
            }
            else if (e.KeyCode == Keys.NumPad1 && p.Face != 5)
            {
                p.Face = 5;
               // p.X -= 3;
               // p.Y += 3;
            }
            else if (e.KeyCode == Keys.NumPad3 && p.Face != 6)
            {
                p.Face = 6;
               // p.X += 3;
               // p.Y += 3;
            }
            else if (e.KeyCode == Keys.NumPad7 && p.Face != 7)
            {
                p.Face = 7;
               // p.X -= 3;
               // p.Y -= 3;
            }
            else if (e.KeyCode == Keys.NumPad9 && p.Face != 8)
            {
                p.Face = 8;
                //p.X += 3;
               // p.Y -= 3;
            }
            if (Common.Time() - p.LastWalkTime <= p.WalkInterval)
                return;
            else if (e.KeyCode == Keys.NumPad8)
            {
                p.Y -= p.Speed;
            }
            else if (e.KeyCode == Keys.NumPad2)
            {
                p.Y += p.Speed;
            }
            else if (e.KeyCode == Keys.NumPad4)
            {
                p.X -= p.Speed;
            }
            else if (e.KeyCode == Keys.NumPad6)
            {
                p.X += p.Speed;
            }
            else if (e.KeyCode == Keys.NumPad1)
            {
                p.X -= p.Speed - 10;
                p.Y += p.Speed - 10;
            }
            else if (e.KeyCode == Keys.NumPad3)
            {
                p.X += p.Speed - 10;
                p.Y += p.Speed - 10;
            }
            else if (e.KeyCode == Keys.NumPad7)
            {
                p.X -= p.Speed - 10;
                p.Y -= p.Speed - 10;
            }
            else if (e.KeyCode == Keys.NumPad9)
            {
                p.X += p.Speed - 10;
                p.Y -= p.Speed - 10;
            }
            else
                return;
            p.AnmFrame = p.AnmFrame + 1;
            if (p.AnmFrame >= int.MaxValue)
                p.AnmFrame = 0;
            p.LastWalkTime = Common.Time();
        }
        public static void Draw(Player[] player,Graphics g)
        {
            Player p = player[CurrentPlayer];
            Rectangle rec = new Rectangle(p.People.Width / 4 * (p.AnmFrame % 4), p.People.Height / 8 * (p.Face - 1), p.People.Width / 4, p.People.Height / 8);
            Bitmap bit0 = p.People.Clone(rec, p.People.PixelFormat);
            g.DrawImage(bit0, p.X, p.Y);
        }
        public static void KeyChangePlayer(Player[] player)
        {
            for (int i = CurrentPlayer + 1; i < player.Length; i++)
            {
                if (player[i].IsActive == 1)
                {
                    SetPlayer(player, CurrentPlayer, i);
                    return;
                }
            }
            for (int i = 0; i < CurrentPlayer; i++)
            {
                if (player[i].IsActive == 1)
                {
                    SetPlayer(player, CurrentPlayer, i);
                    return;
                }
            }
        }
        public static void KeyUp(Player[] player,KeyEventArgs e)
        {
            Player p = player[CurrentPlayer];
            p.LastWalkTime = 0;
            p.AnmFrame = 0;
        }

        public static void SetPlayer(Player[] player,int oldIndex,int newIndex)
        {
            CurrentPlayer = newIndex;
            player[newIndex].X = player[oldIndex].X;
            player[newIndex].Y = player[oldIndex].Y;
            player[newIndex].Face = player[oldIndex].Face;
        }


    }
}
