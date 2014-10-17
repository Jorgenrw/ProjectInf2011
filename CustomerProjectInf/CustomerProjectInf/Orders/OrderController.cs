using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerProjectInf.DatabaseLayer;

namespace CustomerProjectInf.Orders
{
    public class OrderController
    {
        
        private  OrderDB orderDB;
        private Collection<Order> Orders;

         public OrderController()
        {
            orderDB = new OrderDB();
            Orders = orderDB.AllOrders;
        }
        public Collection<Order> AllOrders
        {
            get
            {
                return Orders;
            }
        }
        public void ADD(Order order)
        {
            //Write code to add employee. Remember to use the DatabaseADD method from the EmployeeDB class
            orderDB.DatabaseAdd(order);
            //Also add the employee to the employees collection?
            
            Orders.Add(order);
        }
        public Order FindByID(string idValue)
        {
            int position = 0;
            bool found = (idValue == Orders[position].OrderID);
            while (!found && position < Orders.Count)
            {
                found = (idValue == Orders[position].OrderID);
                if (!found)
                {
                    position += 1;
                }
            }
            if (found)
            {
                return Orders[position];
            }
            else
            {
                return null;
            }
        }
    }
}



