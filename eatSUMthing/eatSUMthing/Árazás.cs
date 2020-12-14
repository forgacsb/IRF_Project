using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eatSUMthing
{
    public partial class Árazás : Form
    {
        public string TeljesÁr { get; private set; }

        public Árazás()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!ValidateÁr(textBox1.Text))
                throw new ValidationException(
                    "A megadott ár nem megfelelő!");
            TeljesÁr = textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public bool ValidateÁr(string ar)
        {
            return Regex.IsMatch(
                ar,
                @"^\d+$");
        }
    }
}
