using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CustomerDTO
    {
        private string customerID;
        private string name;
        private string phone;
        private string email;
        private string address;

        public CustomerDTO(string customerID, string name, string phone, string email, string address)
        {
            this.CustomerID = customerID;
            this.Name = name;
            this.Phone = phone;
            this.Email = email;
            this.Address = address;
        }

        public string CustomerID { get => customerID; set => customerID = value; }
        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
    }
}
