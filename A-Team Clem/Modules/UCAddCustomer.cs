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
            int companyID = conDB.addCustomer();

            fRMMain.showAddCustomerClem();
        }
    }
}
