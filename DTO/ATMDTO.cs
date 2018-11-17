using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class ATMDTO
    {
        private string aTMID;
        private string branch;
        private string address;

        public ATMDTO()
        {

        }

        public ATMDTO(string atmID, string branch, string address)
        {
            this.aTMID = atmID;
            this.branch = branch;
            this.address = address;
        }

        public string AtmID { get => aTMID; set => aTMID = value; }
        public string Branch { get => branch; set => branch = value; }
        public string Address { get => address; set => address = value; }
    }
}
