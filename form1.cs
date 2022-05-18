using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048game
{
    public partial class Form1 : Form
    {
        Label[,] game_board;
        int n = 4;
        int r_x, r_y;
        string r;
        public Form1()
        {
            InitializeComponent();
            game_board = new Label[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    game_board[i, j] = new Label();

                    //  game_board[i, j].Text = "2";

                    game_board[i, j].Anchor = AnchorStyles.Top |
                                              AnchorStyles.Bottom |
                                                     AnchorStyles.Left |
                                                         AnchorStyles.Right;

                    game_board[i, j].Font = new Font("Tahoma", 33);
                    game_board[i, j].ForeColor = Color.FromArgb(118, 112, 104);
                    game_board[i, j].BackColor = Color.FromArgb(205, 193, 181);

                    game_board[i, j].BorderStyle = new BorderStyle();

                    var margin = game_board[i, j].Margin;

                    margin.All = 4;

                    game_board[i, j].Margin = margin;

                    game_board[i, j].TextAlign = ContentAlignment.MiddleCenter;

                    tableLayoutPanel1.Controls.Add(game_board[i, j], i, j);
                   

                }

            }
            numbergenerator();
            numbergenerator();
            colors();

        }


        private void numbergenerator()
        {
            var rand = new Random();
            int[] num = { 2, 2, 2, 4 };

            do
            {
                r_x = rand.Next(0, n);
                r_y = rand.Next(0, n);

            } while (game_board[r_x, r_y].Text != "");

            r = (num[rand.Next(0, num.Length)]).ToString();
            game_board[r_x, r_y].Text = r;

        }
        private void colors()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (game_board[i, j].Text == "")
                    {
                        game_board[i, j].BackColor = Color.FromArgb(204, 197, 178);
                        game_board[i, j].ForeColor = Color.FromArgb(118, 109, 100);

                    }
                    if (game_board[i, j].Text == "2")
                    {
                        game_board[i, j].BackColor = Color.FromArgb(238, 228, 218);
                        game_board[i, j].ForeColor = Color.FromArgb(118, 109, 100);

                    }
                    if (game_board[i, j].Text == "4")
                    {
                        game_board[i, j].BackColor = Color.FromArgb(236, 224, 200);
                        game_board[i, j].ForeColor = Color.FromArgb(117, 109, 99);
                    }
                    if (game_board[i, j].Text == "8")
                    {
                        game_board[i, j].BackColor = Color.FromArgb(242, 117, 121);
                        game_board[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (game_board[i, j].Text == "16")
                    {
                        game_board[i, j].BackColor = Color.FromArgb(246, 148, 99);
                        game_board[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (game_board[i, j].Text == "32")
                    {
                        game_board[i, j].BackColor = Color.FromArgb(245, 124, 95);
                        game_board[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (game_board[i, j].Text == "64")
                    {
                        game_board[i, j].BackColor = Color.FromArgb(246, 93, 59);
                        game_board[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (game_board[i, j].Text == "128")
                    {
                        game_board[i, j].BackColor = Color.FromArgb(237, 206, 113);
                        game_board[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (game_board[i, j].Text == "256")
                    {
                        game_board[i, j].BackColor = Color.FromArgb(237, 204, 97);
                        game_board[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (game_board[i, j].Text == "512")
                    {
                        game_board[i, j].BackColor = Color.FromArgb(236, 200, 80);
                        game_board[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (game_board[i, j].Text == "1024")
                    {
                        game_board[i, j].BackColor = Color.FromArgb(237, 197 , 63);
                        game_board[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (game_board[i, j].Text == "2048")
                    {
                        game_board[i, j].BackColor = Color.FromArgb(62, 57, 51);
                        game_board[i, j].ForeColor = System.Drawing.Color.White;
                    }
                }
            }
          
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            string win = "2048";
     
            bool check = false;
            for (int k = 0; k < 3; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (game_board[i, j].Text != "") 
                        {
                            if (e.KeyData == Keys.Left)
                            {

                                if (i > 0 && game_board[i - 1, j].Text == "")
                                {
                                    check = true;

                                    game_board[i - 1, j].Text = game_board[i, j].Text;
                                    game_board[i, j].Text = "";
                                    colors();


                                }
                                else if (i > 0 && game_board[i - 1, j].Text == game_board[i, j].Text)
                                {
                                    game_board[i - 1, j].Text = Convert.ToString(Convert.ToInt32(game_board[i, j].Text) * 2);
                                    game_board[i, j].Text = "";
                                    colors();

                                }

                            }
                            else if (e.KeyData == Keys.Right)
                            {

                                if (i < n - 1 && game_board[i + 1, j].Text == "")
                                {
                                    check = true;

                                    game_board[i + 1, j].Text = game_board[i, j].Text;
                                    game_board[i, j].Text = "";
                                    colors();


                                }
                                else if (i < 3 && game_board[i + 1, j].Text == game_board[i, j].Text)
                                {
                                    game_board[i + 1, j].Text = Convert.ToString(Convert.ToInt32(game_board[i, j].Text) * 2);
                                    game_board[i, j].Text = "";
                                    colors();

                                }

                            }
                            else if (e.KeyData == Keys.Down)
                            {

                                if (j < n - 1 && game_board[i, j + 1].Text == "")
                                {
                                    check = true;

                                    game_board[i, j + 1].Text = game_board[i, j].Text;
                                    game_board[i, j].Text = "";
                                    colors();


                                }
                                else if (j < 3 - 1 && game_board[i, j + 1].Text == game_board[i, j].Text)
                                {
                                    game_board[i, j + 1].Text = Convert.ToString(Convert.ToInt32(game_board[i, j].Text) * 2);
                                    game_board[i, j].Text = "";
                                    colors();
                                }

                            }
                            else if (e.KeyData == Keys.Up)
                            {

                                if (j > 0 && game_board[i, j - 1].Text == "")
                                {
                                    check = true;

                                    game_board[i, j - 1].Text = game_board[i, j].Text;
                                    game_board[i, j].Text = "";
                                    colors();



                                }
                                else if (j > 0 && game_board[i, j - 1].Text == game_board[i, j].Text)
                                {
                                    game_board[i, j - 1].Text = Convert.ToString(Convert.ToInt32(game_board[i, j].Text) * 2);
                                    game_board[i, j].Text = "";
                                    colors();

                                }
                            }
                        }
                       
                        if (game_board[i, j].Text == win)
                        {
                            MessageBox.Show("You Got the Point!");
                        }
       
                    }
                }
              
            }
            if (check == true)
            {
                numbergenerator();
            }
        }
    }
}

