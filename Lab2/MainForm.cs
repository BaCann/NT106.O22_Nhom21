using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bai01 bai01 = new Bai01();
            bai01.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bai02 bai02 = new Bai02();
            bai02.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bai03 bai03 = new Bai03(); 
            bai03.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bai04 bai04 = new Bai04();
            bai04.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bai05 bai05 = new Bai05();
            bai05.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bai06 bai06 = new Bai06();
            bai06.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bai07 bai07 = new Bai07();
            bai07.Show();
        }
    }
}
