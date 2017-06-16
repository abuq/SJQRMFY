namespace Songjiang_District_Peoples_Court
{
    partial class FormView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormView));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.deStart = new DevExpress.XtraEditors.DateEdit();
            this.deEnd = new DevExpress.XtraEditors.DateEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.cbbTitle = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbbDownUsers = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gcExcelData = new DevExpress.XtraGrid.GridControl();
            this.gvExcelData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbDownUsers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcExcelData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExcelData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.deStart);
            this.layoutControl1.Controls.Add(this.deEnd);
            this.layoutControl1.Controls.Add(this.btnSearch);
            this.layoutControl1.Controls.Add(this.cbbTitle);
            this.layoutControl1.Controls.Add(this.cbbDownUsers);
            this.layoutControl1.Controls.Add(this.gcExcelData);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(740, 268, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(934, 461);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // deStart
            // 
            this.deStart.EditValue = null;
            this.deStart.Location = new System.Drawing.Point(480, 12);
            this.deStart.Name = "deStart";
            this.deStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deStart.Size = new System.Drawing.Size(125, 20);
            this.deStart.StyleController = this.layoutControl1;
            this.deStart.TabIndex = 9;
            // 
            // deEnd
            // 
            this.deEnd.EditValue = null;
            this.deEnd.Location = new System.Drawing.Point(660, 12);
            this.deEnd.Name = "deEnd";
            this.deEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deEnd.Size = new System.Drawing.Size(125, 20);
            this.deEnd.StyleController = this.layoutControl1;
            this.deEnd.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(832, 12);
            this.btnSearch.MaximumSize = new System.Drawing.Size(90, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 22);
            this.btnSearch.StyleController = this.layoutControl1;
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbbTitle
            // 
            this.cbbTitle.Location = new System.Drawing.Point(63, 12);
            this.cbbTitle.Name = "cbbTitle";
            this.cbbTitle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbTitle.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbbTitle.Size = new System.Drawing.Size(362, 20);
            this.cbbTitle.StyleController = this.layoutControl1;
            this.cbbTitle.TabIndex = 6;
            // 
            // cbbDownUsers
            // 
            this.cbbDownUsers.Location = new System.Drawing.Point(63, 36);
            this.cbbDownUsers.Name = "cbbDownUsers";
            this.cbbDownUsers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbDownUsers.Size = new System.Drawing.Size(765, 20);
            this.cbbDownUsers.StyleController = this.layoutControl1;
            this.cbbDownUsers.TabIndex = 5;
            this.cbbDownUsers.SelectedIndexChanged += new System.EventHandler(this.cbbDownUsers_SelectedIndexChanged);
            // 
            // gcExcelData
            // 
            this.gcExcelData.Font = new System.Drawing.Font("宋体", 10F);
            this.gcExcelData.Location = new System.Drawing.Point(12, 60);
            this.gcExcelData.MainView = this.gvExcelData;
            this.gcExcelData.Name = "gcExcelData";
            this.gcExcelData.Size = new System.Drawing.Size(910, 389);
            this.gcExcelData.TabIndex = 4;
            this.gcExcelData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvExcelData});
            // 
            // gvExcelData
            // 
            this.gvExcelData.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gvExcelData.Appearance.FixedLine.Options.UseFont = true;
            this.gvExcelData.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvExcelData.Appearance.FocusedRow.Options.UseFont = true;
            this.gvExcelData.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvExcelData.Appearance.Row.Options.UseFont = true;
            this.gvExcelData.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvExcelData.Appearance.SelectedRow.Options.UseFont = true;
            this.gvExcelData.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvExcelData.GridControl = this.gcExcelData;
            this.gvExcelData.Name = "gvExcelData";
            this.gvExcelData.OptionsBehavior.Editable = false;
            this.gvExcelData.OptionsCustomization.AllowGroup = false;
            this.gvExcelData.OptionsView.ColumnAutoWidth = false;
            this.gvExcelData.OptionsView.ShowGroupPanel = false;
            this.gvExcelData.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvExcelData_RowStyle);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem4,
            this.layoutControlItem2,
            this.layoutControlItem6,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(934, 461);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcExcelData;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(914, 393);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.cbbTitle;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(417, 24);
            this.layoutControlItem3.Text = "选择标题";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(777, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(43, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnSearch;
            this.layoutControlItem4.Location = new System.Drawing.Point(820, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(94, 48);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cbbDownUsers;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(820, 24);
            this.layoutControlItem2.Text = "选择下属";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            this.layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.deStart;
            this.layoutControlItem6.Location = new System.Drawing.Point(417, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(180, 24);
            this.layoutControlItem6.Text = "导入时间";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(48, 14);
            this.layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.deEnd;
            this.layoutControlItem5.Location = new System.Drawing.Point(597, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(180, 24);
            this.layoutControlItem5.Text = "至";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(48, 14);
            this.layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // FormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 461);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据查看";
            this.Load += new System.EventHandler(this.FormView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbDownUsers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcExcelData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExcelData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gcExcelData;
        private DevExpress.XtraGrid.Views.Grid.GridView gvExcelData;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.ComboBoxEdit cbbDownUsers;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.ComboBoxEdit cbbTitle;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.DateEdit deStart;
        private DevExpress.XtraEditors.DateEdit deEnd;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;

    }
}