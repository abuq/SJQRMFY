using DevExpress.Utils;
using DevExpress.XtraEditors;
using Songjiang_District_Peoples_Court.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Songjiang_District_Peoples_Court
{
    public partial class FormExit : Form
    {
        public FormExit()
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
            this.DialogResult = DialogResult.Cancel;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
           

        }
       
        private void Login(string userName, string Password = null)
        {
            
            string sqlLogin = Password != null ? string.Format("select * from USER_TABLE where USERNAME = '{0}' and PASSWORD = '{1}'", userName, Password) : string.Format("select * from USER_TABLE where USERNAME = '{0}'", userName);
            DataTable oDtLogin = SqliteHelper.GetData(sqlLogin);
            if (oDtLogin.Rows.Count == 1)
            {
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                XtraMessageBox.Show("用户名或者密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserName.Focus();
            }
        }
    }
}
