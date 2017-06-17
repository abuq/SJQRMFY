using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Songjiang_District_Peoples_Court
{
    public partial class FormView : Form
    {
        public FormView()
        {
            InitializeComponent();
        }
        #region 私有变量
        private SqlHelper osh = new SqlHelper(GlobalEnvironment.connStr);
        private DataView currentView;
        private DataTable odtGroup;
        private List<string> headerList = new List<string>();
        #endregion
        private void FormView_Load(object sender, EventArgs e)
        {
            //获取标题信息
            DataSet odsTitle = osh.GetTitle();
            if (odsTitle != null && odsTitle.Tables.Count == 1)
            {
                foreach (DataRow odr in odsTitle.Tables[0].Rows)
                {
                    cbbTitle.Properties.Items.Add(odr["title"].ToString());
                }
            }
            //没有下属信息则隐藏下属选择栏
            //if (GlobalEnvironment.GlobalUser.DownUserId != null && GlobalEnvironment.GlobalUser.DownUserId.Count > 0)
            //{
            //    layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //    cbbDownUsers.Properties.Items.AddRange(GlobalEnvironment.GlobalUser.DownUserId);
            //}
            //else
            //{
            //    layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //}
            //预加载信息
            if (cbbTitle.Properties.Items.Count > 0)
            {
                cbbTitle.SelectedIndex = 0;
                btnSearch_Click(null, null);
            }
        }

        private void cbbDownUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取分组信息
            string sqlGroup = string.Format("select * from GROUP_TABLE where USERS like '%{0}%'", cbbDownUsers.SelectedItem.ToString());
            odtGroup = SqliteHelper.GetData(sqlGroup);
            if (odtGroup.Rows.Count == 1)
            {
                //currentView.RowFilter = string.Format("{0} = '{1}'", headerList[0], odtGroup.Rows[0]["GROUPNAME"].ToString());
                gcExcelData.DataSource = currentView.ToTable();
                gvExcelData.BestFitColumns();
                gvExcelData.Appearance.HeaderPanel.Font = new Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbbTitle.SelectedIndex < 0)
            {
                return;
            }
            DataSet odsStatement = osh.GetStatement(cbbTitle.SelectedItem.ToString());
            DataSet odsHeader = osh.GetHeader(cbbTitle.SelectedItem.ToString());
            if (odsStatement != null && odsStatement.Tables.Count == 1 && odsHeader != null && odsHeader.Tables.Count == 1)
            {
                string headers = odsHeader.Tables[0].Rows[0]["header"].ToString();
                headerList = headers.Split(',').ToList();
                List<string> ignoreHeader = GlobalEnvironment.ignoreHeader.Split(',').ToList();
                DataTable odtStatement = odsStatement.Tables[0];
                //按照顺序将表头名称改成excel中文
                for (int i = 0; i < odtStatement.Columns.Count; i++)
                {
                    odtStatement.Columns[i].ColumnName = headerList[i];
                }
                //不需要显示的列删除
                foreach (var iHeader in ignoreHeader)
                {
                    odtStatement.Columns.Remove(iHeader);
                }
                currentView = new DataView(odtStatement);
                //currentView.RowFilter = string.Format("{0} = '{1}'", headerList[0], GlobalEnvironment.GlobalUser.GroupName);
                gcExcelData.DataSource = currentView.ToTable();
                gcExcelData.MainView.PopulateColumns();
                gvExcelData.BestFitColumns();
                gvExcelData.Appearance.HeaderPanel.Font = new Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }

        private void gvExcelData_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.RowHandle >= 0)
            {
                string depart = view.GetRowCellDisplayText(e.RowHandle, view.Columns[headerList[0]]);
                if (depart == GlobalEnvironment.GlobalUser.GroupName)
                {
                    e.Appearance.BackColor = Color.LightYellow;
                }
            }
        }
    }
}
