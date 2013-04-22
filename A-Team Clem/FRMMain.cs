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

namespace A_Team_Clem
{
    public partial class FRMMain : DevExpress.XtraEditors.XtraForm
    {
        public FRMMain()
        {
            InitializeComponent();
            strPathSkin = pathFolderSave + "\\" + skinFileName;

            conDB = new ConMySql();
        }

        private Modules.UCAddCustomerClem addCustomerCustomerClem;
        private Modules.UCReportCustomerClem customerReport;
        private Modules.UCAddEmployeeClem addEmployeeClem;
        private Modules.UCReportEmployeeClem employeeReport;
        private Modules.UCAddProduct addProduct;
        private Modules.UCAddCompany addCompany;
        private Modules.UCAddEmployee addEmployee;
        private Modules.UCAddCustomer addCustomer;
        private Modules.UCAddProductType addProductType;

        private string pathFolderSave = @"Files\save";
        private string skinFileName = "skin.txt";
        private string strPathSkin = "";
        public string strSkinName = "";
        public string formatDate = "dd/MM/yyyy";

        private ConMySql conDB;


        private void FRMMain_Load(object sender, EventArgs e)
        {
            addCustomerCustomerClem = new Modules.UCAddCustomerClem(this) { Dock = DockStyle.Fill };
            customerReport = new Modules.UCReportCustomerClem() { Dock = DockStyle.Fill };
            addEmployeeClem = new Modules.UCAddEmployeeClem() { Dock = DockStyle.Fill };
            employeeReport = new Modules.UCReportEmployeeClem() { Dock = DockStyle.Fill };
            addProduct = new Modules.UCAddProduct(this) { Dock = DockStyle.Fill };
            addCompany = new Modules.UCAddCompany(this) { Dock = DockStyle.Fill };
            addEmployee = new Modules.UCAddEmployee(this) { Dock = DockStyle.Fill };
            addCustomer = new Modules.UCAddCustomer(this) { Dock = DockStyle.Fill };
            addProductType = new Modules.UCAddProductType(this) { Dock = DockStyle.Fill };
        
            loadSkin();
            showAddCustomerClem();
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
            panelShowUserControl.Controls.Clear();
            panelShowUserControl.Controls.Add(customerReport);
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelShowUserControl.Controls.Clear();
            panelShowUserControl.Controls.Add(addEmployeeClem);
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
            panelShowUserControl.Controls.Clear();
            panelShowUserControl.Controls.Add(addCustomerCustomerClem);
        }

        public void showAddCustomer()
        {
            panelShowUserControl.Controls.Clear();
            panelShowUserControl.Controls.Add(addCustomer);
        }

        public void showAddProduct()
        {
            panelShowUserControl.Controls.Clear();
            panelShowUserControl.Controls.Add(addProduct);
        }

        public void showAddCompany()
        {
            panelShowUserControl.Controls.Clear();
            panelShowUserControl.Controls.Add(addCompany);
        }

        public void showAddProductType()
        {
            panelShowUserControl.Controls.Clear();
            panelShowUserControl.Controls.Add(addProductType);
        }

        public void showAddEmployee()
        {
            panelShowUserControl.Controls.Clear();
            panelShowUserControl.Controls.Add(addEmployee);
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