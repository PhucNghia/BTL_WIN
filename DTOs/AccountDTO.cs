using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class AccountDTO
    {
        private string accountID;
        private string custID;
        private string accountNo;
        private string oDID;
        private string wDID;
        private decimal balance;

        public AccountDTO()
        {

        }

        public AccountDTO(string accountID, string custID, string accountNo, string oDID, string wDID, int balance)
        {
            this.AccountID = accountID;
            this.CustID = custID;
            this.AccountNo = accountNo;
            this.ODID = oDID;
            this.WDID = wDID;
            this.Balance = balance;
        }

        public string AccountID { get => accountID; set => accountID = value; }
        public string CustID { get => custID; set => custID = value; }
        public string AccountNo { get => accountNo; set => accountNo = value; }
        public string ODID { get => oDID; set => oDID = value; }
        public string WDID { get => wDID; set => wDID = value; }
        public decimal Balance { get => balance; set => balance = value; }
    }
}
