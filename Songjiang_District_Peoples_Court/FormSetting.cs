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
    public partial class FormSetting : Form
    {
        public FormSetting()
        {
            InitializeComponent();
        }

        #region 控件事件
        private void btnSetting_Click(object sender, EventArgs e)
        {
            if (GlobalEnvironment.TimeTriggers.ContainsKey(dtpSetting.Text))
            {
                XtraMessageBox.Show("已存在时间" + dtpSetting.Text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            GlobalEnvironment.TimeTriggers.Add(dtpSetting.Text, CreateTimer(dtpSetting.Value));
            if (SaveFiles(GlobalEnvironment.TimeTriggers.Keys.ToList()))
            {
                GcTimes.DataSource = GlobalEnvironment.TimeTriggers.Keys.ToList();
            }
            GlobalEnvironment.TimeTriggers[dtpSetting.Text].Tick += ((FormMain)this.MdiParent).OnTimerTick;
            GlobalEnvironment.TimeTriggers[dtpSetting.Text].Start();
        }

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

        private void FormSetting_Load(object sender, EventArgs e)
        {
            if (GlobalEnvironment.TimeTriggers.Count > 0)
            {
                GcTimes.DataSource = GlobalEnvironment.TimeTriggers.Keys.ToList();
            }
        }

        /// <summary>
        /// 删除配置时间点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GlobalEnvironment.TimeTriggers.Remove(this.gvTimes.GetFocusedRowCellValue("Column").ToString());
            if (SaveFiles(GlobalEnvironment.TimeTriggers.Keys.ToList()))
            {
                this.gvTimes.DeleteRow(gvTimes.FocusedRowHandle);
                GcTimes.DataSource = GlobalEnvironment.TimeTriggers.Keys.ToList();
            }
        } 
        #endregion

        #region 公共方法
        /// <summary>
        /// 保存配置时间至本地
        /// </summary>
        /// <param name="settingTimes"></param>
        /// <returns></returns>
        public static bool SaveFiles(List<string> settingTimes)
        {
            if (settingTimes != null && settingTimes.Count > 0)
            {
                string times = string.Join(",", settingTimes);
                try
                {
                    File.WriteAllText(GlobalEnvironment.settingFilePath, times);          
                    return true;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString());
                    return false;
                }
            }
            else
            {
                File.Delete(GlobalEnvironment.settingFilePath);
            }
            return true;
        }
        /// <summary>
        /// 读取本地配置时间
        /// </summary>
        /// <returns></returns>
        public static bool ReadFiles()
        {
            if (File.Exists(GlobalEnvironment.settingFilePath))
            {
                try
                {
                    string times = File.ReadAllText(GlobalEnvironment.settingFilePath);
                    if (!string.IsNullOrEmpty(times))
                    {
                        var timeList = times.Split(',').ToList();
                        foreach (string item in timeList)
                        {
                            GlobalEnvironment.TimeTriggers.Add(item, CreateTimer(Convert.ToDateTime(item)));
                        }
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// 根据配置时间创建定时器
        /// </summary>
        /// <param name="settingTime"></param>
        /// <returns></returns>
        public static Timer CreateTimer(DateTime settingTime)
        {
            var timer = new Timer();
            DateTime newSetTime = Convert.ToDateTime(settingTime.ToShortTimeString());
            TimeSpan ts;
            if (DateTime.Compare(DateTime.Now, newSetTime) > 0)
            {
                ts = DateTime.Now - newSetTime;
            }
            else
            {
                ts = newSetTime - DateTime.Now;
            }
            timer.Interval = Convert.ToInt32(ts.TotalMilliseconds);
            return timer;
        } 
        #endregion
    }
}
