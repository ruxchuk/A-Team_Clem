using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace A_Team_Clem
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();
        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {
        }

        private void radioButtonInWarranty_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonInWarranty.Checked)
            {
                panelWarranty.Visible = false;
            }
            else
            {
                panelWarranty.Visible = true;
            }
        }

        private void radioButtonOutWarranty_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOutWarranty.Checked)
            {
                panelWarranty.Visible = true;
                
            }
            else
            {
                panelWarranty.Visible = false;
            }
        }
    }
}