using Songjiang_District_WebserviceApi.Model;
using Songjiang_District_WebserviceApi.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Songjiang_District_WebserviceApi
{
    public partial class FormImport : Form
    {
        public FormImport()
        {
            InitializeComponent();
        }
        private string fybm = "21A000";
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToString();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string year = DateTime.Now.Year.ToString();
            string lastYear = (DateTime.Now.Year - 1).ToString();
            string lastTwoYear = (DateTime.Now.Year - 2).ToString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();
            //上年旧存
            XDocument lyDepositXml = WebServiceDataHelper.Getdate("5805", lastYear, "1", "", lastYear, "12", "", fybm, "", "", "");
            //去年上年旧存
            XDocument ltyDepositXml = WebServiceDataHelper.Getdate("5805", lastTwoYear, "1", "", lastTwoYear, "12", "", fybm, "", "", "");
            //当月收案
            XDocument acceptanceXml = WebServiceDataHelper.Getdate("5606", year, month, "", year, month, "", fybm, "", "", "");
            //当年收案
            XDocument acceptanceCountXml = WebServiceDataHelper.Getdate("5606", year, "1", "", year, month, "", fybm, "", "", "");
            //去年收案
            XDocument lyAcceptanceXml = WebServiceDataHelper.Getdate("5606", lastYear, "1", "", lastYear, "12", "", fybm, "", "", "");
            //当月结案
            XDocument closedCaseXml = WebServiceDataHelper.Getdate("5705", year, month, "", year, month, "", fybm, "", "", "");
            //当年结案
            XDocument closedCaseCountXml = WebServiceDataHelper.Getdate("5705", year, "1", "", year, month, "", fybm, "", "", "");
            //去年结案
            XDocument lyClosedCaseXml = WebServiceDataHelper.Getdate("5705", lastYear, "1", "", lastYear, "12", "", fybm, "", "", "");
            //当月存案
            XDocument notClosedXml = WebServiceDataHelper.Getdate("5805", year, month, "", year, month, "", fybm, "", "", "");
            //去年当月存案
            XDocument lyNotClosedXml = WebServiceDataHelper.Getdate("5805", lastYear, month, "", lastYear, month, "", fybm, "", "", "");

            var Deposit = lyDepositXml.Elements("data").Select(d => new XmlDataCas
                          {
                              BeginMonth = d.Element("qsny").Value,
                              EndMonth = d.Element("zzny").Value,
                              DepartMent = d.Element("ywtmc").Value,
                              Cas = d.Element("cas").Value
                          }).ToList();
        }
    }
}
