using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace TRANSPORT_1
{
    public partial class REG : Form
    {
        public REG()
        {
            InitializeComponent();
        }

        SQLiteConnection m_dbConnection;

        void add()
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please enter your Name");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Please enter your Mobile Number");
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("Please enter your Email Address");
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("Please enter new User ID No");
                }
                else if(textBox5.Text=="")
                {
                    MessageBox.Show("Please enter new Password");
                }
                else if(comboBox1.Text=="")
                {
                    MessageBox.Show("Please enter a security question");
                }
                else if(textBox7.Text=="")
                {
                    MessageBox.Show("Please enter a answer of the security question");
                }


                else if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text=="" && textBox7.Text=="" && comboBox1.Text=="")
                {
                    MessageBox.Show("Please fill all the details");
                }
                else
                {
                    m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                    m_dbConnection.Open();
                    SQLiteCommand cmd11 = new SQLiteCommand("select EMAIL from REG where EMAIL='" + textBox3.Text + "'", m_dbConnection);
                    SQLiteDataAdapter ds11 = new SQLiteDataAdapter(cmd11);
                    DataSet dss = new DataSet();
                    ds11.Fill(dss, "REG");
                    if (dss.Tables["REG"].Rows.Count >= 1)
                    {

                        MessageBox.Show("Email already exists");
                        m_dbConnection.Close();

                    }
                    else
                    {
                        SQLiteCommand cmd = new SQLiteCommand("insert into REG (NAME,MOB,EMAIL,U_ID,PASS,S_QU,Q_ANS) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','"+textBox5.Text+"','"+comboBox1.Text+"','"+textBox7.Text+"')", m_dbConnection);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("New User has been added");
                        m_dbConnection.Close();

                    }
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("Error In Connection.." + ee);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            add();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            
        }
    }
}
