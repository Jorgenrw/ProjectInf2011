using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

//namespaces
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using CustomerProjectInf.Products;


namespace CustomerProjectInf.DatabaseLayer
{
    public class ProductDB : DB
    {
        //Data members
        private static string table1 = "ProductTable";
        private string sql_SELECT1 = "SELECT * FROM " + table1;

        private Collection<Product> products = new Collection<Product>();


        //Constructors
        public ProductDB()
            : base()
        {
            ReadDataFromTable(sql_SELECT1, table1);
        }

        public Collection<Product> AllProducts
        {
            get
            {
                return products;
            }
        }



        private string ReadDataFromTable(string selectString, string table)
        {
            SqlDataReader reader;
            SqlCommand command;
            try
            {
                command = new SqlCommand(selectString, cnMain);
                cnMain.Open();             //open the connection
                command.CommandType = CommandType.Text;
                reader = command.ExecuteReader();                        //Read from table
                if (reader.HasRows)
                {
                    // Call the FillEmployeeByRole method see step 2.4
                    FillProductById(reader, table, products);       //Fill the collection – 
                }
                reader.Close();   //close the reader 
                cnMain.Close();  //close the connection
                return "success";
            }
            catch (Exception ex)
            {
                cnMain.Close();
                return (ex.ToString());

            }
        }

        private void FillProductById(SqlDataReader reader, string dataTable,
                                                                     Collection<Product> Products)
        {
            Product product = new Product();


            while (reader.Read())                          //While you still have stuff to read
            {
                product.ProductID = reader.GetString(0).Trim();
                product.ProductDescription = reader.GetString(1).Trim();
                product.SupplierID = reader.GetString(2).Trim();
                product.CategoryID = reader.GetString(3).Trim();
                product.QuantityPerUnit = reader.GetInt32(4);
                product.UnitsInStock = reader.GetInt32(5);
                product.UnitPrice = reader.GetDouble(6);
                product.ExpiryDate = reader.GetDateTime(7);
                product.LastUpdate = reader.GetDateTime(8);
                product.EmployeeID = reader.GetString(9);
                product.ShelfNumber = reader.GetString(10);

                Products.Add(product);             //add to the collection
            }
        }
        #region Database Operations --- Add, Edit & Delete
        public void DatabaseAdd(Product product)
        {
            string strSQL = "";

            //Build SQL string for the command

            strSQL =
            "INSERT into ProductTable(ProductID, ProductDescription, SupplierID, CategoryID, QuantityPerUnit, UnitsInStock, UnitPrice, ExpiryDate, LastUpdate, EmployeeID, ShelfNumber)" +
                        "VALUES (" + GetValueString(product) + ")";

            //Create & execute the insert command 
            UpdateDataSource(new SqlCommand(strSQL, cnMain));
        }


        public void DatabaseEdit(Product tempProd)
        {
            string sqlString = "";
            
            //Build SQL string for the Update command

            sqlString = 
            "UPDATE ProductTable"+
            "SET ProductDescription = '" + tempProd.ProductDescription.Trim() + "'," +
                "SupplierID = '" + tempProd.SupplierID.Trim() + "'," +
                "CategoryID = '" + tempProd.CategoryID.Trim() + "'," +
                "QuantityPerUnit = '" + tempProd.QuantityPerUnit.ToString() + "'," +
                "UnitsInStock = '" + tempProd.UnitsInStock.ToString() + "'," +
                "UnitPrice = '" + tempProd.UnitPrice.ToString() + "'," +
                "ExpiryDate = '" + tempProd.ExpiryDate.ToString() + "'," +
                "LastUpdate" + tempProd.LastUpdate.ToString() + "'," +
                "EmployeeID" + tempProd.EmployeeID.Trim() + "'," +
                "ShelfNumber" + tempProd.ShelfNumber.Trim() + "' " +
             "WHERE ProductID = '" + tempProd.ProductID.Trim() + "'";

            //Create & execute the update command 
            UpdateDataSource(new SqlCommand(sqlString, cnMain));
        }


        private string GetValueString(Product TempProd)
        {
            string aStr;

            aStr = TempProd.ProductID + "' , '" + 
                   TempProd.ProductDescription + "' ," +"'" +
                   TempProd.SupplierID + "' ," + " '" +
                   TempProd.CategoryID + "' ," + " '" +
                   TempProd.QuantityPerUnit + "' ," + " '" +
                   TempProd.UnitsInStock + "' ," + " '" +
                   TempProd.UnitPrice + "' ," + " '" +
                   TempProd.ExpiryDate + "' ," + " '" +
                   TempProd.LastUpdate + "' ," + " '" +
                   TempProd.EmployeeID + "' ," + " '" +
                   TempProd.ShelfNumber;

            return aStr;
        }

        #endregion
    }
}


