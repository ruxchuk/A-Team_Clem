using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;

namespace A_Team_Clem
{
    public partial class FRMSettingConDB : DevExpress.XtraEditors.XtraForm
    {
        private string pathFileDB = "";
        private ReadFileConDB readDB;

        public FRMSettingConDB(string pathFile)
        {
            pathFileDB = pathFile;
            InitializeComponent();
            readDB = new ReadFileConDB();
        }

        private void loadSaveFile()
        {
            bool resultLoadFile = readDB.readFileConDB(pathFileDB);
            Debug.WriteLine(resultLoadFile);
            if (resultLoadFile)
            {
                hostName.Text = readDB.hostName;
                DBName.Text = readDB.dataBaseName;
                userName.Text = readDB.userName;
                password.Text = readDB.pwd;
                port.Text = readDB.port;

                testConDB();
            }
        }

        private void saveFile()
        {
            readDB.hostName = hostName.Text;
            readDB.dataBaseName = DBName.Text;
            readDB.userName = userName.Text;
            readDB.pwd = password.Text;
            readDB.port = port.Text;
            readDB.saveFileConDB(pathFileDB);
        }

        private void testConDB()
        {
            ConMySql conDB = new ConMySql();

            bool resultCheckConnect = conDB.CheckConnect();
            conDB.CloseConnection();
            setStatusConnect(resultCheckConnect);
        }

        private void setStatusConnect(bool check)
        {
            if (check)
            {
                status.Text = "   YES   ";
                status.BackColor = Color.Green;
            }
            else
            {
                status.Text = "   NO   ";
                status.BackColor = Color.Red;
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (hostName.Text == "")
            {
                MessageBox.Show("กรุณากรอก Host Name");
                hostName.Select();
                return;
            }
            else if (DBName.Text == "")
            {
                MessageBox.Show("กรุณากรอกชื่อ ฐานข้อมูล");
                DBName.Select();
                return;
            }
            else if (userName.Text == "")
            {
                MessageBox.Show("กรุณากรอก User Name");
                userName.Select();
                return;
            }
            saveFile();
            testConDB();           
        }

        private void test_Click(object sender, EventArgs e)
        {
            saveFile();
            testConDB();
        }

        private void FRMSettingConDB_Load(object sender, EventArgs e)
        {
            loadSaveFile();
        }
    }
}