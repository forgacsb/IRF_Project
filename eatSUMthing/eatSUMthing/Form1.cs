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
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace eatSUMthing
{
    public partial class Form1 : Form
    {
        partnerekEntities context = new partnerekEntities();
        List<Tanár> tanárok= new List<Tanár>();
        List<Diák> diákok= new List<Diák>();
        List<Tanár> szűrttanár = new List<Tanár>();
        List<Diák> szűrtdiák= new List<Diák>();

        Excel.Application xlApp;
        Excel.Workbook xlWB;
        Excel.Worksheet xlSheet;

        public Form1()
        {
            InitializeComponent();

            List<Partner> p = context.Partner.ToList();
            var statusz = (from x in p select x.Státusz).Distinct().ToList();
            var iskola = (from x in p select x.Intézmény).Distinct().ToList();
            var osztaly = (from x in p select x.Osztály).Distinct().ToList();
            comboBox1.DataSource = statusz;
            comboBox4.DataSource = iskola;
            comboBox5.DataSource = osztaly;
            foreach (var x in p)
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
                szűrttanár = (List<Tanár>)(from x in tanárok where x.Intézmény == (string)comboBox4.SelectedItem select x).ToList();
                dataGridView1.DataSource = szűrttanár;
                comboBox5.Visible = false;
                label5.Visible = false;
            }
            else
            {
                szűrtdiák = (List<Diák>)(from x in diákok where x.Intézmény == (string)comboBox4.SelectedItem && x.Osztály == (string)comboBox5.SelectedItem select x).ToList();
                dataGridView1.DataSource = szűrtdiák;
                comboBox5.Visible = true;
                label5.Visible = true;
            }
        }

        public void CreateExcel()
        {
            try
            {
                xlApp = new Excel.Application();

                xlWB = xlApp.Workbooks.Add(Missing.Value);

                xlSheet = xlWB.ActiveSheet;


                CreateTable(); 

                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex)
            {
                string errMsg = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
                MessageBox.Show(errMsg, "Error");

                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;
            }
        }

        private void CreateTable()
        {
            string[] headers = new string[] {
                 "Név",
                 "Napi ár",
                 "Összesen",
                 "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30","31" };
            xlSheet.Cells[1, 1] = (string)comboBox4.SelectedItem;
            xlSheet.Cells[2, 1] = (string)comboBox5.SelectedItem;
            for (int i = 0; i < headers.Length; i++)
            {
                xlSheet.Cells[3, 1 + i] = headers[i];
            }
            object[,] values = new object[szűrtdiák.Count, headers.Length-31];
            int counter = 0;
            foreach (Diák diak in szűrtdiák)
            {
                values[counter, 0] = diak.Név;
                values[counter, 1] = diak.Ár;
                values[counter, 2] = "";
                counter++;
            }

            xlSheet.get_Range(
            GetCell(4, 1),
            GetCell(3 + values.GetLength(0), values.GetLength(1))).Value2 = values;

            Excel.Range headerRange = xlSheet.get_Range(GetCell(3, 1), GetCell(3, headers.Length));
            headerRange.Font.Bold = true;
            headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            headerRange.EntireColumn.AutoFit();
            headerRange.RowHeight = 30;
            headerRange.Interior.Color = Color.Gray;
            headerRange.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);

            Excel.Range calculated = xlSheet.get_Range(GetCell(4, 3),
            GetCell(3 + values.GetLength(0), 3));
            calculated.Formula = "=B4 * counta(D4:AH4)";
        }
        private string GetCell(int x, int y)
                    {
                        string ExcelCoordinate = "";
                        int dividend = y;
                        int modulo;

                        while (dividend > 0)
                        {
                            modulo = (dividend - 1) % 26;
                            ExcelCoordinate = Convert.ToChar(65 + modulo).ToString() + ExcelCoordinate;
                            dividend = (int)((dividend - modulo) / 26);
                        }
                        ExcelCoordinate += x.ToString();

                        return ExcelCoordinate;
                    }
        private void comboBox5_SelectionChangeCommitted(object sender, EventArgs e)
        {
            szűrés();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Validáció v = new Validáció();
            if (v.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Sikeres ellenőrzés! \n A kért folyamat elkezdődött.");
                CreateExcel();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Validáció v = new Validáció();
            if (v.ShowDialog() == DialogResult.OK)
            {
                Árazás á = new Árazás();
                if (á.ShowDialog() == DialogResult.OK)
                {
                    
                    if ((string)comboBox1.SelectedItem == "tanár")
                    {

                        foreach (var i in tanárok)
                        {
                            i.Ár = Int32.Parse(á.TeljesÁr);
                        }
                    }
                    else
                    {
                        foreach (var i in diákok)
                        {
                            i.Ár = Int32.Parse(á.TeljesÁr);

                            if (i.NCS==true)
                            {
                                i.Ár = Int32.Parse(á.TeljesÁr) / 2;
                            }
                            if (i.TB==true)
                            {
                                i.Ár = Int32.Parse(á.TeljesÁr) / 10;
                            }
                            if (i.GYVK==true)
                            {
                                i.Ár = 0;
                            }
                            if (i.Diétás)
                            {
                                i.Ár = (int)(i.Ár * 1.2);
                            }

                        }
                    }
                    szűrés();
                }
                
            }


        }
    }
}
