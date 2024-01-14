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
        short move_count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = "x";
            move_count = 0;

            foreach (var b in tableLayoutPanel1.Controls.OfType<Button>())
            {
                b.Enabled = true;
                b.BackColor = SystemColors.Control;
                b.Text = string.Empty;
            }
            tableLayoutPanel1.Enabled = true;
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is Tic-Tac-Toe.\nX always starts the game, you know the rest.\n\nMade by Michał Jaworek.");
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Enabled = false;
            btn.BackColor = (move_count % 2 == 0) ? Color.SandyBrown : Color.LightBlue;
            btn.Text = turn;

            string[] current_board_state = new string[9];
            bool game_over = false;
            short i = 8;

            foreach (var b in tableLayoutPanel1.Controls.OfType<Button>())
            {
                string txt = b.Text;
                current_board_state[i] = txt;
                //b.Text = i.ToString();
                i--;
            }

            short[,] index = new short[8,3]
            {
                {0, 1, 2},  // check vertically
                {3, 4, 5},
                {6, 7, 8},
                {0, 3, 6},  // check horizontally
                {1, 4, 7},
                {2, 5, 8},
                {0, 4, 8},  // check diagonally
                {2, 4, 6}
            };

            for (i = 0; i < index.GetLength(0); i++)
            {
                game_over = hasWon(current_board_state[index[i, 0]], current_board_state[index[i, 1]], current_board_state[index[i, 2]]);
                if (game_over)
                {
                    tableLayoutPanel1.Enabled = false;
                    MessageBox.Show($"{turn.ToUpper()} wins!");
                    break;
                }
            }

            if (move_count == 8 && !game_over)
                MessageBox.Show("Draw!");

            turn = (move_count % 2 == 0) ? "o" : "x";
            move_count++;
        }

        public bool hasWon(string a, string b, string c)
        {
            bool gameWon = (a == b && b == c && !String.IsNullOrEmpty(b)) ? true : false;
            return gameWon;
        }
    }
}
