namespace DistributedDatabase
{
    partial class AddClient
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
            this.addBtn = new System.Windows.Forms.Button();
            this.femaleRdBtn = new System.Windows.Forms.RadioButton();
            this.maleRdBtn = new System.Windows.Forms.RadioButton();
            this.cmndTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.sdtTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.diachiTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.hotenTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ngaycapDateTime = new System.Windows.Forms.DateTimePicker();
            this.chinhanhTxt = new System.Windows.Forms.TextBox();
            this.removeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(391, 341);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 38);
            this.button2.TabIndex = 28;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // addBtn
            // 
            this.addBtn.Enabled = false;
            this.addBtn.Location = new System.Drawing.Point(292, 341);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(93, 38);
            this.addBtn.TabIndex = 27;
            this.addBtn.Text = "Thêm";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // femaleRdBtn
            // 
            this.femaleRdBtn.AutoSize = true;
            this.femaleRdBtn.Location = new System.Drawing.Point(419, 10);
            this.femaleRdBtn.Name = "femaleRdBtn";
            this.femaleRdBtn.Size = new System.Drawing.Size(54, 24);
            this.femaleRdBtn.TabIndex = 26;
            this.femaleRdBtn.TabStop = true;
            this.femaleRdBtn.Text = "Nữ";
            this.femaleRdBtn.UseVisualStyleBackColor = true;
            this.femaleRdBtn.CheckedChanged += new System.EventHandler(this.femaleRdBtn_CheckedChanged);
            // 
            // maleRdBtn
            // 
            this.maleRdBtn.AutoSize = true;
            this.maleRdBtn.Location = new System.Drawing.Point(346, 10);
            this.maleRdBtn.Name = "maleRdBtn";
            this.maleRdBtn.Size = new System.Drawing.Size(67, 24);
            this.maleRdBtn.TabIndex = 25;
            this.maleRdBtn.TabStop = true;
            this.maleRdBtn.Text = "Nam";
            this.maleRdBtn.UseVisualStyleBackColor = true;
            this.maleRdBtn.CheckedChanged += new System.EventHandler(this.maleRdBtn_CheckedChanged);
            // 
            // cmndTxt
            // 
            this.cmndTxt.Location = new System.Drawing.Point(168, 227);
            this.cmndTxt.MaxLength = 12;
            this.cmndTxt.Name = "cmndTxt";
            this.cmndTxt.Size = new System.Drawing.Size(316, 26);
            this.cmndTxt.TabIndex = 24;
            this.cmndTxt.TextChanged += new System.EventHandler(this.cmndTxt_TextChanged);
            this.cmndTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmndTxt_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "CMND:";
            // 
            // sdtTxt
            // 
            this.sdtTxt.Location = new System.Drawing.Point(168, 188);
            this.sdtTxt.MaxLength = 12;
            this.sdtTxt.Name = "sdtTxt";
            this.sdtTxt.Size = new System.Drawing.Size(316, 26);
            this.sdtTxt.TabIndex = 22;
            this.sdtTxt.TextChanged += new System.EventHandler(this.sdtTxt_TextChanged);
            this.sdtTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sdtTxt_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Số điện thoại:";
            // 
            // diachiTxt
            // 
            this.diachiTxt.Location = new System.Drawing.Point(168, 85);
            this.diachiTxt.Multiline = true;
            this.diachiTxt.Name = "diachiTxt";
            this.diachiTxt.Size = new System.Drawing.Size(316, 87);
            this.diachiTxt.TabIndex = 20;
            this.diachiTxt.TextChanged += new System.EventHandler(this.diachiTxt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Địa chỉ:";
            // 
            // hotenTxt
            // 
            this.hotenTxt.Location = new System.Drawing.Point(168, 46);
            this.hotenTxt.Name = "hotenTxt";
            this.hotenTxt.Size = new System.Drawing.Size(316, 26);
            this.hotenTxt.TabIndex = 18;
            this.hotenTxt.TextChanged += new System.EventHandler(this.hotenTxt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Họ tên:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 20);
            this.label5.TabIndex = 29;
            this.label5.Text = "Thuộc chi nhánh:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 274);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 31;
            this.label7.Text = "Ngày cấp:";
            // 
            // ngaycapDateTime
            // 
            this.ngaycapDateTime.CustomFormat = "dd-MM-yyyy";
            this.ngaycapDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ngaycapDateTime.Location = new System.Drawing.Point(168, 268);
            this.ngaycapDateTime.Name = "ngaycapDateTime";
            this.ngaycapDateTime.Size = new System.Drawing.Size(316, 26);
            this.ngaycapDateTime.TabIndex = 32;
            // 
            // chinhanhTxt
            // 
            this.chinhanhTxt.Location = new System.Drawing.Point(168, 309);
            this.chinhanhTxt.Name = "chinhanhTxt";
            this.chinhanhTxt.ReadOnly = true;
            this.chinhanhTxt.Size = new System.Drawing.Size(316, 26);
            this.chinhanhTxt.TabIndex = 30;
            this.chinhanhTxt.Text = "CN001";
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(12, 341);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(93, 38);
            this.removeBtn.TabIndex = 33;
            this.removeBtn.Text = "Xóa";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Visible = false;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // AddClient
            // 
            this.AcceptButton = this.addBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 393);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.ngaycapDateTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chinhanhTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.femaleRdBtn);
            this.Controls.Add(this.maleRdBtn);
            this.Controls.Add(this.cmndTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.sdtTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.diachiTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hotenTxt);
            this.Controls.Add(this.label2);
            this.Name = "AddClient";
            this.Text = "Thêm khách hàng";
            this.Load += new System.EventHandler(this.AddClient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.RadioButton femaleRdBtn;
        private System.Windows.Forms.RadioButton maleRdBtn;
        private System.Windows.Forms.TextBox cmndTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox sdtTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox diachiTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox hotenTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker ngaycapDateTime;
        private System.Windows.Forms.TextBox chinhanhTxt;
        private System.Windows.Forms.Button removeBtn;
    }
}