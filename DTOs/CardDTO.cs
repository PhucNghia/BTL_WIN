using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CardDTO
    {
        private string cardNo;
        private string status;
        private string accountID;
        private string pIN;
        private string startDate;
        private string expiredDate;
        private int attempt;

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

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public string AccountID
        {
            get
            {
                return accountID;
            }

            set
            {
                accountID = value;
            }
        }

        public string PIN
        {
            get
            {
                return pIN;
            }

            set
            {
                pIN = value;
            }
        }

        public string StartDate
        {
            get
            {
                return startDate;
            }

            set
            {
                startDate = value;
            }
        }

        public string ExpiredDate
        {
            get
            {
                return expiredDate;
            }

            set
            {
                expiredDate = value;
            }
        }

        public int Attempt
        {
            get
            {
                return attempt;
            }

            set
            {
                attempt = value;
            }
        }

        public CardDTO()
        {

        }

        public CardDTO(string cardNo, string status, string accountID, string pIN, string startDate, 
            string expiredDate, int attempt)
        {
            this.CardNo = cardNo;
            this.Status = status;
            this.AccountID = accountID;
            this.PIN = pIN;
            this.StartDate = startDate;
            this.ExpiredDate = expiredDate;
            this.Attempt = attempt;
        }

        
    }
}
