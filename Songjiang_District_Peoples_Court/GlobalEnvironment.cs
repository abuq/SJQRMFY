using System;
using System.Collections.Generic;
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
    }

}
