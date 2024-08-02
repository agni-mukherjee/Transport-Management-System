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
using System.Diagnostics;
using System.Management;

namespace TRANSPORT_1
{
    public partial class BILLING : Form
    {
        public BILLING()
        {
            InitializeComponent();
        }

        public double a = 0.00;
        public double b = 0.00;
        public double c = 0.00;
        public double d = 0.00;
        public double f = 0.00;
        public double g = 0.00;
        public double oc1 = 0.00;
        public double oc2 = 0.00;
        public double oc3 = 0.00;
        public double oc4 = 0.00;
        public double t = 0.00;

        

        void get_data()
        {
            try
            {
                dataGridView1.DataSource = null;
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                DataTable da3 = new DataTable();
                SQLiteDataAdapter cmd = new SQLiteDataAdapter("select * from B_ID2 where B_DATE = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' group by B_ID", m_dbConnection);



                cmd.Fill(da3);


                dataGridView1.DataSource = da3;


                this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.GreenYellow;
                this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[15].Visible = false;
                m_dbConnection.Close();
            }
            catch(Exception EE)
            {
                MessageBox.Show("ERROR" + EE);
            }
        }

        void get_data2()
        {
            dataGridView3.DataSource = null;
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
            m_dbConnection.Open();
            DataTable da3 = new DataTable();
            SQLiteDataAdapter cmd = new SQLiteDataAdapter("select * from B_ID2 where B_ID ='"+_B_ID.Text+"' ", m_dbConnection);



            cmd.Fill(da3);


            dataGridView3.DataSource = da3;


            this.dataGridView3.RowsDefaultCellStyle.BackColor = Color.GreenYellow;
            this.dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            m_dbConnection.Close();
        }

