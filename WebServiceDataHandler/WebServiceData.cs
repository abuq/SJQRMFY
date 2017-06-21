using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;

namespace WebServiceDataHandler
{
    public partial class WebServiceData : DevExpress.XtraEditors.XtraForm
    {
        public WebServiceData()
        {
            InitializeComponent();
        }
        #region 私有变量
        /// <summary>
        /// 指标代码
        /// </summary>
        private string code;
        /// <summary>
        /// 起始年
        /// </summary>
        private string begYear;
        /// <summary>
        /// 起始月
        /// </summary>
        private string begMonth;
        /// <summary>
        /// 起始日
        /// </summary>
        private string begDay;
        /// <summary>
        /// 终止年
        /// </summary>
        private string endYear;
        /// <summary>
        /// 终止月
        /// </summary>
        private string endMonth;
        /// <summary>
        /// 终止日
        /// </summary>
        private string endDay;
        /// <summary>
        /// 法院编码
        /// </summary>
        private string fybm;
        /// <summary>
        /// 业务庭编码
        /// </summary>
        private string bmbm;
        /// <summary>
        /// 法官编码
        /// </summary>
        private string rybm;
        /// <summary>
        /// 其他
        /// </summary>
        private string other;
        private string xml;
        #endregion
        private void btnGet_Click(object sender, EventArgs e)
        {
            localhost.WebService1 gyReport = new localhost.WebService1();
            code = txtCode.Text;
            begYear = txtBegYear.Text;
            begMonth = txtBegMonth.Text;
            begDay = txtBegDay.Text;
            endYear = txtEndYear.Text;
            endMonth = txtEndMonth.Text;
            endDay = txtEndDay.Text;
            fybm = txtFybm.Text;
            bmbm = txtBmbm.Text;
            rybm = txtRybm.Text;
            other = txtOther.Text;
            xml = gyReport.getIndexValue(code, begDay, begMonth, begDay, endYear, endMonth, endDay, fybm, bmbm, rybm, other);
            if (xml.Length>0)
            {
                
                XmlDocument xd = new XmlDocument();
                xd.LoadXml(xml);
                memoEdit1.Text = xd.InnerXml;
            }
        }
    }
}