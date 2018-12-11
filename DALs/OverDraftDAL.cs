﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DALs
{
    public class OverDraftDAL
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ToString());
        public int getOverDraft(string cardNo)
        {
            try
            {
                int overDraft = -1;
                string query = "Select OverDraft.Value from "
                    + "Account inner join Card on Account.AccountID = Card.AccountID " 
                    + "inner join OverDraft on Account.ODID = OverDraft.ODID "
                    + "where CardNo = @cardNo";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    overDraft = Convert.ToInt32(dr["Value"]);
                }
                conn.Close();

                return overDraft;
            }
            catch
            {
                conn.Close();
                return -1;
            }
        }
    }
}
