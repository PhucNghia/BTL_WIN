using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DALs
{
    public class CustomerDAL
    {
        string strCon = ConfigurationManager.ConnectionStrings["connString"].ToString();
        SqlConnection connect = null;
        SqlCommand cmd = null;

        public string getNameCustomer(string cardNo)
        {
            try
            {
                string name = "";
                string query = @"Select Customer.Name from Account inner join Customer 
                            on Account.CustID = Customer.CustomerID inner join Card
                            on Account.AccountID = Card.AccountID
                             where CardNo = @cardNo";
                connect = new SqlConnection(strCon);
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    name = dr["Name"].ToString();
                }
                connect.Close();
                return name;
            }
            catch
            {
                connect.Close();
                return "";
            }
        }
    }
}
