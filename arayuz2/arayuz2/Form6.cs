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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        private TrackBar[] trackBars;
        private Label[] labels;
        public static int kritersayi = Form2.sayi;
        public static int[] agirlikdegerleri =new int[kritersayi];
        public static int[] aday_agirliklar = new int[kritersayi];

        private void Form5_Load_1(object sender, EventArgs e)
        {
            trackBars = new TrackBar[kritersayi];
            labels = new Label[kritersayi];

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

                labels[i].Location = new Point(80, 62 * (i + 1));

                labels[i].BackColor = Color.FromArgb(23, 21, 32);
                labels[i].Size = new Size(190, 30);
                labels[i].ForeColor = Color.FromArgb(255, 255, 255);
                labels[i].Text =i + 1 + ". kriter için aday başarımı";
                labels[i].Font= new Font("bahnschrift", 10);
                
                this.Controls.Add(labels[i]);

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Kabul Edilebilir Maksimum Zam Oranınızı Giriniz");
            }
            else
            {


                for (int i = 0; i < kritersayi; i++)
                {
                    aday_agirliklar[i] = trackBars[i].Value;
                    agirlikdegerleri[i] = Form5.agirliklar[i];
                }
                int[] kriter = new int[kritersayi];
                kriter = agirlikdegerleri;


                int[] aday = new int[kritersayi];
                aday = aday_agirliklar;

                int n_aday = 1;
                int max_value = 0;
                double[,,] bulanikkararmatris = new double[n_aday, kritersayi, 3];
                double[,,] normalizebulanikkararmatris = new double[n_aday, kritersayi, 3];
                double[,,] agirlikli = new double[n_aday, kritersayi, 3];
                double[,] bpbn = new double[n_aday, 2];
                double[] abpbn = new double[n_aday];
                double dp, dn;
                //Kriter İçin

                double[,,] k_agirlik = new double[,,] { { { 0.0, 0.0, 0.1 }, { 0.0, 0.1, 0.3 }, { 0.1, 0.3, 0.5 }, { 0.3, 0.5, 0.7 }, { 0.5, 0.7, 0.9 }, { 0.7, 0.9, 1.0 }, { 0.9, 1.0, 1.0 } } };

                //Kriter Aday İçin
                int[,,] aday_agirlik = new int[,,] { { { 0, 0, 1 }, { 0, 1, 3 }, { 1, 3, 5 }, { 3, 5, 7 }, { 5, 7, 9 }, { 7, 9, 10 }, { 9, 10, 10 } } };


                for (int i = 0; i < n_aday; i++)
                {
                    max_value = 0;
                    for (int n = 0; n < kritersayi; n++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            bulanikkararmatris[i, n, j] = aday_agirlik[0, aday[n] - 1, j];
                            if (max_value < aday_agirlik[0, aday[n] - 1, j])
                            {
                                max_value = aday_agirlik[0, aday[n] - 1, j];

                            }
                        }


                    }
                    for (int n = 0; n < kritersayi; n++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            normalizebulanikkararmatris[i, n, j] = bulanikkararmatris[i, n, j] / max_value;
                        }


                    }


                }
                for (int i = 0; i < n_aday; i++)
                {
                    dp = 0;
                    dn = 0;
                    for (int n = 0; n < kritersayi; n++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            agirlikli[i, n, j] = normalizebulanikkararmatris[i, n, j] * k_agirlik[0, kriter[n] - 1, j];

                        }
                        dp = dp + Math.Sqrt(Math.Pow((1 - agirlikli[i, n, 0]), 2) + Math.Pow((1 - agirlikli[i, n, 1]), 2) + Math.Pow((1 - agirlikli[i, n, 2]), 2));
                        dn = dn + Math.Sqrt(Math.Pow((0 - agirlikli[i, n, 0]), 2) + Math.Pow((0 - agirlikli[i, n, 1]), 2) + Math.Pow((0 - agirlikli[i, n, 2]), 2));
                    }
                    bpbn[i, 0] = dp; bpbn[i, 1] = dn;
                    abpbn[i] = bpbn[i, 1] / (bpbn[i, 0] + bpbn[i, 1]);
                }
              

                double sonuc = abpbn[0];
                
                double kullaniciMaksZam = Convert.ToDouble(textBox1.Text);
                double guncelZam = (kullaniciMaksZam * abpbn[0] / 100);
                string orjsonuc = abpbn[0].ToString();
                string orjsonuc2 = guncelZam.ToString();
                string[] zam = new string[3];
                zam[0] = orjsonuc;
                zam[1] = orjsonuc2;
                zam[2] = DateTime.Now.ToString();
                System.IO.File.AppendAllLines(Application.StartupPath + "\\Zamlar.txt", zam);
                MessageBox.Show("Sonuç=" + abpbn[0].ToString()+"\n Güncel Zam: "+ "%" + guncelZam.ToString(), "Sonuç Hesaplandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
