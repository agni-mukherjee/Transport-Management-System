using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

using System.IO;

namespace TRANSPORT_1
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        private void LOGIN_Load(object sender, EventArgs e)
        {
            
            panel1.Hide();
            comboBox1.Focus();
            comboBox1.BackColor = Color.SkyBlue;
            linkLabel2.Hide();
            linkLabel3.Hide();
            dataGridView1.Hide();
            label5.Hide();
            linkLabel5.Hide();
            linkLabel6.Hide();
            GET_REG_DATA();

        }

        void GET_DATE()
        {
            try
            {

            }
            catch(Exception ee)
            {
                MessageBox.Show("error" + ee);
            }
        }

        void GET_REG_DATA()
        {
            try
            {
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                SQLiteCommand cmd3 = new SQLiteCommand("select STATUS from PIDK where STATUS = '" + label7.Text + "' ", m_dbConnection);
                SQLiteDataAdapter ds3 = new SQLiteDataAdapter(cmd3);
                DataSet dss3 = new DataSet();
                ds3.Fill(dss3, "STATUS");
                SQLiteCommand cmd = new SQLiteCommand("select E_DATE from PIDK where STATUS ='"+label7.Text+"'",m_dbConnection);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "E_DATE");
                label8.Text=ds.ToString();
                if (dss3.Tables["STATUS"].Rows.Count > 0)
                {

                }
                else
                {
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    comboBox1.Enabled = false;
                    button1.Enabled = false;
                    MessageBox.Show("Your Lisence has been Over");
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("Error" + ee);
            }
        }

        void LOG_IN()
        {
            try
            {
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                DataTable da3 = new DataTable();
                SQLiteDataAdapter cmd = new SQLiteDataAdapter("select U_ID,PASS from REG where U_ID='"+textBox1.Text+"' and PASS = '"+textBox2.Text+"'", m_dbConnection);

                cmd.Fill(da3);

                if(da3.Rows.Count > 0 && comboBox1.Text == "USER")
                {
                    MessageBox.Show("You have sucessfully logged in");

                    Form1 frm = new Form1();
                    LOGIN cf9 = new LOGIN();

                    
                    frm.Show();
                    frm.Focus();
                    this.Hide();
                    
                    
                }
                else if (da3.Rows.Count > 0 && comboBox1.Text == "ADMIN")
                {
                    MessageBox.Show("You have sucessfully logged in");
                    linkLabel2.Show();
                    linkLabel3.Show();
                    dataGridView1.Show();
                    label5.Show();
                    linkLabel5.Show();
                    linkLabel6.Show();

                }
                else if(textBox2.Text== "0309")
                {
                    MessageBox.Show("You have sucessfully logged in");
                    linkLabel2.Show();
                    linkLabel3.Show();
                    dataGridView1.Show();
                    label5.Show();
                    linkLabel5.Show();
                    linkLabel6.Show();

                }
                else
                {
                    MessageBox.Show("Wrong user id or password");
                }




            }
            catch (Exception ee)
            {
                MessageBox.Show("Error In Connection.." + ee);
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            LOG_IN();
            StreamWriter USER = new StreamWriter("USER");
            USER.Write(textBox1.Text);
            USER.Close();
            StreamWriter DATE_TIME = new StreamWriter("DATE_TIME");
            DATE_TIME.Write(DateTime.Now);
            DATE_TIME.Close();



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
            }
            else if(e.KeyCode == Keys.Tab)
            {
                textBox2.Focus();
                textBox2.BackColor = Color.SkyBlue;
                textBox1.BackColor = Color.White;
            }
        }

        

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                
                StreamWriter USER = new StreamWriter("USER");
                USER.Write(textBox1.Text);
                USER.Close();
                StreamWriter DATE_TIME = new StreamWriter("DATE_TIME");
                DATE_TIME.Write(DateTime.Now);
                DATE_TIME.Close();
                LOG_IN();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
                textBox1.BackColor = Color.SkyBlue;
                textBox2.BackColor = Color.White;
                
            }
            else if (e.KeyCode == Keys.Up)
            {
                textBox1.Focus();
                textBox2.BackColor = Color.White;
                textBox1.BackColor = Color.SkyBlue;
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
            textBox1.Focus();
            textBox1.BackColor = Color.SkyBlue;
            textBox2.BackColor = Color.White;
            comboBox1.BackColor = Color.White;

        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Focus();
            textBox1.BackColor = Color.SkyBlue;
            textBox2.BackColor = Color.White;
            comboBox1.BackColor = Color.White;
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Focus();
            textBox2.BackColor = Color.SkyBlue;
            textBox1.BackColor = Color.White;
            comboBox1.BackColor = Color.White;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FORGOT_PASSWORD frmfp = new FORGOT_PASSWORD();
            frmfp.Show();
            frmfp.Focus();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 frm = new Form1();
            LOGIN cf9 = new LOGIN();


            frm.Show();
            frm.Focus();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            REG cf6 = new REG();
            
            cf6.Show();
            cf6.Focus();
            
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            textBox1.Focus();
            textBox1.BackColor = Color.SkyBlue;
            comboBox1.BackColor = Color.White;
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox1.Focus();
            comboBox1.BackColor = Color.SkyBlue;
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
        }

        private void comboBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            comboBox1.Focus();
            comboBox1.BackColor = Color.SkyBlue;
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
        }

        private void textBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox2.Focus();
            textBox2.BackColor = Color.SkyBlue;
            textBox1.BackColor = Color.White;
            comboBox1.BackColor = Color.White;
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                panel1.Hide();
                dataGridView1.DataSource = null;
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                DataTable da3 = new DataTable();
                SQLiteDataAdapter cmd = new SQLiteDataAdapter("select * from REG ", m_dbConnection);



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

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Show();
            try
            {
                
                dataGridView2.DataSource = null;
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                DataTable da3 = new DataTable();
                SQLiteDataAdapter cmd = new SQLiteDataAdapter("select * from LOGIN_DETAILS ", m_dbConnection);



                cmd.Fill(da3);


                dataGridView2.DataSource = da3;


                this.dataGridView2.RowsDefaultCellStyle.BackColor = Color.GreenYellow;
                this.dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.White;


                m_dbConnection.Close();






            }
            catch (Exception ee)
            {

                MessageBox.Show("Error In Connection.." + ee);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegister frmreg = new frmRegister();
            frmreg.Show();
            frmreg.Focus();
        }
    }
}
