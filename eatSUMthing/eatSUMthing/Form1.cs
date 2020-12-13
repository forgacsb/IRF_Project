using eatSUMthing.Entities;
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
    public partial class Form1 : Form
    {
        partnerekEntities context = new partnerekEntities();
        List<Tanár> tanárok= new List<Tanár>();
        List<Diák> diákok= new List<Diák>();
        


        public Form1()
        {
            InitializeComponent();

            List<Partner> átmenet = context.Partner.ToList();
            var statusz = (from x in átmenet select x.Státusz).Distinct().ToList();
            var iskola = (from x in átmenet select x.Intézmény).Distinct().ToList();
            var osztaly = (from x in átmenet select x.Osztály).Distinct().ToList();
            comboBox1.DataSource = statusz;
            comboBox4.DataSource = iskola;
            comboBox5.DataSource = osztaly;
            foreach (var x in átmenet)
            {
                if (x.Státusz == "diák")
                {
                    Diák d = new Diák();
                    d.Név = x.Név;
                    d.Anyja_neve = x.Anyja_neve;
                    d.Születési_idő = (DateTime)x.Születési_idő;
                    d.Lakcím = x.Lakcím;
                    d.Intézmény = x.Intézmény;
                    d.Osztály = x.Osztály;
                    d.NCS = (Boolean)x.Nagycsaládos;
                    d.TB = (Boolean)x.Tartós_beteg;
                    d.GYVK = (Boolean)x.GYVK;
                    d.Diétás = (Boolean)x.Diétás;
                    diákok.Add(d);

                }

                if (x.Státusz == "tanár")
                {
                    Tanár t = new Tanár();
                    t.Név = x.Név;
                    t.Születési_idő = (DateTime)x.Születési_idő;
                    t.Lakcím = x.Lakcím;
                    t.Intézmény = x.Intézmény;
                    tanárok.Add(t);

                }
            }
            szűrés();
           // tanár = ((List<Tanár>)(from x in context.Partner.ToList() where x.Státusz=="tanár" select new {x.Név,x.Születési_idő,x.Lakcím,x.Intézmény }));
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            szűrés();
        }

        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            szűrés();
        }

        public void szűrés()
        {
            if ((string)comboBox1.SelectedItem == "tanár")
            {
                dataGridView1.DataSource = (List<Tanár>)(from x in tanárok where x.Intézmény == (string)comboBox4.SelectedItem select x).ToList();
                comboBox5.Visible = false;
                label5.Visible = false;
            }
            else
            {
                dataGridView1.DataSource = (List<Diák>)(from x in diákok where x.Intézmény == (string)comboBox4.SelectedItem && x.Osztály == (string)comboBox5.SelectedItem select x).ToList();
                comboBox5.Visible = true;
                label5.Visible = true;
            }
        }

        private void comboBox5_SelectionChangeCommitted(object sender, EventArgs e)
        {
            szűrés();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Validáció v = new Validáció();
            v.Show();
        }
    }
}
