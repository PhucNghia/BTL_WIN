using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AccountDTO
    {
        private string accountID;
        private string custID;
        private string accountNo;
        private string oDID;
        private string wDID;
        private decimal balance;

        public AccountDTO(string accountID, string custID, string accountNo, string oDID, string wDID, int balance)
        {
            this.AccountID = accountID;
            this.CustID = custID;
            this.AccountNo = accountNo;
            this.ODID = oDID;
            this.WDID = wDID;
            this.Balance = balance;
        }

        public string CustID
        {
            get
            {
                return custID;
            }

            set
            {
                custID = value;
            }
        }

        public string AccountNo
        {
            get
            {
                return accountNo;
            }

            set
            {
                accountNo = value;
            }
        }

        public string ODID
        {
            get
            {
                return oDID;
            }

            set
            {
                oDID = value;
            }
        }

        public string WDID
        {
            get
            {
                return wDID;
            }

            set
            {
                wDID = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return balance;
            }

            set
            {
                balance = value;
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

        public AccountDTO()
        {

        }
    }
}
