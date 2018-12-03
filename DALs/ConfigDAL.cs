using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using DTO;

namespace DALs
{
    public class ConfigDAL
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ToString());

        public int getMaxWithDraw()
        {
            try
            {
                int maxWithDraw = -1;
                string query = "select MaxWithdraw from Config";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    maxWithDraw = Convert.ToInt32(dr["MaxWithdraw"]);
                }
                conn.Close();
                return maxWithDraw;
            }
            catch
            {
                conn.Close();
                return -1;
            }
        }
    }
}
