using DevExpress.Utils;
using DevExpress.XtraEditors;
using Songjiang_District_Peoples_Court.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Songjiang_District_Peoples_Court
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        private UserInfoContext db = new UserInfoContext();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login(txtUserName.Text.Trim(), txtPassword.Text.Trim());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            //System.Diagnostics.Process myProcess = System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath, "AutoUpdater.exe"));
            //myProcess.WaitForExit();
            string localIP = GetLocalIP();
            var user = db.UserIPInfo.Where(u => u.IPAddress == localIP).ToList();
            if (user.Count == 1)
            {
                Login(user[0].UserName);
                this.DialogResult = DialogResult.OK;
            }

        }
        private string GetLocalIP()
        {
            string hostname = Dns.GetHostName();//得到本机名   
            IPHostEntry localhost = Dns.GetHostByName(hostname);
            //IPHostEntry localhost = Dns.GetHostEntry(hostname);   
            IPAddress localaddr = localhost.AddressList[0];
            return localaddr.ToString();
        }
        private void Login(string userName, string Password = null)
        {
            WaitDialogForm wfd = new WaitDialogForm("", "正在登录...");
            string sqlLogin = Password != null ? string.Format("select * from USER_TABLE where USERNAME = '{0}' and PASSWORD = '{1}'", userName, Password) : string.Format("select * from USER_TABLE where USERNAME = '{0}'", userName);
            DataTable oDtLogin = SqliteHelper.GetData(sqlLogin);
            if (oDtLogin.Rows.Count == 1)
            {
                GlobalEnvironment.GlobalUser.UserId = oDtLogin.Rows[0]["USERID"].ToString();
                GlobalEnvironment.GlobalUser.UserName = oDtLogin.Rows[0]["USERNAME"].ToString();
                //获取所属组信息
                wfd.SetCaption("获取所属组信息...");
                string sqlGroup = string.Format("select * from GROUP_TABLE where USERS like '%{0}%'", GlobalEnvironment.GlobalUser.UserId);
                DataTable oDtGroup = SqliteHelper.GetData(sqlGroup);
                if (oDtGroup.Rows.Count == 1)
                {
                    GlobalEnvironment.GlobalUser.GroupName = oDtGroup.Rows[0]["GROUPNAME"].ToString();
                }
                //获取上下级信息
                wfd.SetCaption("获取上下级信息...");
                string sqlUpDown = string.Format("select * from RELUSER_TABLE where USERID = '{0}'", GlobalEnvironment.GlobalUser.UserId);
                DataTable oDtUpDown = SqliteHelper.GetData(sqlUpDown);
                if (oDtUpDown.Rows.Count == 1)
                {
                    string downUserId = oDtUpDown.Rows[0]["DNUSER"].ToString();
                    if (!string.IsNullOrEmpty(downUserId))
                    {
                        GlobalEnvironment.GlobalUser.DownUserId = downUserId.Substring(0, downUserId.Length - 1).Split(',').ToList();
                    }
                }
                wfd.Close();
                this.Visible = false;
                this.DialogResult = DialogResult.OK;
                //FormMain fm = new FormMain();
                //fm.Show();
            }
            else
            {
                XtraMessageBox.Show("用户名或者密码不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserName.Focus();
            }
        }
    }
}
