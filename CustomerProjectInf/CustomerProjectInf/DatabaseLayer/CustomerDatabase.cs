using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Xml;
using CustomerProjectInf.Properties;
using CustomerProjectInf.CustomerNameSpace;

namespace CustomerProjectInf.DatabaseLayer
{
    class CustomerDatabase
    {
        private static string table1 = "CustomerTable";
        private string sql_SELECT1 = "SELECT * FROM " + table1;
        private string strConn = Settings.Default.PoppelDatabaseConnectionString;

        private Collection<CustomerNameSpace.Customer> customers = new Collection<CustomerNameSpace.Customer>();
        private SqlConnection cnMain;//this is so fucking wrong!

        public CustomerDatabase(): base()
        {
            ReadDataFromTable(sql_SELECT1, table1);   //Get the data from ALL 3 tables
            //same for other two Tables 
            
            
            if (cnMain == null)
            {
                Console.Out.Write("Nothing is in hewre"); 
            }
  
        }
        public Collection<CustomerNameSpace.Customer> AllCustomers
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
            cnMain = new SqlConnection(strConn);
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
                                                                      Collection<CustomerNameSpace.Customer> Customers)
        {
            CustomerNameSpace.Customer customer;
            
            //Role.RoleType employeeRole = Role.RoleType.NoRole;

            while (reader.Read())                          //While you still have stuff to read
            {
                customer = new CustomerNameSpace.Customer();
                //Same for EmpID, Name  & Phone, all strings with indices 1, 2, & 3 respectively
                customer.customerId = reader.GetString(0).Trim();
                customer.customerName = reader.GetString(1).Trim();
                //customer.customerPhone = reader.GetString(2).Trim();
                customer.customerAdress = reader.GetString(3).Trim();
                //call the GetRoleInfo method to obtain role specific data from the database
                //customer.Role = GetRoleInfo(reader, customer);
                Customers.Add(customer);             //add to the collection
            }
        }
        public void DatabaseAdd(CustomerNameSpace.Customer TempCus)
        {
            string strSQL = "";

            //Build SQL string for the command

            
           
                
            strSQL = "INSERT into HeadWaitron(customerId, customerName, customerAdress)" +
                         "VALUES ('" + GetValueString(TempCus) + ")";
            
                
            //Create & execute the insert command 
            UpdateDataSource(new SqlCommand(strSQL, cnMain));
        }

        private void UpdateDataSource(SqlCommand sqlCommand)
        {
            throw new NotImplementedException();
        }
        private string GetValueString(CustomerNameSpace.Customer TempCus)
        {
            string aStr;
            //decimal pay = 0;
            string additional ="";

            aStr = TempCus.customerId + "' , '" + TempCus.customerName + "' ," +
                  "'" + "Adress" + "' ," +
                    additional;

            return aStr;
        }





        internal void Add(CustomerNameSpace.Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
