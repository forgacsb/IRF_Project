using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eatSUMthing
{
    public partial class Validáció : Form
    {
        Random rnd = new Random();
        int kivalasztott;
        int[] szamok = new int[5];
        public Validáció()
        {
            InitializeComponent();
            
            for (int i = 0; i < 5; i++)
            {
                szamok[i] = rnd.Next(1,100);

            }
            int j = 0;
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.Text = szamok[j].ToString();
                j++;
            }

            kivalasztott = rnd.Next(1,6);
            label1.Text= szamok[kivalasztott-1].ToString();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == label1.Text)
            {
                button1.BackColor = Color.Green;
                this.DialogResult= DialogResult.OK;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == label1.Text)
            {
                button2.BackColor = Color.Green;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == label1.Text)
            {
                button3.BackColor = Color.Green;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == label1.Text)
            {
                button4.BackColor = Color.Green;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == label1.Text)
            {
                button5.BackColor = Color.Green;
                this.DialogResult = DialogResult.OK;
            }
        }

    }
}
