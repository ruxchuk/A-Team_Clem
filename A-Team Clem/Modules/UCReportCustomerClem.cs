using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;

namespace A_Team_Clem.Modules
{
    public partial class UCReportCustomerClem : DevExpress.XtraEditors.XtraUserControl
    {
        public UCReportCustomerClem(FRMMain mFRM)
        {
            InitializeComponent();
            fRMMain = mFRM;
            conDB = new ConMySql();
            convertDT = new ConvertDateTime();
        }

        private FRMMain fRMMain;
        private ConMySql conDB;
        private ConvertDateTime convertDT;

        public void readData()
        {
            conDB.name_th = customerName.Text;
            conDB.phone = phone.Text;
            conDB.serial = serial.Text;
            conDB.product_name_th = productName.Text;
            conDB.in_document_number_string = inDocumentNumber.Text;
            conDB.status = status.Text;
        }

        private void setDataGrid()
        {
        }

        public void getListClem()
        {
            readData();
            DataSet list = conDB.getListClem(fRMMain.addCustomerCustomerClem.clemType);
            gridControl1.DataSource = list.Tables["get_list_clem"];
            setDataGrid();
        }

        private void imgClear_MouseHover(object sender, EventArgs e)
        {
        }

        private void imgClear_MouseLeave(object sender, EventArgs e)
        {
        }

        private void UCReportCustomerClem_Load(object sender, EventArgs e)
        {
            getListClem();
        }

        private void imgSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
