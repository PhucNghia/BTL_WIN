using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALs;

namespace BULs
{
    public class AccountBUL
    {
        private AccountDAL accountDAL = new AccountDAL();
        private MoneyBUL moneyBUL = new MoneyBUL();

        // widthdraw
        public string getBalance(string cardNo)
        {
            int balance = accountDAL.getBalance(cardNo);
            return moneyBUL.formatMoney(balance);
        }
        
        public bool updateBalance(int money, string cardNo)
        {
            return accountDAL.updateBalance(money, cardNo);
        }

        public bool checkCurrentBalance(string cardNo, int money)
        {
            if (money <= accountDAL.getBalance(cardNo))
                return true;
            else
                return false;
        }
    }
}
