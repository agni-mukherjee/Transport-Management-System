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
using System.IO;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Management;
using System.Text.RegularExpressions;
using System.Net;
using System.Collections.Specialized;
using System.Net.Mail;
using System.Threading;
using System.Net.Sockets;

namespace TRANSPORT_1
{
    public partial class BOOKING : Form
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        AutoCompleteStringCollection namesCollection2 = new AutoCompleteStringCollection();
        AutoCompleteStringCollection namesCollection3 = new AutoCompleteStringCollection();


        public BOOKING()
        {
            InitializeComponent();

            textBox7.KeyPress += new KeyPressEventHandler(textBox7_KeyPress);
        }
        SQLiteConnection m_dbConnection;
        private void BOOKING_Load(object sender, EventArgs e)
        {
            
            
            GET_DATA2();
            
            if(IsMdiChild==true)
            {
                linkLabel1.Enabled = false;
                linkLabel2.Enabled = false;
            }
            
            
            
            
            
            
            groupBox1.Enabled = false;
            auto_s();
            auto_dname();
            auto_cname();
        }
        public void auto_s()
        {
            try
            {
                SQLiteDataReader dReader;
                m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                SQLiteCommand cmd33 = new SQLiteCommand("Select distinct [VH_NO] from [ADD_VEH] order by [VH_NO] asc", m_dbConnection);

                dReader = cmd33.ExecuteReader();
                if (dReader.HasRows == true)
                {
                    while (dReader.Read())
                        namesCollection.Add(dReader["VH_NO"].ToString());

                }
                else
                {

                }
                dReader.Close();
                m_dbConnection.Close();
                textBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
                textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBox2.AutoCompleteCustomSource = namesCollection;

                textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
                textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBox1.AutoCompleteCustomSource = namesCollection;

            }
            catch (Exception e56)
            {
                MessageBox.Show("Error" + e56);
            }
        }

        public void auto_dname()
        {
            try
            {
                SQLiteDataReader dReader;
                m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                SQLiteCommand cmd33 = new SQLiteCommand("Select distinct [NAME] from [ADD_DRV] order by [NAME] asc", m_dbConnection);

                dReader = cmd33.ExecuteReader();
                if (dReader.HasRows == true)
                {
                    while (dReader.Read())
                        namesCollection2.Add(dReader["NAME"].ToString());

                }
                else
                {

                }
                dReader.Close();
                m_dbConnection.Close();
                textBox3.AutoCompleteMode = AutoCompleteMode.Suggest;
                textBox3.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBox3.AutoCompleteCustomSource = namesCollection2;

               
            }   
            catch (Exception e56)
            {
                MessageBox.Show("Error" + e56);
            }
        }

        public void auto_cname()
        {
            try
            {
                SQLiteDataReader dReader;
                m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                SQLiteCommand cmd33 = new SQLiteCommand("Select distinct [C_NAME] from [ADD_CLI] order by [C_NAME] asc", m_dbConnection);

                dReader = cmd33.ExecuteReader();
                if (dReader.HasRows == true)
                {
                    while (dReader.Read())
                        namesCollection3.Add(dReader["C_NAME"].ToString());

                }
                else
                {

                }
                dReader.Close();
                m_dbConnection.Close();
                textBox4.AutoCompleteMode = AutoCompleteMode.Suggest;
                textBox4.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBox4.AutoCompleteCustomSource = namesCollection3;


            }

            catch (Exception e56)
            {
                MessageBox.Show("Error" + e56);
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b' || e.KeyChar == '.') //The  character represents a backspace
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }
        }


