using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALs;
using DTO;
using System.Data;

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

        public  List<LogDTO> LoadLogList(string cardNo)
        {
            List<LogDTO> logList = logDAL.LoadLogList(cardNo);
            List<LogDTO> loglistnew = new List<LogDTO>();
            
            foreach (LogDTO item in logList)
            {
                LogDTO log = item;
                if (item.LogTypeID == "LT001" || item.LogTypeID == "LT002" || item.LogTypeID == "LT003" || item.LogTypeID == "LT004")
                {
                    log.LogTypeID = "-";
                }
                loglistnew.Add(log);
            }
            return loglistnew;
        }
    }
}
