using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace tic_tac_toe
{
    public partial class Form1 : Form
    {
        string turn = "x";

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Enabled = false;
            btn.BackColor = Color.Yellow;

            btn.Text = turn;

            string[] current_board_state = new string[9];
            short i = 8;

            foreach (var b in tableLayoutPanel1.Controls.OfType<Button>())
            {
                string txt = b.Text;
                current_board_state[i] = txt;
                /*
                b.Text = i.ToString();
                MessageBox.Show($"{b.Text}");
                */
                i--;
            }

            if (checkForWinner(current_board_state))
            {
                tableLayoutPanel1.Enabled = false;
                MessageBox.Show($"{turn} wins!");
            }

            turn = (turn == "x") ? "o" : "x";
        }

        public bool hasWon(string a, string b, string c)
        {
            if (a == b && b == c && !String.IsNullOrEmpty(b))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkForWinner(string[] board)
        {
            bool the_game_has_ended = false;

            // check vertically
            for (short i = 0; i < 3; i++)
            {
                if (the_game_has_ended)
                    break;

                string fieldA = board[i],
                    fieldB = board[i + 3],
                    fieldC = board[i + 6];

                the_game_has_ended = hasWon(fieldA, fieldB, fieldC);
            }

            // check horizontally
            for (short i = 0; i < 8; i += 3)
            {
                if (the_game_has_ended)
                    break;

                string fieldA = board[i],
                    fieldB = board[i + 1],
                    fieldC = board[i + 2];

                if (the_game_has_ended = hasWon(fieldA, fieldB, fieldC))
                    break;
            }

            // check diagonally
            for (short i = 0; i <= 2; i += 2)
            {
                if (the_game_has_ended)
                    break;

                if (i == 0)
                {
                    string fieldA = board[i],
                        fieldB = board[i + 4],
                        fieldC = board[i + 8];

                    if (the_game_has_ended = hasWon(fieldA, fieldB, fieldC))
                        break;
                }
                else if (i == 2)
                {
                    string fieldA = board[i],
                        fieldB = board[i + 2],
                        fieldC = board[i + 4];

                    if (the_game_has_ended = hasWon(fieldA, fieldB, fieldC))
                        break;
                }
            }

            return the_game_has_ended;
        }
    }
}
