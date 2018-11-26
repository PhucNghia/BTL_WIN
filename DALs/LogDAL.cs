using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace DALs
{
    public class LogDAL
    {
        string strcon = ConfigurationManager.ConnectionStrings["connString"].ToString();
        SqlConnection conn = null;
        SqlCommand cmd = null;
        public List<LogDTO> getAllLog(string cardNo)
        {
            try
            {
         
                List<LogDTO> arrLog = new List<LogDTO>();
                string query = "select * from Log where CardNo = @cardNo";
                conn = new SqlConnection(strcon);
                conn.Open();
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    LogDTO log = new LogDTO(
                        dr["LogID"].ToString(),
                        dr["logTypeID"].ToString(),
                        dr["ATMID"].ToString(),
                        dr["CardNo"].ToString(),
                        dr["LogDate"].ToString(),
                        Convert.ToInt32(dr["Amount"]),
                        dr["Details"].ToString(),
                        dr["CardNoTo"].ToString());
                    arrLog.Add(log);
                }
                conn.Close();
                return arrLog;
            }
            catch
            {
                conn.Close();
                return null;
            }
        }

        
    }
}
