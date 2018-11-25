using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALs;
using DTO;


namespace BULs
{
    public class AccountBUL
    {
        private AccountDAL accountDAL = new AccountDAL();
        public string getBalance(string cardNo)
        {
            int balance = accountDAL.getBalance(cardNo);
            string str = balance + "";
            List<char> arrchar = new List<char>();
            char[] arr = str.ToCharArray();
            if(arr.Length <=3)
            {
                return str;
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arrchar.Add(arr[i]);
                }
                int count = 1;
                for (int i = arr.Length-1; i>=0; i--)
                {
                    if (count < 3)
                        count++;
                    else if (count == 3)
                    {
                        if (i != 0)
                        {
                            arrchar.Insert(arrchar.Count - (arrchar.Count - i), ',');
                            count = 1;
                        }
                    }
                }
                return String.Join("", arrchar);
            }
        }
        public int getBalanceInt(string cardNo)
        {
            return accountDAL.getBalance(cardNo);
        }
    }
}
