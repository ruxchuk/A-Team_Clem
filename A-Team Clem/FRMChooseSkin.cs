using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraWizard;
using DevExpress.Skins;
using System.IO;

namespace A_Team_Clem
{
    public partial class FRMChooseSkin : DevExpress.XtraEditors.XtraForm
    {
        private FRMMain m_form;
        private string skinPath;
        public FRMChooseSkin(FRMMain p_form, string skinName, string path = "skin.txt")
        {
            InitializeComponent();
            foreach (SkinContainer cnt in SkinManager.Default.Skins)
                listBoxControl1.Items.Add(cnt.SkinName);
            listBoxControl1.SelectedItem = skinName;
            m_form = p_form;
            skinPath = path;
        }
        public string SelectedSkinName { get { return listBoxControl1.SelectedItem.ToString(); } }
        //public bool AllowAnimation { get { return checkEdit1.Checked; } }
        //public bool AllowSkin4Form { get { return checkEdit2.Checked; } }
        public WizardStyle WizardStyle { get { return WizardStyle.Wizard97; } }

        private void listBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(SelectedSkinName);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                m_form.strSkinName = SelectedSkinName;
                saveFileDialog1.FileName = skinPath;
                StreamWriter stW = File.CreateText(saveFileDialog1.FileName);
                stW.WriteLine(SelectedSkinName);
                stW.Close();
                Close();
            }
            catch { }
        }
    }
}