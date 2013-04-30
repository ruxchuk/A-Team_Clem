using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace A_Team_Clem.Modules
{
    public partial class UCAddCompany : DevExpress.XtraEditors.XtraUserControl
    {
        public UCAddCompany(FRMMain mFRM)
        {
            InitializeComponent();
            fRMMain = mFRM;
            conDB = new ConMySql();
            convertDT = new ConvertDateTime();
        }

        private FRMMain fRMMain;
        private ConMySql conDB;
        private ConvertDateTime convertDT;

        private bool validateForm()
        {
            if (nameTH.Text == "")
            {
                MessageBox.Show("กรุณากรอกชื่อบริษัท");
                nameTH.Focus();
                return false;
            }
            return true;
        }

        private void readData()
        {
            conDB.company_name_th = nameTH.Text;
            conDB.company_name_en = nameEng.Text;
            conDB.company_adddress = richTextBoxAddress.Text;
            conDB.company_phone = phone.Text;
            conDB.company_email = email.Text;
            conDB.company_date_create = convertDT.convert(DateTime.Now);
            conDB.company_date_stamp = convertDT.convert(DateTime.Now);
        }

        private void clearData()
        {
            nameTH.Text = "";
            nameEng.Text = "";
            richTextBoxAddress.Text = "";
            phone.Text = "";
            email.Text = "";
            nameTH.Focus();
        }

        private void simpleButtonAddClem_Click(object sender, EventArgs e)
        {
            if (!validateForm())
            {
                return;
            }
            readData();
            int companyID = conDB.addCompany();
            if (companyID == 0)
            {
                MessageBox.Show("ชื่อบริษัท \"" + nameTH.Text + "\" มีการเพิ่มเข้ามาแล้ว\nกรุณาตรวจสอบ");
                nameTH.Focus();
            }
            else
            {
                clearData();
                if (fRMMain.oldPage == "UCAddCustomerClem")
                {
                    fRMMain.addCustomerClem.companyName.Text = nameTH.Text;
                    fRMMain.addCustomerClem.companyName.Focus();
                }
                else if (fRMMain.oldPage == "UCAddEmployeeClem")
                {
                    fRMMain.addEmployeeClem.companyName.Text = nameTH.Text;
                    fRMMain.addEmployeeClem.companyName.Focus();
                }
                fRMMain.changPage();
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            if (fRMMain.oldPage == "UCAddCustomerClem")
            {
                fRMMain.addCustomerClem.companyName.Focus();
            }
            else if (fRMMain.oldPage == "UCAddEmployeeClem")
            {
                fRMMain.addEmployeeClem.companyName.Focus();
            }
            fRMMain.changPage();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void keyDownNextTab(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                SendKeys.Send("{Tab}");
            }
        }

        Keys oldKeyDown;
        private void detail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && oldKeyDown == Keys.Return)
            {
                SendKeys.Send("{Tab}");
                oldKeyDown = Keys.D0;
            }
            else
                oldKeyDown = e.KeyCode;
        }
    }
}
