using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DALs
{
    public class WithdrawLimitDAL
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ToString());
        public int getWithdrawLimit(string cardNo)
        {
            try
            {
                int withdrawLimit = -1;
                string query = "select WithdrawLimit.Value from " +
                    "Account inner join Card on Account.AccountID = Card.AccountID " +
                    "inner join WithdrawLimit on Account.WDID = WithdrawLimit.WDID " +
                    "where CardNo = @cardNo";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    withdrawLimit = Convert.ToInt32(dr["Value"]);
                }
                conn.Close();

                conn.Close();
                return withdrawLimit;
            }
            catch
            {
                conn.Close();
                return -1;
            }
        }
    }
}
