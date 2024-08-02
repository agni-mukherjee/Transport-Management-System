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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SQLiteConnection m_dbConnection;

        void addvh()
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please enter correct Vheicle Number");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Please enter correct Vehicle Type");
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("Please enter correct Engine Number");
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("Please enter correct Chesis Number");
                }
                else if (comboBox1.Text == "")
                {
                    MessageBox.Show("Please enter correct Permit Type");
                }
                else if(textBox1.Text==""&&textBox2.Text==""&&textBox3.Text==""&&textBox4.Text==""&&comboBox1.Text=="")
                {
                    MessageBox.Show("Please fill all the details");
                }
                else
                {
                    m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                    m_dbConnection.Open();
                    SQLiteCommand cmd11 = new SQLiteCommand("select VH_NO from ADD_VEH where VH_NO='" + textBox1.Text + "'", m_dbConnection);
                    SQLiteDataAdapter ds11 = new SQLiteDataAdapter(cmd11);
                    DataSet dss = new DataSet();
                    ds11.Fill(dss, "ADD_VEH");
                    if (dss.Tables["ADD_VEH"].Rows.Count >= 1)
                    {

                        MessageBox.Show("Duplicate Entry ");
                        m_dbConnection.Close();

                    }
                    else
                    {
                        SQLiteCommand cmd = new SQLiteCommand("insert into ADD_VEH (VH_NO,VH_TYPE,EN_NO,CH_NO,P_TYPE) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "')", m_dbConnection);
                        SQLiteCommand cmd2 = new SQLiteCommand("insert into B_ID2(S2) values ('" + label8.Text + "')", m_dbConnection );
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("New Vehicle Added ");
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
                SQLiteDataAdapter cmd = new SQLiteDataAdapter("select * from ADD_VEH", m_dbConnection);

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

        private void Form2_Load(object sender, EventArgs e)
        {
            get_data();
            textBox1.BackColor = Color.SkyBlue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addvh();
            get_data();
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{

            //    addvh();
            //    textBox1.Text = "";
            //    textBox2.Text = "";
            //    textBox3.Text = "";
            //    textBox4.Text = "";
            //    comboBox1.Text = "";

            //    textBox1.Focus();
              

            //    e.Handled = true;
            //}
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                addvh();
                get_data();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                comboBox1.Text = "";
                comboBox1.BackColor = Color.White;
                textBox1.Focus();
                textBox1.BackColor = Color.SkyBlue;

                e.Handled = true;
            }
            //else if (e.KeyCode == Keys.Down)
            //{
            //    textBox4.Focus();
            //    textBox4.BackColor = Color.SkyBlue;
            //    textBox1.BackColor = Color.White;
            //    textBox2.BackColor = Color.White;
            //    textBox3.BackColor = Color.White;
            //    comboBox1.BackColor = Color.White;
            //}
            else if (e.KeyCode == Keys.Up)
            {
                textBox4.Focus();
                textBox4.BackColor = Color.SkyBlue;
                textBox1.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                comboBox1.BackColor = Color.White;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            get_data();
            try
            {

                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please enter Vehicle Number");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Please enter Vehicle Type");
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("Please enter Engine Number");
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("Please enter Chasis Number");
                }
                else if(comboBox1.Text=="")
                {
                    MessageBox.Show("Please enter Permit Type");
                }
                else if(textBox1.Text=="" && textBox2.Text=="" && textBox3.Text=="" && textBox4.Text==""&& comboBox1.Text=="")
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
                    ds.Fill(dss, "ADD_VEH");
                    if (dss.Tables["ADD_VEH"].Rows.Count >= 1)
                    {
                        SQLiteCommand cmd2 = new SQLiteCommand("update ADD_VEH set VH_NO='"+textBox1.Text+"',VH_TYPE='" + textBox2.Text + "',EN_NO='" + textBox3.Text + "',CH_NO='"+textBox4.Text+"',P_TYPE='"+comboBox1.Text+"' where SL='" + label7.Text + "'", m_dbConnection);
                        cmd2.ExecuteNonQuery();
                        m_dbConnection.Close();
                        get_data();
                    }
                    else
                    {


                        SQLiteCommand cmd2 = new SQLiteCommand("update ADD_VEH set VH_NO='" + textBox1.Text + "',VH_TYPE='" + textBox2.Text + "',EN_NO='" + textBox3.Text + "',CH_NO='" + textBox4.Text + "',P_TYPE='" + comboBox1.Text + "'  where SL='" + label7.Text + "'", m_dbConnection);
                        cmd2.ExecuteNonQuery();

                        MessageBox.Show("Data has been saved Successfully !!!");
                        m_dbConnection.Close();
                        get_data();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        comboBox1.Text = "";
                        textBox1.Focus();
                    }
                }
            }
            catch (Exception ee)
            {

                MessageBox.Show("Error In Connection.." + ee);
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
                    textBox1.Text = dr.Cells["VH_NO"].Value.ToString();
                    textBox2.Text = dr.Cells["VH_TYPE"].Value.ToString();
                    textBox3.Text = dr.Cells["EN_NO"].Value.ToString();
                    textBox4.Text = dr.Cells["CH_NO"].Value.ToString();
                    comboBox1.Text = dr.Cells["P_TYPE"].Value.ToString();
                }
            }
            catch
            {

            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

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
                    textBox1.Text = dr.Cells["VH_NO"].Value.ToString();
                    textBox2.Text = dr.Cells["VH_TYPE"].Value.ToString();
                    textBox3.Text = dr.Cells["EN_NO"].Value.ToString();
                    textBox4.Text = dr.Cells["CH_NO"].Value.ToString();
                    comboBox1.Text = dr.Cells["P_TYPE"].Value.ToString();
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

                SQLiteCommand cmd2 = new SQLiteCommand("delete from ADD_VEH where SL='" + label7.Text + "'", m_dbConnection);
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Data has been deleted successfully !!!");
                m_dbConnection.Close();
                get_data();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                comboBox1.Text = "";
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
            else if(e.KeyCode == Keys.Down)
            {
                textBox2.Focus();
                textBox2.BackColor = Color.SkyBlue;
                textBox1.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                comboBox1.BackColor = Color.White;
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
            else if (e.KeyCode == Keys.Down)
            {
                textBox3.Focus();
                textBox3.BackColor = Color.SkyBlue;
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                comboBox1.BackColor = Color.White;
            }
            else if (e.KeyCode==Keys.Up)
            {
                textBox1.Focus();
                textBox1.BackColor = Color.SkyBlue;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                comboBox1.BackColor = Color.White;
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
            else if (e.KeyCode == Keys.Down)
            {
                textBox4.Focus();
                textBox4.BackColor = Color.SkyBlue;
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                comboBox1.BackColor = Color.White;
            }
            else if (e.KeyCode == Keys.Up)
            {
                textBox2.Focus();
                textBox2.BackColor = Color.SkyBlue;
                textBox1.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                comboBox1.BackColor = Color.White;
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
            else if (e.KeyCode == Keys.Down)
            {
                comboBox1.Focus();
                comboBox1.BackColor = Color.SkyBlue;
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
            }
            else if (e.KeyCode == Keys.Up)
            {
                textBox3.Focus();
                textBox3.BackColor = Color.SkyBlue;
                textBox1.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                comboBox1.BackColor = Color.White;
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.BackColor = Color.SkyBlue;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;
            comboBox1.BackColor = Color.White;
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.BackColor = Color.SkyBlue;
            textBox1.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;
            comboBox1.BackColor = Color.White;
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.BackColor = Color.SkyBlue;
            textBox2.BackColor = Color.White;
            textBox1.BackColor = Color.White;
            textBox4.BackColor = Color.White;
            comboBox1.BackColor = Color.White;
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.BackColor = Color.SkyBlue;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox1.BackColor = Color.White;
            comboBox1.BackColor = Color.White;
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;
            comboBox1.BackColor = Color.SkyBlue;
        }
    }
}
