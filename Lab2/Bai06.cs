using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LAB2
{
    public partial class Bai06 : Form
    {
        public Bai06()
        {
            InitializeComponent();
        }

        string str = @"Data Source=VIETDUONG\SQL;Initial Catalog=Lab02_Bai06;Integrated Security=True";
        SqlConnection conn = null;

        private void buttonDSMon_Click(object sender, EventArgs e)
        {
            ShowDSMon();
        }


        private void buttonNguoi_Click(object sender, EventArgs e)
        {
            ShowDSNguoi();
        }

        void ShowDSMon()
        {
            if (conn == null)
            {
                conn = new SqlConnection(str);
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from MonAn";

            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            listViewDSMon.Items.Clear();
            while (reader.Read())
            {
                string id = reader.GetString(0);
                string ten = reader.GetString(1);
                string ncc = reader.GetString(2);

                ListViewItem list = new ListViewItem(id);
                list.SubItems.Add(ten);
                list.SubItems.Add(ncc);

                listViewDSMon.Items.Add(list);
            }
            reader.Close();
        }

        void ShowDSNguoi()
        {
            if (conn == null)
            {
                conn = new SqlConnection(str);
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from NguoiDung";

            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            listViewDSNguoi.Items.Clear();
            while (reader.Read())
            {
                string id = reader.GetString(0);
                string ten = reader.GetString(1);
                string quyen = reader.GetString(2);

                ListViewItem list = new ListViewItem(id);
                list.SubItems.Add(ten);
                list.SubItems.Add(quyen);

                listViewDSNguoi.Items.Add(list);
            }
            reader.Close();
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int number = random.Next(listViewDSMon.Items.Count);
            textBoxMon.Text = listViewDSMon.Items[number].SubItems[1].Text;
            textBoxNguoi.Text = listViewDSMon.Items[number].SubItems[2].Text;
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bai06_Load(object sender, EventArgs e)
        {

        }
    }
}
