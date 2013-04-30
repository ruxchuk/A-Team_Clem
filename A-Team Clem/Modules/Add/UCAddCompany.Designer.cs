namespace A_Team_Clem.Modules
{
    partial class UCAddCompany
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCAddCompany));
            this.labelControl59 = new DevExpress.XtraEditors.LabelControl();
            this.richTextBoxAddress = new System.Windows.Forms.RichTextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.phone = new DevExpress.XtraEditors.TextEdit();
            this.nameEng = new DevExpress.XtraEditors.TextEdit();
            this.nameTH = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.email = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControlPage = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.phone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameEng.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.email.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl59
            // 
            this.labelControl59.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl59.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl59.Location = new System.Drawing.Point(75, 42);
            this.labelControl59.Name = "labelControl59";
            this.labelControl59.Size = new System.Drawing.Size(9, 19);
            this.labelControl59.TabIndex = 1078;
            this.labelControl59.Text = "*";
            // 
            // richTextBoxAddress
            // 
            this.richTextBoxAddress.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.richTextBoxAddress.Location = new System.Drawing.Point(102, 144);
            this.richTextBoxAddress.Name = "richTextBoxAddress";
            this.richTextBoxAddress.Size = new System.Drawing.Size(152, 96);
            this.richTextBoxAddress.TabIndex = 3;
            this.richTextBoxAddress.Text = "";
            this.richTextBoxAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detail_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl1.Location = new System.Drawing.Point(12, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 19);
            this.labelControl1.TabIndex = 1077;
            this.labelControl1.Text = "ชื่อบริษัท";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl2.Location = new System.Drawing.Point(12, 144);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(30, 19);
            this.labelControl2.TabIndex = 1076;
            this.labelControl2.Text = "ที่อยู่";
            // 
            // phone
            // 
            this.phone.Location = new System.Drawing.Point(377, 35);
            this.phone.Name = "phone";
            this.phone.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.phone.Properties.Appearance.Options.UseFont = true;
            this.phone.Size = new System.Drawing.Size(152, 26);
            this.phone.TabIndex = 4;
            this.phone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDownNextTab);
            // 
            // nameEng
            // 
            this.nameEng.Location = new System.Drawing.Point(102, 86);
            this.nameEng.Name = "nameEng";
            this.nameEng.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.nameEng.Properties.Appearance.Options.UseFont = true;
            this.nameEng.Size = new System.Drawing.Size(152, 26);
            this.nameEng.TabIndex = 2;
            this.nameEng.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDownNextTab);
            // 
            // nameTH
            // 
            this.nameTH.Location = new System.Drawing.Point(102, 35);
            this.nameTH.Name = "nameTH";
            this.nameTH.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.nameTH.Properties.Appearance.Options.UseFont = true;
            this.nameTH.Size = new System.Drawing.Size(152, 26);
            this.nameTH.TabIndex = 1;
            this.nameTH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDownNextTab);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.buttonCancel);
            this.groupControl1.Controls.Add(this.buttonClear);
            this.groupControl1.Controls.Add(this.buttonSave);
            this.groupControl1.Controls.Add(this.labelControl59);
            this.groupControl1.Controls.Add(this.richTextBoxAddress);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.phone);
            this.groupControl1.Controls.Add(this.nameEng);
            this.groupControl1.Controls.Add(this.nameTH);
            this.groupControl1.Controls.Add(this.email);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Location = new System.Drawing.Point(3, 60);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(540, 247);
            this.groupControl1.TabIndex = 22;
            this.groupControl1.Text = "ข้อมูลบริษัท";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCancel.BackgroundImage")));
            this.buttonCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancel.Location = new System.Drawing.Point(278, 208);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(82, 32);
            this.buttonCancel.TabIndex = 1082;
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonClear.BackgroundImage")));
            this.buttonClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClear.Location = new System.Drawing.Point(366, 208);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(82, 32);
            this.buttonClear.TabIndex = 1081;
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSave.BackgroundImage")));
            this.buttonSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSave.Location = new System.Drawing.Point(454, 208);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(82, 32);
            this.buttonSave.TabIndex = 1080;
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.simpleButtonAddClem_Click);
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(377, 86);
            this.email.Name = "email";
            this.email.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.email.Properties.Appearance.Options.UseFont = true;
            this.email.Size = new System.Drawing.Size(152, 26);
            this.email.TabIndex = 5;
            this.email.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDownNextTab);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl5.Location = new System.Drawing.Point(12, 93);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(52, 19);
            this.labelControl5.TabIndex = 1075;
            this.labelControl5.Text = "ชื่อ Eng";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl4.Location = new System.Drawing.Point(278, 93);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(38, 19);
            this.labelControl4.TabIndex = 1075;
            this.labelControl4.Text = "email";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl3.Location = new System.Drawing.Point(278, 42);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(58, 19);
            this.labelControl3.TabIndex = 1075;
            this.labelControl3.Text = "เบอร์โทร";
            // 
            // labelControlPage
            // 
            this.labelControlPage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControlPage.Appearance.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlPage.Location = new System.Drawing.Point(206, 15);
            this.labelControlPage.Name = "labelControlPage";
            this.labelControlPage.Size = new System.Drawing.Size(134, 39);
            this.labelControlPage.TabIndex = 21;
            this.labelControlPage.Text = "เพิ่มบริษัท";
            // 
            // UCAddCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.labelControlPage);
            this.MinimumSize = new System.Drawing.Size(546, 310);
            this.Name = "UCAddCompany";
            this.Size = new System.Drawing.Size(546, 310);
            ((System.ComponentModel.ISupportInitialize)(this.phone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameEng.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.email.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl59;
        private System.Windows.Forms.RichTextBox richTextBoxAddress;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit phone;
        private DevExpress.XtraEditors.TextEdit nameEng;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit email;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControlPage;
        public DevExpress.XtraEditors.TextEdit nameTH;
        public System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonSave;
    }
}
