using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALs;

namespace BULs
{
    public class WithdrawLimitBUL
    {
        private WithdrawLimitDAL withdrawLimit = new WithdrawLimitDAL();
        public int getWithdrawLimit(string cardNo)
        {
            return withdrawLimit.getWithdrawLimit(cardNo);
        }
    }
}
