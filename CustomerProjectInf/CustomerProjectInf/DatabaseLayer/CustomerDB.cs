using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

//namespaces
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using CustomerProjectInf.Customers;


namespace CustomerProjectInf.DatabaseLayer
{
    public class CustomerDB : DB
    {
        //Data members
        private static string table1 = "CustomerTable";
        private string sql_SELECT1 = "SELECT * FROM " + table1;

        private Collection<Customer> customers = new Collection<Customer>();


        //Constructors
        public CustomerDB()
            : base()
        {
            ReadDataFromTable(sql_SELECT1, table1);
        }

        public Collection<Customer> AllCustomers
        {
            get
            {
                return customers;
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
                    FillCustomerById(reader, table, customers);       //Fill the collection – 
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

        private void FillCustomerById(SqlDataReader reader, string dataTable,
                                                                     Collection<Customer> Customers)
        {
            Customer customer = new Customer();


            while (reader.Read())                          //While you still have stuff to read
            {

                //Same for EmpID, Name  & Phone, all strings with indices 1, 2, & 3 respectively
                customer.CustomerID = reader.GetString(0).Trim();
                customer.CustomerName = reader.GetString(1).Trim();
                customer.CustomerPhone = reader.GetString(2).Trim();
                customer.CustomerAddress = reader.GetString(3).Trim();
                //call the GetRoleInfo method to obtain role specific data from the database
                //customer.Role = GetRoleInfo(reader, customer);
                Customers.Add(customer);             //add to the collection
            }
        }
        #region Database Operations --- Add, Edit & Delete
        public void DatabaseAdd(Customer customer)
        {
            string strSQL = "";

            //Build SQL string for the command

            strSQL = "INSERT into CustomerTable(CustomerID, CustomerName, CustomerAddress, CustomerTelephone)" +
                        "VALUES ('" + GetValueString(customer) + ")";

            //Create & execute the insert command 
            UpdateDataSource(new SqlCommand(strSQL, cnMain));
        }


        public void DatabaseEdit(Customer tempCus)
        {
            string sqlString = "";
            
            //Build SQL string for the Update command

            sqlString = "Update Customr Set Name = '" + tempCus.CustomerName.Trim() + "'," +
                              "Phone = '" + tempCus.CustomerPhone.Trim() + "'," +
                              "Address =" + tempCus.CustomerAddress.Trim() + " " +
                              "WHERE (ID = '" + tempCus.CustomerID.Trim() + "')";

            //Create & execute the update command 
            UpdateDataSource(new SqlCommand(sqlString, cnMain));
        }


        private string GetValueString(Customer TempCus)
        {
            string aStr;

            aStr = TempCus.CustomerID + "' , '" + TempCus.CustomerName + "' ,'" +
                   TempCus.CustomerAddress + "' ,'"  + TempCus.CustomerPhone;

            return aStr;
        }

        #endregion
    }
}


