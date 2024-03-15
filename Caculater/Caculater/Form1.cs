using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caculater
{
    public partial class Caculater : Form
    {
        public Caculater()
        {
            InitializeComponent();
        }
        double so1 = 0, so2 = 0; 
        double kq = 0;  
        char pt; 

        private void txtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            txtBox.Text += "1";
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            txtBox.Text += "2";
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            txtBox.Text += "3";
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            txtBox.Text += "4";
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            txtBox.Text += "5";
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            txtBox.Text += "6";
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            txtBox.Text += "7";
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            txtBox.Text += "8";
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            txtBox.Text += "9";
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            txtBox.Text += "0";         
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {   
            pt = '+';
            so1 = double.Parse(txtBox.Text);
            txtBox.Text = "";
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            pt = '-';
            so1 = double.Parse(txtBox.Text);
            txtBox.Text = "";
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            pt = '*';
            so1 = double.Parse(txtBox.Text);
            txtBox.Text = "";
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            pt = '/';
            so1 = double.Parse(txtBox.Text);
            txtBox.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtBox.Text = "";
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            so2 = double.Parse(txtBox.Text);
            tinh( so1, so2, pt );

        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            so1 = double.Parse(txtBox.Text);
            so1 = so1 * (-1);
            txtBox.Text = so1.ToString();
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            pt = 'm';
            so1 = double.Parse(txtBox.Text);
            txtBox.Text = "";
        }

        // Hàm con thực hiện phép tính 
        private void tinh( double n1, double n2, char pt)
        {
            double kq = 0;
            switch (pt)
            {
                case '+':
                    kq = n1 + n2;
                    break;
                case '-':
                    kq = n1 - n2;
                    break;
                case '*':
                    kq = n1 * n2;
                    break;
                case '/':
                    if (n2 == 0)
                    {
                        MessageBox.Show("Error !!!","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        kq = n1 / n2;                      
                    }
                    break;
                case 'm':
                    if (n2 == 0)
                    {
                        MessageBox.Show("Error !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        kq = n1 % n2;
                    }
                    break;

            }
            txtBox.Text = kq.ToString();
        }
    }
}
