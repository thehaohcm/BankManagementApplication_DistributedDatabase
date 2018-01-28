namespace DistributedDatabase
{
    partial class NhanVienUC
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
            this.chinhanhCmb = new System.Windows.Forms.ComboBox();
            this.removeBtn = new System.Windows.Forms.Button();
            this.manvTxt = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.themcsBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.femaleRdBtn = new System.Windows.Forms.RadioButton();
            this.hotenTxt = new System.Windows.Forms.TextBox();
            this.maleRdBtn = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.diachiTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sdtTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chinhanhCmb
            // 
            this.chinhanhCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chinhanhCmb.FormattingEnabled = true;
            this.chinhanhCmb.Location = new System.Drawing.Point(644, 152);
            this.chinhanhCmb.Name = "chinhanhCmb";
            this.chinhanhCmb.Size = new System.Drawing.Size(282, 28);
            this.chinhanhCmb.TabIndex = 31;
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(24, 201);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(93, 38);
            this.removeBtn.TabIndex = 30;
            this.removeBtn.Text = "Xóa";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Visible = false;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // manvTxt
            // 
            this.manvTxt.Location = new System.Drawing.Point(176, 41);
            this.manvTxt.Name = "manvTxt";
            this.manvTxt.Size = new System.Drawing.Size(152, 26);
            this.manvTxt.TabIndex = 18;
            this.manvTxt.Text = "NV0001";
            this.manvTxt.TextChanged += new System.EventHandler(this.manvTxt_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(798, 201);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 38);
            this.button2.TabIndex = 29;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Mã nhân viên: ";
            // 
            // themcsBtn
            // 
            this.themcsBtn.Enabled = false;
            this.themcsBtn.Location = new System.Drawing.Point(644, 201);
            this.themcsBtn.Name = "themcsBtn";
            this.themcsBtn.Size = new System.Drawing.Size(148, 38);
            this.themcsBtn.TabIndex = 28;
            this.themcsBtn.Text = "Thêm";
            this.themcsBtn.UseVisualStyleBackColor = true;
            this.themcsBtn.Click += new System.EventHandler(this.themcsBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Họ tên:";
            // 
            // femaleRdBtn
            // 
            this.femaleRdBtn.AutoSize = true;
            this.femaleRdBtn.Location = new System.Drawing.Point(407, 42);
            this.femaleRdBtn.Name = "femaleRdBtn";
            this.femaleRdBtn.Size = new System.Drawing.Size(54, 24);
            this.femaleRdBtn.TabIndex = 27;
            this.femaleRdBtn.TabStop = true;
            this.femaleRdBtn.Text = "Nữ";
            this.femaleRdBtn.UseVisualStyleBackColor = true;
            this.femaleRdBtn.CheckedChanged += new System.EventHandler(this.femaleRdBtn_CheckedChanged);
            // 
            // hotenTxt
            // 
            this.hotenTxt.Location = new System.Drawing.Point(176, 78);
            this.hotenTxt.Name = "hotenTxt";
            this.hotenTxt.Size = new System.Drawing.Size(282, 26);
            this.hotenTxt.TabIndex = 20;
            this.hotenTxt.TextChanged += new System.EventHandler(this.hotenTxt_TextChanged);
            // 
            // maleRdBtn
            // 
            this.maleRdBtn.AutoSize = true;
            this.maleRdBtn.Location = new System.Drawing.Point(334, 42);
            this.maleRdBtn.Name = "maleRdBtn";
            this.maleRdBtn.Size = new System.Drawing.Size(67, 24);
            this.maleRdBtn.TabIndex = 26;
            this.maleRdBtn.TabStop = true;
            this.maleRdBtn.Text = "Nam";
            this.maleRdBtn.UseVisualStyleBackColor = true;
            this.maleRdBtn.CheckedChanged += new System.EventHandler(this.maleRdBtn_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(488, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Địa chỉ:";
            // 
            // diachiTxt
            // 
            this.diachiTxt.Location = new System.Drawing.Point(644, 41);
            this.diachiTxt.Multiline = true;
            this.diachiTxt.Name = "diachiTxt";
            this.diachiTxt.Size = new System.Drawing.Size(282, 91);
            this.diachiTxt.TabIndex = 22;
            this.diachiTxt.TextChanged += new System.EventHandler(this.diachiTxt_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(488, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Thuộc chi nhánh:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Số điện thoại:";
            // 
            // sdtTxt
            // 
            this.sdtTxt.Location = new System.Drawing.Point(176, 154);
            this.sdtTxt.MaxLength = 12;
            this.sdtTxt.Name = "sdtTxt";
            this.sdtTxt.Size = new System.Drawing.Size(282, 26);
            this.sdtTxt.TabIndex = 24;
            this.sdtTxt.TextChanged += new System.EventHandler(this.sdtTxt_TextChanged);
            this.sdtTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sdtTxt_KeyPress);
            // 
            // NhanVienUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chinhanhCmb);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.manvTxt);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.themcsBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.femaleRdBtn);
            this.Controls.Add(this.hotenTxt);
            this.Controls.Add(this.maleRdBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.diachiTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sdtTxt);
            this.Name = "NhanVienUC";
            this.Size = new System.Drawing.Size(945, 263);
            this.Load += new System.EventHandler(this.NhanVienUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox chinhanhCmb;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.TextBox manvTxt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button themcsBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton femaleRdBtn;
        private System.Windows.Forms.TextBox hotenTxt;
        private System.Windows.Forms.RadioButton maleRdBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox diachiTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sdtTxt;
    }
}
