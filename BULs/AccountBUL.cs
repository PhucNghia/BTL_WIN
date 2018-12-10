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
        private OverDraftDAL overDraftDAL = new OverDraftDAL();

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

        public bool checkBalanceAndOverDraft(string cardNo, int money)
        {
            if (money <= accountDAL.getBalance(cardNo) + overDraftDAL.getOverDraft(cardNo))
                return true;
            else
                return false;
        }

        public string getAccountID(string cardNo)
        {
            return accountDAL.getAccountID(cardNo);
        }

        public int getBalanceInt(string cardNo)
        {
            return accountDAL.getBalance(cardNo);
        }
    }
}
