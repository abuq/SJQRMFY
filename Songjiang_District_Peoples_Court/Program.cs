using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Songjiang_District_Peoples_Court
{
    static class Program
    {

        public static EventWaitHandle ProgramStarted;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createNew;
            ProgramStarted = new EventWaitHandle(false, EventResetMode.AutoReset, "Songjiang_District_Peoples_Court", out createNew);

            // 如果该命名事件已经存在(存在有前一个运行实例)，则发事件通知并退出  
            if (!createNew)
            {
                ProgramStarted.Set();
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormLogin());
            FormLogin login = new FormLogin();
            if (login.ShowDialog() == DialogResult.OK)//注意这里要显示模态对话框
            {
                Application.Run(new FormMain());
            }
        }
    }
}
