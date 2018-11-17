using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class StockDTO
    {
        private string stockID;
        private string moneyID;
        private string aTMID;
        private int quantity;

        public StockDTO()
        {

        }

        public StockDTO(string stockID, string moneyID, string aTMID, int quantity)
        {
            this.stockID = stockID;
            this.moneyID = moneyID;
            this.aTMID = aTMID;
            this.quantity = quantity;
        }

        public string StockID { get => stockID; set => stockID = value; }
        public string MoneyID { get => moneyID; set => moneyID = value; }
        public string ATMID { get => aTMID; set => aTMID = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
