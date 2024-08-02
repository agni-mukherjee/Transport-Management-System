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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SQLiteConnection m_dbConnection;

        void adddrv()
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please enter correct Name");
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
                    MessageBox.Show("Please enter correct Lisence Number");
                }
                else if (comboBox1.Text == "")
                {
                    MessageBox.Show("Please enter correct Blood Group");
                }
                else if(textBox5.Text=="")
                {
                    MessageBox.Show("Please enter correct ID Proof Number");
                }
                else if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && comboBox1.Text == "" &&textBox5.Text=="")
                {
                    MessageBox.Show("Please fill all the details");
                }
                else
                {
                    m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                    m_dbConnection.Open();
                    SQLiteCommand cmd11 = new SQLiteCommand("select L_NO from ADD_DRV where L_NO='" + textBox4.Text + "'", m_dbConnection);
                    SQLiteDataAdapter ds11 = new SQLiteDataAdapter(cmd11);
                    DataSet dss = new DataSet();
                    ds11.Fill(dss, "ADD_DRV");
                    if (dss.Tables["ADD_DRV"].Rows.Count >= 1)
                    {

                        MessageBox.Show("Duplicate Entry ");
                        m_dbConnection.Close();

                    }
                    else
                    {
                        SQLiteCommand cmd = new SQLiteCommand("insert into ADD_DRV (NAME,MOB,ADDR,L_NO,BG,ID_NO) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','"+textBox5.Text+"')", m_dbConnection);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("New Driver has been added Successfully !!! ");
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
                SQLiteDataAdapter cmd = new SQLiteDataAdapter("select * from ADD_DRV", m_dbConnection);

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
        private void Form3_Load(object sender, EventArgs e)
        {
            get_data();
            textBox1.BackColor = Color.SkyBlue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adddrv();
            get_data();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            textBox5.Text = "";
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please enter Name");
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
                    MessageBox.Show("Please enter Lisence Number");
                }
                else if (comboBox1.Text == "")
                {
                    MessageBox.Show("Please enter Blood Group");
                }
                else if(textBox5.Text=="")
                {
                    MessageBox.Show("Please enter ID Proof Number");
                }
                else if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && comboBox1.Text == "" && textBox5.Text == "")
                {
                    MessageBox.Show("Please enter all details");
                }
                else
                {

                    m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                    m_dbConnection.Open();
                    SQLiteCommand cmd = new SQLiteCommand("select NAME from ADD_DRV where NAME= '" + textBox1.Text + "'", m_dbConnection);
                    SQLiteDataAdapter ds = new SQLiteDataAdapter(cmd);
                    DataSet dss = new DataSet();
                    ds.Fill(dss, "ADD_DRV");
                    if (dss.Tables["ADD_DRV"].Rows.Count >= 1)
                    {
                        SQLiteCommand cmd2 = new SQLiteCommand("update ADD_DRV set MOB='" + textBox2.Text + "',ADDR='" + textBox3.Text + "',L_NO='" + textBox4.Text + "',BG='" + comboBox1.Text + "',ID_NO='"+textBox5.Text+"' where SL='" + label7.Text + "' and NAME='" + textBox1.Text + "'", m_dbConnection);
                        cmd2.ExecuteNonQuery();
                        m_dbConnection.Close();
                        get_data();
                        MessageBox.Show("Data has been updated Sucessfully !!!");
                    }
                    else
                    {


                        SQLiteCommand cmd2 = new SQLiteCommand("update ADD_DRV set NAME='" + textBox2.Text + "',ADDR='" + textBox3.Text + "',L_NO='" + textBox4.Text + "',BG='" + comboBox1 + "',ID_NO='"+textBox5.Text+"'  where SL='" + label7.Text + "'", m_dbConnection);
                        cmd2.ExecuteNonQuery();

                        MessageBox.Show("Data has been updated Successfully !!!");
                        m_dbConnection.Close();
                        get_data();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        comboBox1.Text = "";
                        textBox5.Text = "";
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
                    textBox1.Text = dr.Cells["NAME"].Value.ToString();
                    textBox2.Text = dr.Cells["MOB"].Value.ToString();
                    textBox3.Text = dr.Cells["ADDR"].Value.ToString();
                    textBox4.Text = dr.Cells["L_NO"].Value.ToString();
                    comboBox1.Text = dr.Cells["BG"].Value.ToString();
                    textBox5.Text = dr.Cells["ID_NO"].Value.ToString();
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
                    textBox1.Text = dr.Cells["NAME"].Value.ToString();
                    textBox2.Text = dr.Cells["MOB"].Value.ToString();
                    textBox3.Text = dr.Cells["ADDR"].Value.ToString();
                    textBox4.Text = dr.Cells["L_NO"].Value.ToString();
                    comboBox1.Text = dr.Cells["BG"].Value.ToString();
                    textBox5.Text = dr.Cells["ID_NO"].Value.ToString();
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

                SQLiteCommand cmd2 = new SQLiteCommand("delete from ADD_DRV where SL='" + label7.Text + "'", m_dbConnection);
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Data has been deleted Successfully !!!");
                m_dbConnection.Close();
                get_data();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                comboBox1.Text = "";


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
            else if(e.KeyCode==Keys.Back)
            {
                textBox1.Focus();
                textBox1.BackColor = Color.SkyBlue;
                textBox2.BackColor = Color.White;
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
            else if (e.KeyCode == Keys.Back)
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


                comboBox1.Focus();
                comboBox1.BackColor = Color.SkyBlue;
                textBox4.BackColor = Color.White;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Tab)
            {
                comboBox1.Focus();
                comboBox1.BackColor = Color.SkyBlue;
                textBox4.BackColor = Color.White;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Back)
            {
                textBox3.Focus();
                textBox3.BackColor = Color.SkyBlue;
                textBox4.BackColor = Color.White;
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                textBox5.Focus();
                textBox5.BackColor = Color.SkyBlue;
                comboBox1.BackColor = Color.White;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Tab)
            {
                textBox5.Focus();
                textBox5.BackColor = Color.SkyBlue;
                comboBox1.BackColor = Color.White;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Back)
            {
                textBox4.Focus();
                textBox4.BackColor = Color.SkyBlue;
                comboBox1.BackColor = Color.White;
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {
                adddrv();
                get_data();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                comboBox1.Text = "";

                
                textBox1.Focus();
                textBox1.BackColor = Color.SkyBlue;
                textBox5.BackColor = Color.White;
            }
            //else if (e.KeyCode == Keys.Tab)
            //{
            //    textBox2.Focus();
            //    textBox2.BackColor = Color.SkyBlue;
            //    textBox1.BackColor = Color.White;
            //    e.Handled = true;
            //}
            else if (e.KeyCode == Keys.Back)
            {
                comboBox1.Focus();
                comboBox1.BackColor = Color.SkyBlue;
                textBox5.BackColor = Color.White;
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.BackColor = Color.SkyBlue;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;
            comboBox1.BackColor = Color.White;
            textBox5.BackColor = Color.White;
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.BackColor = Color.SkyBlue;
            textBox1.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;
            comboBox1.BackColor = Color.White;
            textBox5.BackColor = Color.White;
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.BackColor = Color.SkyBlue;
            textBox2.BackColor = Color.White;
            textBox1.BackColor = Color.White;
            textBox4.BackColor = Color.White;
            comboBox1.BackColor = Color.White;
            textBox5.BackColor = Color.White;
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.BackColor = Color.SkyBlue;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox1.BackColor = Color.White;
            comboBox1.BackColor = Color.White;
            textBox5.BackColor = Color.White;
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;
            comboBox1.BackColor = Color.SkyBlue;
            textBox5.BackColor = Color.White;
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            textBox5.BackColor = Color.SkyBlue;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;
            comboBox1.BackColor = Color.White;
            textBox1.BackColor = Color.White;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
