namespace DistributedDatabase
{
    partial class GiaoDichOption
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
            this.fromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.toDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.matkCmb = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.giaodichCmb = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày:";
            // 
            // fromDatePicker
            // 
            this.fromDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDatePicker.Location = new System.Drawing.Point(163, 16);
            this.fromDatePicker.Name = "fromDatePicker";
            this.fromDatePicker.Size = new System.Drawing.Size(203, 26);
            this.fromDatePicker.TabIndex = 1;
            // 
            // toDatePicker
            // 
            this.toDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toDatePicker.Location = new System.Drawing.Point(163, 58);
            this.toDatePicker.Name = "toDatePicker";
            this.toDatePicker.Size = new System.Drawing.Size(203, 26);
            this.toDatePicker.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mã Tài Khoản:";
            // 
            // matkCmb
            // 
            this.matkCmb.FormattingEnabled = true;
            this.matkCmb.Location = new System.Drawing.Point(163, 102);
            this.matkCmb.Name = "matkCmb";
            this.matkCmb.Size = new System.Drawing.Size(203, 28);
            this.matkCmb.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 45);
            this.button1.TabIndex = 10;
            this.button1.Text = "Xem Giao Dịch";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(231, 196);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 45);
            this.button2.TabIndex = 11;
            this.button2.Text = "Hủy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Loại Giao Dịch:";
            // 
            // giaodichCmb
            // 
            this.giaodichCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.giaodichCmb.FormattingEnabled = true;
            this.giaodichCmb.Items.AddRange(new object[] {
            "Tất Cả",
            "Gửi Tiền",
            "Chuyển Tiền",
            "Rút Tiền"});
            this.giaodichCmb.Location = new System.Drawing.Point(163, 148);
            this.giaodichCmb.Name = "giaodichCmb";
            this.giaodichCmb.Size = new System.Drawing.Size(203, 28);
            this.giaodichCmb.TabIndex = 9;
            this.giaodichCmb.SelectedIndexChanged += new System.EventHandler(this.giaodichCmb_SelectedIndexChanged);
            // 
            // GiaoDichOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 253);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.giaodichCmb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.matkCmb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.toDatePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fromDatePicker);
            this.Controls.Add(this.label1);
            this.Name = "GiaoDichOption";
            this.Text = "GiaoDichOption";
            this.Load += new System.EventHandler(this.GiaoDichOption_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker fromDatePicker;
        private System.Windows.Forms.DateTimePicker toDatePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox matkCmb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox giaodichCmb;
    }
}