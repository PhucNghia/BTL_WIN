using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class Money
    {
        private string moneyID;
        private decimal moneyValue;

        public Money()
        {

        }

        public Money(string moneyID, decimal moneyValue)
        {
            this.MoneyID = moneyID;
            this.MoneyValue = moneyValue;
        }

        public string MoneyID { get => moneyID; set => moneyID = value; }
        public decimal MoneyValue { get => moneyValue; set => moneyValue = value; }
    }
}
