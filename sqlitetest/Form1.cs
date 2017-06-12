using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sqlitetest
{
    public partial class Form1 : Form
    {
        private string connectionString = "";
        public Form1()
        {
            InitializeComponent();
            connectionString = string.Format(@"Data Source={0}\svrdatabase.s3db;Version=3;", Application.StartupPath);
        }

        private void btnGetColumns_Click(object sender, EventArgs e)
        {

            SQLiteConnection con = new SQLiteConnection(connectionString);
            SQLiteCommand cmd = new SQLiteCommand("select * from USER_TABLE", con);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //MyContext context = new MyContext();
            //var empList = context.Users.OrderBy(c => c.USERNAME).ToList();
            //dataGridView1.DataSource = empList;

        }

        private DataTable GetReaderSchema(string tableName, SQLiteConnection connection)
        {
            DataTable schemaTable = null;
            IDbCommand cmd = new SQLiteCommand();
            cmd.CommandText = string.Format("select * from [{0}]", tableName);
            cmd.Connection = connection;

            using (IDataReader reader = cmd.ExecuteReader(CommandBehavior.KeyInfo | CommandBehavior.SchemaOnly))
            {
                schemaTable = reader.GetSchemaTable();
            }
            return schemaTable;
        }
    }
}
