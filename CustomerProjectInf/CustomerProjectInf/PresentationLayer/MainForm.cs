using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomerProjectInf.Customers;

namespace CustomerProjectInf.PresentationLayer
{
    public partial class MainForm : Form
    {

        private AdminForm adminForm;
        private CustomerController customerController;


        public AdminForm currentAdminForm
        {
            get
            { return adminForm; }
            set
            {
                adminForm = value;
            }
        }

     

        public MainForm()
        {
            InitializeComponent();
            adminForm = new AdminForm(customerController);
            customerController = new CustomerController();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
            
        }


        #region Create Child Forms

        private void CreateNewCustForm()
        {
            adminForm = new AdminForm(customerController);
            adminForm.MdiParent = this;        // Setting the MDI Parent
            adminForm.StartPosition = FormStartPosition.CenterParent;
        }

        #endregion


    }
}
