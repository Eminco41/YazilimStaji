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
    public partial class Form2 : Form
    {
        public static int sayi;
        
        public Form2()
        {
            InitializeComponent();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                listBox1.Items.Add(checkedListBox1.Items[e.Index]);
                
            else if (e.NewValue == CheckState.Unchecked)
                listBox1.Items.Remove(checkedListBox1.Items[e.Index]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sayi = listBox1.Items.Count;
            Form1.OnMyEvent(this);
            
            
        }
    }
}
