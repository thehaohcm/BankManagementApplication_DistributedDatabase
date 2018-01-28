namespace DistributedDatabase
{
    partial class AddStaff
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
            this.label1 = new System.Windows.Forms.Label();
            this.manvTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hotenTxt = new System.Windows.Forms.TextBox();
            this.diachiTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sdtTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.maleRdBtn = new System.Windows.Forms.RadioButton();
            this.femaleRdBtn = new System.Windows.Forms.RadioButton();
            this.themcsBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chinhanhCmb = new System.Windows.Forms.ComboBox();
            this.removeBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã nhân viên: ";
            // 
            // manvTxt
            // 
            this.manvTxt.Location = new System.Drawing.Point(160, 51);
            this.manvTxt.Name = "manvTxt";
            this.manvTxt.Size = new System.Drawing.Size(152, 27);
            this.manvTxt.TabIndex = 1;
            this.manvTxt.Text = "NV0001";
            this.manvTxt.TextChanged += new System.EventHandler(this.manvTxt_TextChanged);
            this.manvTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.manvTxt_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ tên:";
            // 
            // hotenTxt
            // 
            this.hotenTxt.Location = new System.Drawing.Point(160, 88);
            this.hotenTxt.Name = "hotenTxt";
            this.hotenTxt.Size = new System.Drawing.Size(282, 27);
            this.hotenTxt.TabIndex = 3;
            this.hotenTxt.TextChanged += new System.EventHandler(this.hotenTxt_TextChanged);
            // 
            // diachiTxt
            // 
            this.diachiTxt.Location = new System.Drawing.Point(160, 127);
            this.diachiTxt.Multiline = true;
            this.diachiTxt.Name = "diachiTxt";
            this.diachiTxt.Size = new System.Drawing.Size(282, 91);
            this.diachiTxt.TabIndex = 5;
            this.diachiTxt.TextChanged += new System.EventHandler(this.diachiTxt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Địa chỉ:";
            // 
            // sdtTxt
            // 
            this.sdtTxt.Location = new System.Drawing.Point(160, 233);
            this.sdtTxt.MaxLength = 12;
            this.sdtTxt.Name = "sdtTxt";
            this.sdtTxt.Size = new System.Drawing.Size(282, 27);
            this.sdtTxt.TabIndex = 7;
            this.sdtTxt.TextChanged += new System.EventHandler(this.sdtTxt_TextChanged);
            this.sdtTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sdtTxt_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Số điện thoại:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "Thuộc chi nhánh:";
            // 
            // maleRdBtn
            // 
            this.maleRdBtn.AutoSize = true;
            this.maleRdBtn.Location = new System.Drawing.Point(318, 52);
            this.maleRdBtn.Name = "maleRdBtn";
            this.maleRdBtn.Size = new System.Drawing.Size(67, 23);
            this.maleRdBtn.TabIndex = 11;
            this.maleRdBtn.TabStop = true;
            this.maleRdBtn.Text = "Nam";
            this.maleRdBtn.UseVisualStyleBackColor = true;
            this.maleRdBtn.CheckedChanged += new System.EventHandler(this.maleRdBtn_CheckedChanged);
            // 
            // femaleRdBtn
            // 
            this.femaleRdBtn.AutoSize = true;
            this.femaleRdBtn.Location = new System.Drawing.Point(391, 52);
            this.femaleRdBtn.Name = "femaleRdBtn";
            this.femaleRdBtn.Size = new System.Drawing.Size(55, 23);
            this.femaleRdBtn.TabIndex = 12;
            this.femaleRdBtn.TabStop = true;
            this.femaleRdBtn.Text = "Nữ";
            this.femaleRdBtn.UseVisualStyleBackColor = true;
            this.femaleRdBtn.CheckedChanged += new System.EventHandler(this.femaleRdBtn_CheckedChanged);
            // 
            // themcsBtn
            // 
            this.themcsBtn.Enabled = false;
            this.themcsBtn.Location = new System.Drawing.Point(250, 317);
            this.themcsBtn.Name = "themcsBtn";
            this.themcsBtn.Size = new System.Drawing.Size(93, 38);
            this.themcsBtn.TabIndex = 13;
            this.themcsBtn.Text = "Thêm";
            this.themcsBtn.UseVisualStyleBackColor = true;
            this.themcsBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(349, 317);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 38);
            this.button2.TabIndex = 14;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.AutoSize = true;
            this.groupControl1.Controls.Add(this.chinhanhCmb);
            this.groupControl1.Controls.Add(this.removeBtn);
            this.groupControl1.Controls.Add(this.manvTxt);
            this.groupControl1.Controls.Add(this.button2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.themcsBtn);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.femaleRdBtn);
            this.groupControl1.Controls.Add(this.hotenTxt);
            this.groupControl1.Controls.Add(this.maleRdBtn);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.diachiTxt);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.sdtTxt);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(458, 367);
            this.groupControl1.TabIndex = 15;
            this.groupControl1.Text = "Thêm Nhân Viên";
            // 
            // chinhanhCmb
            // 
            this.chinhanhCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chinhanhCmb.FormattingEnabled = true;
            this.chinhanhCmb.Location = new System.Drawing.Point(160, 275);
            this.chinhanhCmb.Name = "chinhanhCmb";
            this.chinhanhCmb.Size = new System.Drawing.Size(282, 27);
            this.chinhanhCmb.TabIndex = 16;
            this.chinhanhCmb.SelectedIndexChanged += new System.EventHandler(this.chinhanhCmb_SelectedIndexChanged);
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(8, 317);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(93, 38);
            this.removeBtn.TabIndex = 15;
            this.removeBtn.Text = "Xóa";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Visible = false;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // AddStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 367);
            this.Controls.Add(this.groupControl1);
            this.Name = "AddStaff";
            this.Text = "Thêm nhân viên";
            this.Load += new System.EventHandler(this.AddStaff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox manvTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox hotenTxt;
        private System.Windows.Forms.TextBox diachiTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sdtTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton maleRdBtn;
        private System.Windows.Forms.RadioButton femaleRdBtn;
        private System.Windows.Forms.Button themcsBtn;
        private System.Windows.Forms.Button button2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.ComboBox chinhanhCmb;
    }
}