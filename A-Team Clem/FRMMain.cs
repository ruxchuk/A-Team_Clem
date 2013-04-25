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

namespace A_Team_Clem
{
    public partial class FRMMain : DevExpress.XtraEditors.XtraForm
    {
        public FRMMain()
        {
            InitializeComponent();
            strPathSkin = pathFolderSave + "\\" + skinFileName;

            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormCaption("กำลังทำการเปิดโปรแกรม");
            splashScreenManager1.SetWaitFormDescription("กรุณารอสักครู่");
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
            showAddCustomerClem();

            splashScreenManager1.CloseWaitForm();
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
            panelShowUserControl.Controls.Clear();
            panelShowUserControl.Controls.Add(employeeReport);
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
            if (typeOfClemProduct == "edit")
            {
                addCustomerClem.labelControlPage.Text = "แก้ไขใบรับเคลม/ใบส่งเคลมสินค้า";
                addCustomerClem.getDataForEdit(customerReport.clemID);
            }
            else
            {
                addCustomerClem.labelControlPage.Text = "เพิ่มใบรับเคลม/ใบส่งเคลมสินค้า";
            }
            addCustomerClem.loadAllListData();
            panelShowUserControl.Controls.Clear();
            panelShowUserControl.Controls.Add(addCustomerClem);
            addCustomerClem.customerName.Focus();
        }

        public void showCustomerClemReport()
        {
            //splashScreenManager1.ShowWaitForm();
            //splashScreenManager1.SetWaitFormCaption("กำลังทำการเปิดรายงาน");
            //splashScreenManager1.SetWaitFormDescription("กรุณารอสักครู่");

            panelShowUserControl.Controls.Clear();
            //customerReport.Dispose();
            //customerReport = new UCReportCustomerClem(this) { Dock = DockStyle.Fill };
            panelShowUserControl.Controls.Add(customerReport);
            customerReport.customerName.Focus();
            //splashScreenManager1.CloseWaitForm();
        }

        public void showAddEmployeeClem()
        {
            addEmployeeClem.loadAllListData();
            panelShowUserControl.Controls.Clear();
            panelShowUserControl.Controls.Add(addEmployeeClem);
            addEmployeeClem.serial.Focus();
        }

        public void showAddCustomer()
        {
            panelShowUserControl.Controls.Clear();
            panelShowUserControl.Controls.Add(addCustomer);
            addCustomer.Focus();
        }

        public void showAddProduct()
        {
            panelShowUserControl.Controls.Clear();
            panelShowUserControl.Controls.Add(addProduct);
            addProduct.nameTH.Focus();
        }

        public void showAddCompany()
        {
            panelShowUserControl.Controls.Clear();
            panelShowUserControl.Controls.Add(addCompany);
            addCompany.nameTH.Focus();
        }

        public void showAddProductType()
        {
            panelShowUserControl.Controls.Clear();
            panelShowUserControl.Controls.Add(addProductType);
            addProductType.nameTH.Focus();
        }

        public void showAddEmployee()
        {
            panelShowUserControl.Controls.Clear();
            panelShowUserControl.Controls.Add(addEmployee);
            addEmployee.nameTH.Focus();
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