using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class WithDrawLimitDTO
    {
        private string wDID;
        private decimal value;

        public WithDrawLimitDTO()
        {

        }

        public WithDrawLimitDTO(string wDID, decimal value)
        {
            this.wDID = wDID;
            this.value = value;
        }

        public string WDID { get => wDID; set => wDID = value; }
        public decimal Value { get => value; set => this.value = value; }
    }
}
