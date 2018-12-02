using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALs;
using BULs;

namespace BULs
{
    public class WithdrawLimitBUL
    {
        private WithdrawLimitDAL withdrawLimitDAL = new WithdrawLimitDAL();
        private LogBUL logBUL = new LogBUL();
        public bool checkWithdrawLimit(string logTypeID, string atmID, string cardNo, int money)
        {
            int withdrawLimit = withdrawLimitDAL.getWithdrawLimit(cardNo);
            int totalAmountLogToday = logBUL.getTotalAmount(logTypeID, atmID, cardNo);
            if(money + totalAmountLogToday <= withdrawLimit)
                return true;
            else
                return false;
        }
    }
}
