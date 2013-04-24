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
            //getEmployee();
            getProduct();
            loadInDocumentNumber();
            //getCustomer();
        }

        //private void getCustomer()
        //{
        //    listCustomer = null;
        //    listCustomer = conDB.getCustomer();
        //    if (listPorductType != null)
        //    {
        //        customerName.Properties.Items.AddRange(listCustomer[1]);
        //        customerReceiveProduct.Properties.Items.AddRange(listCustomer[1]);
        //    }
        //}

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

        //private void getEmployee()
        //{
        //    listEmployee = null;
        //    listEmployee = conDB.getEmployee();
        //    if (listEmployee != null)
        //    {
        //        employeeReceiveClem.Properties.Items.AddRange(listEmployee[1]);
        //        employeeClem.Properties.Items.AddRange(listEmployee[1]);
        //        employeeReceiveProduct.Properties.Items.AddRange(listEmployee[1]);
        //        employeeReturn.Properties.Items.AddRange(listEmployee[1]);
        //    }
        //}

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

        private void simpleButtonAddClem_Click(object sender, EventArgs e)
        {

        }
    }
}
