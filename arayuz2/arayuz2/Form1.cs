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
    public partial class Form1 : Form
    {
        public static event EventHandler MyEvent;
        public static event EventHandler MyEvent2;
        public Form1()
        {
            InitializeComponent();
            customizeDesing();
            Form1.MyEvent += new EventHandler(MyEventMethod);
            Form1.MyEvent2 += new EventHandler(MyEventMethod2);
            
        }
        private void MyEventMethod(object sender, EventArgs e)
        {
            openChildForm(new Form5());
        }
        private void MyEventMethod2(object sender, EventArgs e)
        {
            openChildForm(new Form6());
        }
        public static void OnMyEvent(Form frm)
        {
            if (MyEvent != null)
                MyEvent(frm, new EventArgs());

        }
        public static void OnMyEvent2(Form frm)
        {
            if (MyEvent2 != null)
                MyEvent2(frm, new EventArgs());

        }
        

        private void customizeDesing()
        {
            panel2.Visible = false;
        }
        private void hideSubmenu()
        {
            if (panel2.Visible == true)
                panel2.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubmenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            showSubMenu(panel2);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            openChildForm(new Form2());
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            openChildForm(new Form3());
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            openChildForm(new Form4());
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMerkez.Controls.Add(childForm);
            panelMerkez.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            
        }

        private void panelMerkez_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new Form7());
        }
    }
}
