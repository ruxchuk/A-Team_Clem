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
    public partial class UCAddProduct : DevExpress.XtraEditors.XtraUserControl
    {
        private FRMMain fRMMain;
        private ConMySql conDB;
        private ConvertDateTime convertDT;

        public UCAddProduct(FRMMain fRMMain)
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
                MessageBox.Show("กรุณากรอกชื่อสินค้า");
                nameTH.Focus();
                return false;
            }
            return true;
        }

        private void readData()
        {
            conDB.product_name_th = nameTH.Text;
            conDB.product_name_en = nameEng.Text;
            conDB.product_price = double.Parse(price.Text);
            conDB.product_value = value.Text;
            conDB.product_date_create = convertDT.convert(DateTime.Now);
            conDB.product_date_stamp = convertDT.convert(DateTime.Now);
        }

        private void bottonAdd_Click(object sender, EventArgs e)
        {
            if (!validateForm())
            {
                return;
            }
            readData();
            int productID = conDB.addProduct();
            Debug.WriteLine(productID);
            if (productID == 0)
            {
                MessageBox.Show("ชื่อสินค้า \"" + nameTH.Text + "\" มีการเพิ่มเข้ามาแล้ว\nกรุณาตรวจสอบ");
            }
            else
            {
                fRMMain.showAddCustomerClem();
                fRMMain.addCustomerCustomerClem.productName.Text = nameTH.Text;
                fRMMain.addCustomerCustomerClem.productName.Focus();
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            fRMMain.showAddCustomerClem();
            fRMMain.addCustomerCustomerClem.productName.Focus();
        }
    }
}
