using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormXO
{
    public partial class FormXO : Form
    {
        List<String> ButtonsList = new List<String>();
        bool IsEnable = false;
        public bool step = true;
        bool end = false;
        bool MainTurn = true;

        public FormXO() {
            InitializeComponent();
            IsTurn(true);
        }

        public void button1_Click_1(object sender, EventArgs e) {
            if (IsFieldUsed((sender as Button))) {
                if (!IsEnable) {
                    первыйХодToolStripMenuItem.Enabled = false;
                    сменитьИмяToolStripMenuItem.Enabled = false;
                    IsEnable = !IsEnable;
                }

                int x, y;
                (sender as Button).Text = Turn(step);

                Conv((sender as Button).Name, out x, out y);
                Start.mat[x, y] = Turn(step);
                //(sender as Button).Enabled = false;
                if ((sender as Button).Text == "X")
                    (sender as Button).ForeColor = Color.FromArgb(204, 0, 0);
                else
                    (sender as Button).ForeColor = Color.FromArgb(1, 1, 153);
                End(step, Start.mat, out end);

                step = !step;

                if (!end)
                    if (Start.IsName)
                        if (!step)
                            labelTurn.Text = Start.name2;
                        else
                            labelTurn.Text = Start.name1;
                    else
                        if (step)
                        labelTurn.Text = "X";
                    else
                        labelTurn.Text = "O";
            }
        }

        private bool IsFieldUsed(Button button) {
            if (ButtonsList.Count > 0)
                for (int i = 0; i < ButtonsList.Count; i++)
                    if (ButtonsList[i] == button.Name)
                        return false;
            ButtonsList.Add(button.Name);
            return true;
        }

        public String Turn(bool step) {
            String turn;

            if (!step)
                turn = "O";
            else
                turn = "X";

            return turn;
        }
        public String Turn(bool step, bool x) {
            String turn;

            if (x) {
                if (!step)
                    turn = Start.name2 + " Выиграл";
                else
                    turn = Start.name1 + " Выиграл";
            }
            else {
                if (!step)
                    turn = "'O' Выиграли";
                else
                    turn = "'X' Выиграли";
            }
            return turn;
        }

        public void новаяИграToolStripMenuItem1_Click(object sender, EventArgs e) {
            NewGame();
        }

        public void NewGame() {
            ButtonsList.Clear();
            ClearButton();
            IsTurn(MainTurn);
            IsEnable = false;

            if (MainTurn)
                step = true;
            else
                step = false;

            end = false;
            label1.Text = "Ход игрока: ";
            GameOver.Visible = false;
        }

        private void хToolStripMenuItem_Click(object sender, EventArgs e) {
            MainTurn = true;
            step = true;
            IsTurn(true);
        }

        private void оToolStripMenuItem_Click(object sender, EventArgs e) {
            MainTurn = false;
            step = false;
            IsTurn(false);
        }

        private void инфоToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("Связь:\n\nTelegram: @CMETAHKA\nInstagram: @mr.greenson", "Информация");
        }

        private void ClearButton() {
            button0.Text = null;
            button1.Text = null;
            button2.Text = null;
            button3.Text = null;
            button4.Text = null;
            button5.Text = null;
            button6.Text = null;
            button7.Text = null;
            button8.Text = null;

            button0.BackColor = Color.Gainsboro;
            button1.BackColor = Color.Gainsboro;
            button2.BackColor = Color.Gainsboro;
            button3.BackColor = Color.Gainsboro;
            button4.BackColor = Color.Gainsboro;
            button5.BackColor = Color.Gainsboro;
            button6.BackColor = Color.Gainsboro;
            button7.BackColor = Color.Gainsboro;
            button8.BackColor = Color.Gainsboro;

            Start.mat = new string[3, 3] { { " ", " ", " " }, { " ", " ", " " }, { " ", " ", " " } };
            сменитьИмяToolStripMenuItem.Enabled = true;
            первыйХодToolStripMenuItem.Enabled = true;
            step = true;
            IsTurn(true);

            button0.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
        }

        public void IsTurn(bool x) {
            if (!Start.IsName)
                if (x)
                    labelTurn.Text = "X";
                else
                    labelTurn.Text = "O";
            else
            if (x)
                labelTurn.Text = Start.name1;
            else
                labelTurn.Text = Start.name2;
        }

        public void Conv(String text, out int x, out int y) {
            switch (text) {
                case "button0": {
                    x = 0;
                    y = 0;
                }
                break;
                case "button1": {
                    x = 0;
                    y = 1;
                }
                break;
                case "button2": {
                    x = 0;
                    y = 2;
                }
                break;
                case "button3": {
                    x = 1;
                    y = 0;
                }
                break;
                case "button4": {
                    x = 1;
                    y = 1;
                }
                break;
                case "button5": {
                    x = 1;
                    y = 2;
                }
                break;
                case "button6": {
                    x = 2;
                    y = 0;
                }
                break;
                case "button7": {
                    x = 2;
                    y = 1;
                }
                break;
                case "button8": {
                    x = 2;
                    y = 2;
                }
                break;
                default: {
                    x = 0;
                    y = 0;
                }
                break;
            }
        }

        public bool End(bool step, String[,] xo, out bool end) {
            end = false;
            bool flag = true;
            int c = 0;
            for (int i = 0; i < xo.GetLength(0); i++) {
                int i_true = 0;
                int j_true = 0;
                int f_diagonal = 0;
                int s_diagonal = 0;
                for (int j = 0; j < xo.GetLength(1); j++) {
                    if (xo[i, j] == Turn(step)) {
                        i_true++;
                    }
                    if (xo[j, i] == Turn(step)) {
                        j_true++;
                    }
                    if (xo[j, j] == Turn(step)) {
                        f_diagonal++;
                    }
                    if (xo[j, 2 - j] == Turn(step)) {
                        s_diagonal++;
                    }
                }
                if (i_true == 3 || j_true == 3 || f_diagonal == 3 || s_diagonal == 3) {
                    String[,] res = ReFill(xo, i, i_true, j_true, f_diagonal, s_diagonal);
                    for (int m = 0; m < Start.mat.GetLength(0); m++)
                        for (int n = 0; n < Start.mat.GetLength(1); n++)
                            if (res[m, n] == " ")
                                ConvToButton(m, n).Enabled = false;
                            else
                                ConvToButton(m, n).Enabled = true;
                    EndGame(true);
                    flag = false;
                    break;
                }
                for (int j = 0; j < xo.GetLength(1); j++)
                    if (xo[i, j] != " ")
                        c++;
                if (c == 9) {
                    for (int m = 0; m < Start.mat.GetLength(0); m++)
                        for (int n = 0; n < Start.mat.GetLength(1); n++)
                                ConvToButton(m, n).Enabled = false;
                    EndGame(false);
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        private Button ConvToButton(int i, int j) {
            switch (i) {
                case 0: {
                    switch (j) {
                        case 0:
                            return button0;
                        case 1:
                            return button1;
                        case 2:
                            return button2;
                        default:
                            return null;
                    }
                }
                case 1: {
                    switch (j) {
                        case 0:
                            return button3;
                        case 1:
                            return button4;
                        case 2:
                            return button5;
                        default:
                            return null;
                    }
                }
                case 2: {
                    switch (j) {
                        case 0:
                            return button6;
                        case 1:
                            return button7;
                        case 2:
                            return button8;
                        default:
                            return null;
                    }
                }
                default:
                    return null;
            }
        }

        private String[,] ReFill(String[,] xo, int col, int i_true, int j_true, int f_diagonal, int s_diagonal) {
            String[,] res = { { " ", " ", " " }, { " ", " ", " " }, { " ", " ", " " } };
            for (int j = 0; j < xo.GetLength(0); j++) {
                if (i_true == 3)
                    res[col, j] = xo[col, j];
                if (j_true == 3)
                    res[j, col] = xo[j, col];
                if (f_diagonal == 3)
                    res[j, j] = xo[j, j];
                if (s_diagonal == 3)
                    res[j, 2 - j] = xo[j, 2 - j];
            }
            return res;
        }

        private void EndGame(bool IsWin) {
            end = true;
            GameOver.Visible = true;
            ButtonsList.Clear();
            for (int i = 0; i < Start.mat.GetLength(0); i ++) 
                for (int j = 0; j < Start.mat.GetLength(1); j++) 
                    ButtonsList.Add(ConvToButton(i, j).Name);
        }

        private void сменитьИмяToolStripMenuItem_Click(object sender, EventArgs e) {
            Registration r = new Registration(this.labelTurn);
            r.Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void button2_KeyPress(object sender, KeyPressEventArgs e) {
            char r = e.KeyChar;
            switch (r) {
                case 'r':
                    NewGame();
                    break;
                case 'к':
                    NewGame();
                    break;

                case '7':
                    button1_Click_1(button0, null);
                    break;
                case '8':
                    button1_Click_1(button1, null);
                    break;
                case '9':
                    button1_Click_1(button2, null);
                    break;
                case '4':
                    button1_Click_1(button3, null);
                    break;
                case '5':
                    button1_Click_1(button4, null);
                    break;
                case '6':
                    button1_Click_1(button5, null);
                    break;
                case '1':
                    button1_Click_1(button6, null);
                    break;
                case '2':
                    button1_Click_1(button7, null);
                    break;
                case '3':
                    button1_Click_1(button8, null);
                    break;



            }
        }
    }
}
