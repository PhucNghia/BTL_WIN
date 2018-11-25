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
    public class AccountDAL
    {
        string strcon = ConfigurationManager.ConnectionStrings["connString"].ToString();
        SqlConnection conn = null;
        SqlCommand cmd = null;
        public int getBalance(string cardNo)
        {
            try
            {
                int balance = -1;
                string query = "Select  Account.Balance from Account inner join Card on Account.AccountID = Card.AccountID where CardNo = @cardNo";
                conn = new SqlConnection();
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    balance = Convert.ToInt32(dr["Balance"]);
                }
                conn.Close();
                return balance;
                
            }
            catch 
            {
                conn.Close();
                return -1;        
            }       

        }
    }
}
