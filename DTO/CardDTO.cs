using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class CardDTO
    {
        private string cardNo;
        private string status;
        private string accountID;
        private string pIN;
        private string startDate;
        private string expiredDate;
        private int attempt;

        public CardDTO()
        {

        }

        public CardDTO(string cardNo, string status, string accountID, string pIN, string startDate, 
            string expiredDate, int attempt)
        {
            this.cardNo = cardNo;
            this.status = status;
            this.accountID = accountID;
            this.pIN = pIN;
            this.startDate = startDate;
            this.expiredDate = expiredDate;
            this.attempt = attempt;
        }

        public string CardNo { get => cardNo; set => cardNo = value; }
        public string Status { get => status; set => status = value; }
        public string AccountID { get => accountID; set => accountID = value; }
        public string PIN { get => pIN; set => pIN = value; }
        public string StartDate { get => startDate; set => startDate = value; }
        public string ExpiredDate { get => expiredDate; set => expiredDate = value; }
        public int Attempt { get => attempt; set => attempt = value; }
    }
}
