using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerProjectInf.DatabaseLayer;

namespace CustomerProjectInf.CustomerNameSpace
{
    class CustomerController
    {
        private  CustomerDatabase customerDb;
        private Collection<Customer> Customers;

         public CustomerController()
        {
            customerDb = new CustomerDatabase();
            Customers = customerDb.AllCustomers;
        }
        public Collection<Customer> AllCustomers
        {
            get
            {
                return Customers;
            }
        }
        public void ADD(Customer customer)
        {
            //Write code to add employee. Remember to use the DatabaseADD method from the EmployeeDB class
            customerDb.DatabaseAdd(customer);
            //Also add the employee to the employees collection?
            
            Customers.Add(customer);
        }
        public Customer FindByID(string idValue)
        {
            int position = 0;
            bool found = (idValue == Customers[position].customerId);
            while (!found && position < Customers.Count)
            {
                found = (idValue == Customers[position].customerId);
                if (!found)
                {
                    position += 1;
                }
            }
            if (found)
            {
                return Customers[position];
            }
            else
            {
                return null;
            }
        }
    }
}
