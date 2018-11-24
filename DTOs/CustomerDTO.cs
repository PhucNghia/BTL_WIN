using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CustomerDTO
    {
        private string customerID;
        private string name;
        private string phone;
        private string email;
        private string address;

        public string CustomerID
        {
            get
            {
                return customerID;
            }

            set
            {
                customerID = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
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

        public CustomerDTO(string customerID, string name, string phone, string email, string address)
        {
            this.CustomerID = customerID;
            this.Name = name;
            this.Phone = phone;
            this.Email = email;
            this.Address = address;
        }

        
    }
}
