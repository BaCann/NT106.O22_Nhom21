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
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace LAB2
{
    public partial class Bai01 : Form
    {
        public Bai01()
        {
            InitializeComponent();
        }

        private void buttonDoc_Click(object sender, EventArgs e)
        {
            try
            {

                string inputFilePath = "C:\\Users\\USER\\Desktop\\22520300-LeVietDuong\\Lab2\\input1.txt";
                textBoxKQ.Text = File.ReadAllText(inputFilePath);
                MessageBox.Show("Đọc file thành công!", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn file để đọc!", "Thông báo");
            }
        }

        private void buttonGhi_Click(object sender, EventArgs e)
        {
            try
            {
                string outputFilePath = "C:\\Users\\USER\\Desktop\\22520300-LeVietDuong\\Lab2\\output1.txt";
                string content = textBoxKQ.Text.ToUpper();
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    writer.Write(content);
                }
                textBoxKQ.Text = content;
                MessageBox.Show("Ghi file thành công!", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn vị trí lưu file!", "Thông báo");
            }
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bai01_Load(object sender, EventArgs e)
        {

        }
    }
}
