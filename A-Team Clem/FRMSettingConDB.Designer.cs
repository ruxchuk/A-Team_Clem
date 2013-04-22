namespace A_Team_Clem
{
    partial class FRMSettingConDB
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.hostName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.save = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.DBName = new DevExpress.XtraEditors.TextEdit();
            this.userName = new DevExpress.XtraEditors.TextEdit();
            this.password = new DevExpress.XtraEditors.TextEdit();
            this.port = new DevExpress.XtraEditors.TextEdit();
            this.test = new DevExpress.XtraEditors.SimpleButton();
            this.status = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.hostName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.port.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // hostName
            // 
            this.hostName.Location = new System.Drawing.Point(112, 5);
            this.hostName.Name = "hostName";
            this.hostName.Size = new System.Drawing.Size(100, 20);
            this.hostName.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Host Name";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 49);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(79, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Data Base Name";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 123);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(46, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Password";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 86);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(52, 13);
            this.labelControl4.TabIndex = 1;
            this.labelControl4.Text = "User Name";
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(148, 181);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(64, 23);
            this.save.TabIndex = 6;
            this.save.Text = "บันทึก";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 160);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(20, 13);
            this.labelControl5.TabIndex = 1;
            this.labelControl5.Text = "Port";
            // 
            // DBName
            // 
            this.DBName.Location = new System.Drawing.Point(112, 42);
            this.DBName.Name = "DBName";
            this.DBName.Size = new System.Drawing.Size(100, 20);
            this.DBName.TabIndex = 1;
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(112, 79);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(100, 20);
            this.userName.TabIndex = 2;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(112, 116);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(100, 20);
            this.password.TabIndex = 3;
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(112, 153);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(100, 20);
            this.port.TabIndex = 4;
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(78, 182);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(64, 23);
            this.test.TabIndex = 5;
            this.test.Text = "ทดสอบ";
            this.test.Click += new System.EventHandler(this.test_Click);
            // 
            // status
            // 
            this.status.Appearance.BackColor = System.Drawing.Color.Red;
            this.status.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.Location = new System.Drawing.Point(12, 186);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(50, 19);
            this.status.TabIndex = 3;
            this.status.Text = "   No   ";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl6.Location = new System.Drawing.Point(70, 12);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(6, 13);
            this.labelControl6.TabIndex = 7;
            this.labelControl6.Text = "*";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl7.Location = new System.Drawing.Point(97, 49);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(6, 13);
            this.labelControl7.TabIndex = 7;
            this.labelControl7.Text = "*";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl8.Location = new System.Drawing.Point(70, 86);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(6, 13);
            this.labelControl8.TabIndex = 7;
            this.labelControl8.Text = "*";
            // 
            // FRMSettingConDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(229, 217);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.status);
            this.Controls.Add(this.test);
            this.Controls.Add(this.save);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.port);
            this.Controls.Add(this.password);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.DBName);
            this.Controls.Add(this.hostName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRMSettingConDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ตั้งค่าฐานข้อมูล";
            this.Load += new System.EventHandler(this.FRMSettingConDB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hostName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.port.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit hostName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton save;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit DBName;
        private DevExpress.XtraEditors.TextEdit userName;
        private DevExpress.XtraEditors.TextEdit password;
        private DevExpress.XtraEditors.TextEdit port;
        private DevExpress.XtraEditors.SimpleButton test;
        private DevExpress.XtraEditors.LabelControl status;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
    }
}