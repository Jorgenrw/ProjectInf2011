using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerProjectInf.DatabaseLayer;

namespace CustomerProjectInf
{
    public class ProductController
    {
        
        private  ProductDB productDB;
        private Collection<Product> Products;

         public ProductController()
        {
            productDB = new ProductDB();
            Products = productDB.AllProducts;
        }
        public Collection<Product> AllProducts
        {
            get
            {
                return Products;
            }
        }
        public void ADD(Product product)
        {
            //Write code to add employee. Remember to use the DatabaseADD method from the EmployeeDB class
            productDB.DatabaseAdd(product);
            //Also add the employee to the employees collection?
            
            Products.Add(product);
        }
        public Product FindByID(string idValue)
        {
            int position = 0;
            bool found = (idValue == Products[position].ProductID);
            while (!found && position < Products.Count)
            {
                found = (idValue == Products[position].ProductID);
                if (!found)
                {
                    position += 1;
                }
            }
            if (found)
            {
                return Products[position];
            }
            else
            {
                return null;
            }
        }
    }
}

    
