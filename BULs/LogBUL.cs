using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALs;
using DTO;

namespace BULs
{
    public class LogBUL
    {
        LogDAL logDAL = new LogDAL();
        public List<LogDTO> getAllLog(string cardNo)
        {
            List<LogDTO> arrLog = logDAL.getAllLog(cardNo);
            List<LogDTO> arrLogNew = new List<LogDTO>();

            if (arrLog == null)
                return null;
            for (int i = 0; i < arrLog.Count; i++)
            {
                LogDTO log = arrLog[i];
                if (log.LogTypeID.Equals("logtype01"))
                {
                    log.LogTypeID = "Rút tiền";
                }
                else if (log.LogTypeID.Equals("logtype02"))
                {
                    log.LogTypeID = "Chuyển tiền";
                }
                else if (log.LogTypeID.Equals("logtype03"))
                {
                    log.LogTypeID = "Kiểm tra tài khoản";
                }
                else if (log.LogTypeID.Equals("logtype04"))
                {
                    log.LogTypeID = "Đổi mã PIN";
                }
                arrLogNew.Add(log);
            }

            return arrLogNew;
        }
    }
}
