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
    public partial class UCAddEmployee : DevExpress.XtraEditors.XtraUserControl
    {
        private FRMMain fRMMain;
        private ConMySql conDB;
        private ConvertDateTime convertDT;

        private bool validateForm()
        {
            if (nameTH.Text == "")
            {
                MessageBox.Show("กรุณากรอกชื่อลูกค้า");
                return false;
            }
            else if (phone.Text == "")
            {
                MessageBox.Show("กรุณากรอกเบอร์โทรลูกค้า");
                return false;
            }
            return true;
        }

        private void readData()
        {
            //conDB.customer_id = 0;
            conDB.name_th = nameTH.Text;
            conDB.name_en = nameEng.Text;
            conDB.address = richTextBoxAddress.Text;
            conDB.phone = phone.Text;
            conDB.email = email.Text;
            conDB.customer_date_create = convertDT.convert(DateTime.Now);
            conDB.customer_date_stamp = convertDT.convert(DateTime.Now);
        }

        public UCAddEmployee(FRMMain fRMMain)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.fRMMain = fRMMain;
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (!validateForm())
            {
                return;
            }
            readData();

            int resultID = conDB.addEmployee();
            if (resultID != 0)
            {

            }
            else
            {
                MessageBox.Show("การเพิ่มข้อมูลผิดพลาด");
            }
        }
    }
}
