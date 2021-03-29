using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace FormXO
{
    public partial class Registration : Form
    {
        private Label label;

        public Registration(Label LabelTurn) {
            label = LabelTurn;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) {
            if (!String.IsNullOrWhiteSpace(text1.Text) && !String.IsNullOrWhiteSpace(text2.Text)) {
                Start.name1 = text1.Text;
                Start.name2 = text2.Text;
                Start.IsName = true;

                label.Text = Start.name1;

                this.Close();
            }
            else {
                if (String.IsNullOrWhiteSpace(text1.Text)) {
                    text1.BackColor = Color.DarkSalmon;
                }
                if (String.IsNullOrWhiteSpace(text2.Text)) {
                    text2.BackColor = Color.DarkSalmon;
                }
            }
        }

        private void text1_MouseClick(object sender, MouseEventArgs e) {
            (sender as TextBox).BackColor = Color.White;
        }
    }
}
