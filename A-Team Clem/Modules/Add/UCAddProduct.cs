using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;
using DevExpress.XtraEditors.Mask;

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

            price.Properties.Mask.MaskType = MaskType.Numeric;
            price.Properties.Mask.EditMask = "n";
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

        private void clearData()
        {
            nameTH.Text = "";
            nameEng.Text = "";
            price.Text = "0";
            value.SelectedIndex = -1;
            nameTH.Focus();
            nameTH.Focus();
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
                nameTH.Focus();
            }
            else
            {
                clearData();
                if (fRMMain.oldPage == "UCAddCustomerClem")
                {
                    fRMMain.addCustomerClem.productName.Text = nameTH.Text;
                    fRMMain.addCustomerClem.productName.Focus();
                }
                else if (fRMMain.oldPage == "UCAddEmployeeClem")
                {
                    fRMMain.addEmployeeClem.productName.Text = nameTH.Text;
                    fRMMain.addEmployeeClem.productName.Focus();
                }
                fRMMain.changPage();
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            if (fRMMain.oldPage == "UCAddCustomerClem")
            {
                fRMMain.addCustomerClem.productName.Focus();
            }
            else if (fRMMain.oldPage == "UCAddEmployeeClem")
            {
                fRMMain.addEmployeeClem.productName.Focus();
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
