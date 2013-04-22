using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using System.Globalization;

namespace A_Team_Clem.Modules
{
    public partial class UCCustomerClem : DevExpress.XtraEditors.XtraUserControl
    {
        private ConMySql conDB;
        public int curCustomerID = 0;
        public int curEmployeeID = 0;

        private string dateCreate = "";


        public UCCustomerClem()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            InitializeComponent();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("");
            panelControl5.Appearance.BackColor = Color.Red;

            conDB = new ConMySql();
        }

        public bool validateForm()
        {
            if (cmbCustomerName.Text == "")
            {
                cmbCustomerName.Select();
                return false;
            }
            else if (textEditPhone.Text == "")
            {
                textEditPhone.Select();
                return false;
            }
            else if (productName.Text == "")
            {
                productName.Select();
                return false;
            }
            else if (companyName.Text == "")
            {
                companyName.Select();
                return false;
            }
            else if (productType.Text == "")
            {
                productType.Select();
                return false;
            }
            else if (dtProductEndDate.Text == "")
            {
                dtProductEndDate.Select();
                return false;
            }
            else if (employeeReceiveClem.Text == "")
            {
                employeeReceiveClem.Select();
                return false;
            }
            else if (textEditChargebacks.Text == "")
            {
                textEditChargebacks.Select();
                return false;
            }
            return true;
        }

        private void readData()
        {
            conDB.product_type_id = productType.SelectedText;
            conDB.company_id = companyName.SelectedText;

            conDB.product_name = productName.Text;
            conDB.serial = serial.Text;
            conDB.address = richTextBoxAddress.Text;
            conDB.phone = textEditPhone.Text;
            conDB.status = status.Text;
            conDB.date_create = dateCreate;
            conDB.date_product = dtProductEndDate.DateTime.Year + "-" + dtProductEndDate.DateTime.Month + "-" + dtProductEndDate.DateTime.Day;
            conDB.date_stamp = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
            if (radioButtonInWarranty.Checked){
                conDB.warranty = "ในประกัน";
                conDB.chargebacks = "0";
            } else {
                conDB.warranty = "นอกประกัน";
                conDB.chargebacks = textEditChargebacks.Text;
            }
            conDB.symptom = richTextBoxSymptom.Text;
            conDB.equipment = richTextBoxEquipment.Text;
            conDB.detail = richTextBoxDetail.Text;

            conDB.in_document_number_id = "";//***
            conDB.in_document_number = textEditInDocumentNumber.Text;

            conDB.out_document_number = textEditOutDocumentNumber.Text;
            conDB.in_serial_clem = textEditInSerialClem.Text;
            conDB.out_serial_clem = textEditOutSerialClem.Text;
            conDB.clem_type = "ใบรับเคลม";
            conDB.customer_clem = textEditCustomerClem.Text;
            conDB.employee_receive_clem = employeeReceiveClem.Text;
            conDB.employee_clem = employeeClem.Text;
            conDB.company_receive_clem = textEditCompanyReceiveClem.Text;
            conDB.company_return = textEditCompanyReturn.Text;
            conDB.employee_receive_product = employeeReceiveProduct.Text;
            conDB.employee_return = employeeReturn.Text;
            conDB.customer_receive_product = textEditCustomerReceiveProduct.Text;
        }

        private void simpleButtonAddClem_Click(object sender, EventArgs e)
        {
            bool resultValidateForm = validateForm();
            if (!resultValidateForm)
            {
                MessageBox.Show("กรุณากรอกข้อมูลที่กำหนด");
                return;
            }
            
            readData();
            bool resultAddClem = conDB.addClem();
            if (resultAddClem)
            {

            }
            else 
            {
                MessageBox.Show("การเพิ่มข้อมูลผิดพลาด");
            }
        }

        private void radioButtonInWarranty_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonInWarranty.Checked)
            {
                panelWarranty.Visible = false;
            }
            else
            {
                panelWarranty.Visible = true;
            }
        }

        private void radioButtonOutWarranty_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOutWarranty.Checked)
            {
                panelWarranty.Visible = true;
                textEditChargebacks.Select();
            }
            else
            {
                panelWarranty.Visible = false;
            }
        }

        private void cmbCustomerName_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
