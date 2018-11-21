using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OverDraftDTO
    {
        private string oDID;
        private decimal value;

        public OverDraftDTO()
        {

        }

        public OverDraftDTO(string oDID, decimal value)
        {
            this.ODID = oDID;
            this.Value = value;
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
    }
}
