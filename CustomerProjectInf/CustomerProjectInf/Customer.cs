using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProjectInf
{
    public class Customer
    {
        private int Id;
        private string name;
        private int phone;
        private string Adress;

        public Customer(int id, string name, int phone, string adress)
        {
            this.Id = id;
            this.name = name;
            this.phone = phone;
            this.Adress = adress;
        }
        public int customerId
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
        
    }
}
