using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LAB2
{
    public partial class Bai02 : Form
    {
        public Bai02()
        {
            InitializeComponent();
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string content = sr.ReadToEnd();
            textBoxShow.Text = content;

            string name = ofd.SafeFileName.ToString();
            textBoxFileName.Text = name;

            string url = fs.Name.ToString();
            textBoxURL.Text = url;

            long size = fs.Length;
            textBoxSize.Text = size.ToString() + " bytes";

            int linecount = 0;
            foreach (string line in content.Split('\n'))
            {
                linecount++;   
            }
            textBoxLineCount.Text = linecount.ToString();

            int wordcount = 0;
            foreach (string line in content.Split('\n'))
            {
                foreach (string word in line.Split(' '))
                {
                    wordcount++;
                }
            }
            textBoxWordCount.Text = wordcount.ToString();

            long charatercount = content.Count();
            textBoxCharaterCount.Text = charatercount.ToString();

            fs.Close();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bai02_Load(object sender, EventArgs e)
        {

        }
    }
}
