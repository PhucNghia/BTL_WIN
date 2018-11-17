using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class LogDTO
    {
        private string logID;
        private string logTypeID;
        private string aTMID;
        private string cardNo;
        private string logDate;
        private decimal amount;
        private string details;
        private string cardNoTo;

        public LogDTO()
        {

        }

        public LogDTO(string logID, string logTypeID, string aTMID, string cardNo, string logDate, decimal amount, 
            string details, string cardNoTo)
        {
            this.logID = logID;
            this.logTypeID = logTypeID;
            this.aTMID = aTMID;
            this.cardNo = cardNo;
            this.logDate = logDate;
            this.amount = amount;
            this.details = details;
            this.cardNoTo = cardNoTo;
        }

        public string LogID { get => logID; set => logID = value; }
        public string LogTypeID { get => logTypeID; set => logTypeID = value; }
        public string ATMID { get => aTMID; set => aTMID = value; }
        public string CardNo { get => cardNo; set => cardNo = value; }
        public string LogDate { get => logDate; set => logDate = value; }
        public decimal Amount { get => amount; set => amount = value; }
        public string Details { get => details; set => details = value; }
        public string CardNoTo { get => cardNoTo; set => cardNoTo = value; }
    }
}
