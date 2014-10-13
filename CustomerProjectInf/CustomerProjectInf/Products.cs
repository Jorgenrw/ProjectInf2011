using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProjectInf
{
    class Products
    {
        private string id;
        private double price;
        private string name;
        private bool expired;
        //private int quantity; hmm, do we need this here?

        public Products(string pId, double pPrice, string pName, bool pExpired)
        {
            this.id = pId;
            this.price = pPrice;
            this.name = pName;
            expired = false;
        }
        public string productId
        {
            get
            {
                return id;
            }
            set
            {
                //set customer Id here
            }
        }
        public string productName
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
        public double productPrice
        {
            get
            {
                return price;
            }
            set
            {
                // set customer phone here
            }
        }
        public bool productExpired
        {
            get
            {
                return expired;
            }
            set
            {
                // set customer address here
            }
        }

    }
}