        public void count_B_ID()
        {
            try
            {
                m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();

                SQLiteCommand cmd = new SQLiteCommand("insert into B_ID(B_DATE) values('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "')", m_dbConnection);
                cmd.ExecuteNonQuery();

                SQLiteCommand cmd23 = new SQLiteCommand("select SL from B_ID order by SL desc limit 1", m_dbConnection);
                SQLiteDataAdapter daa = new SQLiteDataAdapter(cmd23);
                DataSet dss = new DataSet();
                daa.Fill(dss, "B_ID");
                if (dss.Tables["B_ID"].Rows.Count >= 1)
                {
                    label21.Text = dss.Tables["B_ID"].Rows[0]["SL"].ToString();
                    m_dbConnection.Close();
                    _B_ID.Text = "TMS/" + label21.Text;
                    m_dbConnection.Open();

                    SQLiteCommand cmd3 = new SQLiteCommand("update B_ID set B_ID='" + _B_ID.Text + "' where SL='" + label21.Text + "'", m_dbConnection);
                    cmd3.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("ERROR");
                }
                m_dbConnection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error In Connection.." + e);
            }
        }

        void FETCH_B_ID()
        {
            try
              {
            //    m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
            //    m_dbConnection.Open();

            //    SQLiteCommand cmd2 = new SQLiteCommand("select DESTINATION from B_ID2 where VEH_NO='" + textBox11.Text + "'", m_dbConnection);
            //    SQLiteDataAdapter da2 = new SQLiteDataAdapter(cmd2);
            //    DataSet ds3 = new DataSet();
            //    da2.Fill(ds3, "B_ID2");
            //    int d = ds3.Tables["B_ID2"].Rows.Count;

            //    if (d > 0)
            //    {
            //        textBox5.Text = ds3.Tables["B_ID2"].Rows[0]["DESTINATION"].ToString();
            //    }

                SQLiteCommand cmd = new SQLiteCommand("select B_ID from B_ID2 where V_NO='" + textBox1.Text + "' and S2='G'", m_dbConnection);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "B_ID2");

                int c = ds.Tables["B_ID2"].Rows.Count;

                if (c > 0)
                {
                    _B_ID.Text = ds.Tables["B_ID2"].Rows[0]["B_ID"].ToString();
                }
                else
                {

                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
            }
        }

        void B_INSERT()
        {
            try
            {
                m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                SQLiteCommand cmdd = new SQLiteCommand("select B_ID from B_ID where B_ID='" + _B_ID.Text + "'", m_dbConnection);
                SQLiteDataAdapter daa = new SQLiteDataAdapter(cmdd);
                DataSet dss = new DataSet();
                daa.Fill(dss, "B_ID");
                if (dss.Tables["B_ID"].Rows.Count >= 1)
                {
                    MessageBox.Show("Duplicate");
                    m_dbConnection.Close();
                    count_B_ID();
                }
                else
                {
                    SQLiteCommand cmd2 = new SQLiteCommand("insert into B_ID(B_ID,B_DATE) values('" + _B_ID.Text +  "','"   + dateTimePicker1.Value.ToString("yyyy-MM-dd") +  "')", m_dbConnection);
                    cmd2.ExecuteNonQuery();

                    m_dbConnection.Close();
                    groupBox1.Enabled = true;
                    textBox2.Focus();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        void 
            add()
        {
            try
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Please enter correct Vehicle Number");
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("Please enter correct Driver Name");
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("Please enter correct Client Name");
                }
                else if (textBox5.Text == "")
                {
                    MessageBox.Show("Please enter correct Consigning");
                }
                else if (textBox6.Text == "")
                {
                    MessageBox.Show("Please enter correct Item Description");
                }
                else if (textBox7.Text == "")
                {
                    MessageBox.Show("Please enter Quantity");
                }
                else if(textBox11.Text=="")
                {
                    MessageBox.Show("Please enter Pack Type");
                }
                else if (textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "" && textBox6.Text == "" && textBox7.Text == ""&&textBox11.Text=="")
                {
                    MessageBox.Show("Please fill all the details");
                }
                else
                {
                    m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                    m_dbConnection.Open();
                    SQLiteCommand cmd = new SQLiteCommand("insert into B_ID2 (B_ID,B_DATE,V_NO,D_NAME,C_NAME,CON,I_DES,QTY,P_TYPE" +
                            ") values('" + _B_ID.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox11.Text + "')", m_dbConnection);
                    SQLiteCommand cmd3 = new SQLiteCommand("select S2 from B_ID2 where B_ID = '"+_B_ID.Text+"' and S2 = 'F",m_dbConnection);
                    cmd.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();

                    SQLiteDataAdapter ds3 = new SQLiteDataAdapter(cmd3);
                    DataSet dss3 = new DataSet();
                    ds3.Fill(dss3, "S2");
                    if (dss3.Tables["S2"].Rows.Count >=1 )
                    {
                        DialogResult res = MessageBox.Show("Are you sure to modify"+Environment.NewLine+"V No- "+textBox2.Text+" B Id- "+_B_ID.Text, "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);


                         if(res==DialogResult.Yes)
                        {
                            m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                            m_dbConnection.Open();
                            SQLiteCommand cmd4 = new SQLiteCommand("insert into B_ID2 (B_ID,B_DATE,V_NO,D_NAME,C_NAME,CON,I_DES,QTY,P_TYPE" +
                                    ") values('" + _B_ID.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox11.Text + "')", m_dbConnection);
                            cmd4.ExecuteNonQuery();
                        }
                         else if(res==DialogResult.No)
                        {

                        }
                         else if(res==DialogResult.Cancel)
                        {

                        }
                       
                    }



                    //SQLiteCommand cmd2 = new SQLiteCommand("insert into B_ID2 set DS='" + label16.Text + "' where B_ID='" + _B_ID.Text + "'", m_dbConnection);

                    MessageBox.Show("New Booking Details has been added Successfully !!! ");
                    m_dbConnection.Close();

                }
            }
            catch
            {
                
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                count_B_ID();
                textBox2.Text = textBox1.Text.ToString();
                groupBox1.Enabled = true;
            }
            catch 
            {

                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add();
            





            get_data();
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox11.Text = "";
          
            
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                SQLiteCommand cmd11 = new SQLiteCommand("select V_NO from B_ID2 where V_NO='" + textBox1.Text + "' and S2='F'", m_dbConnection);
                SQLiteCommand cmd12 = new SQLiteCommand("select V_NO from B_ID2 where V_NO ='" + textBox1.Text + "' and S2 =' '", m_dbConnection);
                SQLiteCommand cmd13 = new SQLiteCommand("select V_NO from B_ID2 where V_NO='" + textBox1.Text + "' and S2='G'", m_dbConnection);
                SQLiteDataAdapter ds11 = new SQLiteDataAdapter(cmd11);
                SQLiteDataAdapter ds12 = new SQLiteDataAdapter(cmd12);
                SQLiteDataAdapter ds13 = new SQLiteDataAdapter(cmd13);
                DataSet dss = new DataSet();
                DataSet dss2 = new DataSet();
                DataSet dss3 = new DataSet();
                ds11.Fill(dss, "S2");
                ds12.Fill(dss2, "S2");
                ds13.Fill(dss3, "S2");
                if (dss.Tables["S2"].Rows.Count >= 1)
                {
                    MessageBox.Show("Vehicle has already booked");
                    linkLabel1.Enabled = true;


                }
                else if (dss2.Tables["S2"].Rows.Count>=1)
                {
                    MessageBox.Show("Vehicle is Empty and available for booking");
                    linkLabel1.Enabled = true;
                    linkLabel2.Enabled = false;
                }
                else if (dss3.Tables["S2"].Rows.Count>=1)
                {
                    MessageBox.Show("Vehicle is half booked and available for booking");
                    
                    linkLabel2.Enabled = true;
                }
                else if (textBox1.Text=="")
                {
                    MessageBox.Show("Please enter a Vehicle number");
                }
                //else
                //{
                //    MessageBox.Show("Vehicle is Empty and Avilable for booking");
                //    linkLabel1.Enabled = true;
                //}
                
            }
            catch 
            {

                
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
                    label17.Text = dr.Cells["SL"].Value.ToString();
                    _B_ID.Text = dr.Cells["B_ID"].Value.ToString();
                    dateTimePicker1.Text = dr.Cells["B_DATE"].Value.ToString();
                    textBox2.Text = dr.Cells["V_NO"].Value.ToString();
                    textBox3.Text = dr.Cells["D_NAME"].Value.ToString();
                    textBox4.Text = dr.Cells["C_NAME"].Value.ToString();
                    textBox5.Text = dr.Cells["CON"].Value.ToString();
                    textBox6.Text = dr.Cells["I_DES"].Value.ToString();
                    textBox7.Text = dr.Cells["QTY"].Value.ToString();
                    textBox11.Text = dr.Cells["P_TYPE"].Value.ToString();
                    textBox8.Text = dr.Cells["KM"].Value.ToString();
                    textBox9.Text = dr.Cells["REF_NO"].Value.ToString();
                    textBox10.Text = dr.Cells["REMARKS"].Value.ToString();


                    panel1.Enabled = true;

                }
            }
            catch (Exception EE)
            {
                MessageBox.Show("" + EE);
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
                    label17.Text = dr.Cells["SL"].Value.ToString();
                    _B_ID.Text = dr.Cells["B_ID"].Value.ToString();
                    dateTimePicker1.Text = dr.Cells["B_DATE"].Value.ToString();
                    textBox2.Text = dr.Cells["V_NO"].Value.ToString();
                    textBox3.Text = dr.Cells["D_NAME"].Value.ToString();
                    textBox4.Text = dr.Cells["C_NAME"].Value.ToString();
                    textBox5.Text = dr.Cells["CON"].Value.ToString();
                    textBox6.Text = dr.Cells["I_DES"].Value.ToString();
                    textBox7.Text = dr.Cells["QTY"].Value.ToString();
                    textBox11.Text = dr.Cells["P_TYPE"].Value.ToString();
                    textBox8.Text = dr.Cells["KM"].Value.ToString();
                    textBox9.Text = dr.Cells["REF_NO"].Value.ToString();
                    textBox10.Text = dr.Cells["REMARKS"].Value.ToString();


                    panel1.Enabled = true;

                }
            }
            catch (Exception EE)
            {
                MessageBox.Show("" + EE);
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
                SQLiteDataAdapter cmd = new SQLiteDataAdapter("select * from B_ID2 where B_ID = '"+_B_ID.Text+"'", m_dbConnection);

                

                cmd.Fill(da3);


                dataGridView1.DataSource = da3;


                this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.GreenYellow;
                this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[15].Visible = false;
                m_dbConnection.Close();






            }
            catch (Exception ee)
            {

                MessageBox.Show("Error In Connection.." + ee);
            }
        }

        void GET_DATA2()
        {

            

            try
            {

                
                dataGridView2.DataSource = null;
                m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                DataTable da3 = new DataTable();
                SQLiteDataAdapter cmd = new SQLiteDataAdapter("select * from B_ID2 where S2='F'", m_dbConnection);

                cmd.Fill(da3);


                dataGridView2.DataSource = da3;


                this.dataGridView2.RowsDefaultCellStyle.BackColor = Color.GreenYellow;
                this.dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.White;


                dataGridView2.Columns[4].Visible = false;
                dataGridView2.Columns[5].Visible = false;
                dataGridView2.Columns[6].Visible = false;
                dataGridView2.Columns[7].Visible = false;
                dataGridView2.Columns[8].Visible = false;
                dataGridView2.Columns[9].Visible = false;
                dataGridView2.Columns[10].Visible = false;
                dataGridView2.Columns[11].Visible = false;
                dataGridView2.Columns[12].Visible = false;
                dataGridView2.Columns[13].Visible = false;
                dataGridView2.Columns[14].Visible = false;
                dataGridView2.Columns[15].Visible = false;
                m_dbConnection.Close();






            }
            catch (Exception ee)
            {

                MessageBox.Show("Error In Connection.." + ee);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Are you sure to modify", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (res == DialogResult.Yes)

                {
                    m_dbConnection = new SQLiteConnection("Data Source =" + _DATA.Text + ".s3db;Version=3;");

                    m_dbConnection.Open();

                    SQLiteCommand cmd2 = new SQLiteCommand("delete from B_ID2 where SL='" + label17.Text + "'", m_dbConnection);
                    cmd2.ExecuteNonQuery();

                    MessageBox.Show("Data has been deleted successfully !!!");
                    m_dbConnection.Close();
                    get_data();
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox11.Text = "";
                    _B_ID.Text = "";
                    textBox2.Focus();

                    GET_DATA2();
                }
                else if(res == DialogResult.No)
                {

                }
                else if(res == DialogResult.Cancel)
                {

                }
            }
            catch (Exception ee)
            {

                MessageBox.Show("Error In Connection.." + ee);
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {


                try
                {
                    m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                    m_dbConnection.Open();
                    SQLiteCommand cmd11 = new SQLiteCommand("select S2 from B_ID2 where V_NO='" + textBox2.Text + "' and S2='F'", m_dbConnection);
                    SQLiteCommand cmd12 = new SQLiteCommand("select VH_NO from ADD_VEH where VH_NO ='"+textBox2.Text+"'",m_dbConnection);
                    SQLiteDataAdapter ds12 = new SQLiteDataAdapter(cmd12);
                    SQLiteDataAdapter ds11 = new SQLiteDataAdapter(cmd11);
                    DataSet dss2 = new DataSet();
                    DataSet dss = new DataSet();
                    ds12.Fill(dss2, "ADD_VEH");
                    ds11.Fill(dss, "B_ID2");
                    if (dss.Tables["B_ID2"].Rows.Count > 0)
                    {
                        MessageBox.Show("Vehicle has already booked");
                        textBox2.Text = "";
                        textBox2.Focus();

                    }
                    else if(dss2.Tables["ADD_VEH"].Rows.Count <= 0)
                    {
                        MessageBox.Show("Vehicle not exists in your Database !!!");
                    }
                    else
                    {

                        textBox3.Focus();
                        m_dbConnection.Close();


                    }
                }
                catch
                {


                }
                

                e.Handled = true; 

            }
            else if (e.KeyCode == Keys.Down)
            {
                try
                {
                    m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                    m_dbConnection.Open();
                    SQLiteCommand cmd11 = new SQLiteCommand("select S2 from B_ID2 where V_NO='" + textBox2.Text + "' and S2='F'", m_dbConnection);
                    SQLiteCommand cmd12 = new SQLiteCommand("select VH_NO from ADD_VEH where VH_NO ='" + textBox2.Text + "'", m_dbConnection);
                    SQLiteDataAdapter ds12 = new SQLiteDataAdapter(cmd12);
                    SQLiteDataAdapter ds11 = new SQLiteDataAdapter(cmd11);
                    DataSet dss2 = new DataSet();
                    DataSet dss = new DataSet();
                    ds12.Fill(dss2, "ADD_VEH");
                    ds11.Fill(dss, "B_ID2");
                    if (dss.Tables["B_ID2"].Rows.Count > 0)
                    {
                        MessageBox.Show("Vehicle has already booked");
                        textBox2.Text = "";
                        textBox2.Focus();

                    }
                    else if (dss2.Tables["ADD_VEH"].Rows.Count <= 0)
                    {
                        MessageBox.Show("Vehicle not exists in your Database !!!");
                    }
                    else
                    {

                        textBox3.Focus();
                        m_dbConnection.Close();


                    }
                }
                catch
                {


                }


                e.Handled = true;
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                SQLiteCommand cmd11 = new SQLiteCommand("select NAME from ADD_DRV where NAME='" + textBox3.Text + "' ", m_dbConnection);
                SQLiteDataAdapter ds11 = new SQLiteDataAdapter(cmd11);
                DataSet dss = new DataSet();
                ds11.Fill(dss, "ADD_DRV");
                if (dss.Tables["ADD_DRV"].Rows.Count > 0)
                {
                    //MessageBox.Show("Vehicle has already booked");
                    //textBox2.Text = "";
                    //textBox2.Focus();

                    textBox4.Focus();
                    //textBox2.BackColor = Color.SkyBlue;
                    //textBox1.BackColor = Color.White;
                    e.Handled = true;

                }
                else
                {
                    MessageBox.Show("Driver not Exists !!!");
                }

                //textBox4.Focus();
                ////textBox2.BackColor = Color.SkyBlue;
                ////textBox1.BackColor = Color.White;
                //e.Handled = true;
            }
            else if(e.KeyCode == Keys.Down)
            {
                m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                SQLiteCommand cmd11 = new SQLiteCommand("select NAME from ADD_DRV where NAME='" + textBox3.Text + "' ", m_dbConnection);
                SQLiteDataAdapter ds11 = new SQLiteDataAdapter(cmd11);
                DataSet dss = new DataSet();
                ds11.Fill(dss, "ADD_DRV");
                if (dss.Tables["ADD_DRV"].Rows.Count > 0)
                {
                    //MessageBox.Show("Vehicle has already booked");
                    //textBox2.Text = "";
                    //textBox2.Focus();

                    textBox4.Focus();
                    //textBox2.BackColor = Color.SkyBlue;
                    //textBox1.BackColor = Color.White;
                    e.Handled = true;

                }
                else
                {
                    MessageBox.Show("Driver not Exists !!!");
                }

                //textBox4.Focus();
                ////textBox2.BackColor = Color.SkyBlue;
                ////textBox1.BackColor = Color.White;
                //e.Handled = true;
            }
            else if(e.KeyCode == Keys.Up)
            {
                textBox2.Focus();
                e.Handled = true;
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                SQLiteCommand cmd11 = new SQLiteCommand("select C_NAME from ADD_CLI where C_NAME='" + textBox4.Text + "' ", m_dbConnection);
                SQLiteDataAdapter ds11 = new SQLiteDataAdapter(cmd11);
                DataSet dss = new DataSet();
                ds11.Fill(dss, "ADD_CLI");
                if (dss.Tables["ADD_CLI"].Rows.Count > 0)
                {
                    

                    textBox5.Focus();
                    //textBox2.BackColor = Color.SkyBlue;
                    //textBox1.BackColor = Color.White;
                    e.Handled = true;

                }
                else
                {
                    MessageBox.Show("Client not Exists !!!");
                }

                //textBox5.Focus();
                ////textBox2.BackColor = Color.SkyBlue;
                ////textBox1.BackColor = Color.White;
                //e.Handled = true;
            }
            else if(e.KeyCode == Keys.Down)
            {
                m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                SQLiteCommand cmd11 = new SQLiteCommand("select C_NAME from ADD_CLI where C_NAME='" + textBox4.Text + "' ", m_dbConnection);
                SQLiteDataAdapter ds11 = new SQLiteDataAdapter(cmd11);
                DataSet dss = new DataSet();
                ds11.Fill(dss, "ADD_CLI");
                if (dss.Tables["ADD_CLI"].Rows.Count > 0)
                {


                    textBox5.Focus();
                    //textBox2.BackColor = Color.SkyBlue;
                    //textBox1.BackColor = Color.White;
                    e.Handled = true;

                }
                else
                {
                    MessageBox.Show("Client not Exists !!!");
                }

                //textBox5.Focus();
                ////textBox2.BackColor = Color.SkyBlue;
                ////textBox1.BackColor = Color.White;
                //e.Handled = true;
            }
            else if(e.KeyCode == Keys.Up)
            {
                textBox3.Focus();
                e.Handled = true;
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                textBox6.Focus();
                e.Handled = true;
            }
            else if(e.KeyCode == Keys.Down)
            {
                textBox6.Focus();
                e.Handled = true;
            }
            else if(e.KeyCode == Keys.Up)
            {
                textBox4.Focus();
                e.Handled = true;
            }

                    
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox7.Focus();
                e.Handled = true;
            }
            else if(e.KeyCode == Keys.Down)
            {
                textBox7.Focus();
                e.Handled = true;
            }
            else if(e.KeyCode == Keys.Up)
            {
                textBox5.Focus();
                e.Handled = true;
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox11.Focus();
                e.Handled = true;
            }
            else if(e.KeyCode == Keys.Down)
            {
                textBox11.Focus();
                e.Handled = true;
            }
            else if(e.KeyCode == Keys.Up)
            {
                textBox6.Focus();
                e.Handled = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox2.Text == "" && textBox3.Text == "" && textBox8.Text == "" && textBox9.Text == "" && textBox10.Text == "")
                {
                    MessageBox.Show("Please fill all the details");
                }
                //else if(textBox3.Text=="")
                //{
                //    MessageBox.Show("Please enter Driver Name");
                //}
              
                //else if(textBox8.Text=="")
                //{
                //    MessageBox.Show("Please enter KM out");
                //}
                //else if(textBox9.Text=="")
                //{
                //    MessageBox.Show("Please enter Reference");
                //}
                //else if(textBox10.Text=="")
                //{
                //    MessageBox.Show("Please  enter Remarka");
                //}
               
                //else if(textBox2.Text=="" && textBox3.Text=="" && textBox8.Text=="" && textBox9.Text=="" && textBox10.Text=="" )
                //{
                //    MessageBox.Show("Please fill all the details");
                //}
                else
                {
                    m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                    m_dbConnection.Open();
                    SQLiteCommand cmd = new SQLiteCommand("update B_ID2 set S2='" + label19.Text + "' where B_ID='" + _B_ID.Text + "'", m_dbConnection);
                    SQLiteCommand cmd2 = new SQLiteCommand("update B_ID2 set KM='"+textBox8.Text+"',REF_NO='"+textBox9.Text+"',REMARKS='"+textBox10.Text+"' where B_ID ='"+_B_ID.Text+"'",m_dbConnection);
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();


                    m_dbConnection.Close();

                    MessageBox.Show("Full booked");

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";
                    textBox11.Text = "";
                    _B_ID.Text = "";

                    get_data();
                    GET_DATA2();
                }
            }
            catch (Exception ee)
            {

                MessageBox.Show("Error In Connection..." + ee);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            groupBox1.Enabled = true;
            
            FETCH_B_ID();

            try
            {
                m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                DataTable da3 = new DataTable();
                SQLiteCommand cmd = new SQLiteCommand("select (B_ID,V_NO,D_NAME) from B_ID2 where V_NO='" + textBox1.Text + "'", m_dbConnection);
                


                textBox2.Text = textBox1.Text.ToString();
                



                //label17.Text = 
                //_B_ID.Text = dr.Cells["B_ID"].Value.ToString();
                //textBox2.Text = dr.Cells["V_NO"].Value.ToString();
                //textBox3.Text = dr.Cells["D_NAME"].Value.ToString();
                //textBox4.Text = dr.Cells["C_NAME"].Value.ToString();
                //textBox5.Text = dr.Cells["CON"].Value.ToString();
                //textBox6.Text = dr.Cells["I_DES"].Value.ToString();
                //textBox7.Text = dr.Cells["QTY"].Value.ToString();
                //textBox11.Text = dr.Cells["P_TYPE"].Value.ToString();
                //dateTimePicker1.Text = dr.Cells["B_DATE"].Value.ToString();

            }
            catch
            {


            }

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GET_DATA2();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
            m_dbConnection.Open();
            SQLiteCommand cmd = new SQLiteCommand("update B_ID2 set S2='" + label18.Text + "' where B_ID='" + _B_ID.Text + "'", m_dbConnection);
            SQLiteCommand cmd2 = new SQLiteCommand("insert into B_ID2 (DS)='"+label16.Text+"' where B_ID='" + _B_ID.Text + "'", m_dbConnection);
            cmd.ExecuteNonQuery();


            m_dbConnection.Close();

            MessageBox.Show("Booking Deatils has been Saved for Later ");

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox11.Text = "";





            GET_DATA2();
            get_data();


        }

        private void linkLabel4_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GET_DATA2();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Are you sure to modify" , "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);


