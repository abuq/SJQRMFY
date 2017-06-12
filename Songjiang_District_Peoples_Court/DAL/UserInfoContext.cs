using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Songjiang_District_Peoples_Court.DAL
{
   public class UserInfoContext : DbContext
    {
       public UserInfoContext()
           : base("ConnStr")
        { 
        }
       public DbSet<UserIP> UserIPInfo { get; set; }

    }
}
