using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Songjiang_District_Peoples_Court
{
    public partial class FormImportManagement : Form
    {
        public FormImportManagement()
        {
            InitializeComponent();
        }
        private SqlHelper osh = new SqlHelper(GlobalEnvironment.connStr);
        #region 控件事件
       

        /// <summary>
        /// 显示行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvTimes_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = e.RowHandle.ToString();
                }
            }
        }

        private void FormImportManagement_Load(object sender, EventArgs e)
        {
            DataSet odsTitle = osh.GetTitle();
            if (odsTitle != null && odsTitle.Tables.Count == 1)
            {
                GcImportDt.DataSource = odsTitle.Tables[0];
            }
        }

        /// <summary>
        /// 删除配置时间点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (osh.DeleteByTitle(this.gvImportDt.GetFocusedRowCellValue("title").ToString()))
            {
                this.gvImportDt.DeleteRow(gvImportDt.FocusedRowHandle); 
            }
        } 
        #endregion

      

       
    }
}
