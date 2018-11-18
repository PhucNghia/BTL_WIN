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

        public decimal Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        public WithDrawLimitDTO()
        {

        }

        public WithDrawLimitDTO(string wDID, decimal value)
        {
            this.WDID = wDID;
            this.Value = value;
        }

      
    }
}
