using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlidingPuzzle_JobbagyMate
{
    public partial class Form1 : Form
    {
        int Counter;
        public Form1()
        {
            InitializeComponent();
        }

        public void EmptySpotChecker(Button Butt1, Button Butt2)
        {
            if (Butt2.Text == "")
            {
                Butt2.Text = Butt1.Text;
                Butt1.Text = "";
            }
        }

        public void SolutionChecker()
        {
            if(button1.Text == "1" && button2.Text == "2" && button3.Text == "3" && button4.Text == "4" && button5.Text == "5" && button6.Text == "6" && button7.Text == "7" && button8.Text == "8")
            {
                MessageBox.Show("Well done! You won!", "Sliding Puzzle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Counter = Counter + 1;
            textBox1.Text = "Number of clicks: " + Counter;
        }

        public void Shuffle()
        {
            int[] bnum = new int[9];
            int i, j, rowchecker;
            Boolean flag = false;

            i = 1;
            do
            {
                Random rnd = new Random();
                rowchecker = Convert.ToInt32((rnd.Next(0, 8)) + 1);

                for (j = 1; j <= i; j++)
                {
                    if (bnum[j] == rowchecker)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag == true)
                {
                    flag = false;
                }
                else
                {
                    bnum[i] = rowchecker;
                    i = i + 1;
                }
            }
            while (i <= 8);

            button1.Text = Convert.ToString(bnum[1]);
            button2.Text = Convert.ToString(bnum[2]);
            button3.Text = Convert.ToString(bnum[3]);
            button4.Text = Convert.ToString(bnum[4]);
            button5.Text = Convert.ToString(bnum[5]);
            button6.Text = Convert.ToString(bnum[6]);
            button7.Text = Convert.ToString(bnum[7]);
            button8.Text = Convert.ToString(bnum[8]);
            button9.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            EmptySpotChecker(button7, button4);
            EmptySpotChecker(button7, button8);
            SolutionChecker();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EmptySpotChecker(button3, button2);
            EmptySpotChecker(button3, button6);
            SolutionChecker();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult iExit = MessageBox.Show("Do you want to exit?", "Sliding Puzzle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (iExit == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult iExit = MessageBox.Show("Do you want to exit?", "Sliding Puzzle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (iExit == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void buttonSolution_Click(object sender, EventArgs e)
        {
            button1.Text = Convert.ToString(1);
            button2.Text = Convert.ToString(2);
            button3.Text = Convert.ToString(3);
            button4.Text = Convert.ToString(4);
            button5.Text = Convert.ToString(5);
            button6.Text = Convert.ToString(6);
            button7.Text = Convert.ToString(7);
            button8.Text = Convert.ToString(8);
            button9.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Shuffle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmptySpotChecker(button1, button2);
            EmptySpotChecker(button1, button4);
            SolutionChecker();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmptySpotChecker(button2, button1);
            EmptySpotChecker(button2, button3);
            EmptySpotChecker(button2, button5);
            SolutionChecker();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EmptySpotChecker(button4, button1);
            EmptySpotChecker(button4, button5);
            EmptySpotChecker(button4, button7);
            SolutionChecker();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EmptySpotChecker(button6, button3);
            EmptySpotChecker(button6, button5);
            EmptySpotChecker(button6, button9);
            SolutionChecker();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EmptySpotChecker(button5, button2);
            EmptySpotChecker(button5, button4);
            EmptySpotChecker(button5, button6);
            EmptySpotChecker(button5, button8);
            SolutionChecker();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            EmptySpotChecker(button8, button5);
            EmptySpotChecker(button8, button7);
            EmptySpotChecker(button8, button9);
            SolutionChecker();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            EmptySpotChecker(button9, button6);
            EmptySpotChecker(button9, button8);
            SolutionChecker();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Shuffle();
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            Shuffle();
            textBox1.Clear();

            this.Refresh();
            this.Hide();
            Form1 NewGame = new Form1();
            NewGame.Show();
        }
    }
}
