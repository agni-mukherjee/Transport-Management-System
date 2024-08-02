using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Text;
using System.IO;

namespace TRANSPORT_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string a = "";
        public string b = "";
        private void addVHEToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            Form2 cf = new Form2();
            cf.MdiParent = this;
            cf.Show();
        }

        void ADD_LOGIN_DETAILS()
        {
            try
            {
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                SQLiteCommand cmd = new SQLiteCommand("insert into LOGIN_DETAILS(U_ID,DATE_TIME) values('"+label1.Text+"','"+label4.Text+"')",m_dbConnection);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ee)
            {
                MessageBox.Show("Error" + ee);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            toolStripStatusLabel1.Text = System.DateTime.Now.ToShortDateString();
            toolStripStatusLabel2.Text = " ";
            StreamReader USER = new StreamReader(@"D:\Project\TRANSPORT_1\TRANSPORT_1\bin\x86\Debug\USER");
            a = USER.ReadLine();
            label1.Text = a;
            USER.Close();
            StreamReader DATE_TIME = new StreamReader(@"D:\Project\TRANSPORT_1\TRANSPORT_1\bin\x86\Debug\DATE_TIME");
            b = DATE_TIME.ReadLine();
            label4.Text = b;
            DATE_TIME.Close();
            ADD_LOGIN_DETAILS();

        }

        private void addDriverToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form3 cf1 = new Form3();
            cf1.MdiParent = this;
            cf1.Show();
            
        }

        private void reportReviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VHE_REVIEW cf1 = new VHE_REVIEW();
            cf1.MdiParent = this;
            cf1.Show();
            cf1.Focus();
        }

        private void addClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ADD_CLIENT cf2 = new ADD_CLIENT();
            cf2.MdiParent = this;
            cf2.Show();
            cf2.Focus();
        }

        private void fullBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BOOKING cf3 = new BOOKING();
            cf3.MdiParent = this;
            cf3.Show();
            cf3.Focus();
        }

        private void reviewReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CLI_REVIEW cf4 = new CLI_REVIEW();
            cf4.MdiParent = this;
            cf4.Show();
            cf4.Focus();
        }

        private void addDriverToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reviewReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DRIVER_REVIEW cf5 = new DRIVER_REVIEW();
            cf5.MdiParent = this;
            cf5.Show();
            cf5.Focus();
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            REG cf6 = new REG();
            cf6.MdiParent = this;
            cf6.Show();
            cf6.Focus();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOGIN cf7 = new LOGIN();
            Form1 cf8 = new Form1();
            this.Close();
            cf7.Show();
            
        }

        private void reportReviewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BOOKING_REPORT cf2 = new BOOKING_REPORT();
            cf2.MdiParent = this;
            cf2.Show();
            cf2.Focus();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void billingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BILLING cf2 = new BILLING();
            cf2.MdiParent = this;
            cf2.Show();
            cf2.Focus();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