        private void BILLING_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            panel1.Enabled = false;
            get_data3();
            
            
        }
        void add()
        {
            try
            {
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                SQLiteCommand cmd3 = new SQLiteCommand("select BS from B_ID2 where B_ID = '" + _B_ID.Text + "' and C_NAME = '"+_C_NAME.Text+"' and BS = 'DONE' ", m_dbConnection);
                SQLiteDataAdapter ds3 = new SQLiteDataAdapter(cmd3);
                DataSet dss3 = new DataSet();
                ds3.Fill(dss3, "S1");
                if(dss3.Tables["S1"].Rows.Count > 0)
                {
                    MessageBox.Show("Bill already Exists");
                }
                else
                {
                    SQLiteCommand cmd = new SQLiteCommand("insert into BILL(BILL_ID, BILL_DATE, BOOKING_ID, BOOKING_DATE, V_NO, D_NAME, C_NAME, CON, ITEM, QTY, P_TYPE, KM_OUT, KM_IN, REF_NO, REMARKS, TRAVELLED, KM_RATE, TOTAL_RATE, OC1, OC2, OC3, OC4, TOTAL_CHARGE ) values('"+label27.Text+"','"+ dateTimePicker2.Value.ToString("yyyy-MM-dd") + "','"+_B_ID.Text+"','"+_B_DATE.Text+"','"+_V_NO.Text+"','"+_D_NAME.Text+"','"+_C_NAME.Text+"','"+_CON.Text+"','"+_I_DES.Text+"','"+_QTY.Text+"','"+_P_TYPE.Text+"','"+textBox1.Text+"','"+textBox2.Text+"','"+_REF_NO.Text+"','"+_REMARKS.Text+"','"+textBox9.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"','"+textBox6.Text+"','"+textBox7.Text+"','"+textBox8.Text+"','"+label28.Text+"')",m_dbConnection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bill has been created sucessfully and added to database");
                    SQLiteCommand cmd2 = new SQLiteCommand("update B_ID2 set BS ='" + label29.Text + "' where B_ID = '" + _B_ID.Text + "' and C_NAME = '" + _C_NAME.Text + "'",m_dbConnection);
                    cmd2.ExecuteNonQuery();
                    
                } 




            }
            catch(Exception ee)
            {
                MessageBox.Show("Error" + ee);
            }
        }

        void get_data3()
        {
            try
            {
                dataGridView2.DataSource = null;
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                DataTable da3 = new DataTable();
                SQLiteDataAdapter cmd = new SQLiteDataAdapter("select * from BILL  ", m_dbConnection);



                cmd.Fill(da3);


                dataGridView2.DataSource = da3;


                this.dataGridView2.RowsDefaultCellStyle.BackColor = Color.GreenYellow;
                this.dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[3].Visible = false;
                dataGridView2.Columns[4].Visible = false;
                dataGridView2.Columns[5].Visible = false;
                dataGridView2.Columns[6].Visible = false;
                dataGridView2.Columns[8].Visible = false;
                dataGridView2.Columns[9].Visible = false;
                dataGridView2.Columns[10].Visible = false;
                dataGridView2.Columns[11].Visible = false;
                dataGridView2.Columns[12].Visible = false;
                dataGridView2.Columns[13].Visible = false;
                dataGridView2.Columns[14].Visible = false;
                dataGridView2.Columns[15].Visible = false;
                dataGridView2.Columns[16].Visible = false;
                dataGridView2.Columns[17].Visible = false;
                dataGridView2.Columns[18].Visible = false;
                dataGridView2.Columns[19].Visible = false;
                dataGridView2.Columns[20].Visible = false;
                dataGridView2.Columns[21].Visible = false;
                dataGridView2.Columns[22].Visible = false;
                dataGridView2.Columns[23].Visible = false;
                dataGridView2.Columns[24].Visible = false;
                dataGridView2.Columns[25].Visible = false;
                dataGridView2.Columns[26].Visible = false;

                m_dbConnection.Close();
            }
            catch(Exception ee)
            {
                MessageBox.Show("Error" + ee);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            get_data();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DialogResult res = MessageBox.Show("Are you sure to Bill", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (res == DialogResult.Yes)
                {
                    SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                    m_dbConnection.Open();
                    SQLiteCommand cmd3 = new SQLiteCommand("select BS from B_ID2 where B_ID = '" + _B_ID.Text + "' and C_NAME = '" + _C_NAME.Text + "' and BS = 'DONE' ", m_dbConnection);
                    SQLiteDataAdapter ds3 = new SQLiteDataAdapter(cmd3);
                    DataSet dss3 = new DataSet();
                    ds3.Fill(dss3, "BS");
                    if (dss3.Tables["BS"].Rows.Count > 0)
                    {
                        MessageBox.Show("Bill already Exists");
                    }
                    else
                    {
                        if (e.RowIndex >= 0)
                        {


                            DataGridViewRow dr = this.dataGridView3.Rows[e.RowIndex];
                            _B_ID.Text = dr.Cells["B_ID"].Value.ToString();
                            _B_ID.Text = dr.Cells["B_ID"].Value.ToString();
                            _B_DATE.Text = dr.Cells["B_DATE"].Value.ToString();
                            _V_NO.Text = dr.Cells["V_NO"].Value.ToString();
                            _D_NAME.Text = dr.Cells["D_NAME"].Value.ToString();
                            _C_NAME.Text = dr.Cells["C_NAME"].Value.ToString();
                            _C_NAME2.Text = dr.Cells["C_NAME"].Value.ToString();
                            _CON.Text = dr.Cells["CON"].Value.ToString();
                            _I_DES.Text = dr.Cells["I_DES"].Value.ToString();
                            _QTY.Text = dr.Cells["QTY"].Value.ToString();
                            _P_TYPE.Text = dr.Cells["P_TYPE"].Value.ToString();
                            _KM.Text = dr.Cells["KM"].Value.ToString();
                            textBox1.Text = dr.Cells["KM"].Value.ToString();
                            _REF_NO.Text = dr.Cells["REF_NO"].Value.ToString();
                            _REMARKS.Text = dr.Cells["REMARKS"].Value.ToString();
                            m_dbConnection.Close();


                            panel1.Enabled = true;
                            groupBox1.Enabled = true;
                            BILLING_ID();

                        }
                    }
                }
                else if(res == DialogResult.No)
                {

                }
                else if(res == DialogResult.Cancel)
                {

                }
            }
            catch (Exception EE)
            {
                MessageBox.Show("Error" + EE);
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{

            //    SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
            //    m_dbConnection.Open();
            //    SQLiteCommand cmd3 = new SQLiteCommand("select BS from B_ID2 where B_ID = '" + _B_ID.Text + "' and C_NAME = '" + _C_NAME.Text + "' and BS = 'DONE' ", m_dbConnection);
            //    SQLiteDataAdapter ds3 = new SQLiteDataAdapter(cmd3);
            //    DataSet dss3 = new DataSet();
            //    ds3.Fill(dss3, "BS");
            //    if (dss3.Tables["BS"].Rows.Count > 0)
            //    {
            //        MessageBox.Show("Bill already Exists");
            //    }
            //    else
            //    {
            //        if (e.RowIndex >= 0)
            //        {


            //            DataGridViewRow dr = this.dataGridView3.Rows[e.RowIndex];
            //            _B_ID.Text = dr.Cells["B_ID"].Value.ToString();
            //            _B_ID.Text = dr.Cells["B_ID"].Value.ToString();
            //            _B_DATE.Text = dr.Cells["B_DATE"].Value.ToString();
            //            _V_NO.Text = dr.Cells["V_NO"].Value.ToString();
            //            _D_NAME.Text = dr.Cells["D_NAME"].Value.ToString();
            //            _C_NAME.Text = dr.Cells["C_NAME"].Value.ToString();
            //            _C_NAME2.Text = dr.Cells["C_NAME"].Value.ToString();
            //            _CON.Text = dr.Cells["CON"].Value.ToString();
            //            _I_DES.Text = dr.Cells["I_DES"].Value.ToString();
            //            _QTY.Text = dr.Cells["QTY"].Value.ToString();
            //            _P_TYPE.Text = dr.Cells["P_TYPE"].Value.ToString();
            //            _KM.Text = dr.Cells["KM"].Value.ToString();
            //            textBox1.Text = dr.Cells["KM"].Value.ToString();
            //            _REF_NO.Text = dr.Cells["REF_NO"].Value.ToString();
            //            _REMARKS.Text = dr.Cells["REMARKS"].Value.ToString();
            //            m_dbConnection.Close();


            //            panel1.Enabled = true;
            //            groupBox1.Enabled = true;
            //            BILLING_ID();

            //        }
            //    }
            //}
            //catch (Exception EE)
            //{
            //    MessageBox.Show("Error" + EE);
            //}
        }

        private void dataGridView3_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DialogResult res = MessageBox.Show("Are you sure to Bill", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (res == DialogResult.Yes)
                {
                    SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                    m_dbConnection.Open();
                    SQLiteCommand cmd3 = new SQLiteCommand("select BS from B_ID2 where B_ID = '" + _B_ID.Text + "' and C_NAME = '" + _C_NAME.Text + "' and BS = 'DONE' ", m_dbConnection);
                    SQLiteDataAdapter ds3 = new SQLiteDataAdapter(cmd3);
                    DataSet dss3 = new DataSet();
                    ds3.Fill(dss3, "BS");
                    if (dss3.Tables["BS"].Rows.Count > 0)
                    {
                        MessageBox.Show("Bill already Exists");
                    }
                    else
                    {
                        if (e.RowIndex >= 0)
                        {


                            DataGridViewRow dr = this.dataGridView3.Rows[e.RowIndex];
                            _B_ID.Text = dr.Cells["B_ID"].Value.ToString();
                            _B_ID.Text = dr.Cells["B_ID"].Value.ToString();
                            _B_DATE.Text = dr.Cells["B_DATE"].Value.ToString();
                            _V_NO.Text = dr.Cells["V_NO"].Value.ToString();
                            _D_NAME.Text = dr.Cells["D_NAME"].Value.ToString();
                            _C_NAME.Text = dr.Cells["C_NAME"].Value.ToString();
                            _C_NAME2.Text = dr.Cells["C_NAME"].Value.ToString();
                            _CON.Text = dr.Cells["CON"].Value.ToString();
                            _I_DES.Text = dr.Cells["I_DES"].Value.ToString();
                            _QTY.Text = dr.Cells["QTY"].Value.ToString();
                            _P_TYPE.Text = dr.Cells["P_TYPE"].Value.ToString();
                            _KM.Text = dr.Cells["KM"].Value.ToString();
                            textBox1.Text = dr.Cells["KM"].Value.ToString();
                            _REF_NO.Text = dr.Cells["REF_NO"].Value.ToString();
                            _REMARKS.Text = dr.Cells["REMARKS"].Value.ToString();
                            m_dbConnection.Close();


                            panel1.Enabled = true;
                            groupBox1.Enabled = true;
                            BILLING_ID();

                        }
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
                MessageBox.Show("Error" + EE);
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            get_data2();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            get_data2();
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dataGridView3_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                    m_dbConnection.Open();

                    DataGridViewRow dr = this.dataGridView1.Rows[e.RowIndex];
                    _B_ID.Text = dr.Cells["B_ID"].Value.ToString();
                    //_B_ID.Text = dr.Cells["B_ID"].Value.ToString();
                    //dateTimePicker1.Text = dr.Cells["B_DATE"].Value.ToString();
                    //textBox2.Text = dr.Cells["V_NO"].Value.ToString();
                    //textBox3.Text = dr.Cells["D_NAME"].Value.ToString();
                    //textBox4.Text = dr.Cells["C_NAME"].Value.ToString();
                    //textBox5.Text = dr.Cells["CON"].Value.ToString();
                    //textBox6.Text = dr.Cells["I_DES"].Value.ToString();
                    //textBox7.Text = dr.Cells["QTY"].Value.ToString();
                    //textBox11.Text = dr.Cells["P_TYPE"].Value.ToString();
                    //textBox8.Text = dr.Cells["KM"].Value.ToString();
                    //textBox9.Text = dr.Cells["REF_NO"].Value.ToString();
                    //textBox10.Text = dr.Cells["REMARKS"].Value.ToString();
                    //m_dbConnection.Close();


                    //panel1.Enabled = true;
                    //groupBox1.Enabled = true;

                    get_data2();
                }
            }
            catch (Exception EE)
            {
                MessageBox.Show("Error" + EE);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                    m_dbConnection.Open();

                    DataGridViewRow dr = this.dataGridView1.Rows[e.RowIndex];
                    _B_ID.Text = dr.Cells["B_ID"].Value.ToString();
                    //_B_ID.Text = dr.Cells["B_ID"].Value.ToString();
                    //dateTimePicker1.Text = dr.Cells["B_DATE"].Value.ToString();
                    //textBox2.Text = dr.Cells["V_NO"].Value.ToString();
                    //textBox3.Text = dr.Cells["D_NAME"].Value.ToString();
                    //textBox4.Text = dr.Cells["C_NAME"].Value.ToString();
                    //textBox5.Text = dr.Cells["CON"].Value.ToString();
                    //textBox6.Text = dr.Cells["I_DES"].Value.ToString();
                    //textBox7.Text = dr.Cells["QTY"].Value.ToString();
                    //textBox11.Text = dr.Cells["P_TYPE"].Value.ToString();
                    //textBox8.Text = dr.Cells["KM"].Value.ToString();
                    //textBox9.Text = dr.Cells["REF_NO"].Value.ToString();
                    //textBox10.Text = dr.Cells["REMARKS"].Value.ToString();
                    //m_dbConnection.Close();


                    //panel1.Enabled = true;
                    //groupBox1.Enabled = true;

                    get_data2();
                }
            }
            catch (Exception EE)
            {
                MessageBox.Show("Error" + EE);
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                    m_dbConnection.Open();

                    DataGridViewRow dr = this.dataGridView1.Rows[e.RowIndex];
                    _B_ID.Text = dr.Cells["B_ID"].Value.ToString();
                    //_B_ID.Text = dr.Cells["B_ID"].Value.ToString();
                    //dateTimePicker1.Text = dr.Cells["B_DATE"].Value.ToString();
                    //textBox2.Text = dr.Cells["V_NO"].Value.ToString();
                    //textBox3.Text = dr.Cells["D_NAME"].Value.ToString();
                    //textBox4.Text = dr.Cells["C_NAME"].Value.ToString();
                    //textBox5.Text = dr.Cells["CON"].Value.ToString();
                    //textBox6.Text = dr.Cells["I_DES"].Value.ToString();
                    //textBox7.Text = dr.Cells["QTY"].Value.ToString();
                    //textBox11.Text = dr.Cells["P_TYPE"].Value.ToString();
                    //textBox8.Text = dr.Cells["KM"].Value.ToString();
                    //textBox9.Text = dr.Cells["REF_NO"].Value.ToString();
                    //textBox10.Text = dr.Cells["REMARKS"].Value.ToString();
                    //m_dbConnection.Close();


                    //panel1.Enabled = true;
                    //groupBox1.Enabled = true;

                    get_data2();
                }
            }
            catch (Exception EE)
            {
                MessageBox.Show("Error" + EE);
            }
        }
        void BILLING_ID()
        {
            try
            {
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();

                SQLiteCommand cmd = new SQLiteCommand("insert into BILL_ID(BILL_DATE) values('" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "')", m_dbConnection);
                cmd.ExecuteNonQuery();

                SQLiteCommand cmd23 = new SQLiteCommand("select SL from BILL_ID order by SL desc limit 1", m_dbConnection);
                SQLiteDataAdapter daa = new SQLiteDataAdapter(cmd23);
                DataSet dss = new DataSet();
                daa.Fill(dss, "BILL_ID");
                if (dss.Tables["BILL_ID"].Rows.Count >= 1)
                {
                    label26.Text = dss.Tables["BILL_ID"].Rows[0]["SL"].ToString();
                    m_dbConnection.Close();
                    label27.Text = "TMSB/" + label26.Text;
                    m_dbConnection.Open();

                    SQLiteCommand cmd3 = new SQLiteCommand("update BILL_ID set BILL_ID='" + label27.Text + "' where SL='" + label26.Text + "'", m_dbConnection);
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

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)

            {
                try
                {
                    a = double.Parse(textBox1.Text);
                    b = double.Parse(textBox2.Text);
                    c = (b - a);
                    textBox9.Text = c.ToString("0 ");
                    textBox9.Focus();
                }
                catch(Exception ee)
                {
                    MessageBox.Show("Error" + ee);
                }
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                d = double.Parse(textBox3.Text);
                f = (d * c);
                textBox4.Text = f.ToString("0.00");
                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (textBox5.Text == "")
                {
                    textBox5.Text = "0.00";
                    textBox6.Focus();
                }
                else
                {
                    oc1 = double.Parse(textBox5.Text);
                    textBox6.Focus();
                }
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox6.Text == "")
                {
                    textBox6.Text = "0.00";
                    textBox7.Focus();
                }
                else
                {
                    oc2 = double.Parse(textBox6.Text);
                    textBox7.Focus();
                }
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox7.Text == "")
                {
                    textBox7.Text = "0.00";
                    textBox8.Focus();
                }
                else
                {
                    oc3 = double.Parse(textBox7.Text);
                    textBox8.Focus();
                }
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox8.Text == "")
                {
                    textBox8.Text = "0.00";
                }
                else
                {
                    oc4 = double.Parse(textBox8.Text);
                    t = (f + oc1 + oc2 + oc3 + oc4);
                    label28.Text = t.ToString("0.00");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            oc4 = double.Parse(textBox8.Text);
            t = (f + oc1 + oc2 + oc3 + oc4);
            label28.Text = t.ToString("0.00");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            add();
            get_data();
            get_data2();
            get_data3();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            label27.Text = "";
            _C_NAME.Text = "";
            _C_NAME2.Text = "";
            _B_ID.Text = "";
            _B_DATE.Text = "";
            _V_NO.Text = "";
            _D_NAME.Text = "";
            _CON.Text = "";
            _I_DES.Text = "";
            _QTY.Text = "";
            _P_TYPE.Text = "";
            _REF_NO.Text = "";
            _REMARKS.Text = "";
            label28.Text = "";
            _KM.Text = "";
        }

        void delete()
        {
            try
            {
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                SQLiteCommand cmd = new SQLiteCommand("Delete from BILL where BILL_ID = '" + label27.Text+"'",m_dbConnection);
                SQLiteCommand cmd2 = new SQLiteCommand("update B_ID2 set BS = ' '",m_dbConnection);
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Bill has been deleted successfully from database");
            }
            catch(Exception ee)
            {
                MessageBox.Show("Error" + ee);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            delete();
            get_data2();
            get_data3();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            label27.Text = "";
            _C_NAME.Text = "";
            _C_NAME2.Text = "";
            _B_ID.Text = "";
            _B_DATE.Text = "";
            _V_NO.Text = "";
            _D_NAME.Text = "";
            _CON.Text = "";
            _I_DES.Text = "";
            _QTY.Text = "";
            _P_TYPE.Text = "";
            _REF_NO.Text = "";
            _REMARKS.Text = "";
            label28.Text = "";
            _KM.Text = "";
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Are you sure to modify", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);


                if (res == DialogResult.Yes)
                {
                    SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                    m_dbConnection.Open();

                    if (e.RowIndex >= 0)
                    {
                        DataGridViewRow dr = this.dataGridView2.Rows[e.RowIndex];
                        label30.Text = dr.Cells["SL"].Value.ToString();
                        _C_NAME2.Text = dr.Cells["C_NAME"].Value.ToString();
                        label27.Text = dr.Cells["BILL_ID"].Value.ToString();
                        dateTimePicker2.Text = dr.Cells["BILL_DATE"].Value.ToString();
                        textBox1.Text = dr.Cells["KM_OUT"].Value.ToString();
                        textBox2.Text = dr.Cells["KM_IN"].Value.ToString();
                        textBox9.Text = dr.Cells["TRAVELLED"].Value.ToString();
                        textBox3.Text = dr.Cells["KM_RATE"].Value.ToString();
                        textBox4.Text = dr.Cells["TOTAL_RATE"].Value.ToString();
                        textBox5.Text = dr.Cells["OC1"].Value.ToString();
                        textBox6.Text = dr.Cells["OC2"].Value.ToString();
                        textBox7.Text = dr.Cells["OC2"].Value.ToString();
                        textBox8.Text = dr.Cells["OC4"].Value.ToString();
                        label28.Text = dr.Cells["TOTAL_CHARGE"].Value.ToString();
                        _B_ID.Text = dr.Cells["BOOKING_ID"].Value.ToString();
                        _B_DATE.Text = dr.Cells["BOOKING_DATE"].Value.ToString();
                        _V_NO.Text = dr.Cells["V_NO"].Value.ToString();
                        _D_NAME.Text = dr.Cells["D_NAME"].Value.ToString();
                        _C_NAME.Text = dr.Cells["C_NAME"].Value.ToString();
                        _CON.Text = dr.Cells["CON"].Value.ToString();
                        _I_DES.Text = dr.Cells["ITEM"].Value.ToString();
                        _QTY.Text = dr.Cells["QTY"].Value.ToString();
                        _P_TYPE.Text = dr.Cells["P_TYPE"].Value.ToString();
                        _REF_NO.Text = dr.Cells["REF_NO"].Value.ToString();
                        _REMARKS.Text = dr.Cells["REMARKS"].Value.ToString();



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
            catch(Exception ee)
            {
                MessageBox.Show("Error" + ee);
            }
        
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StreamWriter File = new StreamWriter("BILL_ID");
            File.Write(label27.Text);
            File.Close();
            Process.Start(@"D:\Project\TRANSPORT_1\TRANSPORT_1\WindowsFormsApplication1.application");

            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
