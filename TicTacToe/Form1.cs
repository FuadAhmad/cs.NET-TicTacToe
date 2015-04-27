using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private bool _isXTurn = true; // true = X turn, false = Y turn;
        private int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developer : Fuad Ahmad", "Tic Tac Toe");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonClick(object sender, EventArgs e)
        {
            Button b = (Button) sender;
            if (_isXTurn)
            {
                b.Text = "X";
                turnFor.Text = "O";
            }
            else
            {
                b.Text = "O";
                turnFor.Text = "X";
            }
            count++;
            b.Enabled = false;
            _isXTurn = !_isXTurn;
            checkResult();
        }

        private void checkResult()
        {
            // Row check for result
            if (((A1.Text == A2.Text) && (A1.Text == A3.Text) && (!A1.Enabled)) ||
                ((B1.Text == B2.Text) && (B1.Text == B3.Text) && (!B1.Enabled)) ||
                ((C1.Text == C2.Text) && (C1.Text == C3.Text) && (!C1.Enabled)))
            {
                makeResult();
            }
           // Column check for result
            else if (((A1.Text == B1.Text) && (A1.Text == C1.Text) && (!A1.Enabled)) ||
                     ((A2.Text == B2.Text) && (A2.Text == C2.Text) && (!A2.Enabled)) ||
                     ((A3.Text == B3.Text) && (A3.Text == C3.Text) && (!A3.Enabled)))
            {
                makeResult();
            }
            // Diagonal check for result
            else if (((A1.Text == B2.Text) && (A1.Text == C3.Text) && (!A1.Enabled)) ||
                     ((A3.Text == B2.Text) && (A3.Text == C1.Text) && (!A3.Enabled)))
            {
                makeResult();
            }
            else if (count == 9)
            {
                MessageBox.Show("Match Drawn.");
                //makeButtonStatus(false);
            }
        } // end of checkResult(); 

        // new game
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            makeButtonStatus(true);
            makeButtonTextClear();
            turnFor.Text = "X";
            count = 0;
        }

        private void makeResult()
        {
            string winner = "";
            if (_isXTurn)
            {
                winner = "O";
            }
            else
            {
                winner = "X";
            }
            MessageBox.Show(winner + " is winner.");
            makeButtonStatus(false);
        }

        private void makeButtonStatus(bool status)
        {
            A1.Enabled = status;
            A2.Enabled = status;
            A3.Enabled = status;
            B1.Enabled = status;
            B2.Enabled = status;
            B3.Enabled = status;
            C1.Enabled = status;
            C2.Enabled = status;
            C3.Enabled = status;
        }

        private void makeButtonTextClear()
        {
            A1.Text = "";
            A2.Text = "";
            A3.Text = "";
            B1.Text = "";
            B2.Text = "";
            B3.Text = "";
            C1.Text = "";
            C2.Text = "";
            C3.Text = "";
        }
    }
}
