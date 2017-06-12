using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Songjiang_District_Peoples_Court
{
    public class SqlHelper
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private string connStr;
        public SqlHelper(string connstr)
        {
            connStr = connstr;
        }
        /// <summary>
        /// excel数据导入数据库
        /// </summary>
        /// <param name="ImportDt">表格数据</param>
        /// <param name="removedRows">最后需要删除的行数</param>
        /// <returns></returns>
        public bool InsertDataTable(DataTable ImportDt, int removedRows)
        {
            string[] strColumns = GetColumnsByDataTable(ImportDt);
            if (strColumns.Length == 0)
            {
                return false;
            }
            string sCol = string.Join(",", strColumns);
            StringBuilder sb;
            SqlConnection con = new SqlConnection(connStr);//连接数据库
            con.Open();
            SqlTransaction trans = con.BeginTransaction();//事物对象 
            try
            {
                SqlCommand com = new SqlCommand();//数据操作对象  
                com.Connection = con;//指定连接  
                com.Transaction = trans;//指定事物
                string sql = @"INSERT INTO [MonthStatement] ([department],[lyDeposit],[ltyDeposit],[tbAcceptance],[Acceptance],[AcceptanceCount],[lyAcceptance],[AcceptanceCompared],[tbClosedCase],[ClosedCase],[ClosedCaseCount],[lyClosedCase],[ClosedCaseCompared],[NotClosed],[lyNotClosed],[NotClosedCompared],[monthConcurrentClosingrate],[allConcurrentClosingrate],[lyConcurrentClosingrate],[ConcurrentClosingrateCompared],[Closingrate],[lyClosingrate],[ClosingrateCompared],[opcode],[importdt],[title])";
                string sqlHeader = @"INSERT INTO [dbo].[StatementHeader]([title],[header]) VALUES('{0}','{1}')";
                if (ImportDt.Rows.Count > 0)
                {
                    for (int ii = 1; ii < ImportDt.Rows.Count - removedRows; ii++)
                    {  //对datatable循环
                        sb = new StringBuilder();
                        sb.Append(sql);
                        sb.Append("values('");
                        for (int i = 0; i < ImportDt.Columns.Count; i++)
                        {
                            sb.Append(ImportDt.Rows[ii][ImportDt.Columns[i].ColumnName].ToString() + "','");
                        }
                        sb.Append(GlobalEnvironment.GlobalUser.UserName + "','");
                        sb.Append(DateTime.Now.ToString() + "','");
                        sb.Append(GlobalEnvironment.title);
                        sb.Append("')");
                        com.CommandText = sb.ToString();
                        com.ExecuteNonQuery();//执行该行   
                    }
                    sqlHeader = string.Format(sqlHeader, GlobalEnvironment.title, sCol);
                    com.CommandText = sqlHeader;
                    com.ExecuteNonQuery();   
                    trans.Commit();//如果全部执行完毕.提交 
                }
            }
            catch (Exception ex)
            {
                trans.Rollback();//如果有异常.回滚. 
                return false;
            }
            finally
            {
                con.Close();//关闭连接 
            }
            return true;
        }

        /// <summary>
        /// 获取标题内容
        /// </summary>
        /// <returns></returns>
        public DataSet GetTitle()
        {
            try
            {
                string sql = @"select distinct title from MonthStatement";
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connStr))
                {
                    using (DataSet ds = new DataSet())
                    {
                        adapter.Fill(ds);
                        adapter.SelectCommand.Parameters.Clear();
                        return ds;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// 获取标题下所有内容
        /// </summary>
        /// <returns></returns>
        public DataSet GetStatement(string title)
        {
            string sql = @"select [department],[lyDeposit],[ltyDeposit],[tbAcceptance],[Acceptance],[AcceptanceCount],[lyAcceptance],[AcceptanceCompared],[tbClosedCase],[ClosedCase],[ClosedCaseCount],[lyClosedCase],[ClosedCaseCompared],[NotClosed],[lyNotClosed],[NotClosedCompared],[monthConcurrentClosingrate],[allConcurrentClosingrate],[lyConcurrentClosingrate],[ConcurrentClosingrateCompared],[Closingrate],[lyClosingrate],[ClosingrateCompared] from v_MonthStatement where title = '{0}'";
            try
            {
                sql = string.Format(sql, title);
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connStr))
                {
                    using (DataSet ds = new DataSet())
                    {
                        adapter.Fill(ds);
                        adapter.SelectCommand.Parameters.Clear();
                        return ds;     
                    }
                }              
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取标题下的表头信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetHeader(string title)
        {
            string sql = @"select header from StatementHeader where title = '{0}'";
            try
            {
                sql = string.Format(sql, title);
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connStr))
                {
                    using (DataSet ds = new DataSet())
                    {
                        adapter.Fill(ds);
                        adapter.SelectCommand.Parameters.Clear();
                        return ds;
                    }
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static string[] GetColumnsByDataTable(DataTable dt)
        {
            string[] strColumns = null;
            if (dt.Columns.Count > 0)
            {
                int columnNum = 0;
                columnNum = dt.Columns.Count;
                strColumns = new string[columnNum];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    strColumns[i] = string.Format("{0}", dt.Columns[i].ColumnName);
                }
            }
            return strColumns;
        }


    }
}
