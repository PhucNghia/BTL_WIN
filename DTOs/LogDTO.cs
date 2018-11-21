using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LogDTO
    {
        private string logID;
        private string logTypeID;
        private string aTMID;
        private string cardNo;
        private string logDate;
        private decimal amount;
        private string details;
        private string cardNoTo;

        public string LogID
        {
            get
            {
                return logID;
            }

            set
            {
                logID = value;
            }
        }

        public string LogTypeID
        {
            get
            {
                return logTypeID;
            }

            set
            {
                logTypeID = value;
            }
        }

        public string ATMID
        {
            get
            {
                return aTMID;
            }

            set
            {
                aTMID = value;
            }
        }

        public string CardNo
        {
            get
            {
                return cardNo;
            }

            set
            {
                cardNo = value;
            }
        }

        public string LogDate
        {
            get
            {
                return logDate;
            }

            set
            {
                logDate = value;
            }
        }

        public decimal Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        public string Details
        {
            get
            {
                return details;
            }

            set
            {
                details = value;
            }
        }

        public string CardNoTo
        {
            get
            {
                return cardNoTo;
            }

            set
            {
                cardNoTo = value;
            }
        }

        public LogDTO()
        {

        }

        public LogDTO(string logID, string logTypeID, string aTMID, string cardNo, string logDate, decimal amount, 
            string details, string cardNoTo)
        {
            this.LogID = logID;
            this.LogTypeID = logTypeID;
            this.ATMID = aTMID;
            this.CardNo = cardNo;
            this.LogDate = logDate;
            this.Amount = amount;
            this.Details = details;
            this.CardNoTo = cardNoTo;
        }

       
    }
}
