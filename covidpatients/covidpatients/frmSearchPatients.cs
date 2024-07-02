using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace covidpatients
{
    public partial class frmSearchPatients : Form
    {
        public int selInt { get; set; }
        public frmSearchPatients()
        {
            InitializeComponent();
        }

        private void frmSearchPatients_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=MK\SQLEXPRESS01; Initial Catalog =CovidPatients; User ID=sa; Password=pass123 ";
            conn.Open();
            

            string sql = "";
            sql = "SELECT * FROM tblpatients";
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataReader rd = comm.ExecuteReader();
            while (rd.Read())
            {
                ListViewItem item = new ListViewItem(rd[0].ToString());
                item.SubItems.Add(rd[1].ToString());
                item.SubItems.Add(rd[2].ToString());
                item.SubItems.Add(rd[3].ToString());
                item.SubItems.Add(rd[4].ToString());
                item.SubItems.Add(rd[5].ToString());
                item.SubItems.Add(rd[6].ToString());

                lvwlist.Items.Add(item);
            }
            conn.Close();
        }

        private void lvwlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwlist.FocusedItem == null) return;
            int i = lvwlist.FocusedItem.Index;
            label1.Text = lvwlist.Items[i].Text + " Name;" + lvwlist.Items[i].SubItems[1].Text + " Id No."+ lvwlist.Items[i].SubItems[2].Text;
            this.selInt = int.Parse(lvwlist.Items[i].Text);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lvwlist_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSearchPatients_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
