using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DTO;

namespace DALs
{
    public class CardDAL
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ToString());
        public bool checkCardNo(string cardNo)
        {
            try
            {
                conn.Open();
                CardDTO cardDTO = null;
                string sql = "select * from Card where CardNo = @cardNo";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cardDTO = new CardDTO(
                        dr["CardNo"].ToString(),
                        dr["Status"].ToString(),
                        dr["AccountID"].ToString(),
                        dr["PIN"].ToString(),
                        dr["StartDate"].ToString(),
                        dr["ExpiredDate"].ToString(),
                        int.Parse(dr["Attempt"].ToString()));
                }
                conn.Close();
                if (cardDTO == null)
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                conn.Close();
                return false;
            }
        }

        public string getExpiredDate(string cardNo)
        {
            try
            {
                conn.Open();
                string expiredDate = "";
                string sql = "Select ExpiredDate from Card where CardNo = @cardNo";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    expiredDate = DateTime.Parse(dr["ExpiredDate"].ToString()).ToString("yyyy-MM-dd");
                }
                conn.Close();
                return expiredDate;
            }
            catch (Exception)
            {
                conn.Close();
                return "";
            }
        }

        public string getStatus(string cardNo)
        {
            try
            {
                conn.Open();
                string status = "";
                string sql = "Select Status from Card where CardNo = @cardNo";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    status = dr["Status"].ToString();
                }
                conn.Close();
                return status;
            }
            catch (Exception)
            {
                conn.Close();
                return "";
            }
        }


    }
}
