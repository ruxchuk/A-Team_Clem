using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Diagnostics;
using A_Team_Clem.Modules;
using DevExpress.LookAndFeel;

namespace A_Team_Clem
{
    public partial class FRMMain : DevExpress.XtraEditors.XtraForm
    {
        public FRMMain()
        {
            InitializeComponent();
            strPathSkin = pathFolderSave + "\\" + skinFileName;
            showWaitingForm("กำลังทำการเปิดโปรแกรม");
            conDB = new ConMySql();
        }

        public UCAddCustomerClem addCustomerClem;
        public UCReportCustomerClem customerReport;
        public UCAddEmployeeClem addEmployeeClem;
        public UCReportEmployeeClem employeeReport;
        public UCAddProduct addProduct;
        public UCAddCompany addCompany;
        public UCAddEmployee addEmployee;
        public UCAddCustomer addCustomer;
        public UCAddProductType addProductType;


        private string pathFolderSave = @"Files\save";
        private string skinFileName = "skin.txt";
        private string strPathSkin = "";
        public string strSkinName = "";
        public string formatDate = "dd/MM/yyyy";
        public string typeOfClemProduct = "add";

        private ConMySql conDB;
        public string curPage = "";
        public string oldPage = "";

        private void FRMMain_Load(object sender, EventArgs e)
        {
            addCustomerClem = new UCAddCustomerClem(this) { Dock = DockStyle.Fill }; 
            customerReport = new UCReportCustomerClem(this) { Dock = DockStyle.Fill };
            addEmployeeClem = new UCAddEmployeeClem(this) { Dock = DockStyle.Fill };
            employeeReport = new UCReportEmployeeClem() { Dock = DockStyle.Fill };
            addProduct = new UCAddProduct(this) { Dock = DockStyle.Fill };
            addCompany = new UCAddCompany(this) { Dock = DockStyle.Fill };
            addEmployee = new UCAddEmployee(this) { Dock = DockStyle.Fill };
            addCustomer = new UCAddCustomer(this) { Dock = DockStyle.Fill };
            addProductType = new UCAddProductType(this) { Dock = DockStyle.Fill };
        
            loadSkin();


            closeWaitingForm();
            showAddCustomerClem();


            panelShowUserControl.Appearance.BackColor = Color.Aqua;
            panelShowUserControl.Appearance.BackColor2 = Color.Aqua;
            panelShowUserControl.Appearance.Options.UseBackColor = true;

            //panelShowUserControl.LookAndFeel.UseDefaultLookAndFeel = false;
            //panelShowUserControl.LookAndFeel.Style = LookAndFeelStyle.Flat;
        }

        private void loadSkin()
        {
            //check folder
            bool IsExists = Directory.Exists(pathFolderSave);
            if (!IsExists)
                Directory.CreateDirectory(pathFolderSave);

            try
            {
                //openFileDialog1.FileName = strPathSkin;
                StreamReader stR = File.OpenText(strPathSkin);
                strSkinName = stR.ReadLine();
                stR.Close();
            }
            catch
            {
                //saveFileDialog1.FileName = strPathSkin;
                StreamWriter stW = File.CreateText(strPathSkin);
                stW.WriteLine("Glass Oceans");
                strSkinName = "Glass Oceans";
                stW.Close();
            }
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(strSkinName);
        }

        public void showWaitingForm(string message)
        {
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormCaption(message);
            splashScreenManager1.SetWaitFormDescription("กรุณารอสักครู่");
        }

        public void changPage(string goTo = "back")
        {
            if (goTo == "back")
            {
                selectPage(oldPage);
            }
            else
            {
                selectPage(curPage);
            }
        }

        public void selectPage(string page)
        {
            switch (page)
            {
                case "UCAddCompany":
                    showAddCompany();
                    break;
                case "UCAddCustomer":
                    showAddCustomer();
                    break;
                case "UCAddCustomerClem":
                    showAddCustomerClem();
                    break;
                case "UCAddEmployee":
                    showAddEmployee();
                    break;
                case "UCAddEmployeeClem":
                    showAddEmployeeClem();
                    break;
                case "UCAddProduct":
                    showAddProduct();
                    break;
                case "UCAddProductType":
                    showAddProductType();
                    break;
                case "UCReportCustomerClem":
                    showCustomerClemReport();
                    break;
                case "UCReportEmployeeClem":
                    showEmployeeClemReport();
                    break;
                default:
                    break;
            }
        }

        //public void focusInputCustomerClem()
        //{
        //    switch (oldPage)
        //    {
        //        case "UCAddCompany":
        //            addCustomerClem.companyName.Focus();
        //            break;
        //        case "UCAddCustomer":
        //            addCustomerClem.customerName.Focus();
        //            break;
        //        case "UCAddEmployee":
        //            addCustomerClem.employeeClem.Focus();
        //            break;
        //        case "UCAddProduct":
        //            addCustomerClem.productName.Focus();
        //            break;
        //        case "UCAddProductType":
        //            addCustomerClem.productType.Focus();
        //            break;
        //        default:
        //            break;
        //    }
        //}

