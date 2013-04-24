﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;
using DevExpress.XtraGrid.Columns;
using System.IO;
using DevExpress.Utils;

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
        private string strPathLayout = @"Files\save\UCReportCustomerClem.xml";
        private Stream saveDefaultLayout;
        private int sizeX = 47;
        private int sizeY = 45;
        private int curSizeX = 40;
        private int curSizeY = 40;

        public void readData()
        {
            conDB.name_th = customerName.Text;
            conDB.phone = phone.Text;
            conDB.serial = serial.Text;
            conDB.product_name_th = productName.Text;
            conDB.in_document_number_string = inDocumentNumber.Text;
            conDB.status = status.Text;
        }

        private void clearData()
        {
            customerName.Text = "";
            phone.Text = "";
            serial.Text = "";
            productName.Text = "";
            inDocumentNumber.Text = "";
            status.SelectedIndex = -1;
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

        public void saveLayout()
        {
            //ตั้งให้ save แบบไม่ต้อง fillter
            gridView1.OptionsLayout.StoreDataSettings = false;

            saveDefaultLayout = new System.IO.MemoryStream();
            gridView1.SaveLayoutToStream(saveDefaultLayout);
            saveDefaultLayout.Seek(0, System.IO.SeekOrigin.Begin);

            try
            {
                gridView1.RestoreLayoutFromXml(strPathLayout);
            }
            catch
            {
                gridView1.SaveLayoutToXml(strPathLayout);
            }
        }

        public void getListClem()
        {
            //splashScreenManager1.ShowWaitForm();
            //splashScreenManager1.SetWaitFormCaption("กำลังทำการค้นหา");
            //splashScreenManager1.SetWaitFormDescription("กรุณารอสักครู่");

            readData();
            DataSet list = conDB.getListClem(fRMMain.addCustomerClem.clemType);
            gridControl1.DataSource = list.Tables["get_list_clem"];
            setGridView();
        }

        #region set mouse
        private void imgSearch_MouseHover(object sender, EventArgs e)
        {

            imgSearch.Size = new Size(sizeX, sizeY);
        }

        private void imgSearch_MouseLeave(object sender, EventArgs e)
        {

            imgSearch.Size = new Size(curSizeX, curSizeY);
        }

        private void imgClear_MouseHover(object sender, EventArgs e)
        {
            imgClear.Size = new Size(sizeX, sizeY);
        }

        private void imgClear_MouseLeave(object sender, EventArgs e)
        {
            imgClear.Size = new Size(curSizeX, curSizeY);
        }
        #endregion

        private void UCReportCustomerClem_Load(object sender, EventArgs e)
        {
            getListClem();
        }

        private void imgSearch_Click(object sender, EventArgs e)
        {
            getListClem();
        }

        private void imgClear_Click(object sender, EventArgs e)
        {
            clearData();
        }
    }
}
