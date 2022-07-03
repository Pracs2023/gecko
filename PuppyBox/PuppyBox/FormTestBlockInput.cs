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
    public partial class FormTestBlockInput : Form
    {
        public FormTestBlockInput()
        {
            InitializeComponent();
        }
        private bool IsAcceptInput = true;
        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            lblClick.MouseDown -= lblClick_MouseDown;
            IsAcceptInput = false;
            while (i < 3000)
            {
                this.Text = "Program will block input until value of i is 3000. Now i is " + i.ToString();
                i++;
                this.Refresh();
            }
            IsAcceptInput = true;
            Timer T = new Timer();
            T.Interval = 10;
            T.Enabled = true;
            T.Tick += T_Tick;
           

        }
        private void T_Tick(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
            ((Timer)sender).Enabled = false;
            lblClick.MouseDown += lblClick_MouseDown;

        }

        private void lblClick_MouseDown(object sender, MouseEventArgs e)
        {
            if(!IsAcceptInput)
            {
                return;
            }
            //this.button1.Text = "pictureBox1_MouseDown";
            this.textBox1.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss ") + " pictureBox1_MouseDown " + Environment.NewLine);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblClick.MouseDown -= lblClick_MouseDown;
            lblClick.MouseDown += lblClick_MouseDown;
            IsAcceptInput = false;
            int i = 0;
            while (i < 3000)
            {
                this.Text ="Program will block input until value of i is 3000. Now i is " + i.ToString();
                i++;
                this.Refresh();
            }
            IsAcceptInput = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblClick.MouseDown += lblClick_MouseDown;
        }
    }
}
