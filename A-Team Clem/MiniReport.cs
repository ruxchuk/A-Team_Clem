using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using A_Team_Clem.Modules;

namespace A_Team_Clem
{
    public partial class MiniReport : DevExpress.XtraReports.UI.XtraReport
    {
        
        public MiniReport()
        {
            InitializeComponent();
        }

        public void setData()
        {
            dateTimeThai.Text = "";
            inDocumentNumber.Text = "";
            customerName.Text = "";
            address.Text = "";
            phone.Text = "";
            productName.Text = "";
            company.Text = "";
            productType.Text = "";
            dtProductEndDate.Text = "";
            warranty.Text = "";
            chargebacks.Text = "";
            symptom.Text = "";
            equipment.Text = "";
            detail2.Text = "";
        }

    }
}
