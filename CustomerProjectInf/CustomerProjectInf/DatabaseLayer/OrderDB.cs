using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

//namespaces
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using CustomerProjectInf.Orders;


namespace CustomerProjectInf.DatabaseLayer
{
    public class OrderDB : DB
    {
        //Data members
        private static string table1 = "OrderTable";
        private string sql_SELECT1 = "SELECT * FROM " + table1;

        private Collection<Order> orders = new Collection<Order>();


        //Constructors
        public OrderDB()
            : base()
        {
            ReadDataFromTable(sql_SELECT1, table1);
        }

        public Collection<Order> AllOrders
        {
            get
            {
                return orders;
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
                    FillOrderById(reader, table, orders);       //Fill the collection – 
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

        private void FillOrderById(SqlDataReader reader, string dataTable,
                                                                     Collection<Order> Orders)
        {
            Order order = new Order();


            while (reader.Read())                          //While you still have stuff to read
            {
                order.OrderID = reader.GetString(0).Trim();
                order.CustomerID = reader.GetString(1).Trim();
                order.EmployeeID = reader.GetString(2).Trim();
                order.ProductID = reader.GetString(3).Trim();
                order.UnitPrice = reader.GetDouble(4);
                order.Quantity = reader.GetInt32(5);
                order.OrderDate = reader.GetDateTime(6);
                order.RequiredDate = reader.GetDateTime(7);
                order.ShippedDate = reader.GetDateTime(8);
                order.LastUpdate = reader.GetDateTime(9);

                Orders.Add(order);             //add to the collection
            }
        }
        #region Database Operations --- Add, Edit & Delete
        public void DatabaseAdd(Order order)
        {
            string strSQL = "";

            //Build SQL string for the command

            strSQL =
            "INSERT into ProductTable(ProductID, ProductDescription, SupplierID, CategoryID, QuantityPerUnit, UnitsInStock, UnitPrice, ExpiryDate, LastUpdate, EmployeeID, ShelfNumber)" +
                        "VALUES ('" + GetValueString(order) + ")";

            //Create & execute the insert command 
            UpdateDataSource(new SqlCommand(strSQL, cnMain));
        }


        public void DatabaseEdit(Order tempOrder)
        {
            string sqlString = "";

            //Build SQL string for the Update command

            sqlString =
            "Update ProductTable Set CustomerID = '" + tempOrder.CustomerID.Trim() + "'," +
                                    "EmployeeID = '" + tempOrder.EmployeeID.Trim() + "'," +
                                    "ProductID = '" + tempOrder.ProductID.ToString() + "'," +
                                    "UnitPrice = '" + tempOrder.UnitPrice.ToString() + "'," +
                                    "Quantity = '" + tempOrder.Quantity.ToString() + "'," +
                                    "OrderDate = '" + tempOrder.OrderDate.ToString() + "'," +
                                    "RequiredDate = '" + tempOrder.RequiredDate.ToString() + "'," +
                                    "ShippedDate = '" + tempOrder.ShippedDate.ToString() + "'," +
                                    "LastUpdate = '" + tempOrder.LastUpdate.ToString() + "'," +
                                    " " +
                              "WHERE (OrderID = '" + tempOrder.OrderID.Trim() + "')";

            //Create & execute the update command 
            UpdateDataSource(new SqlCommand(sqlString, cnMain));
        }


        private string GetValueString(Order TempOrder)
        {
            string aStr;

            aStr = TempOrder.OrderID + "' , '" +
                   TempOrder.CustomerID + "' ," + "'" +
                   TempOrder.EmployeeID + "' ," + " '" +
                   TempOrder.ProductID + "' ," + " '" +
                   TempOrder.UnitPrice + "' ," + " '" +
                   TempOrder.Quantity + "' ," + " '" +
                   TempOrder.OrderDate + "' ," + " '" +
                   TempOrder.RequiredDate + "' ," + " '" +
                   TempOrder.ShippedDate + "' ," + " '" +
                   TempOrder.LastUpdate;

            return aStr;
        }

        #endregion
    }
}
