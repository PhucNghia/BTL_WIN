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
    public class StockDAL
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ToString());
        public bool updateQuantity(string atmID, string moneyID, int quantity )
        {
            try
            {
                int currenQuantity = -1;
                string query = "select Quantity from Stock  where ATMID = @atmId and MoneyID = @moneyID";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("atmId", atmID);
                cmd.Parameters.AddWithValue("moneyID", moneyID);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    currenQuantity = Convert.ToInt32(dr["Quantity"]);
                }
                conn.Close();
                int newQuantity = currenQuantity - quantity;
                if (newQuantity < 0)
                    return false;

                string queryUpdate = "update Stock set Quantity = @newQuantity where ATMID = @atmId and MoneyID = @moneyID";
                conn.Open();
                SqlCommand cmd1 = new SqlCommand(queryUpdate, conn);
                cmd1.Parameters.AddWithValue("newQuantity", newQuantity);
                cmd1.Parameters.AddWithValue("atmId", atmID);
                cmd1.Parameters.AddWithValue("moneyID", moneyID);
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

        public int getQuantity(string atmID, string moneyID)
        {
            try
            {
                int currentQuantity = -1;
                string query = "select Quantity from Stock  where ATMID = @atmId and MoneyID = @moneyID";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("atmId", atmID);
                cmd.Parameters.AddWithValue("moneyID", moneyID);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    currentQuantity = Convert.ToInt32(dr["Quantity"]);
                }
                conn.Close();
                return currentQuantity;
            }
            catch
            {
                conn.Close();
                return -1;
            }
        }
    }
}
