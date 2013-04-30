using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace A_Team_Clem
{
    public partial class UCListCompany : DevExpress.XtraEditors.XtraUserControl
    {
        private FRMMain fRMMain;

        public UCListCompany(FRMMain fRMMain)
        {
            // TODO: Complete member initialization
            this.fRMMain = fRMMain;
            InitializeComponent();
        }
    }
}
