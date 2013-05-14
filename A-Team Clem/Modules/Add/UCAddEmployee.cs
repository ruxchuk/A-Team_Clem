using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;

namespace A_Team_Clem.Modules
{
    public partial class UCAddEmployee : DevExpress.XtraEditors.XtraUserControl
    {
        private FRMMain fRMMain;
        private ConMySql conDB;
        private ConvertDateTime convertDT;

        public UCAddEmployee(FRMMain fRMMain)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.fRMMain = fRMMain;
            conDB = new ConMySql();
            convertDT = new ConvertDateTime();
            dtStart.Properties.DisplayFormat.FormatString = fRMMain.formatDate;
            dtStart.Properties.Mask.EditMask = fRMMain.formatDate;
        }

        private bool validateForm()
        {
            if (nameTH.Text == "")
            {
                MessageBox.Show("กรุณากรอกชื่อพนักงาน");
                nameTH.Select();
                return false;
            }
            else if (phone.Text == "")
            {
                MessageBox.Show("กรุณากรอกเบอร์พนักงานก่อน");
                phone.Select();
                return false;
            }
            return true;
        }

        private void readData()
        {
            //conDB.customer_id = 0;
            conDB.employee_name_th = nameTH.Text;
            conDB.employee_name_en = nameEng.Text;
            conDB.employee_nickname = nickname.Text;
            conDB.employee_adress = richTextBoxAddress.Text;
            conDB.employee_phone = phone.Text;
            conDB.employee_date_start = convertDT.convert(dtStart.DateTime);
            conDB.employee_date_create = convertDT.convert(DateTime.Now);
            conDB.employee_date_stamp = convertDT.convert(DateTime.Now);
        }

        private void clearData()
        {
            nameTH.Text = "";
            nameEng.Text = "";
            nickname.Text = "";
            richTextBoxAddress.Text = "";
            phone.Text = "";
            dtStart.DateTime = DateTime.Now;
            nameTH.Focus();
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (!validateForm())
            {
                return;
            }
            readData();
            int employeeID = conDB.addEmployee();
            Debug.WriteLine(employeeID);
            if (employeeID == 0)
            {
                MessageBox.Show("ชื่อพนักงาน \"" + nameTH.Text + "\" มีการเพิ่มเข้ามาแล้ว\nกรุณาตรวจสอบ");
                nameTH.Focus();
            }
            else
            {
                clearData();
                if (fRMMain.oldPage == "UCAddCustomerClem")
                {
                    fRMMain.addCustomerClem.employeeClem.Text = nameTH.Text;
                    fRMMain.addCustomerClem.employeeClem.Focus();
                }
                else if (fRMMain.oldPage == "UCAddEmployeeClem")
                {
                    fRMMain.addEmployeeClem.employeeClem.Text = nameTH.Text;
                    fRMMain.addEmployeeClem.employeeClem.Focus();
                }
                fRMMain.changPage();
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            if (fRMMain.oldPage == "UCAddCustomerClem")
            {
                fRMMain.addCustomerClem.employeeClem.Focus();
            }
            else if (fRMMain.oldPage == "UCAddEmployeeClem")
            {
                fRMMain.addEmployeeClem.employeeClem.Focus();
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
