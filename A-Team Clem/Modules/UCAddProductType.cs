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
    public partial class UCAddProductType : DevExpress.XtraEditors.XtraUserControl
    {
        private FRMMain fRMMain;
        private ConMySql conDB;
        private ConvertDateTime convertDT;

        public UCAddProductType(FRMMain fRMMain)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.fRMMain = fRMMain;
            conDB = new ConMySql();
            convertDT = new ConvertDateTime();
        }

        private bool validateForm()
        {
            if (nameTH.Text == "")
            {
                MessageBox.Show("กรุณากรอกชื่อชนิดสินค้า");
                nameTH.Focus();
                return false;
            }
            return true;
        }

        private void readData()
        {
            conDB.product_type_name_th = nameTH.Text;
            conDB.product_type_name_en = nameEng.Text;
            conDB.product_type_date_create = convertDT.convert(DateTime.Now);
            conDB.product_type_date_stamp = convertDT.convert(DateTime.Now);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!validateForm())
            {
                return;
            }
            readData();
            int productID = conDB.addProductType();
            Debug.WriteLine(productID);
            if (productID == 0)
            {
                MessageBox.Show("ชนิดสินค้า \"" + nameTH.Text + "\" มีการเพิ่มเข้ามาแล้ว\nกรุณาตรวจสอบ");
            }
            else
            {
                fRMMain.showAddCustomerClem();
                fRMMain.addCustomerClem.productType.Text = nameTH.Text;
                fRMMain.addCustomerClem.productType.Focus();
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            fRMMain.showAddCustomerClem();
            fRMMain.addCustomerClem.productType.Focus();
        }
    }
}
