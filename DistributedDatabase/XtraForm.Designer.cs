namespace DistributedDatabase
{
    partial class XtraForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraForm));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.gridControl3 = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemSearchControl1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchControl();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.undoBarBtn = new DevExpress.XtraBars.BarButtonItem();
            this.redoBarBtn = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tKCtrlFrm = new DistributedDatabase.TaiKhoanUC();
            this.nVCtrlFrm = new DistributedDatabase.NhanVienUC();
            this.kHCtrlFrm = new DistributedDatabase.KhachHangUC();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cachedReportAsMATK1 = new DistributedDatabase.CachedReportAsMATK();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchControl1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl3
            // 
            this.gridControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl3.Location = new System.Drawing.Point(0, 0);
            this.gridControl3.MainView = this.gridView3;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.Size = new System.Drawing.Size(1627, 447);
            this.gridControl3.TabIndex = 1;
            this.gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3,
            this.gridView7});
            this.gridControl3.Click += new System.EventHandler(this.gridControl3_Click);
            this.gridControl3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridControl3_KeyPress);
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.gridControl3;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsBehavior.ReadOnly = true;
            this.gridView3.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView3_SelectionChanged);
            this.gridView3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridView3_KeyUp);
            this.gridView3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridView3_KeyPress);
            this.gridView3.Click += new System.EventHandler(this.gridView3_Click);
            this.gridView3.DoubleClick += new System.EventHandler(this.gridView3_DoubleClick);
            // 
            // gridView7
            // 
            this.gridView7.GridControl = this.gridControl3;
            this.gridView7.Name = "gridView7";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barEditItem1,
            this.barButtonItem4,
            this.barButtonItem5,
            this.undoBarBtn,
            this.redoBarBtn,
            this.barButtonItem6});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 9;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSearchControl1});
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.barEditItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.undoBarBtn),
            new DevExpress.XtraBars.LinkPersistInfo(this.redoBarBtn)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            toolTipTitleItem1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipTitleItem1.Appearance.Options.UseImage = true;
            toolTipTitleItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem1.Image")));
            toolTipItem1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            toolTipItem1.Appearance.Options.UseImage = true;
            toolTipItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolTipItem1.Image")));
            toolTipItem1.LeftIndent = 6;
            toolTipTitleItem2.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            toolTipTitleItem2.Appearance.Options.UseImage = true;
            toolTipTitleItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem2.Image")));
            toolTipTitleItem2.LeftIndent = 6;
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            superToolTip1.Items.Add(toolTipTitleItem2);
            this.barButtonItem1.SuperTip = superToolTip1;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.Glyph")));
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.LargeGlyph")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.Glyph")));
            this.barButtonItem3.Id = 2;
            this.barButtonItem3.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.LargeGlyph")));
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemSearchControl1;
            this.barEditItem1.Id = 3;
            this.barEditItem1.ImageUri.Uri = "Zoom";
            this.barEditItem1.Name = "barEditItem1";
            this.barEditItem1.Width = 150;
            this.barEditItem1.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.barEditItem1_HyperlinkClick);
            this.barEditItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barEditItem1_ItemClick);
            this.barEditItem1.ItemPress += new DevExpress.XtraBars.ItemClickEventHandler(this.barEditItem1_ItemPress);
            // 
            // repositoryItemSearchControl1
            // 
            this.repositoryItemSearchControl1.AllowAutoApply = false;
            this.repositoryItemSearchControl1.AutoHeight = false;
            this.repositoryItemSearchControl1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.repositoryItemSearchControl1.Name = "repositoryItemSearchControl1";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "search";
            this.barButtonItem4.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.Glyph")));
            this.barButtonItem4.Id = 4;
            this.barButtonItem4.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.LargeGlyph")));
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // undoBarBtn
            // 
            this.undoBarBtn.Caption = "Undo";
            this.undoBarBtn.Glyph = ((System.Drawing.Image)(resources.GetObject("undoBarBtn.Glyph")));
            this.undoBarBtn.Id = 6;
            this.undoBarBtn.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("undoBarBtn.LargeGlyph")));
            this.undoBarBtn.Name = "undoBarBtn";
            toolTipTitleItem3.Text = "Undo";
            superToolTip2.Items.Add(toolTipTitleItem3);
            this.undoBarBtn.SuperTip = superToolTip2;
            this.undoBarBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6_ItemClick);
            // 
            // redoBarBtn
            // 
            this.redoBarBtn.Caption = "Redo";
            this.redoBarBtn.Glyph = ((System.Drawing.Image)(resources.GetObject("redoBarBtn.Glyph")));
            this.redoBarBtn.Id = 7;
            this.redoBarBtn.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("redoBarBtn.LargeGlyph")));
            this.redoBarBtn.Name = "redoBarBtn";
            toolTipTitleItem4.Text = "Undo";
            superToolTip3.Items.Add(toolTipTitleItem4);
            this.redoBarBtn.SuperTip = superToolTip3;
            this.redoBarBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.redoBarBtn_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1627, 36);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 830);
            this.barDockControlBottom.Size = new System.Drawing.Size(1627, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 36);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 794);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1627, 36);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 794);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Undo";
            this.barButtonItem5.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.Glyph")));
            this.barButtonItem5.Id = 5;
            this.barButtonItem5.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.LargeGlyph")));
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "save";
            this.barButtonItem6.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.Glyph")));
            this.barButtonItem6.Id = 8;
            this.barButtonItem6.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.LargeGlyph")));
            this.barButtonItem6.Name = "barButtonItem6";
            toolTipTitleItem5.Text = "Lưu thông tin";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "Khi chọn,bạn không thể quay lại những thay đổi trước đó";
            superToolTip4.Items.Add(toolTipTitleItem5);
            superToolTip4.Items.Add(toolTipItem2);
            this.barButtonItem6.SuperTip = superToolTip4;
            this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6_ItemClick_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 483);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1627, 347);
            this.panel1.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tKCtrlFrm);
            this.groupBox1.Controls.Add(this.nVCtrlFrm);
            this.groupBox1.Controls.Add(this.kHCtrlFrm);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1627, 347);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bảng Điều Khiển";
            // 
            // tKCtrlFrm
            // 
            this.tKCtrlFrm.Location = new System.Drawing.Point(59, 73);
            this.tKCtrlFrm.Name = "tKCtrlFrm";
            this.tKCtrlFrm.Size = new System.Drawing.Size(917, 191);
            this.tKCtrlFrm.TabIndex = 2;
            this.tKCtrlFrm.Visible = false;
            // 
            // nVCtrlFrm
            // 
            this.nVCtrlFrm.Location = new System.Drawing.Point(42, 43);
            this.nVCtrlFrm.Name = "nVCtrlFrm";
            this.nVCtrlFrm.Size = new System.Drawing.Size(945, 263);
            this.nVCtrlFrm.TabIndex = 1;
            this.nVCtrlFrm.Visible = false;
            this.nVCtrlFrm.Load += new System.EventHandler(this.nVCtrlFrm_Load);
            // 
            // kHCtrlFrm
            // 
            this.kHCtrlFrm.Location = new System.Drawing.Point(59, 36);
            this.kHCtrlFrm.Name = "kHCtrlFrm";
            this.kHCtrlFrm.Size = new System.Drawing.Size(928, 228);
            this.kHCtrlFrm.TabIndex = 0;
            this.kHCtrlFrm.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridControl3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1627, 447);
            this.panel2.TabIndex = 7;
            // 
            // XtraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1627, 830);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "XtraForm";
            this.Text = "XtraForm";
            this.Load += new System.EventHandler(this.XtraForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchControl1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView7;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchControl repositoryItemSearchControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem undoBarBtn;
        private DevExpress.XtraBars.BarButtonItem redoBarBtn;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DistributedDatabase.KhachHangUC kHCtrlFrm;
        private CachedReportAsMATK cachedReportAsMATK1;
        private NhanVienUC nVCtrlFrm;
        private TaiKhoanUC tKCtrlFrm;
    }
}