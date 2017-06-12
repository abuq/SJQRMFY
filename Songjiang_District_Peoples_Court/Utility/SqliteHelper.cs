using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Songjiang_District_Peoples_Court
{
    public static class SqliteHelper
    {
        private static string connectionString = string.Format(@"Data Source={0}\svrdatabase.s3db;Version=3;", Application.StartupPath);
        public static DataTable GetData(string sql)
        {
            SQLiteConnection con = new SQLiteConnection(connectionString);
            SQLiteCommand cmd = new SQLiteCommand(sql, con);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
