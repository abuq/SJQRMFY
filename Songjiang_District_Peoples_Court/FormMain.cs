using DevExpress.XtraEditors;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Songjiang_District_Peoples_Court
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            this.WindowState = (System.Windows.Forms.FormWindowState)GlobalEnvironment.windowState;
            this.ShowInTaskbar = GlobalEnvironment.windowState != 1;
        }
        #region 私有变量
        private DataTable odtImport = null;
        private SqlHelper osh = new SqlHelper(GlobalEnvironment.connStr);
        #endregion

        #region 控件事件
        /// <summary>
        /// 窗体最小化时显示托盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                notifyIcon1.Visible = true;
            }
            else
            {
                notifyIcon1.Visible = false;
            }
        }
        /// <summary>
        /// 双击显示界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            barStaticItem1.Caption = GlobalEnvironment.GlobalUser.UserName;
            xtraTabbedMdiManager1.MdiParent = this;
            if (FormSetting.ReadFiles())
            {
                foreach (var item in GlobalEnvironment.TimeTriggers)
                {
                    item.Value.Tick += OnTimerTick;
                    item.Value.Start();
                }
            }
            barBtnShow_ItemClick(null, null);
        }

        private void barBtnSetting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormSetting fs = new FormSetting();
            OpenMDIWindow(fs);

        }

        public void OnTimerTick(object sender, EventArgs e)
        {
            if (IsDisposed)
            {
                if (GlobalEnvironment.TimeTriggers.ContainsKey(DateTime.Now.ToShortTimeString() + ":00"))
                {
                    GlobalEnvironment.TimeTriggers[DateTime.Now.ToShortTimeString() + ":00"].Stop();
                }
                return;
            }
            if (notifyIcon1.Visible == true)
            {
                notifyIcon1.ShowBalloonTip(60000, "您有新的数据推送", "您有新的数据推送", ToolTipIcon.Info);
            }
            if (GlobalEnvironment.TimeTriggers.ContainsKey(DateTime.Now.ToShortTimeString() + ":00"))
            {
                GlobalEnvironment.TimeTriggers[DateTime.Now.ToShortTimeString() + ":00"].Stop();
            }
        }

        private void barBtnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ImportData();
        }

        private void barBtnShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormView fv = new FormView();
            OpenMDIWindow(fv);
        }

        private void tsmImport_Click(object sender, EventArgs e)
        {
            ImportData();
        }

        private void tsmShow_Click(object sender, EventArgs e)
        {
            FormView fv = new FormView();
            fv.Show();
        }

        private void tsmSetting_Click(object sender, EventArgs e)
        {
            FormSetting fs = new FormSetting();
            fs.Show();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FormExit())
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// excel数据获取，返回datatable
        /// </summary>
        private DataTable ExcelImport()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Excel文件";
            ofd.FileName = "";
            ofd.Filter = "Excel2003文件(*.xls)|*.xls|Excel2007文件(*.xlsx)|*.xlsx";
            ofd.ValidateNames = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.RestoreDirectory = true;
            string strName = string.Empty;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                strName = ofd.FileName;
            }
            if (strName == "")
            {
                XtraMessageBox.Show("没有选择Excel文件！无法进行数据导入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            else
            {
                try
                {
                    using (ExcelHelper excelHelper = new ExcelHelper(strName))
                    {
                        DataTable odt = excelHelper.ExcelToDataTable(null, true, 1);
                        if (odt.Rows.Count > 0)
                        {
                            return odt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("从电子表格文件中装载数据异常！" + ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            return null;
        }

        /// <summary>
        /// 数据导入数据库
        /// </summary>
        private void ImportData()
        {
            odtImport = ExcelImport();
            DataSet odsTitle = osh.GetTitle();
            if (odsTitle != null && odsTitle.Tables.Count == 1)
            {
                foreach (DataRow odr in odsTitle.Tables[0].Rows)
                {
                    if (odr["title"].ToString() == GlobalEnvironment.title)
                    {
                        XtraMessageBox.Show(string.Format("已存在{0}的数据，不能再次导入！", GlobalEnvironment.title), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            if (odtImport != null && odtImport.Rows.Count > 0)
            {
                if (osh.InsertDataTable(odtImport, 0))
                {
                    XtraMessageBox.Show("导入成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GlobalEnvironment.title = "";
                }
                else
                {
                    XtraMessageBox.Show("导入失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        /// 加载窗体   
        /// </summary>   
        /// <param name="oForm">窗体</param>    
        private void OpenMDIWindow(Form oForm)
        {
            string fullName = oForm.Name;
            if (ContainMDIChild(fullName))
                return;
            oForm.MdiParent = this;
            oForm.Show();
            xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[oForm];    //使得标签的选择为当前新建的窗口
        }

        /// <summary>   
        /// 判断MDI中是否已存在当前窗体   
        /// </summary>   
        /// <param name="formName">窗体类型名称</param>   
        /// <returns></returns>   
        private bool ContainMDIChild(string formName)
        {
            foreach (Form f in MdiChildren)
            {
                if (f.Name == formName)
                {
                    f.Select();
                    return true;
                }
            }
            return false;
        }

        private bool FormExit()
        {
            FormExit fe = new FormExit();
            if (fe.ShowDialog() == DialogResult.OK)
            {
                return true;
            }
            return false;
        }
        #endregion




    }
}
