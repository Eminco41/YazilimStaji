using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arayuz2
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        public void DosyaOku()
        {
            
            var fileLines = File.ReadAllLines((Application.StartupPath + "\\Zamlar.txt"));

            int count = 0;
            for (int i = 0; i + 2 < fileLines.Length; i += 3)
            {
                listView1.Items.Add(
                    new ListViewItem(new[]
                    {
                        count.ToString(),
                        fileLines[i],
                        fileLines[i + 1],
                        fileLines[i + 2],

                    }));
                count++;
            }





        }

        private void Form7_Load(object sender, EventArgs e)
        {
            
            listView1.View = View.Details;
            listView1.Columns.Add("Çalışan ID");
            listView1.Columns.Add("Hesaplanan Zam Oranı");
            listView1.Columns.Add("Yapılacak Zam Oranı");
            listView1.Columns.Add("Hesaplanma Tarihi");
            for (int i = 0; i < listView1.Columns.Count; i++)
            {
                listView1.Columns[i].Width = -2;
            }
            DosyaOku();
        }
    }
}
