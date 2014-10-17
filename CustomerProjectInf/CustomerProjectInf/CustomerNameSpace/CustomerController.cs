using System;
 using System.Collections.Generic;
 using System.Collections.ObjectModel;
 using System.Linq;
 using System.Text;
 using System.Threading.Tasks;
 using CustomerProjectInf.DatabaseLayer;
 
-namespace CustomerProjectInf.CustomerNameSpace
+namespace CustomerProjectInf.Customers
 {
-    class CustomerController
+    public class CustomerController
     {
-        private  CustomerDatabase customerDB;
+        private  CustomerDB customerDB;
         private Collection<Customer> Customers;
 
          public CustomerController()
         {
-            customerDB = new CustomerDatabase();
+            customerDB = new CustomerDB();
             Customers = customerDB.AllCustomers;
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
             customerDB.DatabaseAdd(customer);
             //Also add the employee to the employees collection?
             
             Customers.Add(customer);
         }
         public Customer FindByID(string idValue)
         {
             int position = 0;
             bool found = (idValue == Customers[position].CustomerID);
             while (!found && position < Customers.Count)
             {
                 found = (idValue == Customers[position].CustomerID);
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