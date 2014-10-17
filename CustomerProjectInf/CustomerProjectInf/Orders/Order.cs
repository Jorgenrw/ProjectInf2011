using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProjectInf.Orders
{
    public class Order
    {
        #region Properties
        string productid;
        string employeeid;
        string customerid;
        string orderid;
        double unitprice;
        int quantity;
        DateTime? orderdate;
        DateTime? requireddate;
        DateTime? shippeddate;
        DateTime? lastupdate;
        #endregion


        public string ProductID
        {
            get
            {
                return productid;
            }
            set
            {
                productid = value;
            }
        }

        public string EmployeeID
        {
            get
            {
                return employeeid;
            }
            set
            {
                employeeid = value;
            }
        }

        public string CustomerID
        {
            get
            {
                return customerid;
            }
            set
            {
                customerid = value;
            }
        }

        public string OrderID
        {
            get
            {
                return orderid;
            }
            set
            {
                orderid = value;
            }
        }

        public double UnitPrice
        {
            get
            {
                return unitprice;
            }
            set
            {
                unitprice = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }

        public DateTime? OrderDate
        {
            get
            {
                return orderdate;
            }
            set
            {
                orderdate = value;
            }
        }

        public DateTime? RequiredDate
        {
            get
            {
                return requireddate;
            }
            set
            {
                requireddate = value;
            }
        }

        public DateTime? ShippedDate
        {
            get
            {
                return shippeddate;
            }
            set
            {
                shippeddate = value;
            }
        }

        public DateTime? LastUpdate
        {
            get
            {
                return lastupdate;
            }
            set
            {
                lastupdate = value;
            }
        }
    }
}
