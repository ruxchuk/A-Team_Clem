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
using System.Diagnostics;

namespace A_Team_Clem.Modules
{
    public partial class UCAddCustomerClem : DevExpress.XtraEditors.XtraUserControl
    {
        private ConMySql conDB;
        private ConvertDateTime convertDT;
        public int curCustomerID = 0;
        public int curEmployeeID = 0;
        private FRMMain mainForm;
        public List<string>[] listCustomer;
        public List<string>[] listPorductType;
        public List<string>[] listCompany;
        public List<string>[] listEmployee;
        public List<string>[] listProduct;
        public List<string>[] listProductType;

        public UCAddCustomerClem(FRMMain mFRM)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            InitializeComponent();
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("");
            //panelControl5.Appearance.BackColor = Color.Red;
            mainForm = mFRM;
            conDB = new ConMySql();
            convertDT = new ConvertDateTime();

            //set รูปแบบวันที่
            dtProductEndDate.Properties.DisplayFormat.FormatString = mainForm.formatDate;
            dtProductEndDate.Properties.Mask.EditMask = mainForm.formatDate;
        }

        public void loadAllListData()
        {
            getCustomer();
            getProductType(); 
            getCompany(); 
            getEmployee();
            getProduct();
        }

        private void getCustomer()
        {
            listCustomer = null;
            listCustomer = conDB.getCustomer();
            cmbCustomerName.Properties.Items.AddRange(listCustomer[1]);
            textEditCustomerReceiveProduct.Properties.Items.AddRange(listCustomer[1]);
        }

        private void getProductType()
        {
            listPorductType = null;
            listPorductType = conDB.getProductType();
            productType.Properties.Items.AddRange(listPorductType[1]);
        }

        private void getCompany()
        {
            listCompany = null;
            listCompany = conDB.getCompany();
            companyName.Properties.Items.AddRange(listCompany[1]);
        }

        private void getEmployee()
        {
            listEmployee = null;
            listEmployee = conDB.getEmployee();
            employeeReceiveClem.Properties.Items.AddRange(listEmployee[1]);
            employeeClem.Properties.Items.AddRange(listEmployee[1]);
            employeeReceiveProduct.Properties.Items.AddRange(listEmployee[1]);
            employeeReturn.Properties.Items.AddRange(listEmployee[1]);
        }

        private void getProduct()
        {
            listProduct = null;
            listProduct = conDB.getProduct();
            productName.Properties.Items.AddRange(listProduct[1]);

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
            return true;
        }

        private void readData()
        {
            if (cmbCustomerName.SelectedIndex == -1)
            {
                conDB.customer_id = 0;
            }
            else
            {
                conDB.customer_id = int.Parse(listCustomer[0][cmbCustomerName.SelectedIndex]);
            }
            if (productType.SelectedIndex == -1)
            {
                conDB.product_type_id = 0;
            }
            else
            {
                conDB.product_type_id = int.Parse(listPorductType[0][productType.SelectedIndex]);
            }
            conDB.product_type_id = 0; //productType.SelectedText;
            conDB.company_id = 0;// companyName.SelectedText;

            conDB.product_name = productName.Text;
            conDB.serial = serial.Text;
            conDB.address = richTextBoxAddress.Text;
            conDB.phone = textEditPhone.Text;
            conDB.status = status.Text;
            conDB.date_create = convertDT.convert(DateTime.Now);
            conDB.date_product = convertDT.convert(dtProductEndDate.DateTime);
            conDB.date_stamp = convertDT.convert(DateTime.Now);
            if (radioButtonInWarranty.Checked)
            {
                conDB.warranty = "ในประกัน";
                conDB.chargebacks = 0;
            }
            else
            {
                conDB.warranty = "นอกประกัน";
                conDB.chargebacks = double.Parse(textEditChargebacks.Text);
            }
            conDB.symptom = richTextBoxSymptom.Text;
            conDB.equipment = richTextBoxEquipment.Text;
            conDB.detail = richTextBoxDetail.Text;

            conDB.in_document_number_id = 0;//***
            conDB.in_document_number = convertDT.convert(DateTime.Now);

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
            //if (!resultValidateForm)
            //{
            //    MessageBox.Show("กรุณากรอกข้อมูลที่กำหนด");
            //    return;
            //}

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

        private void imgAddCustomer_Click(object sender, EventArgs e)
        {
            mainForm.showAddCustomer();
        }

        private void imgAddProduct_Click(object sender, EventArgs e)
        {
            mainForm.showAddProduct();
        }

        private void imgAddCompany_Click(object sender, EventArgs e)
        {
            mainForm.showAddCompany();
        }

        private void imgAddTypeProduct_Click(object sender, EventArgs e)
        {
            mainForm.showAddProductType();
        }

        private void imgAddEmployee_Click(object sender, EventArgs e)
        {
            mainForm.showAddEmployee();
        }

        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomerName.SelectedIndex != -1)
            {
                richTextBoxAddress.Text = listCustomer[3][cmbCustomerName.SelectedIndex];
                textEditCustomerClem.Text = listCustomer[1][cmbCustomerName.SelectedIndex];
                textEditPhone.Text = listCustomer[4][cmbCustomerName.SelectedIndex];
            }
            else
            {

            }
        }
    }
}
