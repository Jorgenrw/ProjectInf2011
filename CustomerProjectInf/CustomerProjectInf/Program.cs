using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomerProjectInf.CustomerNameSpace;
namespace CustomerProjectInf
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
      
        [STAThread]
        static void Main()
        {
            CustomerController customerController = new CustomerController();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginScreenForm());
        }
    }
}
