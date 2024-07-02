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
namespace covidpatients
{
    public partial class frmPatients : Form
    {
        int curId = 0;
        public frmPatients()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            curId = 0;
            clearText();
            txtName.Focus();
        }
        private void clearText()
        {
            txtName.Text = "";
            txtIdNo.Text = "";
            txtCountry.Text = "";
            dtpDOB.Value = DateTime.Today;
            cmbGender.SelectedIndex = -1;
            chkIsActive.Checked = true;
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if(txtName.Text.Trim() == "")
            {
                MessageBox.Show("please enter patient name");
                txtName.Focus();
                return;

           

            }
            if (txtIdNo.Text.Trim() == "")
            {

                MessageBox.Show("please enter id no");
                txtIdNo.Focus();
                return;
            }
            //database connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=MK\SQLEXPRESS01; Initial Catalog =CovidPatients; User ID=sa; Password=pass123 ";
            conn.Open();
            //code
            int val = 0;
            if (chkIsActive.Checked) val = 1;

            string sql = "";

            if (curId == 0)
            {
                sql = "INSERT INTO tblpatients(Name,IdNo,DOB,Gender,Country,IsActive)VALUES('" + txtName.Text + "'," + txtIdNo.Text + ",'" + dtpDOB.Value.ToString("yyyyMMdd") + "','" + cmbGender.Text + "','" + txtCountry.Text + "'," + val + ")";

            }
            else
            {
                sql = "UPDATE tblpatients SET Name='" + txtName.Text + "',IdNo=" + txtIdNo.Text + ",DOB='" + dtpDOB.Value.ToString("yyyyMMdd") + "',Gender='" + cmbGender.Text + "',Country='" + txtCountry.Text + "',IsActive=" + val + " WHERE PatientId=" + curId;

            }
            MessageBox.Show(sql);

            SqlCommand comm = new SqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            //MessageBox.Show(sql);
            conn.Close();
            MessageBox.Show("Process Completed");
          }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            frmSearchPatients frm = new frmSearchPatients();
            frm.ShowDialog();
            displayInfo(frm.selInt);
            curId = frm.selInt;
        }
        private void displayInfo(int id )
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=MK\SQLEXPRESS01; Initial Catalog =CovidPatients; User ID=sa; Password=pass123 ";
            conn.Open();


            string sql = "";
            sql = "SELECT * FROM tblpatients WHERE PatientId="+id;
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataReader rd = comm.ExecuteReader();
            if (rd.Read())
            {
               
                txtName.Text=rd[1].ToString();
                txtIdNo.Text=rd[2].ToString();
                 dtpDOB.Value=DateTime.Parse(rd[3].ToString());
                cmbGender.Text= rd[4].ToString();
                txtCountry.Text= rd[5].ToString();
              chkIsActive.Checked=bool.Parse(rd[6].ToString());

               
            }
            conn.Close();

        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            if(curId <=0 )
            {
                MessageBox.Show("Please select an item to delete", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult dresult = MessageBox.Show("Are you sure you want to delete the selected item?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dresult == DialogResult.No)
                return;


            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=MK\SQLEXPRESS01; Initial Catalog =CovidPatients; User ID=sa; Password=pass123 ";
            conn.Open();
            //code
            string sql = "";
            {
                sql = "DELETE FROM tblpatients WHERE   PatientId=" + curId;

            }
            MessageBox.Show(sql);

            SqlCommand comm = new SqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            //MessageBox.Show(sql);
            conn.Close();
            MessageBox.Show("Process succeeded");
            curId = 0;
            clearText();
            txtName.Focus();

        }
    }
    }

