using System;
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

            saveLayout();
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
