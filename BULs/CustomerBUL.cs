using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALs;
namespace BULs
{
    public class CustomerBUL
    {
        CustomerDAL customerDAL = new CustomerDAL();

        public string getNameCustomer(string cardNo)
        {
            return customerDAL.getNameCustomer(cardNo);
        }
    }
}
