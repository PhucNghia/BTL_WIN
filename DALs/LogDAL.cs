using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace DALs
{
   public class LogDAL
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ToString());
        private string getLogID()
        {
            try
            {
                string sql = "Select count(*) from Log";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                int id = (Int32)cmd.ExecuteScalar();
                conn.Close();
                return "LOG" + id + 1;
            }
            catch (Exception)
            {
                conn.Close();
                return "";
            }
        }
        public bool createLog( string logType, string atmID, string cardNo, string logDate, decimal amount, string details, string cardNoTo)
        {
            string logId = getLogID();
            try
            {
                string query = "insert into Log values(@logId,@logType,@atmID,@cardNo, @date,@amount,@details,@cardTo)";
                conn.Open();
                SqlCommand cmd1 = new SqlCommand(query, conn);
                cmd1.Parameters.AddWithValue("logId", logId);
                cmd1.Parameters.AddWithValue("logType", logType);
                cmd1.Parameters.AddWithValue("atmID", atmID);
                cmd1.Parameters.AddWithValue("cardNo", cardNo);
                cmd1.Parameters.AddWithValue("date", logDate);
                cmd1.Parameters.AddWithValue("amount", amount);
                cmd1.Parameters.AddWithValue("details", details);
                cmd1.Parameters.AddWithValue("cardTo", cardNoTo);
                cmd1.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception)
            {
                conn.Close();
                return false;
            }
        }

    }
}
