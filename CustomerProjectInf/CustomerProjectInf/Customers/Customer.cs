using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProjectInf.CustomerNameSpace
{
    public class Customer
    {
        private string id;
        private string name;
        private string phone;
        private string address;
        private bool blacklisted;

        public Customer()
        {
            id = "";
            name = "";
            address = "";
            phone = "";
            blacklisted = false;
        }
        //int phone,, bool blacklisted
        public Customer(string idVal, string nameVal, string addressVal, string phoneVal, bool blacklistedVal)
        {
            id = idVal;
            name = nameVal;
            phone = phoneVal;
            address = addressVal;
            blacklisted = blacklistedVal;
        }

        public string CustomerID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string CustomerName
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
        public string CustomerPhone
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
        public string CustomerAddress
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
        public bool CustomerBlacklisted
        {
            get
            {
                return blacklisted;
            }
            set
            {
                blacklisted = value;
            }
        }

    }
}
