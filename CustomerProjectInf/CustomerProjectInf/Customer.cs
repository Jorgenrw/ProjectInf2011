using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProjectInf
{
    public class Customer
    {
        private string Id;
        private string name;
        private int phone;
        private string Adress;
        private bool blacklisted;

        public Customer(string id, string name, int phone, string adress, bool blacklisted)
        {
            this.Id = id;
            this.name = name;
            this.phone = phone;
            this.Adress = adress;
            blacklisted = false;
        }
        public string customerId
        {
            get
            {
                return Id;
            }
            set
            {
                //set customer Id here
            }
        }
        public string customerName
        {
            get
            {
                return name;
            }
            set
            {
                //set customer name here
            }
        }
        public int customerPhone
        {
            get
            {
                return phone;
            }
            set
            {
                // set customer phone here
            }
        }
        public string customerAdress
        {
            get
            {
                return Adress;
            }
            set
            {
                // set customer address here
            }
        }
        public bool customerBlacklister
        {
            get
            {
                return blacklisted;
            }
            set
            {
                //set blacklist customer
            }
        }
        
    }
}
