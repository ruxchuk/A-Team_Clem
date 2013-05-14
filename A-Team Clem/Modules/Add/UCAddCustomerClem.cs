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
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using DevExpress.XtraEditors.Mask;

namespace A_Team_Clem.Modules
{
    public partial class UCAddCustomerClem : DevExpress.XtraEditors.XtraUserControl
    {
        private ConMySql conDB;
        private ConvertDateTime convertDT;
        private FRMMain fRMMain;

        public string clemType = "ใบรับเคลม/ใบส่งเคลม";

        public List<string>[] listCustomer;
        public List<string>[] listPorductType;
        public List<string>[] listCompany;
        public List<string>[] listEmployee;
        public List<string>[] listProduct;
        public List<string>[] listProductType;

        private bool checkAddMRU = false;
        public int clem_id = 0;
        public int inDocumentNumberID = 0;

        public UCAddCustomerClem(FRMMain mFRM)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            InitializeComponent();
            fRMMain = mFRM;
            conDB = new ConMySql();
            convertDT = new ConvertDateTime();

            //set รูปแบบวันที่
            dtProductEndDate.Properties.DisplayFormat.FormatString = fRMMain.formatDate;
            dtProductEndDate.Properties.Mask.EditMask = fRMMain.formatDate;

            textEditChargebacks.Properties.Mask.MaskType = MaskType.Numeric;
            textEditChargebacks.Properties.Mask.EditMask = "n";
        }

        #region load data
        public void loadInDocumentNumber()
        {
            inDocumentNumber.Text = conDB.getNewIDDocumentNumber(clemType);
        }

        public void getDataForEdit(int clemID)
        {
            //clearData();
            clem_id = clemID;

            conDB.name_th = "";
            conDB.phone = "";
            conDB.serial = "";
            conDB.product_name_th = "";
            conDB.in_document_number_string = "";
            conDB.status = "";

            DataSet ds = conDB.getListClem(clemType, clemID);
            DataRow dr = ds.Tables["get_list_clem"].Rows[0];
            customerName.Text = dr["customer_name_th"].ToString();
            productType.Text = dr["product_type_name_th"].ToString();
            companyName.Text = dr["company_name_th"].ToString();

            productName.Text = dr["product_name"].ToString();
            serial.Text = dr["serial"].ToString();
            address.Text = dr["address"].ToString();
            phone.Text = dr["phone"].ToString();
            status.Text = dr["status"].ToString();
            dtProductEndDate.DateTime = DateTime.Parse(dr["date_product"].ToString());
            if (dr["status"].ToString() == "ในประกัน")
            {
                radioButtonInWarranty.Checked = true;
            }
            else
            {
                radioButtonOutWarranty.Checked = true;
            }
            textEditChargebacks.Text = dr["chargebacks"].ToString();
            symptom.Text = dr["symptom"].ToString();
            equipment.Text = dr["equipment"].ToString();
            detail.Text = dr["detail"].ToString();
            inDocumentNumberID = int.Parse(dr["in_document_number_id"].ToString());

            inDocumentNumber.Text = dr["in_document_number_str"].ToString();
            outDocumentNumber.Text = dr["out_document_number"].ToString();
            inSerialClem.Text = dr["in_serial_clem"].ToString();
            outSerialClem.Text = dr["out_serial_clem"].ToString();
            customerClem.Text = dr["customer_name_th"].ToString();
            employeeReceiveClem.Text = dr["employee_receive_clem"].ToString();
            employeeClem.Text = dr["employee_clem"].ToString();
            companyReceiveClem.Text = dr["company_receive_clem"].ToString();
            companyReturn.Text = dr["company_return"].ToString();
            employeeReceiveProduct.Text = dr["employee_receive_product"].ToString();
            employeeReturn.Text = dr["employee_return"].ToString();
            customerReceiveProduct.Text = dr["customer_receive_product"].ToString();
            customerName.Focus();
        }

        public void loadAllListData()
        {
            checkAddMRU = false;
            getProductType(); 
            getCompany(); 
            getEmployee();
            getProduct();
            getCustomer();
            checkAddMRU = true;
        }

