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
    public partial class UCAddCustomer : DevExpress.XtraEditors.XtraUserControl
    {
        private FRMMain fRMMain;
        private ConMySql conDB;
        private ConvertDateTime convertDT;

        public UCAddCustomer(FRMMain fRMMain)
        {
            // TODO: Complete member initialization
            this.fRMMain = fRMMain;
            InitializeComponent();
            conDB = new ConMySql();
            convertDT = new ConvertDateTime();
        }

        private bool validateForm()
        {
            if (nameTH.Text == "")
            {
                MessageBox.Show("กรุณากรอกชื่อลูกค้า");
                nameTH.Focus();
                return false;
            }
            if (phone.Text == "")
            {
                MessageBox.Show("กรุณากรอกเบอร์โทรลูกค้า");
                phone.Focus();
                return false;
            }
            return true;
        }

        private void readData()
        {
            conDB.name_th = nameTH.Text;
            conDB.name_en = nameEng.Text;
            conDB.address = address.Text;
            conDB.phone = phone.Text;
            conDB.email = email.Text;
            conDB.customer_date_create = convertDT.convert(DateTime.Now);
            conDB.customer_date_stamp = convertDT.convert(DateTime.Now);
        }

        private void simpleButtonAddClem_Click(object sender, EventArgs e)
        {
            if (!validateForm())
            {
                return;
            }
            readData();
            int customerID = conDB.addCustomer();
            Debug.WriteLine(customerID);
            if (customerID == 0)
            {
                MessageBox.Show("ชื่อลูกค้า \"" + nameTH.Text + "\" มีการเพิ่มเข้ามาแล้ว\nกรุณาตรวจสอบ");
            }
            else
            {
                fRMMain.showAddCustomerClem();
                fRMMain.addCustomerCustomerClem.customerName.Text = nameTH.Text;
                fRMMain.addCustomerCustomerClem.customerName.Focus();
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            fRMMain.showAddCustomerClem();
            fRMMain.addCustomerCustomerClem.customerName.Focus();
        }
    }
}
