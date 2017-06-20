using System;
using System.Collections.Generic;
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
            switch (index_code)
            {
                case "5601":
                    break;
                case "5602":
                    break;
                case "5603":
                    break;
                case "5604":
                    break;
                case "5605":
                    break;
                case "5606":
                    break;
                case "5607":
                    break;
                case "5608":
                    break;
                case "5701":
                    break;
                case "5702":
                    break;
                case "5703":
                    break;
                case "5704":
                    break;
                case "5705":
                    break;
                case "5706":
                    break;
                case "5707":
                    break;
                case "5708":
                    break;
                case "5709":
                    break;
                case "5710":
                    break;
                case "5801":
                    break;
                case "5802":
                    break;
                case "5803":
                    break;
                case "5804":
                    break;
                case "5805":
                    break;
                case "5806":
                    break;
                case "5807":
                    break;
                case "601":
                    break;
                case "602":
                    break;
                case "603":
                    break;
                case "901":
                    break;
                case "902":
                    break;
                case "903":
                    break;
                case "1401":
                    break;
                case "1402":
                    break;
                case "1403":
                    break;
                case "2001":
                    break;
                case "2002":
                    break;
                case "2003":
                    break;
                case "2101":
                    break;
                case "2102":
                    break;
                case "2103":
                    break;
                case "2201":
                    break;
                case "2202":
                    break;
                case "2203":
                    break;
                case "2601":
                    break;
                case "2602":
                    break;
                case "2603":
                    break;
                case "2801":
                    break;
                case "2802":
                    break;
                case "2803":
                    break;
                case "3101":
                    break;
                case "3102":
                    break;
                case "3103":
                    break;
                case "3401":
                    break;
                case "3402":
                    break;
                case "3403":
                    break;
                case "4401":
                    break;
                case "4402":
                    break;
                case "4403":
                    break;
                case "5201":
                    break;
                case "5202":
                    break;
                case "5203":
                    break;
                case "6901":
                    break;
                case "7001":
                    break;
                case "9201":
                    break;
                case "6001":
                    break;
                case "6002":
                    break;
                case "6003":
                    break;
                case "6004":
                    break;
                case "6006":
                    break;
                case "6008":
                    break;
                case "5722":
                    break;
                case "5723":
                    break;
                case "5724":
                    break;
                case "5725":
                    break;
                case "5727":
                    break;
                case "5728":
                    break;
                case "5711":
                    break;
                case "5712":
                    break;
                case "5812":
                    break;
                case "5813":
                    break;
                case "5814":
                    break;
                case "5817":
                    break;
                case "5818":
                    break;
                case "50101":
                    break;
                case "50102":
                    break;
                case "50103":
                    break;
                case "50501":
                    break;
                case "50502":
                    break;
                case "50503":
                    break;
                case "50504":
                    break;
                case "50513":
                    break;
                case "50514":
                    break;
                case "50515":
                    break;
                case "10103":
                    break;
                case "10104":
                    break;
                case "10106":
                    break;
                default:
                    break;
            }
            return "你好";       
        }
    }
}
