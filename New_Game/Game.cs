using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_Game
{
    public enum Players
    {
        Not,
        Cross,
        Zero
    }
    public partial class Game : Form
    {
       
        Players cur_player = Players.Zero;
        Players[] area = new Players[9];
        Players win = Players.Not;

        public Game()
        {
            InitializeComponent();
        }

        public void is_end()
        {
            if (area[0].Equals(area[1]) && area[0].Equals(area[2]) && !area[0].Equals(Players.Not))
            {
                win = area[0];
            } else if (area[3].Equals(area[4]) && area[3].Equals(area[5]) && !area[3].Equals(Players.Not))
            {
                win = area[3];
            }else if (area[6].Equals(area[7]) && area[6].Equals(area[8]) && !area[6].Equals(Players.Not))
            {
                win = area[6];
            }else if (area[0].Equals(area[3]) && area[0].Equals(area[6]) && !area[0].Equals(Players.Not))
            {
                win = area[0];
            } else if (area[1].Equals(area[4]) && area[1].Equals(area[7]) && !area[1].Equals(Players.Not))
            {
                win = area[1];
            } else if (area[2].Equals(area[5]) && area[2].Equals(area[8]) && !area[2].Equals(Players.Not))
            {
                win = area[2];
            } else if (area[0].Equals(area[4]) && area[0].Equals(area[8]) && !area[0].Equals(Players.Not))
            {
                win = area[0];
            } else if (area[2].Equals(area[4]) && area[2].Equals(area[6]) && !area[2].Equals(Players.Not))
            {
                
            }
        }

        private void masiv_pos (int pos, Players cur_player)
        {
            area[pos] = cur_player;
        }

        private void button_process(Button button, int pos)
        {
            if (cur_player == Players.Zero)
            {
                Bitmap bmp = new Bitmap(Properties.Resources.Мимозыря);
                button.BackgroundImage = bmp;
                button.BackgroundImageLayout = ImageLayout.Stretch;
                cur_player = Players.Cross;
                masiv_pos(pos, Players.Cross);
            }
            else
            if (cur_player == Players.Cross)
            {
                Bitmap bmp = new Bitmap(Properties.Resources.Чикибамбони);
                button.BackgroundImage = bmp;
                button.BackgroundImageLayout = ImageLayout.Stretch;
                cur_player = Players.Zero;
                masiv_pos(pos, Players.Zero);
            }
            button.Enabled = false;
            is_end();
            if (!win.Equals(Players.Not))
            {
                using (Win f = new Win(win))
                {
                    f.ShowDialog();
                }
            }
        }



        private void Game_Load(object sender, EventArgs e)
        {

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            button_process(button7, 0);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            button_process(button8, 1);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            button_process(button9, 2);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            button_process(button4, 3);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            button_process(button5, 4);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            button_process(button6, 5);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            button_process(button1, 6);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            button_process(button2, 7);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            button_process(button3, 8);
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            Button[] buttons = new Button[] { button7, button8, button9, button4, button3, button5, button6, button2, button3, button1 };
           for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Enabled = true;
                buttons[i].BackgroundImage = null;
            }
             cur_player = Players.Zero;
            area = new Players[9];
            win = Players.Not;
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
