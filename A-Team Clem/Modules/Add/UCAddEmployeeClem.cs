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

        private bool checkAddMRU = false;
        public int clem_id = 0;
        public int inDocumentNumberID = 0;

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
            //customerName.Text = dr["customer_name_th"].ToString();
            productType.Text = dr["product_type_name_th"].ToString();
            companyName.Text = dr["company_name_th"].ToString();

            productName.Text = dr["product_name"].ToString();
            serial.Text = dr["serial"].ToString();
            //address.Text = dr["address"].ToString();
            //phone.Text = dr["phone"].ToString();
            status.Text = dr["status"].ToString();
            dtProductEndDate.DateTime = DateTime.Parse(dr["date_product"].ToString());
            //if (dr["status"].ToString() == "ในประกัน")
            //{
            //    radioButtonInWarranty.Checked = true;
            //}
            //else
            //{
            //    radioButtonOutWarranty.Checked = true;
            //}
            //textEditChargebacks.Text = dr["chargebacks"].ToString();
            symptom.Text = dr["symptom"].ToString();
            equipment.Text = dr["equipment"].ToString();
            detail.Text = dr["detail"].ToString();
            inDocumentNumberID = int.Parse(dr["in_document_number_id"].ToString());

            inDocumentNumber.Text = dr["in_document_number_str"].ToString();
            outDocumentNumber.Text = dr["out_document_number"].ToString();
            //inSerialClem.Text = dr["in_serial_clem"].ToString();
            //outSerialClem.Text = dr["out_serial_clem"].ToString();
            //customerClem.Text = dr["customer_name_th"].ToString();
            //employeeReceiveClem.Text = dr["employee_receive_clem"].ToString();
            employeeClem.Text = dr["employee_clem"].ToString();
            companyReceiveClem.Text = dr["company_receive_clem"].ToString();
            companyReturn.Text = dr["company_return"].ToString();
            employeeReceiveProduct.Text = dr["employee_receive_product"].ToString();
            //employeeReturn.Text = dr["employee_return"].ToString();
            //customerReceiveProduct.Text = dr["customer_receive_product"].ToString();
            serial.Focus();
        }

        public void loadInDocumentNumber()
        {
            inDocumentNumber.Text = conDB.getNewIDDocumentNumber(clemType);
        }

        public void loadAllListData()
        {
            checkAddMRU = false;
            getProductType();
            getCompany();
            getEmployee();
            getProduct();
            checkAddMRU = true;
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
            conDB.address = "";
            conDB.phone = "";
            conDB.status = status.Text;
            conDB.date_create = convertDT.convert(DateTime.Now);
            conDB.date_product = convertDT.convert(dtProductEndDate.DateTime);
            conDB.date_stamp = convertDT.convert(DateTime.Now);
            conDB.chargebacks = 0;
            conDB.warranty = "";
            conDB.symptom = symptom.Text.Trim();
            conDB.equipment = equipment.Text.Trim();
            conDB.detail = detail.Text.Trim();

            if (fRMMain.typeOfEmployeeClem == "add")
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
            conDB.in_serial_clem = "";
            conDB.out_serial_clem = "";
            conDB.clem_type = clemType;
            conDB.customer_clem = "";
            conDB.employee_receive_clem = "";
            conDB.employee_clem = employeeClem.Text.Trim();
            conDB.company_receive_clem = companyReceiveClem.Text.Trim();
            conDB.company_return = companyReturn.Text.Trim();
            conDB.employee_receive_product = employeeReceiveProduct.Text.Trim();
            conDB.employee_return = "";
            conDB.customer_receive_product = "";

        }
        #endregion


        public void clearData()
        {
            //customerName.Text = "";
            //address.Text = "";
            //phone.Text = "";
            serial.Text = "";
            productName.Text = "";
            companyName.Text = "";
            productType.Text = "";
            dtProductEndDate.Text = "";
            inDocumentNumber.Text = conDB.getNewIDDocumentNumber(clemType);
            outDocumentNumber.Text = "";
            //inSerialClem.Text = "";
            //outSerialClem.Text = "";
            //customerClem.Text = "";
            //employeeReceiveClem.Text = "";
            employeeClem.Text = "";
            companyReceiveClem.Text = "";
            companyReturn.Text = "";
            employeeReceiveProduct.Text = "";
            //employeeReturn.Text = "";
            //customerReceiveProduct.Text = "";
            status.Text = "";
            //radioButtonInWarranty.Checked = true;
            //textEditChargebacks.Text = "0";
            symptom.Text = "";
            equipment.Text = "";
            detail.Text = "";
            serial.Focus();
        }

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
            if (fRMMain.typeOfEmployeeClem == "add")
            {
                int clemID = conDB.addClem(); 
                fRMMain.closeWaitingForm();
                if (clemID == 0)
                {
                    MessageBox.Show("การเพิ่มข้อมูลผิดพลาด");
                }
                else
                {
                    fRMMain.typeOfEmployeeClem = "edit";
                    getDataForEdit(clemID);
                }
            }
            else
            {
                resultAddClem = conDB.updateClemProduct(clem_id); 
                fRMMain.closeWaitingForm();
                if (!resultAddClem)
                {
                    MessageBox.Show("การแก้ไขข้อมูลผิดพลาด");
                }
            }
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
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            fRMMain.typeOfEmployeeClem = "add";
            labelControlPage.Text = "เพิ่มใบส่งเคลมสินค้า";
            clem_id = 0;
            clearData();
            buttonCancel.Visible = false;
            buttonCopy.Visible = false;
            buttonPrint.Visible = false;
            buttonDelete.Visible = false;
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            fRMMain.typeOfEmployeeClem = "add";
            labelControlPage.Text = "เพิ่มใบส่งเคลมสินค้า";
            inDocumentNumber.Text = conDB.getNewIDDocumentNumber(clemType);
            buttonCancel.Visible = false;
            buttonCopy.Visible = false;
            buttonPrint.Visible = false;
            buttonDelete.Visible = false;
            serial.Focus();
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

        private void buttonClear_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            bool resultValidateForm = validateForm();
            if (!resultValidateForm)
            {
                return;
            }
            fRMMain.showWaitingForm("กำลังทำการเปิดหน้าปริ้น");
            ReportPrintTool pt = new ReportPrintTool(new MiniReport());

            // Get the Print Tool's printing system.
            PrintingSystemBase ps = pt.PrintingSystem;

            fRMMain.showWaitingForm("กำลังทำการเปิดหน้าปริ้น");
            // Show a report's Print Preview.
            pt.ShowPreviewDialog();

            // Zoom the print preview, so that it fits the entire page.
            ps.ExecCommand(PrintingSystemCommand.ViewWholePage);

            // Invoke the Hand tool.
            ps.ExecCommand(PrintingSystemCommand.HandTool, new object[] { true });

            // Hide the Hand tool.
            ps.ExecCommand(PrintingSystemCommand.HandTool, new object[] { false });

        }

        private void productType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productType.SelectedIndex != -1)
            {
                conDB.product_type_id = searchIDFromList(listPorductType[1], listPorductType[0], productType.Text);
            }
            else
            {
                conDB.product_type_id = -1;
            }
        }


    }
}
