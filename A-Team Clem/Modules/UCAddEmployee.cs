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
            conDB.employee_ddress = richTextBoxAddress.Text;
            conDB.employee_phone = phone.Text;
            conDB.employee_date_start = convertDT.convert(dtStart.DateTime);
            conDB.employee_date_create = convertDT.convert(DateTime.Now);
            conDB.employee_date_stamp = convertDT.convert(DateTime.Now);
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
            }
            else
            {
                fRMMain.showAddCustomerClem();
                fRMMain.addCustomerCustomerClem.employeeReceiveClem.Text = nameTH.Text;
                fRMMain.addCustomerCustomerClem.employeeReceiveClem.Focus();
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            fRMMain.showAddCustomerClem();
            fRMMain.addCustomerCustomerClem.employeeReceiveClem.Focus();
        }
    }
}
