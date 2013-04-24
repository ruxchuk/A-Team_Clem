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
    public partial class UCAddEmployeeClem : DevExpress.XtraEditors.XtraUserControl
    {
        private FRMMain fRMMain;
        private ConMySql conDB;
        private ConvertDateTime convertDT;
        public string clemType = "ใบส่งเคลม";

        public List<string>[] listCustomer;
        public List<string>[] listPorductType;
        public List<string>[] listCompany;
        public List<string>[] listEmployee;
        public List<string>[] listProduct;
        public List<string>[] listProductType;

        public UCAddEmployeeClem(FRMMain fRMMain)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            InitializeComponent();
            // TODO: Complete member initialization
            this.fRMMain = fRMMain;
            conDB = new ConMySql();
            convertDT = new ConvertDateTime();

            //set รูปแบบวันที่
            dtProductEndDate.Properties.DisplayFormat.FormatString = fRMMain.formatDate;
            dtProductEndDate.Properties.Mask.EditMask = fRMMain.formatDate;
        }

        #region load data
        public void loadInDocumentNumber()
        {
            inDocumentNumber.Text = conDB.getNewIDDocumentNumber(clemType);
        }

        public void loadAllListData()
        {
            getProductType();
            getCompany();
            getEmployee();
            getProduct();
            loadInDocumentNumber();
        }

        private void getProductType()
        {
            listPorductType = null;
            listPorductType = conDB.getProductType();
            if (listPorductType != null)
            {
                productType.Properties.Items.AddRange(listPorductType[1]);
            }
        }

        private void getCompany()
        {
            listCompany = null;
            listCompany = conDB.getCompany();
            if (listCompany != null)
            {
                companyName.Properties.Items.AddRange(listCompany[1]);
            }
        }

        private void getEmployee()
        {
            listEmployee = null;
            listEmployee = conDB.getEmployee();
            if (listEmployee != null)
            {
                employeeClem.Properties.Items.AddRange(listEmployee[1]);
                employeeReceiveProduct.Properties.Items.AddRange(listEmployee[1]);
            }
        }

        private void getProduct()
        {
            listProduct = null;
            listProduct = conDB.getProduct();
            if (listProduct != null)
            {
                productName.Properties.Items.AddRange(listProduct[1]);
            }
        }

        #endregion


        #region validate data
        public bool validateForm()
        {
            //if (customerName.Text == "")
            //{
            //    MessageBox.Show("กรุณากรอกชื่อลูกค้า");
            //    customerName.Select();
            //    return false;
            //}
            //else if (phone.Text == "")
            //{
            //    MessageBox.Show("กรุณากรอกเบอร์โทรลูกค้า");
            //    phone.Select();
            //    return false;
            //}
            //else 
                if (productName.Text == "")
            {
                MessageBox.Show("กรุณากรอกชื่อสินค้า");
                productName.Select();
                return false;
            }
            else if (companyName.Text == "")
            {
                MessageBox.Show("กรุณากรอกชื่อบริษัท");
                companyName.Select();
                return false;
            }
            else if (productType.Text == "")
            {
                MessageBox.Show("กรุณากรอกชนิดสินค้า");
                productType.Select();
                return false;
            }
            else if (dtProductEndDate.Text == "")
            {
                MessageBox.Show("กรุณากรอกวันที่สินค้าหมดอายุ");
                dtProductEndDate.Select();
                return false;
            }
            //else if (employeeReceiveClem.Text == "")
            //{
            //    MessageBox.Show("กรุณากรอกชื่อพนักงานที่รับเคลมสินค้า");
            //    employeeReceiveClem.Select();
            //    return false;
            //}
            else if (status.Text == "")
            {
                MessageBox.Show("กรุณาสถานะ");
                status.Select();
                return false;
            }
            return true;
        }

        private void readData()
        {
            conDB.customer_id = 0;
            if (productType.SelectedIndex < 0)
            {
                conDB.product_type_name_th = productType.Text;
                conDB.product_type_name_en = "";
                conDB.product_type_date_create = convertDT.convert(DateTime.Now);
                conDB.product_type_date_stamp = convertDT.convert(DateTime.Now);
            }
            else
            {
                conDB.product_type_id = int.Parse(listPorductType[0][productType.SelectedIndex]);
            }

            if (companyName.SelectedIndex < 0)
            {
                conDB.company_name_th = companyName.Text;
                conDB.company_name_en = "";
                conDB.company_adddress = "";
                conDB.company_phone = "";
                conDB.company_email = "";
                conDB.company_date_create = convertDT.convert(DateTime.Now);
                conDB.company_date_stamp = convertDT.convert(DateTime.Now);
            }
            else
            {
                conDB.company_id = int.Parse(listCompany[0][companyName.SelectedIndex]);
            }

            conDB.product_name = productName.Text;
            conDB.serial = serial.Text;
            conDB.status = status.Text;
            conDB.date_create = convertDT.convert(DateTime.Now);
            conDB.date_product = convertDT.convert(dtProductEndDate.DateTime);
            conDB.date_stamp = convertDT.convert(DateTime.Now);
            //if (radioButtonInWarranty.Checked)
            //{
            //    conDB.warranty = "ในประกัน";
            //    conDB.chargebacks = 0;
            //}
            //else
            //{
            //    conDB.warranty = "นอกประกัน";
            //    conDB.chargebacks = double.Parse(textEditChargebacks.Text);
            //}

            conDB.warranty = "";
            conDB.chargebacks = 0;

            conDB.symptom = symptom.Text;
            conDB.equipment = equipment.Text;
            conDB.detail = detail.Text;

            conDB.in_document_number_id = conDB.getNewIDClemOfMonth(clemType);
            conDB.in_document_number = convertDT.convert(DateTime.Now);
            conDB.in_document_number_string = inDocumentNumber.Text;

            conDB.out_document_number = outDocumentNumber.Text;
            conDB.in_serial_clem = "";
            conDB.out_serial_clem = "";
            conDB.clem_type = clemType;
            conDB.customer_clem = "";
            conDB.employee_receive_clem = "";
            conDB.employee_clem = employeeClem.Text;
            conDB.company_receive_clem = companyReceiveClem.Text;
            conDB.company_return = companyReturn.Text;
            conDB.employee_receive_product = employeeReceiveProduct.Text;
            conDB.employee_return = "";
            conDB.customer_receive_product = "";

        }
        #endregion

        private void simpleButtonAddClem_Click(object sender, EventArgs e)
        {
            bool resultValidateForm = validateForm();
            if (!resultValidateForm)
            {
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
    }
}
