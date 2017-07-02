using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Songjiang_District_Peoples_Court
{
    public class GlobalEnvironment
    {
        /// <summary>
        /// 全局用户
        /// </summary>
        public static UserInfo GlobalUser = new UserInfo();
        /// <summary>
        /// 提醒时间集合
        /// </summary>
        public static Dictionary<string, Timer> TimeTriggers = new Dictionary<string, Timer>();
        /// <summary>
        /// 提醒时间本地保存路径
        /// </summary>
        public static string settingFilePath = Path.Combine(Application.StartupPath, "setting.txt");
        /// <summary>
        /// 数据库连接
        /// </summary>
        public static string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        /// <summary>
        /// 当前excel标题
        /// </summary>
        public static string title = "";
        /// <summary>
        /// 业务庭结案情况表不需要显示的列
        /// </summary>
        public static string ignoreHeader = ConfigurationManager.AppSettings["ignoreHeader"].ToString();
        /// <summary>
        /// 窗口启动大小 2最大化 1最小化 0正常大小
        /// </summary>
        public static int windowState = Convert.ToInt32(ConfigurationManager.AppSettings["windowState"]); 
    }

}
