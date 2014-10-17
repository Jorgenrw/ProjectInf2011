using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProjectInf.Customers
{
    public class Customer
    {
        private string Id;
        private string name;
        private string phone;
        private string Adress;
        private bool blacklisted;
        
        public Customer()
        {
            Id = "";
            name = "";
            Adress = "";
            phone = "";
            blacklisted = false;
        }
        //int phone,, bool blacklisted
        public Customer(string idVal, string nameVal, string addressVal, string phoneVal, bool blacklistedVal)
        {
            Id = idVal;
            name = nameVal;
            phone = phoneVal;
            Adress = addressVal;
            blacklisted = blacklistedVal;
        }
        public string CustomerID
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
                 return Adress;
             }
             set
             {
                 Adress = value;
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
