using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SQLite;
using System.Data.Common;
namespace sqlitetest
{
    [Table("USER_TABLE")]
    public class UserInfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string USERID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }

    }

    public class MyContext : DbContext
    {
        public DbSet<UserInfo> Users { get; set; }

        public MyContext()
            : base("SqliteTest")
        {
           
        }
    }
}
