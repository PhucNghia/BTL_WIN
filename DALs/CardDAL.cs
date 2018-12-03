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

        // Validate CardNo
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

        // Validate Pin
        public string getStatus(string cardNo)
        {
            try
            {
                string status = "";
                string sql = "Select Status from Card where CardNo = @cardNo";
                conn.Open();
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

        public int getAttempt(string cardNo)
        {
            try
            {
                int attempt = 0;
                string sql = "Select Attempt from Card where CardNo = @cardNo";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    attempt = Convert.ToInt16(dr["Attempt"].ToString());
                }
                conn.Close();
                return attempt;
            }
            catch (Exception)
            {
                conn.Close();
                return 0;
            }
        }

        public void updateAttemptStatus(string cardNo,bool reAttempt)
        {
            try
            {
                int attempt = getAttempt(cardNo) + 1;
                string sql = "";
                if (reAttempt)
                {
                    attempt = 0;
                }
                if (attempt < 3)
                    sql = "update Card set Attempt = @attempt where CardNo = @cardNo";
                else
                {
                    attempt = 3;
                    sql = "update Card set Attempt = @attempt, Status = 'block' where CardNo = @cardNo";
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("attempt", attempt);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                conn.Close();
            }
        }

        public string getPIN(string cardNo)
        {
            try
            {
                conn.Open();
                string pin = "";
                string sql = "Select PIN from Card where CardNo = @cardNo";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    pin = dr["Pin"].ToString().Trim();
                }
                conn.Close();
                return pin;
            }
            catch (Exception)
            {
                conn.Close();
                return "";
            }
        }

        public bool changePIN(string cardNo, string newPIN)
        {
            try
            {
                conn.Open();
               
                string sql = "update Card set PIN= @newPIN where CardNo = @cardNo";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                cmd.Parameters.AddWithValue("newPIN", newPIN);
                cmd.ExecuteNonQuery();
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
