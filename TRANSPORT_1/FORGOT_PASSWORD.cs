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
    public partial class FORGOT_PASSWORD : Form
    {
        public FORGOT_PASSWORD()
        {
            InitializeComponent();
        }

        private void FORGOT_PASSWORD_Load(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        void RECOVER()
        {
            try
            {
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                DataTable da3 = new DataTable();
                SQLiteDataAdapter cmd = new SQLiteDataAdapter("select U_ID,EMAIL from REG where U_ID='" + textBox1.Text + "' and EMAIL = '" + textBox2.Text + "'", m_dbConnection);

                cmd.Fill(da3);

                if (da3.Rows.Count > 0)
                {

                    panel1.Show();
                    textBox3.BringToFront();
                    textBox4.BringToFront();
                    label5.BringToFront();
                    label6.BringToFront();
                    label7.BringToFront();
                    button2.BringToFront();
                    textBox1.Hide();
                    textBox2.Hide();
                    label1.Hide();
                    label2.Hide();
                    label3.Hide();
                    button1.Hide();


                }
                else
                {
                    MessageBox.Show("Wrong Information");
                }
            }
            catch
            {

            }
        }

        void SAVE()
        {
            try
            {
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                SQLiteCommand cmd = new SQLiteCommand("update REG set PASS='" + textBox3.Text + "' where U_ID = '" + textBox1.Text + "' and EMAIL = '" + textBox2.Text + "'", m_dbConnection);
                cmd.ExecuteNonQuery();


                m_dbConnection.Close();

                MessageBox.Show("your password has been changed sucessfully");
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error In Connection.." + ee);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RECOVER();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SAVE();
        }
    }
}
