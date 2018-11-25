using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALs;

namespace BULs
{
   public class LogBUL
    {
        LogDAL logDAL = new LogDAL();
        public bool createLog(string logType, string atmID, string cardNo, string logDate, decimal amount, string details, string cardNoTo)
        {
            return logDAL.createLog(logType, atmID, cardNo, logDate, amount, details, cardNoTo);
        }
    }
}
