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

            Debug.WriteLine(conDB.getNewIDClemOfMonth(clemType));
        }

        #region load data
        public void loadInDocumentNumber()
        {
            inDocumentNumber.Text = conDB.getNewIDDocumentNumber(clemType);
        }

        public void getDataForEdit(int clemID)
        {
            //clearData();
            fRMMain.typeOfClemProduct = "edit";
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
            Debug.WriteLine(inDocumentNumber.Text);
            outDocumentNumber.Text = dr["out_document_number"].ToString();
            inSerialClem.Text = dr["in_serial_clem"].ToString();
            outSerialClem.Text = dr["out_serial_clem"].ToString();
            customerClem.Text = dr["customer_name_th"].ToString();
            employeeReceiveClem.Text = dr["employee_receive_product"].ToString();
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
            else
            {
                conDB.customer_id = int.Parse(listCustomer[0][customerName.SelectedIndex]);
            }

            if (productType.SelectedIndex < 0)
            {
                conDB.product_type_name_th = productType.Text.Trim();
                conDB.product_type_name_en = "";
                conDB.product_type_date_create = convertDT.convert(DateTime.Now);
                conDB.product_type_date_stamp = convertDT.convert(DateTime.Now);
                conDB.product_type_id = conDB.addProductType();
            }
            else
            {
                conDB.product_type_id = int.Parse(listPorductType[0][productType.SelectedIndex]);
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
            else
            {
                conDB.company_id = int.Parse(listCompany[0][companyName.SelectedIndex]);
            }

            if (productName.SelectedIndex < 0)
            {
                conDB.product_name_th = productName.Text.Trim();
                conDB.product_name_en = "";
                conDB.product_price = 0;
                conDB.product_value = "";
                conDB.product_date_create = convertDT.convert(DateTime.Now);
                conDB.product_date_stamp = convertDT.convert(DateTime.Now);
                conDB.product_id = conDB.addProduct();
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

            if (fRMMain.typeOfClemProduct == "add")
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

            readData();
            bool resultAddClem;
            if (fRMMain.typeOfClemProduct == "add")
            {
                resultAddClem = conDB.addClem();
            }
            else
            {
                resultAddClem = conDB.updateClemProduct(clem_id);
                Debug.WriteLine("updated");
            }
            if (resultAddClem)
            {
                clearData();
                fRMMain.typeOfClemProduct = "add";
                //
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

        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customerName.SelectedIndex != -1)
            {
                address.Text = listCustomer[3][customerName.SelectedIndex];
                customerClem.Text = listCustomer[1][customerName.SelectedIndex];
                phone.Text = listCustomer[4][customerName.SelectedIndex];
            }
            else
            {

            }
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

            ReportPrintTool pt = new ReportPrintTool(new MiniReport());

            // Get the Print Tool's printing system.
            PrintingSystemBase ps = pt.PrintingSystem;

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


        #region keydown enter
        private void customerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                address.Focus();
            }
        }

        Keys oldKeyAddress;
        private void address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && oldKeyAddress == Keys.Return)
            {
                phone.Focus();
                oldKeyAddress = Keys.D1;
            }
            else
                oldKeyAddress = e.KeyCode;
        }

        private void phone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                serial.Focus();
            }
        }

        private void serial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                productName.Focus();
            }
        }

        private void productName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                companyName.Focus();
            }
        }

        private void companyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                productType.Focus();
            }
        }

        private void productType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                dtProductEndDate.Focus();
            }
        }

        private void dtProductEndDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                outDocumentNumber.Focus();
            }
        }

        private void outDocumentNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                inSerialClem.Focus();
            }
        }

        private void inSerialClem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                outSerialClem.Focus();
            }
        }

        private void outSerialClem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                employeeReceiveClem.Focus();
            }
        }

        private void employeeReceiveClem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                employeeClem.Focus();
            }
        }

        private void employeeClem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                companyReceiveClem.Focus();
            }
        }

        private void companyReceiveClem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                companyReturn.Focus();
            }
        }

        private void companyReturn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                employeeReceiveProduct.Focus();
            }
        }

        private void employeeReceiveProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                employeeReturn.Focus();
            }
        }

        private void employeeReturn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                customerReceiveProduct.Focus();
            }
        }

        private void customerReceiveProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                status.Focus();
            }
        }

        private void status_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                radioButtonInWarranty.Focus();
            }
        }

        private void radioButtonInWarranty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                symptom.Focus();
            }
        }

        Keys oldKeySymptom;
        private void symptom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && oldKeySymptom == Keys.Return)
            {
                equipment.Focus();
                oldKeySymptom = Keys.D0;
            }
            else oldKeySymptom = e.KeyCode;
        }

        Keys oldKeyEquipment;
        private void equipment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && oldKeyEquipment == Keys.Return)
            {
                detail.Focus();
                oldKeyEquipment = Keys.D0;
            }
            else oldKeyEquipment = e.KeyCode;
        }

        Keys oldKeyDetail;
        private void detail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && oldKeyDetail == Keys.Return)
            {
                simpleButtonAddClem_Click(EventArgs.Empty, null);
                oldKeyDetail = Keys.D0;
            }
            else oldKeyDetail = e.KeyCode;
        }
#endregion

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            fRMMain.typeOfClemProduct = "add";
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
            fRMMain.typeOfClemProduct = "add";
            labelControlPage.Text = "เพิ่มใบรับเคลม/ใบส่งเคลมสินค้า";
            buttonCancel.Visible = false;
            buttonCopy.Visible = false;
            buttonPrint.Visible = false;
            buttonDelete.Visible = false;

        }
    }
}
