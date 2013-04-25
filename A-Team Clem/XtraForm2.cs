using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;

namespace A_Team_Clem
{
    public partial class XtraForm2 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm2()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // Create a report instance, assigned to a Print Tool.
            ReportPrintTool pt = new ReportPrintTool(new XtraReport1());

            // Get the Print Tool's printing system.
            PrintingSystemBase ps = pt.PrintingSystem;

            // Show a report's Print Preview.
            pt.ShowPreview();

            // Zoom the print preview, so that it fits the entire page.
            ps.ExecCommand(PrintingSystemCommand.ViewWholePage);

            // Invoke the Hand tool.
            ps.ExecCommand(PrintingSystemCommand.HandTool, new object[] { true });

            // Hide the Hand tool.
            ps.ExecCommand(PrintingSystemCommand.HandTool, new object[] { false });
        }
    }
}