﻿using System;
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
    public partial class Árazás : Form
    {
        public int TeljesÁr { get; private set; }

        public Árazás()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TeljesÁr = Int32.Parse(textBox1.Text);
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
