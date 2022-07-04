using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuppyBox
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            this.richTextBox1.LinkClicked += RichTextBox1_LinkClicked;

        }

        private void RichTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            // throw new NotImplementedException();
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void linkLabel1_LickClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text );

        }
    }
}
