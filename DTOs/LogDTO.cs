using System;
using System.Collections.Generic;
using System.Data;
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
        private DateTime logDate;
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

        public DateTime LogDate
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

        public LogDTO(string logID, string logTypeID, string aTMID, string cardNo, DateTime logDate, decimal amount, 
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
        public LogDTO(DataRow row)
        {
            this.LogID = row["logID"].ToString();
            this.LogTypeID = row["logTypeID"].ToString();
            this.ATMID = row["aTMID"].ToString();
            this.CardNo = row["cardNo"].ToString();
            this.LogDate = DateTime.Parse(row["logDate"].ToString());
            this.Amount = Decimal.Parse(row["amount"].ToString());
            this.Details = row["details"].ToString();
            this.CardNoTo = row["cardNoTo"].ToString();
        }
       
    }
}
