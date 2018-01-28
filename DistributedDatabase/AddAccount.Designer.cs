namespace DistributedDatabase
{
    partial class AddAccount
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
            this.button2 = new System.Windows.Forms.Button();
            this.themcsBtn = new System.Windows.Forms.Button();
            this.chinhanhTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maTKTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.soduTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.sdtRdb = new System.Windows.Forms.RadioButton();
            this.cmndRdb = new System.Windows.Forms.RadioButton();
            this.sdtCbb = new System.Windows.Forms.ComboBox();
            this.cmndTxt = new System.Windows.Forms.TextBox();
            this.labelcmnd = new System.Windows.Forms.Label();
            this.hotenRdBtn = new System.Windows.Forms.RadioButton();
            this.hotenCbb = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.removeBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(385, 336);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 38);
            this.button2.TabIndex = 28;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // themcsBtn
            // 
            this.themcsBtn.Location = new System.Drawing.Point(286, 336);
            this.themcsBtn.Name = "themcsBtn";
            this.themcsBtn.Size = new System.Drawing.Size(93, 38);
            this.themcsBtn.TabIndex = 27;
            this.themcsBtn.Text = "Thêm";
            this.themcsBtn.UseVisualStyleBackColor = true;
            this.themcsBtn.Click += new System.EventHandler(this.themcsBtn_Click);
            // 
            // chinhanhTxt
            // 
            this.chinhanhTxt.Location = new System.Drawing.Point(172, 190);
            this.chinhanhTxt.Name = "chinhanhTxt";
            this.chinhanhTxt.ReadOnly = true;
            this.chinhanhTxt.ShortcutsEnabled = false;
            this.chinhanhTxt.Size = new System.Drawing.Size(272, 26);
            this.chinhanhTxt.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "Thuộc chi nhánh:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Số điện thoại:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Họ tên:";
            // 
            // maTKTxt
            // 
            this.maTKTxt.Location = new System.Drawing.Point(172, 37);
            this.maTKTxt.Name = "maTKTxt";
            this.maTKTxt.ShortcutsEnabled = false;
            this.maTKTxt.Size = new System.Drawing.Size(272, 26);
            this.maTKTxt.TabIndex = 16;
            this.maTKTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maTKTxt_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Mã tài khoản: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.soduTxt);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.sdtRdb);
            this.groupBox1.Controls.Add(this.cmndRdb);
            this.groupBox1.Controls.Add(this.sdtCbb);
            this.groupBox1.Controls.Add(this.cmndTxt);
            this.groupBox1.Controls.Add(this.labelcmnd);
            this.groupBox1.Controls.Add(this.hotenRdBtn);
            this.groupBox1.Controls.Add(this.hotenCbb);
            this.groupBox1.Controls.Add(this.maTKTxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chinhanhTxt);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(468, 318);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thêm Tài Khoản";
            // 
            // soduTxt
            // 
            this.soduTxt.Location = new System.Drawing.Point(172, 229);
            this.soduTxt.MaxLength = 12;
            this.soduTxt.Name = "soduTxt";
            this.soduTxt.ShortcutsEnabled = false;
            this.soduTxt.Size = new System.Drawing.Size(272, 26);
            this.soduTxt.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 33;
            this.label5.Text = "Số dư: ";
            // 
            // sdtRdb
            // 
            this.sdtRdb.AutoSize = true;
            this.sdtRdb.Location = new System.Drawing.Point(145, 152);
            this.sdtRdb.Name = "sdtRdb";
            this.sdtRdb.Size = new System.Drawing.Size(21, 20);
            this.sdtRdb.TabIndex = 32;
            this.sdtRdb.TabStop = true;
            this.sdtRdb.UseVisualStyleBackColor = true;
            this.sdtRdb.CheckedChanged += new System.EventHandler(this.sdtRdb_CheckedChanged);
            // 
            // cmndRdb
            // 
            this.cmndRdb.AutoSize = true;
            this.cmndRdb.Location = new System.Drawing.Point(145, 113);
            this.cmndRdb.Name = "cmndRdb";
            this.cmndRdb.Size = new System.Drawing.Size(21, 20);
            this.cmndRdb.TabIndex = 31;
            this.cmndRdb.TabStop = true;
            this.cmndRdb.UseVisualStyleBackColor = true;
            this.cmndRdb.CheckedChanged += new System.EventHandler(this.cmndRdb_CheckedChanged);
            // 
            // sdtCbb
            // 
            this.sdtCbb.FormattingEnabled = true;
            this.sdtCbb.Location = new System.Drawing.Point(172, 149);
            this.sdtCbb.MaxLength = 12;
            this.sdtCbb.Name = "sdtCbb";
            this.sdtCbb.Size = new System.Drawing.Size(272, 28);
            this.sdtCbb.TabIndex = 30;
            this.sdtCbb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sdtCbb_KeyPress);
            // 
            // cmndTxt
            // 
            this.cmndTxt.Location = new System.Drawing.Point(172, 110);
            this.cmndTxt.MaxLength = 12;
            this.cmndTxt.Name = "cmndTxt";
            this.cmndTxt.ShortcutsEnabled = false;
            this.cmndTxt.Size = new System.Drawing.Size(272, 26);
            this.cmndTxt.TabIndex = 29;
            this.cmndTxt.TextChanged += new System.EventHandler(this.cmndRdb_CheckedChanged);
            this.cmndTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmndTxt_KeyPress);
            // 
            // labelcmnd
            // 
            this.labelcmnd.AutoSize = true;
            this.labelcmnd.Location = new System.Drawing.Point(16, 113);
            this.labelcmnd.Name = "labelcmnd";
            this.labelcmnd.Size = new System.Drawing.Size(60, 20);
            this.labelcmnd.TabIndex = 28;
            this.labelcmnd.Text = "CMND:";
            // 
            // hotenRdBtn
            // 
            this.hotenRdBtn.AutoSize = true;
            this.hotenRdBtn.Location = new System.Drawing.Point(145, 72);
            this.hotenRdBtn.Name = "hotenRdBtn";
            this.hotenRdBtn.Size = new System.Drawing.Size(21, 20);
            this.hotenRdBtn.TabIndex = 27;
            this.hotenRdBtn.TabStop = true;
            this.hotenRdBtn.UseVisualStyleBackColor = true;
            this.hotenRdBtn.CheckedChanged += new System.EventHandler(this.hotenRdBtn_CheckedChanged);
            // 
            // hotenCbb
            // 
            this.hotenCbb.FormattingEnabled = true;
            this.hotenCbb.Location = new System.Drawing.Point(172, 69);
            this.hotenCbb.Name = "hotenCbb";
            this.hotenCbb.Size = new System.Drawing.Size(272, 28);
            this.hotenCbb.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 336);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 38);
            this.button1.TabIndex = 33;
            this.button1.Text = "Tìm kiếm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(115, 336);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(100, 38);
            this.removeBtn.TabIndex = 34;
            this.removeBtn.Text = "Xóa";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Visible = false;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // AddAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 388);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.themcsBtn);
            this.Name = "AddAccount";
            this.Text = "Thêm Tài Khoản";
            this.Load += new System.EventHandler(this.AddAccount_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button themcsBtn;
        private System.Windows.Forms.TextBox chinhanhTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox maTKTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox cmndTxt;
        private System.Windows.Forms.Label labelcmnd;
        private System.Windows.Forms.RadioButton hotenRdBtn;
        private System.Windows.Forms.ComboBox hotenCbb;
        private System.Windows.Forms.ComboBox sdtCbb;
        private System.Windows.Forms.RadioButton sdtRdb;
        private System.Windows.Forms.RadioButton cmndRdb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox soduTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button removeBtn;
    }
}