        private void getCustomer()
        {
            listCustomer = null;
            listCustomer = conDB.getCustomer();
            if (listPorductType != null)
            {
                customerName.Properties.Items.AddRange(listCustomer[1]);
                customerReceiveProduct.Properties.Items.AddRange(listCustomer[1]);
            }
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
            conDB.company_name_th = "";
            conDB.company_phone = "";
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
                employeeReceiveClem.Properties.Items.AddRange(listEmployee[1]);
                employeeClem.Properties.Items.AddRange(listEmployee[1]);
                employeeReceiveProduct.Properties.Items.AddRange(listEmployee[1]);
                employeeReturn.Properties.Items.AddRange(listEmployee[1]);
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
            if (customerName.Text == "")
            {
                MessageBox.Show("กรุณากรอกชื่อลูกค้า");
                customerName.Select();
                return false;
            }
            else if (phone.Text == "")
            {
                MessageBox.Show("กรุณากรอกเบอร์โทรลูกค้า");
                phone.Select();
                return false;
            }
            else if (productName.Text == "")
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
            else if (employeeReceiveClem.Text == "")
            {
                MessageBox.Show("กรุณากรอกชื่อพนักงานที่รับเคลมสินค้า");
                employeeReceiveClem.Select();
                return false;
            }
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
            if (customerName.SelectedIndex < 0)
            {
                conDB.name_th = customerName.Text.Trim();
                conDB.name_en = "";
                conDB.address = address.Text.Trim();
                conDB.phone = phone.Text.Trim();
                conDB.email = "";
                conDB.customer_date_create = convertDT.convert(DateTime.Now);
                conDB.customer_date_stamp = convertDT.convert(DateTime.Now);
                conDB.customer_id = conDB.addCustomer();
            }

            if (productName.SelectedText == "")
            {
                conDB.product_name_th = productName.Text.Trim();
                conDB.product_name_en = "";
                conDB.product_price = 0;
                conDB.product_value = "";
                conDB.product_date_create = convertDT.convert(DateTime.Now);
                conDB.product_date_stamp = convertDT.convert(DateTime.Now);
                conDB.product_id = conDB.addProduct();
            }

            if (companyName.SelectedIndex < 0)
            {
                conDB.company_name_th = companyName.Text.Trim();
                conDB.company_name_en = "";
                conDB.company_adddress = "";
                conDB.company_phone = "";
                conDB.company_email = "";
                conDB.company_date_create = convertDT.convert(DateTime.Now);
                conDB.company_date_stamp = convertDT.convert(DateTime.Now);
                conDB.company_id = conDB.addCompany();
            }

            if (productType.SelectedIndex < 0)
            {
                conDB.product_type_name_th = productType.Text.Trim();
                conDB.product_type_name_en = "";
                conDB.product_type_date_create = convertDT.convert(DateTime.Now);
                conDB.product_type_date_stamp = convertDT.convert(DateTime.Now);
                conDB.product_type_id = conDB.addProductType();
            }

            conDB.product_name = productName.Text.Trim();
            conDB.serial = serial.Text.Trim();
            conDB.address = address.Text.Trim();
            conDB.phone = phone.Text.Trim();
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
            conDB.symptom = symptom.Text.Trim();
            conDB.equipment = equipment.Text.Trim();
            conDB.detail = detail.Text.Trim();

            if (fRMMain.typeOfCustomerClem == "add")
            {
                conDB.in_document_number_id = conDB.getNewIDClemOfMonth(clemType);
            }
            else
            {
                conDB.in_document_number_id = conDB.getNewIDClemOfMonth(clemType);
            }
            conDB.in_document_number = convertDT.convert(DateTime.Now);
            conDB.in_document_number_string = inDocumentNumber.Text;

            conDB.out_document_number = outDocumentNumber.Text.Trim();
            conDB.in_serial_clem = inSerialClem.Text.Trim();
            conDB.out_serial_clem = outSerialClem.Text.Trim();
            conDB.clem_type = clemType;
            conDB.customer_clem = customerClem.Text.Trim();
            conDB.employee_receive_clem = employeeReceiveClem.Text.Trim();
            conDB.employee_clem = employeeClem.Text.Trim();
            conDB.company_receive_clem = companyReceiveClem.Text.Trim();
            conDB.company_return = companyReturn.Text.Trim();
            conDB.employee_receive_product = employeeReceiveProduct.Text.Trim();
            conDB.employee_return = employeeReturn.Text.Trim();
            conDB.customer_receive_product = customerReceiveProduct.Text.Trim();

        }
        #endregion

