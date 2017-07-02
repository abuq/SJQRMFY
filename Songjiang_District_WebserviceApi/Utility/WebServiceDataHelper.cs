using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Songjiang_District_WebserviceApi.Utility
{
    public static class WebServiceDataHelper
    {
        static ServiceReference1.OpenAxisWebServiceClient gyreport = new ServiceReference1.OpenAxisWebServiceClient();
        public static XDocument Getdate(string code, string begYear, string begMonth, string begDay, string endYear, string endMonth, string endDay, string fybm, string bmbm, string rybm, string other)
        {
            string xml = gyreport.getIndexValue(code, begYear, begMonth, begDay, endYear, endMonth, endDay, fybm, bmbm, rybm, other);
            if (xml.Length > 0)
            {
                XDocument xd = XDocument.Parse(xml);              
                return xd;
            }
            return null;
        }
    }
}
