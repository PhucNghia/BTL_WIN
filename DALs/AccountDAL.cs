using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using DTOs;

namespace DALs
{
    public class AccountDAL
    {
        OverDraftDAL overdraftDAL = new OverDraftDAL();
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ToString());

        public int getBalance(string cardNo)
        {
            try
            {
                int balance = -1;
                string query = "select Account.Balance from Account inner join Card on Account.AccountID = Card.AccountID where CardNo = @cardNo";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
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

        public bool updateBalance(int money, string cardNo) 
        {
            try
            {
                int balance = getBalance(cardNo);
                int newBalance = balance - money - 1100;    // trừ thêm lệ phí là 1100 vnd

                string queryUpdate = "update Account set Account.Balance = @newBalance " +
                    "from Account inner join Card on Account.AccountID = Card.AccountID where Card.CardNo = @cardNo ";
                conn.Open();
                SqlCommand cmd1 = new SqlCommand(queryUpdate, conn);
                cmd1.Parameters.AddWithValue("newBalance", newBalance);
                cmd1.Parameters.AddWithValue("cardNo", cardNo);
                cmd1.ExecuteNonQuery();

                conn.Close();
                return true;
            }
            catch
            {
                conn.Close();
                return false;
            }
        }

        public string getAccountID(string cardNo)
        {
            try
            {
                string accountID = "";
                string query = "select Account.AccountID from Account join Card on Account.AccountID = Card.AccountID where Card.CardNo = @cardNo";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    accountID = dr[0].ToString();
                }
                conn.Close();
                return accountID;
            }
            catch
            {
                conn.Close();
                return "";
            }
        }

        public bool compareBalance(int money, string cardNo)
        {
            try
            {
                int balance = -1;
                int overdraft = overdraftDAL.getOverDraft(cardNo);
                string query = "Select Account.Balance from Account inner join Card on Account.AccountID = Card.AccountID where CardNo = @cardNo";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    balance = Convert.ToInt32(dr["Balance"]);
                }
                conn.Close();
                if (money <= balance +overdraft)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                conn.Close();
                return false;
            }
        }

        public int UpdateBalance(int money, string cardNo, string cardNoTo, int transferFee)
        {
            try
            {
                int balance = -1;
                string query = "SELECT Account.Balance FROM Account INNER JOIN Card ON Account.AccountID = Card.AccountID WHERE CardNo = @cardNo";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    balance = Convert.ToInt32(dr["Balance"]);
                }
                conn.Close();
                int newBalance = balance - money - transferFee;

                string queryUpdate = "UPDATE Account SET Account.Balance = @newBalance FROM Account INNER JOIN Card ON Account.AccountID = Card.AccountID WHERE Card.CardNo = @cardNo ";
                conn.Open();
                SqlCommand cmd1 = new SqlCommand(queryUpdate, conn);
                cmd1.Parameters.AddWithValue("newBalance", newBalance);
                cmd1.Parameters.AddWithValue("cardNo", cardNo);
                cmd1.ExecuteNonQuery();
                conn.Close();

                UpdateBalanceTo(money, cardNoTo);
                return newBalance;
            }
            catch
            {
                conn.Close();
                return 0;
            }
        }

        public void UpdateBalanceTo(int money, string cardNo)
        {
            try
            {
                int balance = -1;
                string query = "SELECT Account.Balance FROM Account INNER JOIN Card ON Account.AccountID = Card.AccountID WHERE CardNo = @cardNo";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    balance = Convert.ToInt32(dr["Balance"]);
                }
                conn.Close();
                int newBalance = balance + money;

                string queryUpdate = "UPDATE Account SET Account.Balance = @newBalance FROM Account INNER JOIN Card ON Account.AccountID = Card.AccountID WHERE Card.CardNo = @cardNo ";
                conn.Open();
                SqlCommand cmd1 = new SqlCommand(queryUpdate, conn);
                cmd1.Parameters.AddWithValue("newBalance", newBalance);
                cmd1.Parameters.AddWithValue("cardNo", cardNo);
                cmd1.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                conn.Close();
            }
        }
    }
}
