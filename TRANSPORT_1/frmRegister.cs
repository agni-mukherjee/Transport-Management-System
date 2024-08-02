using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FoxLearn.License;
using System.Data.SQLite;

using System.IO;

namespace TRANSPORT_1
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        void REG()
        {
            try
            {
                if(textBox1.Text=="")
                {
                    MessageBox.Show("Please enter Customer Name");
                }
                else if(textBox2.Text=="")
                {
                    MessageBox.Show("Please enter Mobile Number");
                }
                else if(textBox3.Text=="")
                {
                    MessageBox.Show("Please enter Email Address");
                }
                else if(textBox4.Text=="")
                {
                    MessageBox.Show("Please enter Company Name");
                }
                else if(textBox5.Text=="")
                {
                    MessageBox.Show("Please enter Address");
                }
                else
                {
                    
                    KeyManager km = new KeyManager(lblProductID.Text);
                    KeyValuesClass kv;
                    string productkey = string.Empty;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        byte ProductCode = 0;
                        kv = new KeyValuesClass()
                        {
                            Type = LicenseType.FULL,
                            Header = Convert.ToByte(9),
                            Footer = Convert.ToByte(6),
                            ProductCode = (byte)ProductCode,
                            Edition = Edition.ENTERPRISE,
                            Version = 1,

                        };
                        if (!km.GenerateKey(kv, ref productkey))
                        {
                            lblPK.Text = "ERROR";
                        }
                        lblPK.Text = productkey;
                        SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                        m_dbConnection.Open();
                        SQLiteCommand cmd = new SQLiteCommand("insert into PIDK(P_ID,C_NAME,M_NO,EMAIL,COMP_NAME,ADDR,L_TYPE,P_KEY,S_DATE,E_DATE) values ('" + lblProductID.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox1.Text + "','" + lblPK.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "')", m_dbConnection);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Product Key Generated Sucessfully");
                        m_dbConnection.Close();



                    }
                    else if(comboBox1.SelectedIndex == 1)
                    {
                        byte ProductCode = 0;
                        kv = new KeyValuesClass()
                        {
                            Type = LicenseType.FULL,
                            Header = Convert.ToByte(9),
                            Footer = Convert.ToByte(6),
                            ProductCode = (byte)ProductCode,
                            Edition = Edition.ENTERPRISE,
                            Version = 1,

                        };
                        if (!km.GenerateKey(kv, ref productkey))
                        {
                            lblPK.Text = "ERROR";
                        }
                        lblPK.Text = productkey;
                        SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                        m_dbConnection.Open();
                        SQLiteCommand cmd = new SQLiteCommand("insert into PIDK(P_ID,C_NAME,M_NO,EMAIL,COMP_NAME,ADDR,L_TYPE,P_KEY,S_DATE,E_DATE) values ('" + lblProductID.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox1.Text + "','" + lblPK.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "')", m_dbConnection);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Product Key Generated Sucessfully");
                        m_dbConnection.Close();
                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {
                        byte ProductCode = 0;
                        kv = new KeyValuesClass()
                        {
                            Type = LicenseType.FULL,
                            Header = Convert.ToByte(9),
                            Footer = Convert.ToByte(6),
                            ProductCode = (byte)ProductCode,
                            Edition = Edition.ENTERPRISE,
                            Version = 1,

                        };
                        if (!km.GenerateKey(kv, ref productkey))
                        {
                            lblPK.Text = "ERROR";
                        }
                        lblPK.Text = productkey;
                        SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                        m_dbConnection.Open();
                        SQLiteCommand cmd = new SQLiteCommand("insert into PIDK(P_ID,C_NAME,M_NO,EMAIL,COMP_NAME,ADDR,L_TYPE,P_KEY,S_DATE,E_DATE) values ('" + lblProductID.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox1.Text + "','" + lblPK.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "')", m_dbConnection);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Product Key Generated Sucessfully");
                        m_dbConnection.Close();
                    }
                    else
                    {
                        byte ProductCode = 0;
                        kv = new KeyValuesClass()
                        {
                            Type = LicenseType.TRIAL,
                            Header = Convert.ToByte(9),
                            Footer = Convert.ToByte(6),
                            ProductCode = (byte)ProductCode,
                            Edition = Edition.ENTERPRISE,
                            Version = 1,
                            //Expiration = DateTime.Now.Date.AddDays(Convert.ToInt32(textBox6.Text)),
                        };
                    }
                    if (!km.GenerateKey(kv, ref productkey))
                    {
                        lblPK.Text = "ERROR";
                    }
                    //lblPK.Text = productkey;
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show("error\n" + ee);
            }
        }

        void VALIDATE()
        {
            try
            {
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source= " + _DATA.Text + ".s3db;Version=3;");
                m_dbConnection.Open();
                SQLiteCommand cmd = new SQLiteCommand("select P_ID,P_KEY from PIDK where P_ID= '" + lblProductID.Text + "' and P_KEY='"+lblPK.Text+"'", m_dbConnection);
                SQLiteDataAdapter ds = new SQLiteDataAdapter(cmd);
                DataSet dss = new DataSet();
                ds.Fill(dss, "PIDK");
                
                if(dss.Tables["PIDK"].Rows.Count>=1)
                {
                    
                    KeyManager km = new KeyManager(lblProductID.Text);
                    KeyValuesClass kv = new KeyValuesClass();
                    string productkey = lblPK.Text;
                    if (km.ValidKey(ref productkey))
                    {
                        LicenseInfo lic = new LicenseInfo();
                        lic.ProductKey = productkey;
                        lic.FullName = "EPIOTECH";
                        if (kv.Type == LicenseType.TRIAL)
                        {
                            lic.Day = kv.Expiration.Day;
                            lic.Month = kv.Expiration.Month;
                            lic.Year = kv.Expiration.Year;
                        }
                        km.SaveSuretyFile(string.Format(@"{0}\Key.lic", Application.StartupPath), lic);
                        
                        SQLiteCommand cmd2 = new SQLiteCommand("update PIDK set STATUS = '"+label11.Text+"' where P_KEY='" + textBox8.Text + "'", m_dbConnection);
                        cmd2.ExecuteNonQuery();
                        m_dbConnection.Close();
                        MessageBox.Show("You have been successfully registered.FUCK", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Your Product Key is invalid", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    
                }
                else
                {
                    MessageBox.Show("Invalid Product Key");
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show("error" + ee);
            }
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            try
            {
                comboBox1.SelectedIndex = 0;
                lblProductID.Text = ComputerInfo.GetComputerId();
            }
            catch(Exception ee)
            {
                MessageBox.Show("Error" + ee);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(comboBox1.SelectedIndex==0)
                {
                    dateTimePicker2.Value = DateTime.Today.AddDays(+30);
                    REG();
                }
                else if(comboBox1.SelectedIndex==1)
                {
                    dateTimePicker2.Value = DateTime.Today.AddDays(+180);
                    REG();
                }
                else if(comboBox1.SelectedIndex==2)
                {
                    dateTimePicker2.Value = DateTime.Today.AddDays(+365);
                    REG();
                }
                
                
            }
            catch(Exception ee)
            {
                MessageBox.Show("error"+ee);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VALIDATE();
        }
    }
}
