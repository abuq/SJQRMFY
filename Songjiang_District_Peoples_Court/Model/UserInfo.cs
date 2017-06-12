using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Songjiang_District_Peoples_Court
{
    public  class UserInfo
    {
        /// <summary>
        /// 用户ID，由编号和用户名组合而成，中间|分割
        /// </summary>
        public  string UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public  string UserName { get; set; }
        /// <summary>
        /// 密码（明码）
        /// </summary>
        public  string PassWord { get; set; }
        /// <summary>
        /// 所属分组
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// 上级用户
        /// </summary>
        public List<string> UpUserId { get; set; }
        /// <summary>
        /// 下级用户
        /// </summary>
        public List<string> DownUserId { get; set; }
        /// <summary>
        /// 用户IP
        /// </summary>
        public string IP { get; set; }


    }
    [Serializable]
    public class UserIP
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public string IPAddress { get; set; }
    }
}
