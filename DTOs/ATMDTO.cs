using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ATMDTO
    {
        private string aTMID;
        private string branch;
        private string address;

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

        public string Branch
        {
            get
            {
                return branch;
            }

            set
            {
                branch = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public ATMDTO()
        {

        }

        public ATMDTO(string atmID, string branch, string address)
        {
            this.ATMID = atmID;
            this.Branch = branch;
            this.Address = address;
        }
    }
}
