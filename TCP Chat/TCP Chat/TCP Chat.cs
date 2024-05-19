using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP_Chat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TCP_Client f = new TCP_Client();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TCP_Server f = new TCP_Server();
            f.Show();
        }
    }
}
