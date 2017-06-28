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
using System.IO;

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
            ServiceReference1.OpenAxisWebServiceClient gyreport2 = new ServiceReference1.OpenAxisWebServiceClient();
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

            xml = gyreport2.getIndexValue(code, begYear, begMonth, begDay, endYear, endMonth, endDay, fybm, bmbm, rybm, other);
            //xml = gyReport.getIndexValue(code, begDay, begMonth, begDay, endYear, endMonth, endDay, fybm, bmbm, rybm, other);
            if (xml.Length > 0)
            {
                //memoEdit1.Text = xml;
                XmlDocument xd = new XmlDocument();
                xd.LoadXml(xml);
                memoEdit1.Text = xd.InnerXml;
                gcXml.DataSource = ConvertXMLToDataSet(xml).Tables[0];
                gcXml.MainView.PopulateColumns();
            }
        }

        private DataSet ConvertXMLToDataSet(string xmlData)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                DataSet xmlDS = new DataSet();
                stream = new StringReader(xmlData);
                reader = new XmlTextReader(stream);
                xmlDS.ReadXml(reader);
                return xmlDS;
            }
            catch (Exception ex)
            {
                string strTest = ex.Message;
                return null;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel2003文件(*.xls)|*.xls";
            sfd.ValidateNames = true;
            //sfd.CheckFileExists = true;
            //sfd.CheckPathExists = true;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                gcXml.ExportToXls(sfd.FileName);
            }

        }
    }
}