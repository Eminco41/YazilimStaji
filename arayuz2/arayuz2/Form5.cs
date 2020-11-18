using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arayuz2
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        private TrackBar[] trackBars;
        private Label[] labels;
        private ProgressBar[] progressBars;
        public static int kritersayi = Form2.sayi;
        public static int[] agirliklar = new int[kritersayi];



        private void Form5_Load_1(object sender, EventArgs e)
        {
            trackBars = new TrackBar[kritersayi];
            labels = new Label[kritersayi];
            progressBars = new ProgressBar[kritersayi];

            
            for (int i = 0; i < kritersayi; i++)

            {
               
                trackBars[i] = new TrackBar();
              
                trackBars[i].Location = new Point(353,62*(i+1));
              

                trackBars[i].Minimum = 0;
                trackBars[i].Maximum = 7;
                trackBars[i].BackColor = Color.FromArgb(23, 21, 32);
                trackBars[i].Size = new Size(432, 50);
                
                trackBars[i].LargeChange = 1;
                trackBars[i].SmallChange = 1;

            
               
                this.Controls.Add(trackBars[i]);

            }



            for (int i = 0; i < kritersayi; i++)

            {

                labels[i] = new Label();

                labels[i].Location = new Point(100, 62 * (i + 1));

                labels[i].BackColor = Color.FromArgb(23, 21, 32);
                labels[i].Size = new Size(95, 30);
                labels[i].ForeColor = Color.FromArgb(255, 255, 255);
                labels[i].Text =i + 1 + ". kriter";
                
                labels[i].Font= new Font("bahnschrift", 15);
                
                this.Controls.Add(labels[i]);

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < kritersayi; i++)
            {
                agirliklar[i] = trackBars[i].Value;

            }
            Form1.OnMyEvent2(this);
            
        }
    }
}
