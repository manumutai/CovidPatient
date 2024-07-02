using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace covidpatients
{
    public partial class frmlogin : Form
    {
        public   bool IsSucceedded { get; set; }

        public frmlogin()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.IsSucceedded = false;
            //validation code

            if(txtUserName.Text.Trim()=="")
            {
                MessageBox.Show("Username Required ");
                txtUserName.Focus();
                return;
            }
            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Password Required ");
                txtPassword.Focus();
                return;
            }
            //further code

        
            this.IsSucceedded = true;
            this.Close();
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {
            this.IsSucceedded = false;

        }
    }
}
