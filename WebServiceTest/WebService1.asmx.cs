using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServiceTest
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://gyreport.hshfy.sh.cn")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
     //[System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string getIndexValue(string index_code,string beg_year,string beg_month,string beg_day,string end_year,string end_month,string end_day,string fybm,string bmbm,string rybm,string others)
        {
            string xml =  ReadFile(index_code);
            if (xml.Length > 0)
            {
                return xml;
            }
            return ReadFile("error");
        }

        private string ReadFile(string fileName)
        {
            try
            {
                string AbsoluteFileName =Server.MapPath("./") + "ReturnXml/"+fileName+".xml";
                if (File.Exists(AbsoluteFileName))
                {
                    return File.ReadAllText(AbsoluteFileName);
                }
                //return AbsoluteFileName;
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
            return "";
        }
    }

}
