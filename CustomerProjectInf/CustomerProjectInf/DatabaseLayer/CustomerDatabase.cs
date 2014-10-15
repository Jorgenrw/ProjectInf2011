using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Xml;
using CustomerProjectInf.DatabaseLayer;

namespace CustomerProjectInf.DatabaseLayer
{
    class CustomerDatabase
    {
        private static string table1 = "Customer";
        private string sql_SELECT1 = "SELECT * FROM " + table1;

        private Collection<Customer> customers = new Collection<Customer>();
        private SqlConnection cnMain;//this is so fucking wrong!

        public CustomerDatabase()
            : base()
        {
            ReadDataFromTable(sql_SELECT1, table1);   //Get the data from ALL 3 tables
            //same for other two Tables 
  
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
            Customer customer;
            
            //Role.RoleType employeeRole = Role.RoleType.NoRole;

            switch (dataTable)                                //Determine the role from table name
            {
                case "HeadWaitron":
                    employeeRole = Role.RoleType.HeadWaitron;
                    break;
                //same for other two roles & the default Role
                case "Waitron":
                    employeeRole = Role.RoleType.Waitron;
                    break;
                case "Runner":
                    employeeRole = Role.RoleType.Runner;
                    break;
                default:
                    employeeRole = Role.RoleType.NoRole;
                    break;
            }
            while (reader.Read())                          //While you still have stuff to read
            {
                customer = new Customer((byte)employeeRole);
                //Same for EmpID, Name  & Phone, all strings with indices 1, 2, & 3 respectively
                customer.Id = reader.GetString(0).Trim();
                customer.Name = reader.GetString(1).Trim();
                customer.Phone = reader.GetString(2).Trim();
                customer.Adress = reader.GetString(3).Trim();
                //call the GetRoleInfo method to obtain role specific data from the database
                //customer.Role = GetRoleInfo(reader, customer);
                Customers.Add(customer);             //add to the collection
            }
        }


    }
}
