using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Testapp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=testapp.accdb");
        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = con.CreateCommand();
            con.Open();
            cmd.CommandText = "Insert into Student(FirstName,LastName)Values('" + textBox1.Text + "','" + textBox2.Text + "')";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Submitted","Congrats");
            con.Close();

        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            //leDbCommand cmd = con.CreateCommand();
            con.Open();
            //cmd.CommandText = "Select *from student";
            //cmd.Connection = con;
            string queryString =
  "Select *from student";
            OleDbDataAdapter adapter = new OleDbDataAdapter(queryString, con);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "student");
            dataGridView1.DataSource = ds; // dataset
            dataGridView1.DataMember = "student";
            con.Close();
        }
    }
}