                if (res == DialogResult.Yes)
                {
                    m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                    m_dbConnection.Open();

                    if (e.RowIndex >= 0)
                    {
                        DataGridViewRow dr = this.dataGridView2.Rows[e.RowIndex];
                        label17.Text = dr.Cells["SL"].Value.ToString();
                        _B_ID.Text = dr.Cells["B_ID"].Value.ToString();
                        dateTimePicker1.Text = dr.Cells["B_DATE"].Value.ToString();
                        textBox2.Text = dr.Cells["V_NO"].Value.ToString();
                        textBox3.Text = dr.Cells["D_NAME"].Value.ToString();
                        textBox4.Text = dr.Cells["C_NAME"].Value.ToString();
                        textBox5.Text = dr.Cells["CON"].Value.ToString();
                        textBox6.Text = dr.Cells["I_DES"].Value.ToString();
                        textBox7.Text = dr.Cells["QTY"].Value.ToString();
                        textBox11.Text = dr.Cells["P_TYPE"].Value.ToString();
                        textBox8.Text = dr.Cells["KM"].Value.ToString();
                        textBox9.Text = dr.Cells["REF_NO"].Value.ToString();
                        textBox10.Text = dr.Cells["REMARKS"].Value.ToString();
                        m_dbConnection.Close();


                        panel1.Enabled = true;
                        groupBox1.Enabled = true;

                    }
                }
                else if (res == DialogResult.No)
                {

                }
                else if (res == DialogResult.Cancel)
                {

                }
            }
            catch (Exception EE)
            {
                MessageBox.Show("" + EE);
            }
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Are you sure to modify" , "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);


                if (res == DialogResult.Yes)
                {
                    m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                    m_dbConnection.Open();

                    if (e.RowIndex >= 0)
                    {
                        DataGridViewRow dr = this.dataGridView2.Rows[e.RowIndex];
                        label17.Text = dr.Cells["SL"].Value.ToString();
                        _B_ID.Text = dr.Cells["B_ID"].Value.ToString();
                        dateTimePicker1.Text = dr.Cells["B_DATE"].Value.ToString();
                        textBox2.Text = dr.Cells["V_NO"].Value.ToString();
                        textBox3.Text = dr.Cells["D_NAME"].Value.ToString();
                        textBox4.Text = dr.Cells["C_NAME"].Value.ToString();
                        textBox5.Text = dr.Cells["CON"].Value.ToString();
                        textBox6.Text = dr.Cells["I_DES"].Value.ToString();
                        textBox7.Text = dr.Cells["QTY"].Value.ToString();
                        textBox11.Text = dr.Cells["P_TYPE"].Value.ToString();
                        textBox8.Text = dr.Cells["KM"].Value.ToString();
                        textBox9.Text = dr.Cells["REF_NO"].Value.ToString();
                        textBox10.Text = dr.Cells["REMARKS"].Value.ToString();
                        m_dbConnection.Close();


                        panel1.Enabled = true;
                        groupBox1.Enabled = true;

                    }
                }
                else if (res == DialogResult.No)
                {

                }
                else if (res == DialogResult.Cancel)
                {

                }
            }
            catch (Exception EE)
            {
                MessageBox.Show("" + EE);
            }
        }

        void fetch2()
        {

        }

        





        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Are you sure to modify" , "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);


                if (res == DialogResult.Yes)
                {
                    m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                    m_dbConnection.Open();

                    if (e.RowIndex >= 0)
                    {
                        DataGridViewRow dr = this.dataGridView2.Rows[e.RowIndex];
                        label17.Text = dr.Cells["SL"].Value.ToString();
                        _B_ID.Text = dr.Cells["B_ID"].Value.ToString();
                        dateTimePicker1.Text = dr.Cells["B_DATE"].Value.ToString();
                        textBox2.Text = dr.Cells["V_NO"].Value.ToString();
                        textBox3.Text = dr.Cells["D_NAME"].Value.ToString();
                        textBox4.Text = dr.Cells["C_NAME"].Value.ToString();
                        textBox5.Text = dr.Cells["CON"].Value.ToString();
                        textBox6.Text = dr.Cells["I_DES"].Value.ToString();
                        textBox7.Text = dr.Cells["QTY"].Value.ToString();
                        textBox11.Text = dr.Cells["P_TYPE"].Value.ToString();
                        textBox8.Text = dr.Cells["KM"].Value.ToString();
                        textBox9.Text = dr.Cells["REF_NO"].Value.ToString();
                        textBox10.Text = dr.Cells["REMARKS"].Value.ToString();
                        m_dbConnection.Close();


                        panel1.Enabled = true;
                        groupBox1.Enabled = true;

                    }
                }
                else if (res == DialogResult.No)
                {

                }
                else if (res == DialogResult.Cancel)
                {

                }














                //m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                //m_dbConnection.Open();

                //if (e.RowIndex >= 0)
                //{
                //    DataGridViewRow dr = this.dataGridView2.Rows[e.RowIndex];
                //    label17.Text = dr.Cells["SL"].Value.ToString();
                //    _B_ID.Text = dr.Cells["B_ID"].Value.ToString();
                //    dateTimePicker1.Text = dr.Cells["B_DATE"].Value.ToString();
                //    textBox2.Text = dr.Cells["V_NO"].Value.ToString();
                //    textBox3.Text = dr.Cells["D_NAME"].Value.ToString();
                //    textBox4.Text = dr.Cells["C_NAME"].Value.ToString();
                //    textBox5.Text = dr.Cells["CON"].Value.ToString();
                //    textBox6.Text = dr.Cells["I_DES"].Value.ToString();
                //    textBox7.Text = dr.Cells["QTY"].Value.ToString();
                //    textBox11.Text = dr.Cells["P_TYPE"].Value.ToString();
                //    textBox8.Text = dr.Cells["KM"].Value.ToString();
                //    textBox9.Text = dr.Cells["REF_NO"].Value.ToString();
                //    textBox10.Text = dr.Cells["REMARKS"].Value.ToString();
                //    m_dbConnection.Close();
                    

                //    panel1.Enabled = true;
                //    groupBox1.Enabled = true;

                //}
            }
            catch (Exception EE)
            {
                MessageBox.Show("" + EE);
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow dr = this.dataGridView1.Rows[e.RowIndex];
                    label17.Text = dr.Cells["SL"].Value.ToString();
                    _B_ID.Text = dr.Cells["B_ID"].Value.ToString();
                    dateTimePicker1.Text = dr.Cells["B_DATE"].Value.ToString();
                    textBox2.Text = dr.Cells["V_NO"].Value.ToString();
                    textBox3.Text = dr.Cells["D_NAME"].Value.ToString();
                    textBox4.Text = dr.Cells["C_NAME"].Value.ToString();
                    textBox5.Text = dr.Cells["CON"].Value.ToString();
                    textBox6.Text = dr.Cells["I_DES"].Value.ToString();
                    textBox7.Text = dr.Cells["QTY"].Value.ToString();
                    textBox11.Text = dr.Cells["P_TYPE"].Value.ToString();
                    textBox8.Text = dr.Cells["KM"].Value.ToString();
                    textBox9.Text = dr.Cells["REF_NO"].Value.ToString();
                    textBox10.Text = dr.Cells["REMARKS"].Value.ToString();


                    panel1.Enabled = true;

                }
            }
            catch (Exception EE)
            {
                MessageBox.Show("" + EE);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                try
                {
                    m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                    m_dbConnection.Open();
                    SQLiteCommand cmd11 = new SQLiteCommand("select V_NO from B_ID2 where V_NO='" + textBox1.Text + "' and S2='F'", m_dbConnection);
                    SQLiteCommand cmd12 = new SQLiteCommand("select V_NO from B_ID2 where V_NO ='" + textBox1.Text + "' and S2 =' '", m_dbConnection);
                    SQLiteCommand cmd13 = new SQLiteCommand("select V_NO from B_ID2 where V_NO='" + textBox1.Text + "' and S2='G'", m_dbConnection);
                    SQLiteDataAdapter ds11 = new SQLiteDataAdapter(cmd11);
                    SQLiteDataAdapter ds12 = new SQLiteDataAdapter(cmd12);
                    SQLiteDataAdapter ds13 = new SQLiteDataAdapter(cmd13);
                    DataSet dss = new DataSet();
                    DataSet dss2 = new DataSet();
                    DataSet dss3 = new DataSet();
                    ds11.Fill(dss, "S2");
                    ds12.Fill(dss2, "S2");
                    ds13.Fill(dss3, "S2");
                    if (dss.Tables["S2"].Rows.Count >= 1)
                    {
                        MessageBox.Show("Vehicle has already booked");
                        linkLabel1.Enabled = true;


                    }
                    else if (dss2.Tables["S2"].Rows.Count >= 1)
                    {
                        MessageBox.Show("Vehicle is Empty and available for booking");
                        linkLabel1.Enabled = true;
                        linkLabel2.Enabled = true;
                    }
                    else if (dss3.Tables["S2"].Rows.Count >= 1)
                    {
                        MessageBox.Show("Vehicle is half booked and available for booking");
                        
                        linkLabel2.Enabled = true;
                    }
                    else if (textBox1.Text == "")
                    {
                        MessageBox.Show("Please enter a Vehicle number");
                    }
                    else
                    {
                        MessageBox.Show("Vehicle is Empty and Avilable for booking");
                        linkLabel1.Enabled = true;
                    }

                }
                catch(Exception EE)
                {
                    MessageBox.Show("" + EE);

                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                SQLiteCommand cmd = new SQLiteCommand("update B_ID2 setB_ID='"+_B_ID.Text+"',B_DATE='"+dateTimePicker1.Value.ToString("yyyy-MM-dd")+"',V_NO='"+textBox2.Text+"',D_NAME='"+textBox3.Text+"',C_NAME='"+textBox4.Text+"',CON='"+textBox5.Text+"',I_DES='"+textBox6.Text+"',QTY='"+textBox7.Text+"',P_TYPE='"+textBox11.Text+"',KM='"+textBox8.Text+"',REF_NO='"+textBox9.Text+"',REMARKS='"+textBox10.Text+"' where B_ID='" + _B_ID.Text + "'", m_dbConnection);
                MessageBox.Show("Your data has been modified sucessfully");
                get_data();
                GET_DATA2(); 
            }
            catch(Exception EE)
            {
                MessageBox.Show("" + EE);
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox9.Focus();

            }
            else if(e.KeyCode == Keys.Down)
            {
                textBox9.Focus();
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox10.Focus();

            }
            else if (e.KeyCode == Keys.Down)
            {
                textBox10.Focus();
            }
            else if(e.KeyCode == Keys.Up)
            {
                textBox8.Focus();
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (textBox2.Text == "" && textBox3.Text == "" && textBox8.Text == "" && textBox9.Text == "" && textBox10.Text == "")
                    {
                        MessageBox.Show("Please fill all the details");
                    }
                    //else if(textBox3.Text=="")
                    //{
                    //    MessageBox.Show("Please enter Driver Name");
                    //}

                    //else if(textBox8.Text=="")
                    //{
                    //    MessageBox.Show("Please enter KM out");
                    //}
                    //else if(textBox9.Text=="")
                    //{
                    //    MessageBox.Show("Please enter Reference");
                    //}
                    //else if(textBox10.Text=="")
                    //{
                    //    MessageBox.Show("Please  enter Remarka");
                    //}

                    //else if(textBox2.Text=="" && textBox3.Text=="" && textBox8.Text=="" && textBox9.Text=="" && textBox10.Text=="" )
                    //{
                    //    MessageBox.Show("Please fill all the details");
                    //}
                    else
                    {
                        
                        m_dbConnection.Open();
                        SQLiteCommand cmd = new SQLiteCommand("update B_ID2 set S2='" + label19.Text + "' where B_ID='" + _B_ID.Text + "'", m_dbConnection);
                        SQLiteCommand cmd2 = new SQLiteCommand("update B_ID2 set KM='" + textBox8.Text + "',REF_NO='" + textBox9.Text + "',REMARKS='" + textBox10.Text + "' where B_ID ='" + _B_ID.Text + "'", m_dbConnection);
                        cmd.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();


                        m_dbConnection.Close();

                        MessageBox.Show("Full booked");

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = ""; 
                        textBox8.Text = "";
                        textBox9.Text = "";
                        textBox10.Text = "";
                        textBox11.Text = "";

                        get_data();
                        GET_DATA2();
                    }
                }
                catch (Exception ee)
                {

                    MessageBox.Show("Error In Connection..." + ee);
                }

            }
            else if (e.KeyCode == Keys.Down)
            {
                button3.Focus();
            }
            else if(e.KeyCode == Keys.Up)
            {
                textBox9.Focus();
            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                add();






                get_data();
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox11.Text = "";

                e.Handled = true;

            }
            else if(e.KeyCode == Keys.Down)
            {
                add();






                get_data();
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox11.Text = "";


                e.Handled = true;
            }
            else if(e.KeyCode == Keys.Up)
            {
                textBox7.Focus();
                e.Handled = true;
            }
        }
    }
}
    