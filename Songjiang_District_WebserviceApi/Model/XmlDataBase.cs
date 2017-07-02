using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Songjiang_District_WebserviceApi.Model
{
    public class XmlDataBase
    {
        public string BeginMonth { get; set; }
        public string EndMonth { get; set; }
        public string DepartMent { get; set; }
    }

    public class XmlDataSas : XmlDataBase
    {
        public string Sas { get; set; }
    }
    public class XmlDataJas : XmlDataBase
    {
        public string Jas { get; set; }
    }
    public class XmlDataCas : XmlDataBase
    {
        public string Cas { get; set; }
    }
}