        //public void focusInputEmployeeClem()
        //{
        //    switch (oldPage)
        //    {
        //        case "UCAddCompany":
        //            addEmployeeClem.companyName.Focus();
        //            break;
        //        case "UCAddEmployee":
        //            addEmployeeClem.employeeClem.Focus();
        //            break;
        //        case "UCAddProduct":
        //            addEmployeeClem.productName.Focus();
        //            break;
        //        case "UCAddProductType":
        //            addEmployeeClem.productType.Focus();
        //            break;
        //        default:
        //            break;
        //    }
        //}

        public void closeWaitingForm()
        {
            splashScreenManager1.CloseWaitForm();
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {            
            showAddCustomerClem();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            showCustomerClemReport();
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            showAddEmployeeClem();
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FRMChooseSkin skin = new FRMChooseSkin(this, strSkinName, strPathSkin);
            skin.ShowDialog();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Debug.WriteLine(conDB.pathFileDB);
            FRMSettingConDB settingDB = new FRMSettingConDB(conDB.pathFileDB);
            settingDB.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //DialogResult resultMsg = MessageBox.Show("ต้องการออกจากโปรแกรม ใช่ หรือไม่", "ออกจากโปรแกรม", 
            //    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            Close();
        }

        public void showAddCustomerClem()
        {
            oldPage = curPage;
            curPage = "UCAddCustomerClem";
            showWaitingForm("กำลังทำการโหลดข้อมูล");
            if (typeOfClemProduct == "edit")
            {
                addCustomerClem.labelControlPage.Text = "แก้ไขใบรับเคลม/ใบส่งเคลมสินค้า";
                //addCustomerClem.getDataForEdit(customerReport.clemID);
            }
            else
            {
                addCustomerClem.loadInDocumentNumber();
                addCustomerClem.labelControlPage.Text = "เพิ่มใบรับเคลม/ใบส่งเคลมสินค้า";
            }
            addCustomerClem.loadAllListData();
            panelShowUserControl.Controls.Clear();
            panelShowUserControl.Controls.Add(addCustomerClem);
            addCustomerClem.customerName.Focus();
            closeWaitingForm();
        }

        public void showCustomerClemReport()
        {
            oldPage = curPage;
            curPage = "UCReportCustomerClem";

            showWaitingForm("กำลังทำการเปิดรายงาน");

            panelShowUserControl.Controls.Clear();
            panelShowUserControl.Controls.Add(customerReport);
            if (customerReport.customerName.Text == "" &&
                customerReport.phone.Text == "" &&
                customerReport.serial.Text == "" &&
                customerReport.productName.Text == "" &&
                customerReport.inDocumentNumber.Text == "" &&
                customerReport.status.Text == ""
                )
            {
                customerReport.getListClem();
            }

            customerReport.customerName.Focus();
            closeWaitingForm();
        }

        public void showAddEmployeeClem()
        {
            oldPage = curPage;
            curPage = "UCAddEmployeeClem";

            addEmployeeClem.loadAllListData();
            panelShowUserControl.Controls.Clear();
            panelShowUserControl.Controls.Add(addEmployeeClem);
            addEmployeeClem.serial.Focus();
        }

        public void showAddCustomer()
        {
            oldPage = curPage;
            curPage = "UCAddCustomer";

            panelShowUserControl.Controls.Clear();
            panelShowUserControl.Controls.Add(addCustomer);
            addCustomer.Focus();
        }

        public void showAddProduct()
        {
            oldPage = curPage;
            curPage = "UCAddProduct";

            panelShowUserControl.Controls.Clear();
            panelShowUserControl.Controls.Add(addProduct);
            addProduct.nameTH.Focus();
        }

        public void showAddCompany()
        {
            oldPage = curPage;
            curPage = "UCAddCompany";

            panelShowUserControl.Controls.Clear();
            panelShowUserControl.Controls.Add(addCompany);
            addCompany.nameTH.Focus();
        }

        public void showAddProductType()
        {
            oldPage = curPage;
            curPage = "UCAddProductType";

            panelShowUserControl.Controls.Clear();
            panelShowUserControl.Controls.Add(addProductType);
            addProductType.nameTH.Focus();
        }

        public void showAddEmployee()
        {
            oldPage = curPage;
            curPage = "UCAddEmployee";

            panelShowUserControl.Controls.Clear();
            panelShowUserControl.Controls.Add(addEmployee);
            addEmployee.nameTH.Focus();
        }

        public void showEmployeeClemReport()
        {
            oldPage = curPage;
            curPage = "UCReportEmployeeClem";

            panelShowUserControl.Controls.Clear();
            panelShowUserControl.Controls.Add(employeeReport);
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            showAddCustomer();
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            showAddCompany();
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            showAddEmployee();
        }

        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            showAddProduct();
        }

        private void navBarItem13_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            showAddProductType();
        }

    }
}