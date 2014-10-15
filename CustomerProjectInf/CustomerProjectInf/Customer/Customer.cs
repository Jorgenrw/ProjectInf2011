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
                Id = value;
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
                name = value;
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
                phone = value;
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
                Adress = value;
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
                blacklisted = value;
            }
        }
        
    }
}
