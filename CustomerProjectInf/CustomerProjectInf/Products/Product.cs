using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProjectInf
{
    public class Product
    {
        #region Properties
        private string productid;
        private string productdescription;
        private string supplierid;
        private string categoryid;
        private int quantityperunit;
        private int unitsinstock;
        private double unitprice;
        private DateTime? expirydate;
        private DateTime? lastupdate;
        private string employeeid;
        private string shelfnumber;
        #endregion

        #region Constructors
        public Product()
        {
            productid = "";
            productdescription = "";
            supplierid = "";
            categoryid = "";
            quantityperunit = 0;
            unitsinstock = 0;
            unitprice = 0;
            expirydate = null;
            lastupdate = null;
            employeeid = "";
            shelfnumber = "";
        }

        public Product(string productidVal, string productdescriptionVal, string supplieridVal,
        string categoryidVal, int quantityperunitVal, int unitsinstockVal, double unitpriceVal,
        DateTime expirydateVal, DateTime lastupdateVal, string employeeidVal, string shelfnumberVal)
        {
            productid = productidVal;
            productdescription = productdescriptionVal;
            supplierid = supplieridVal;
            categoryid = categoryidVal;
            quantityperunit = quantityperunitVal;
            unitsinstock = unitsinstockVal;
            unitprice = unitpriceVal;
            expirydate = expirydateVal;
            lastupdate = lastupdateVal;
            employeeid = employeeidVal;
            shelfnumber = shelfnumberVal;
        }
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


        public string ProductDescription
        {
            get
            {
                return productdescription;
            }
            set
            {
                productdescription = value;
            }
        }

        public string SupplierID
        {
            get
            {
                return supplierid;
            }
            set
            {
                supplierid = value;
            }
        }

        public string CategoryID
        {
            get
            {
                return categoryid;
            }
            set
            {
                categoryid = value;
            }
        }

        public int QuantityPerUnit
        {
            get
            {
                return quantityperunit;
            }
            set
            {
                quantityperunit = value;
            }
        }

        public int UnitsInStock
        {
            get
            {
                return unitsinstock;
            }
            set
            {
                unitsinstock = value;
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

        public string ShelfNumber
        {
            get
            {
                return shelfnumber;
            }
            set
            {
                shelfnumber = value;
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
        public DateTime? ExpiryDate
        {
            get
            {
                return expirydate;
            }
            set
            {
                expirydate = value;
            }
        }

    }
}
