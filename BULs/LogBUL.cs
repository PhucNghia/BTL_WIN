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
        public void createLog(string logType, string atmID, string cardNo, decimal amount, string details, string cardNoTo)
        {
            DateTime date = DateTime.Parse(DateTime.Now.ToString());
            logDAL.createLog(logType, atmID, cardNo, date, amount, details, cardNoTo);
        }

        public int getTotalAmount(string logTypeID, string atmID, string cardNo)
        {
            string startDate, endDate;
            startDate = DateTime.Today.ToString("yyyy-MM-dd") + " 00:00:00";
            endDate = DateTime.Today.ToString("yyyy-MM-dd") + " 23:59:59";
            return logDAL.getTotalAmount(logTypeID, atmID, cardNo, startDate, endDate);
        }
    }
}