        private void simpleButtonAddClem_Click(object sender, EventArgs e)
        {
            bool resultValidateForm = validateForm();
            if (!resultValidateForm)
            {
                return;
            }
            fRMMain.showWaitingForm("กำลังทำการบันทึกข้อมูล");
            readData();
            bool resultAddClem;
            if (fRMMain.typeOfCustomerClem == "add")
            {
                resultAddClem = conDB.addClem();
            }
            else
            {
                resultAddClem = conDB.updateClemProduct(clem_id);
            }
            fRMMain.closeWaitingForm();
            if (resultAddClem)
            {
                clearData();
                fRMMain.typeOfCustomerClem = "add";
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
            fRMMain.showAddCustomer();
        }

        private void imgAddProduct_Click(object sender, EventArgs e)
        {
            fRMMain.showAddProduct();
        }

        private void imgAddCompany_Click(object sender, EventArgs e)
        {
            fRMMain.showAddCompany();
        }

        private void imgAddTypeProduct_Click(object sender, EventArgs e)
        {
            fRMMain.showAddProductType();
        }

        private void imgAddEmployee_Click(object sender, EventArgs e)
        {
            fRMMain.showAddEmployee();
        }

        public void clearData()
        {
            customerName.Text = "";
            address.Text = "";
            phone.Text = "";
            serial.Text = "";
            productName.Text = "";
            companyName.Text = "";
            productType.Text = "";
            dtProductEndDate.Text = "";
            inDocumentNumber.Text = conDB.getNewIDDocumentNumber(clemType);
            outDocumentNumber.Text = "";
            inSerialClem.Text = "";
            outSerialClem.Text = "";
            customerClem.Text = "";
            employeeReceiveClem.Text = "";
            employeeClem.Text = "";
            companyReceiveClem.Text = "";
            companyReturn.Text = "";
            employeeReceiveProduct.Text = "";
            employeeReturn.Text = "";
            customerReceiveProduct.Text = "";
            status.Text = "";
            radioButtonInWarranty.Checked = true;
            textEditChargebacks.Text = "0";
            symptom.Text = "";
            equipment.Text = "";
            detail.Text = "";
            customerName.Focus();
        }

        private void customerName_AddingMRUItem(object sender, DevExpress.XtraEditors.Controls.AddingMRUItemEventArgs e)
        {
            e.Cancel = checkAddMRU;
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            bool resultValidateForm = validateForm();
            if (!resultValidateForm)
            {
                return;
            }
            MiniReport mini = new MiniReport();

            mini.dateTimeThai.Text = "";
            mini.inDocumentNumber.Text = inDocumentNumber.Text;
            mini.customerName.Text = customerName.Text;
            mini.address.Text = address.Text;
            mini.phone.Text = phone.Text;
            mini.productName.Text = productName.Text;
            mini.company.Text = companyName.Text;
            mini.productType.Text = productType.Text;
            mini.dtProductEndDate.Text = dtProductEndDate.Text;
            if (radioButtonInWarranty.Checked)
            {
                mini.warranty.Text = "ในประกัน";
            mini.chargebacks.Text = "0";
            }
            else
            {
                mini.warranty.Text = "นอกประกัน";
                mini.chargebacks.Text = textEditChargebacks.Text;
            }
            mini.symptom.Text = symptom.Text.Trim() == "" ? "-" : symptom.Text.Trim();
            mini.equipment.Text = equipment.Text.Trim() == "" ? "-" : equipment.Text.Trim();
            mini.detail2.Text = detail.Text.Trim() == "" ? "-" : detail.Text.Trim();

            fRMMain.showWaitingForm("กำลังทำการเปิดหน้าปริ้น");
            ReportPrintTool pt = new ReportPrintTool(mini);

            // Get the Print Tool's printing system.
            PrintingSystemBase ps = pt.PrintingSystem;
            fRMMain.closeWaitingForm();

            // Show a report's Print Preview.
            pt.ShowPreviewDialog();

            // Zoom the print preview, so that it fits the entire page.
            ps.ExecCommand(PrintingSystemCommand.ViewWholePage);

            // Invoke the Hand tool.
            ps.ExecCommand(PrintingSystemCommand.HandTool, new object[] { true });

            // Hide the Hand tool.
            ps.ExecCommand(PrintingSystemCommand.HandTool, new object[] { false });
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            fRMMain.typeOfCustomerClem = "add";
            labelControlPage.Text = "เพิ่มใบรับเคลม/ใบส่งเคลมสินค้า";
            clem_id = 0;
            clearData();
            buttonCancel.Visible = false;
            buttonCopy.Visible = false;
            buttonPrint.Visible = false;
            buttonDelete.Visible = false;
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            fRMMain.typeOfCustomerClem = "add";
            labelControlPage.Text = "เพิ่มใบรับเคลม/ใบส่งเคลมสินค้า";
            inDocumentNumber.Text = conDB.getNewIDDocumentNumber(clemType);
            buttonCancel.Visible = false;
            buttonCopy.Visible = false;
            buttonPrint.Visible = false;
            buttonDelete.Visible = false;
            customerName.Focus();
        }

        //ค้นหา ID จาก ชื่อใน List
        public int searchIDFromList(List<string> arrData, List<string> arrID, string strSearch)
        {
            for (int i = 0; i < arrData.Count; i++)
            {
                if (strSearch == arrData[i])
                {
                    return int.Parse(arrID[i]);
                }
            }
            return -1;
        }

        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (customerName.SelectedIndex != -1)
            {
                conDB.customer_id = searchIDFromList(listCustomer[1], listCustomer[0], customerName.Text);
                for (int i = 0; i < listCustomer[0].Count; i++)
                {
                    if (int.Parse(listCustomer[0][i]) == conDB.customer_id)
                    {
                        address.Text = listCustomer[3][i];
                        phone.Text = listCustomer[4][i];
                    }
                }
            }
            else
            {
                conDB.customer_id = -1;
                address.Text = "";
                phone.Text = "";
            }
        }

        private void productName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productName.SelectedIndex != -1)
            {
                conDB.product_id = searchIDFromList(listProduct[1], listProduct[0], productName.Text);
            }
            else
            {
                conDB.product_id = -1;
            }
        }

        private void companyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (companyName.SelectedIndex != -1)
            {
                conDB.company_id = searchIDFromList(listCompany[1], listCompany[0], companyName.Text);
            }
            else
            {
                conDB.company_id = -1;
            }
        }

        private void customerName_TextChanged(object sender, EventArgs e)
        {
            customerClem.Text = customerName.Text;
        }  
    }
}
