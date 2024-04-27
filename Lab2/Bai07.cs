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
    public partial class Bai07 : Form
    {
        public Bai07()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bai07_Load(object sender, EventArgs e)
        {

        }
      

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (webBrowser.CanGoBack)
            {
                webBrowser.GoBack();
            }
        }

       
        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select your path. " })
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    webBrowser.Url = new Uri(fbd.SelectedPath);
                    txtPath.Text = fbd.SelectedPath;
                }
        }

        private void btnForward_Click_1(object sender, EventArgs e)
        {
            if (webBrowser.CanGoForward)
            {
                webBrowser.GoForward();
            }
        }
    }
}
