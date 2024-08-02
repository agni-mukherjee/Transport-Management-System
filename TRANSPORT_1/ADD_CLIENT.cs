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
    public partial class ADD_CLIENT : Form
    {
        public ADD_CLIENT()
        {
            InitializeComponent();
        }

        SQLiteConnection m_dbConnection;
        void addcli()
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please enter correct Client Name");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Please enter correct Mobile Number");
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("Please enter correct Address");
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("Please enter correct ID No");
                }
                
                else if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" )
                {
                    MessageBox.Show("Please fill all the details");
                }
                else
                {
                    m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                    m_dbConnection.Open();
                    SQLiteCommand cmd11 = new SQLiteCommand("select ID_NO from ADD_CLI where ID_NO='" + textBox4.Text + "'", m_dbConnection);
                    SQLiteDataAdapter ds11 = new SQLiteDataAdapter(cmd11);
                    DataSet dss = new DataSet();
                    ds11.Fill(dss, "ADD_CLI");
                    if (dss.Tables["ADD_CLI"].Rows.Count >= 1)
                    {

                        MessageBox.Show("Duplicate Entry ");
                        m_dbConnection.Close();

                    }
                    else
                    {
                        SQLiteCommand cmd = new SQLiteCommand("insert into ADD_CLI (C_NAME,MOB,ADDR,ID_NO) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", m_dbConnection);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("New Client has been Added ");
                        m_dbConnection.Close();

                    }
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("Error In Connection.." + ee);
            }
        }

        void get_data()
        {
            try
            {

                dataGridView1.DataSource = null;
                m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                DataTable da3 = new DataTable();
                SQLiteDataAdapter cmd = new SQLiteDataAdapter("select * from ADD_CLI", m_dbConnection);

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
        private void ADD_CLIENT_Load(object sender, EventArgs e)
        {
            get_data();
            textBox1.Focus();
            textBox1.BackColor = Color.SkyBlue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addcli();
            get_data();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox4.BackColor = Color.White;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            get_data();
            try
            {

                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please enter Client Name");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Please enter Mobile Number");
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("Please enter Address");
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("Please enter ID Number");
                }
               
                else if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "")
                {
                    MessageBox.Show("Please enter all details");
                }
                else
                {

                    m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                    m_dbConnection.Open();
                    SQLiteCommand cmd = new SQLiteCommand("select VH_NO from ADD_VEH where VH_NO= '" + textBox1.Text + "'", m_dbConnection);
                    SQLiteDataAdapter ds = new SQLiteDataAdapter(cmd);
                    DataSet dss = new DataSet();
                    ds.Fill(dss, "ADD_CLI");
                    if (dss.Tables["ADD_CLI"].Rows.Count >= 1)
                    {
                        SQLiteCommand cmd2 = new SQLiteCommand("update ADD_CLI set C_NAME='" + textBox1.Text + "',MOB='" + textBox2.Text + "',ADDR='" + textBox3.Text + "',ID_NO='" + textBox4.Text + "' where SL='" + label7.Text + "'", m_dbConnection);
                        cmd2.ExecuteNonQuery();
                        m_dbConnection.Close();
                        get_data();
                    }
                    else
                    {


                        SQLiteCommand cmd2 = new SQLiteCommand("update ADD_CLI set C_NAME='" + textBox1.Text + "',MOB='" + textBox2.Text + "',ADDR='" + textBox3.Text + "',ID_NO='" + textBox4.Text + "'  where SL='" + label7.Text + "'", m_dbConnection);
                        cmd2.ExecuteNonQuery();

                        MessageBox.Show("Data has been saved Successfully !!!");
                        m_dbConnection.Close();
                        get_data();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        
                        textBox1.Focus();
                    }
                }
            }
            catch (Exception ee)
            {

                MessageBox.Show("Error In Connection.." + ee);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow dr = this.dataGridView1.Rows[e.RowIndex];
                    label7.Text = dr.Cells["SL"].Value.ToString();
                    textBox1.Text = dr.Cells["C_NAME"].Value.ToString();
                    textBox2.Text = dr.Cells["MOB"].Value.ToString();
                    textBox3.Text = dr.Cells["ADDR"].Value.ToString();
                    textBox4.Text = dr.Cells["ID_NO"].Value.ToString();
                    
                }
            }
            catch
            {

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow dr = this.dataGridView1.Rows[e.RowIndex];
                    label7.Text = dr.Cells["SL"].Value.ToString();
                    textBox1.Text = dr.Cells["C_NAME"].Value.ToString();
                    textBox2.Text = dr.Cells["MOB"].Value.ToString();
                    textBox3.Text = dr.Cells["ADDR"].Value.ToString();
                    textBox4.Text = dr.Cells["ID_NO"].Value.ToString();
                 
                }
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {


                m_dbConnection = new SQLiteConnection("Data Source =" + _DATA.Text + ".s3db;Version=3;");

                m_dbConnection.Open();

                SQLiteCommand cmd2 = new SQLiteCommand("delete from ADD_CLI where SL='" + label7.Text + "'", m_dbConnection);
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Data has been deleted successfully !!!");
                m_dbConnection.Close();
                get_data();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                
                textBox1.Focus();


            }
            catch (Exception ee)
            {

                MessageBox.Show("Error In Connection.." + ee);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                textBox2.Focus();
                textBox2.BackColor = Color.SkyBlue;
                textBox1.BackColor = Color.White;
                e.Handled = true;
            }
            else if(e.KeyCode==Keys.Tab)
            {
                textBox2.Focus();
                textBox2.BackColor = Color.SkyBlue;
                textBox1.BackColor = Color.White;
                e.Handled = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                textBox3.Focus();
                textBox3.BackColor = Color.SkyBlue;
                textBox2.BackColor = Color.White;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Tab)
            {
                textBox3.Focus();
                textBox3.BackColor = Color.SkyBlue;
                textBox2.BackColor = Color.White;
                e.Handled = true;
            }
            else if(e.KeyCode==Keys.Back)
            {
                textBox1.Focus();
                textBox1.BackColor = Color.SkyBlue;
                textBox2.BackColor = Color.White;
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                textBox4.Focus();
                textBox4.BackColor = Color.SkyBlue;
                textBox3.BackColor = Color.White;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Tab)
            {
                textBox4.Focus();
                textBox4.BackColor = Color.SkyBlue;
                textBox3.BackColor = Color.White;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Back)
            {
                textBox2.Focus();
                textBox2.BackColor = Color.SkyBlue;
                textBox3.BackColor = Color.White;
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                addcli();
                get_data();
                textBox1.Focus();
                textBox1.BackColor = Color.SkyBlue;
                textBox4.BackColor = Color.White;
                e.Handled = true;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";

            }
            else if (e.KeyCode == Keys.Back)
            {
                textBox3.Focus();
                textBox3.BackColor = Color.SkyBlue;
                textBox4.BackColor = Color.White;
            }

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.BackColor = Color.SkyBlue;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.BackColor = Color.SkyBlue;
            textBox1.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.BackColor = Color.SkyBlue;
            textBox2.BackColor = Color.White;
            textBox1.BackColor = Color.White;
            textBox4.BackColor = Color.White;
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.BackColor = Color.SkyBlue;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox1.BackColor = Color.White;
        }
    }
}
