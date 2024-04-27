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
    public partial class Bai05 : Form
    {
        public Bai05()
        {
            InitializeComponent();
        }

        public class DuLieu
        {
            public string Ten;
            public int GiaVe;
            public int Phong;
            public string ChoNgoi;

            public DuLieu()
            {

            }
        }

        public class TongKet
        {
            public string Ten;
            public int GiaVe;
            public int Phong;
            public string ChoNgoi;
            public int TongVe = 15;
            public int DaBan;
            public int Ton;
            public float TyLe;
            public long DoanhThu;
            public int XepHang;

            public TongKet()
            {

            }

            public string Show()
            {
                string content = "";
                content += Ten + Environment.NewLine;
                content += GiaVe.ToString() + Environment.NewLine;
                content += Phong.ToString() + Environment.NewLine;  
                content += ChoNgoi + Environment.NewLine;
                content += TongVe.ToString() + Environment.NewLine;
                content += DaBan.ToString() + Environment.NewLine;
                content += Ton.ToString() + Environment.NewLine;
                content += TyLe.ToString() + Environment.NewLine;
                content += DoanhThu.ToString() + Environment.NewLine;
                content += XepHang.ToString() + Environment.NewLine + Environment.NewLine;
                return content;
            }
        }

        List<DuLieu> DuLieuList = new List<DuLieu>();

        List<TongKet> TongKetList = new List<TongKet>();

        private void buttonDoc_Click(object sender, EventArgs e)
        {
            string content = "";
            try
            {
                string inputFilePath = "C:\\Users\\USER\\Desktop\\22520300-LeVietDuong\\Lab2\\input5.txt";
                content = File.ReadAllText(inputFilePath);
                textBoxDoc.Text = content;
                MessageBox.Show("Đọc file thành công!", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn file để đọc!", "Thông báo");
            }

            List<string> list = new List<string>();
            foreach (var dulieu in content.Split('\n'))
            {
                list.Add(dulieu); 
            }
            int i = 0;
            while (i < list.Count)
            {
                DuLieu dulieulist = new DuLieu();
                dulieulist.Ten = list[i];
                dulieulist.GiaVe = int.Parse(list[i + 1]);
                dulieulist.Phong = int.Parse(list[i + 2]);
                dulieulist.ChoNgoi = list[i + 3];    
                DuLieuList.Add(dulieulist);
                i += 5;
            }    
        }

        private void buttonXuat_Click(object sender, EventArgs e)
        {
            foreach (var dulieu in DuLieuList)
            {
                TongKet tongket = new TongKet();
                tongket.Ten = dulieu.Ten;
                tongket.GiaVe = dulieu.GiaVe;
                tongket.Phong = dulieu.Phong;
                tongket.ChoNgoi = dulieu.ChoNgoi;
                List<string> chongoi = new List<string>();
                foreach (var cho in tongket.ChoNgoi.Split(' '))
                {
                    chongoi.Add(cho);
                }
                tongket.DaBan = chongoi.Count;
                tongket.Ton = tongket.TongVe - chongoi.Count;
                tongket.TyLe = (float)tongket.DaBan / tongket.TongVe;
                long sum = 0;
                foreach (var cho in chongoi)
                {
                    if (cho == "A1" || cho == "A5" || cho == "C1" || cho == "C5")
                    {
                        sum += tongket.GiaVe / 4;
                    }
                    else
                    {
                        if (cho == " B2" || cho == "B3" || cho == "B4")
                        {
                            sum += tongket.GiaVe * 2;
                        }
                        else
                        {
                            sum += tongket.GiaVe;
                        }
                    }
                }
                tongket.DoanhThu = sum;
                TongKetList.Add(tongket);
            }

            TongKetList.Sort((a, b) => b.DoanhThu.CompareTo(a.DoanhThu));
            int i = 1;
            foreach (TongKet tongket in TongKetList)
            {
                tongket.XepHang = i;
                i++;
            }

            foreach (TongKet tongket in TongKetList)
            {
                textBoxGhi.Text += tongket.Show();
            }

            string outputFilePath = "C:\\Users\\USER\\Desktop\\22520300-LeVietDuong\\Lab2\\output5.txt";
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.Write(textBoxGhi.Text);
            }
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bai05_Load(object sender, EventArgs e)
        {

        }
    }
}
