namespace A_Team_Clem.Modules
{
    partial class UCReportCustomerClem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCReportCustomerClem));
            this.labelControlPage = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.status = new DevExpress.XtraEditors.MRUEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.productName = new DevExpress.XtraEditors.MRUEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.inDocumentNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.serial = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.phone = new DevExpress.XtraEditors.TextEdit();
            this.imgClear = new System.Windows.Forms.PictureBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.imgSearch = new System.Windows.Forms.PictureBox();
            this.customerName = new DevExpress.XtraEditors.MRUEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.status.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inDocumentNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControlPage
            // 
            this.labelControlPage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControlPage.Appearance.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlPage.Location = new System.Drawing.Point(363, 15);
            this.labelControlPage.Name = "labelControlPage";
            this.labelControlPage.Size = new System.Drawing.Size(314, 39);
            this.labelControlPage.TabIndex = 2;
            this.labelControlPage.Text = "รายงานใบรับเคลมสินค้า";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 167);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1034, 340);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.status);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.productName);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.inDocumentNumber);
            this.groupControl1.Controls.Add(this.labelControl18);
            this.groupControl1.Controls.Add(this.serial);
            this.groupControl1.Controls.Add(this.labelControl11);
            this.groupControl1.Controls.Add(this.phone);
            this.groupControl1.Controls.Add(this.imgClear);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.imgSearch);
            this.groupControl1.Controls.Add(this.customerName);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(3, 60);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1034, 101);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "ค้นหารายการ";
            // 
            // status
            // 
            this.status.AllowDrop = true;
            this.status.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.status.Location = new System.Drawing.Point(718, 61);
            this.status.Name = "status";
            this.status.Properties.AllowRemoveMRUItems = false;
            this.status.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.status.Properties.Appearance.Options.UseFont = true;
            this.status.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.status.Properties.CaseSensitiveSearch = true;
            this.status.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.status.Properties.Items.AddRange(new object[] {
            "รับของ",
            "รับเคลม",
            "ส่งเคลม",
            "สำเร็จ"});
            this.status.Properties.Sorted = true;
            this.status.Size = new System.Drawing.Size(169, 26);
            this.status.TabIndex = 1091;
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl6.Location = new System.Drawing.Point(585, 68);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(44, 19);
            this.labelControl6.TabIndex = 1092;
            this.labelControl6.Text = "สถานะ";
            // 
            // productName
            // 
            this.productName.AllowDrop = true;
            this.productName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.productName.Location = new System.Drawing.Point(374, 61);
            this.productName.Name = "productName";
            this.productName.Properties.AllowRemoveMRUItems = false;
            this.productName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.productName.Properties.Appearance.Options.UseFont = true;
            this.productName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.productName.Properties.CaseSensitiveSearch = true;
            this.productName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.productName.Properties.Sorted = true;
            this.productName.Size = new System.Drawing.Size(188, 26);
            this.productName.TabIndex = 1089;
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl4.Location = new System.Drawing.Point(310, 68);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(58, 19);
            this.labelControl4.TabIndex = 1090;
            this.labelControl4.Text = "ชื่อสินค้า";
            // 
            // inDocumentNumber
            // 
            this.inDocumentNumber.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.inDocumentNumber.EditValue = "";
            this.inDocumentNumber.Enabled = false;
            this.inDocumentNumber.Location = new System.Drawing.Point(718, 25);
            this.inDocumentNumber.Name = "inDocumentNumber";
            this.inDocumentNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inDocumentNumber.Properties.Appearance.Options.UseFont = true;
            this.inDocumentNumber.Size = new System.Drawing.Size(169, 26);
            this.inDocumentNumber.TabIndex = 1087;
            // 
            // labelControl18
            // 
            this.labelControl18.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl18.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl18.Location = new System.Drawing.Point(583, 32);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(129, 19);
            this.labelControl18.TabIndex = 1088;
            this.labelControl18.Text = "เลขที่เอกสารภายใน";
            // 
            // serial
            // 
            this.serial.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.serial.Location = new System.Drawing.Point(374, 25);
            this.serial.Name = "serial";
            this.serial.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.serial.Properties.Appearance.Options.UseFont = true;
            this.serial.Size = new System.Drawing.Size(188, 26);
            this.serial.TabIndex = 1085;
            // 
            // labelControl11
            // 
            this.labelControl11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl11.Location = new System.Drawing.Point(310, 32);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(39, 19);
            this.labelControl11.TabIndex = 1086;
            this.labelControl11.Text = "Serial";
            // 
            // phone
            // 
            this.phone.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.phone.Location = new System.Drawing.Point(87, 61);
            this.phone.Name = "phone";
            this.phone.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.phone.Properties.Appearance.Options.UseFont = true;
            this.phone.Size = new System.Drawing.Size(188, 26);
            this.phone.TabIndex = 1068;
            // 
            // imgClear
            // 
            this.imgClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imgClear.BackgroundImage")));
            this.imgClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imgClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgClear.Location = new System.Drawing.Point(924, 56);
            this.imgClear.Name = "imgClear";
            this.imgClear.Size = new System.Drawing.Size(52, 40);
            this.imgClear.TabIndex = 1072;
            this.imgClear.TabStop = false;
            this.imgClear.Tag = "Clear";
            this.imgClear.MouseLeave += new System.EventHandler(this.imgClear_MouseLeave);
            this.imgClear.MouseHover += new System.EventHandler(this.imgClear_MouseHover);
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl3.Location = new System.Drawing.Point(23, 68);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(58, 19);
            this.labelControl3.TabIndex = 1069;
            this.labelControl3.Text = "เบอร์โทร";
            // 
            // imgSearch
            // 
            this.imgSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imgSearch.BackgroundImage")));
            this.imgSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imgSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgSearch.Location = new System.Drawing.Point(977, 56);
            this.imgSearch.Name = "imgSearch";
            this.imgSearch.Size = new System.Drawing.Size(52, 40);
            this.imgSearch.TabIndex = 1072;
            this.imgSearch.TabStop = false;
            this.imgSearch.Tag = "ค้นหา";
            this.imgSearch.Click += new System.EventHandler(this.imgSearch_Click);
            // 
            // customerName
            // 
            this.customerName.AllowDrop = true;
            this.customerName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.customerName.Location = new System.Drawing.Point(86, 25);
            this.customerName.Name = "customerName";
            this.customerName.Properties.AllowRemoveMRUItems = false;
            this.customerName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.customerName.Properties.Appearance.Options.UseFont = true;
            this.customerName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.customerName.Properties.CaseSensitiveSearch = true;
            this.customerName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.customerName.Properties.Sorted = true;
            this.customerName.Size = new System.Drawing.Size(188, 26);
            this.customerName.TabIndex = 1070;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl1.Location = new System.Drawing.Point(23, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 19);
            this.labelControl1.TabIndex = 1071;
            this.labelControl1.Text = "ชื่อลูกค้า";
            // 
            // UCReportCustomerClem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.labelControlPage);
            this.MinimumSize = new System.Drawing.Size(1040, 507);
            this.Name = "UCReportCustomerClem";
            this.Size = new System.Drawing.Size(1040, 507);
            this.Load += new System.EventHandler(this.UCReportCustomerClem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.status.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inDocumentNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControlPage;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        public DevExpress.XtraEditors.MRUEdit customerName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.PictureBox imgClear;
        private System.Windows.Forms.PictureBox imgSearch;
        private DevExpress.XtraEditors.TextEdit phone;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit serial;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit inDocumentNumber;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        public DevExpress.XtraEditors.MRUEdit productName;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.MRUEdit status;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}
