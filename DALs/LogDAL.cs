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
                int id = (Int32)cmd.ExecuteScalar() + 1;
                conn.Close();
                return "LOG" + id;
            }
            catch (Exception)
            {
                conn.Close();
                return "";
            }
        }
        public void createLog( string logType, string atmID, string cardNo, DateTime logDate, decimal amount, string details, string cardNoTo)
        {
            string logId = getLogID();
            try
            {
                string query = "insert into Log values(@logId, @logType, @atmID, @cardNo, " +
                    "convert(datetime, @date, 5), @amount, @details, @cardTo)";
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
                return;
            }
            catch (Exception)
            {
                conn.Close();
                return;
            }
        }

        public int getTotalAmount(string logTypeID, string atmID, string cardNo, string startDate, string endDate)
        {
            int totalAmount = 0;
            try
            {
                string query = "select sum(Log.Amount) from Card inner join Log on Card.CardNo = Log.CardNo " +
                    "inner join ATM on ATM.ATMID = Log.ATMID " +
                    "inner join LogType on LogType.LogTypeID = Log.LogTypeID " +
                    "where LogType.LogTypeID = @logTypeID And ATM.ATMID = @atmID And Card.CardNo = @cardNo And " +
                    "LogDate >= @startDate and LogDate <= @endDate";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("logTypeID", logTypeID);
                cmd.Parameters.AddWithValue("atmID", atmID);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                cmd.Parameters.AddWithValue("startDate", startDate);
                cmd.Parameters.AddWithValue("endDate", endDate);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    totalAmount = int.Parse(dr[0].ToString());
                }

                conn.Close();
                return totalAmount;
            }
            catch (Exception)
            {
                conn.Close();
                return -1;
            }
        }
    }
}
