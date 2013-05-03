using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;

namespace A_Team_Clem
{
    public partial class UCListCompany : DevExpress.XtraEditors.XtraUserControl
    {
        private FRMMain fRMMain;
        private ConMySql conDB;
        private List<string>[] listCompany;
        private bool checkAddMRU = false;

        public UCListCompany(FRMMain fRMMain)
        {
            // TODO: Complete member initialization
            this.fRMMain = fRMMain;
            InitializeComponent();
            conDB = new ConMySql();
            //listCompany = conDB.getCompany();
        }

        private void loadData()
        {
            checkAddMRU = false;
            nameTH.Properties.Items.AddRange(fRMMain.addCustomerClem.listCustomer[1]);
            nameTH.Properties.Items.AddRange(fRMMain.addCustomerClem.listProduct[1]);
            checkAddMRU = true;
        }

        public void readData()
        {
            conDB.company_name_th = nameTH.Text;
            conDB.company_phone = phone.Text;
        }

        public void getListCompany()
        {
            readData();
            gridControl1.DataSource = conDB.getCompany();
            //setGridView();
            loadData();
            
            nameTH.Focus();
        }

        private void setGridView()
        {
            gridView1.Columns["id"].Caption = "ID ใบเคลม";
            gridView1.Columns["customer_name_th"].Caption = "ชื่อลูกค้า";
            gridView1.Columns["address"].Caption = "ที่อยู่";
            gridView1.Columns["phone"].Caption = "เบอร์โทรศัพท์";
            gridView1.Columns["serial"].Caption = "Serial";
            gridView1.Columns["status"].Caption = "สถานะ";
            gridView1.Columns["product_name"].Caption = "ชื่อสินค้า";
            gridView1.Columns["company_name_th"].Caption = "บริษัท";
            gridView1.Columns["product_type_name_th"].Caption = "ชนิดสินค้า";
            gridView1.Columns["date_product"].Caption = "วันหมดอายุ";
            gridView1.Columns["date_product"].DisplayFormat.FormatType = FormatType.DateTime;
            gridView1.Columns["date_product"].DisplayFormat.FormatString = fRMMain.formatDate;
            gridView1.Columns["in_document_number_str"].Caption = "เลขที่เอกสารภายใน";
            gridView1.Columns["out_document_number"].Caption = "เลขที่เอกสารภายนอก";
            gridView1.Columns["in_serial_clem"].Caption = "เลขที่เลขที่ใบรับเคลมภายใน";
            gridView1.Columns["out_serial_clem"].Caption = "เลขที่เลขที่ใบรับเคลมภายนอก";
            gridView1.Columns["customer_clem"].Caption = "1. ลูกค้า-ผู้ส่งเคลม";
            gridView1.Columns["employee_receive_clem"].Caption = "2. พนักงาน-ผู้รับเคลม";
            gridView1.Columns["employee_clem"].Caption = "3. พนักงาน-ผู้ส่งเคลม";
            gridView1.Columns["company_receive_clem"].Caption = "4. บริษัท-ผู้รับเคลม";
            gridView1.Columns["company_return"].Caption = "5. บริษัท-ผู้คืนของ";
            gridView1.Columns["employee_receive_product"].Caption = "6. พนักงาน-ผู้รับของ";
            gridView1.Columns["employee_return"].Caption = "7. พนักงาน-ผู้คืนของ";
            gridView1.Columns["customer_receive_product"].Caption = "8.ลูกค้า-ผู้รับของ";
            gridView1.Columns["warranty"].Caption = "การประกัน";
            gridView1.Columns["chargebacks"].Caption = "เก็บเงินเพิ่ม";
            gridView1.Columns["symptom"].Caption = "อาการเสีย";
            gridView1.Columns["equipment"].Caption = "อุปกรณ์ที่ซ่อม";
            gridView1.Columns["detail"].Caption = "อุปกรณ์ที่ซ่อม";
            gridView1.Columns["date_create"].Caption = "วันที่ทำรายการ";
            gridView1.Columns["date_create"].DisplayFormat.FormatType = FormatType.DateTime;
            gridView1.Columns["date_create"].DisplayFormat.FormatString = fRMMain.formatDate;
            gridView1.Columns["date_stamp"].Caption = "วันที่แก้ไข";
            gridView1.Columns["date_stamp"].DisplayFormat.FormatType = FormatType.DateTime;
            gridView1.Columns["date_stamp"].DisplayFormat.FormatString = fRMMain.formatDate;

            gridView1.Columns["in_document_number_id"].Visible = false;


            gridView1.OptionsView.ShowFooter = true;
            //gridView1.OptionsView.ShowGroupedColumns = true;


            //set column width (autofit)
            //            gridView1.BestFitColumns();
            //            gridView1.BestFitMaxRowCount = -1;
            gridView1.OptionsView.ColumnAutoWidth = false;
            foreach (GridColumn col in gridView1.Columns)
            {
                //col.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
                col.BestFit();//ทำให้ column โชว์ชื่อเต็ม
            }

            //freeze panel
            //gridView1.Columns["No."].Fixed = FixedStyle.Left;

            //disable edit
            gridView1.OptionsBehavior.Editable = false;

            AutoHeightHelper helper = new AutoHeightHelper(gridView1);
            helper.EnableColumnPanelAutoHeight();

            //saveLayout();
        }


    }
}
