using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace TRANSPORT_1
{
    public partial class CLI_REVIEW : Form
    {
        public CLI_REVIEW()
        {
            InitializeComponent();
        }

        SQLiteConnection m_dbConnection;

        void get_cname()
        {
            try
            {

                dataGridView1.DataSource = null;
                m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                DataTable da3 = new DataTable();
                SQLiteDataAdapter cmd = new SQLiteDataAdapter("select * from ADD_CLI where C_NAME like  '%" + textBox1.Text + "%'", m_dbConnection);

                cmd.Fill(da3);


                dataGridView1.DataSource = da3;


                this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.GreenYellow;
                this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;


                m_dbConnection.Close();






            }
            catch (Exception ee)
            {

                MessageBox.Show("Error In Connection.." + ee);
            }
        }

        void get_cmob()
        {
            try
            {

                dataGridView1.DataSource = null;
                m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                DataTable da3 = new DataTable();
                SQLiteDataAdapter cmd = new SQLiteDataAdapter("select * from ADD_CLI where MOB like  '%" + textBox2.Text + "%'", m_dbConnection);

                cmd.Fill(da3);


                dataGridView1.DataSource = da3;


                this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.GreenYellow;
                this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;


                m_dbConnection.Close();






            }
            catch (Exception ee)
            {

                MessageBox.Show("Error In Connection.." + ee);
            }
        }


        void get_cid()
        {
            try
            {

                dataGridView1.DataSource = null;
                m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                DataTable da3 = new DataTable();
                SQLiteDataAdapter cmd = new SQLiteDataAdapter("select * from ADD_CLI where ID_NO like  '%" + textBox3.Text + "%'", m_dbConnection);

                cmd.Fill(da3);


                dataGridView1.DataSource = da3;


                this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.GreenYellow;
                this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;


                m_dbConnection.Close();






            }
            catch (Exception ee)
            {

                MessageBox.Show("Error In Connection.." + ee);
            }
        }

        void get_caddr()
        {
            try
            {

                dataGridView1.DataSource = null;
                m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                DataTable da3 = new DataTable();
                SQLiteDataAdapter cmd = new SQLiteDataAdapter("select * from ADD_CLI where addr like  '%" + textBox4.Text + "%'", m_dbConnection);

                cmd.Fill(da3);


                dataGridView1.DataSource = da3;


                this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.GreenYellow;
                this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;


                m_dbConnection.Close();






            }
            catch (Exception ee)
            {

                MessageBox.Show("Error In Connection.." + ee);
            }
        }

        private void CLI_REVIEW_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            get_cname();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            get_cmob();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            get_cid();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            get_caddr();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                get_cname();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                get_cmob();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                get_cid();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                get_caddr();
            }
        }
    }
}
