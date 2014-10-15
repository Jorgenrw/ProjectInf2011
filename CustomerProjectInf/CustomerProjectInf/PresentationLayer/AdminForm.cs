using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//import customer class
namespace CustomerProjectInf
{
    public partial class AdminForm : Form
    {
        //Drawing properties for the drawing of the tabs.
        private RectangleF tabStringAdmin;
        private RectangleF tabStringCC;
        private RectangleF tabStringVC;
        private RectangleF tabStringEC;
        private RectangleF tabStringCO;
        private RectangleF tabStringVCO;
        private RectangleF tabStringI;

        private Customer customer;
        private string curUsername = string.Empty;
        //private ArrayList Customer = new ArrayList();
        private Timer timerLabel;
        //public adminForm(string username)
        public AdminForm()
        {
            InitializeComponent();
            //this.curUsername = username;
            adminFormActivatedLabel.Text = curUsername;
            //changeTextForm();
            tabStringAdmin = (RectangleF)adminPageTabControl.GetTabRect(0);
            tabStringCC = (RectangleF)adminPageTabControl.GetTabRect(1);
            tabStringVC = (RectangleF)adminPageTabControl.GetTabRect(2);
            tabStringEC = (RectangleF)adminPageTabControl.GetTabRect(3);
            tabStringCO = (RectangleF)adminPageTabControl.GetTabRect(4);
            tabStringVCO = (RectangleF)adminPageTabControl.GetTabRect(5);
            tabStringI = (RectangleF)adminPageTabControl.GetTabRect(6);
            adminPageTabControl.SelectedIndexChanged += new EventHandler(adminPageTabControl_SelectedIndexChanged);
            adminPageTabControl.DrawItem += new DrawItemEventHandler(drawStringTab);

           
            //Create customer section ->>

            //<--end

            //View customer section ->>
            searchVCTextbox.KeyPress += new KeyPressEventHandler(searchKeypressedVC);
            
            //<--end
            
            //Edit customer section ->>
            searchECTextbox.KeyPress += new KeyPressEventHandler(searchKeypressedEC);
            //<--end

            //Create Customer order section ->>
            searchCOTextbox.KeyPress += new KeyPressEventHandler(searchKeypressedCO);
            //<--end
        }
        private void drawStringTab(object sender, DrawItemEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = this.Font;
            SolidBrush brushTabText = new SolidBrush(Color.Black);
            
            switch (e.Index)
            {
                case 0:
                    e.Graphics.FillRectangle(new SolidBrush(Color.Silver), e.Bounds);
                    break;
                case 1:
                    e.Graphics.FillRectangle(new SolidBrush(Color.Silver), e.Bounds);
                    break;
                case 2:
                    e.Graphics.FillRectangle(new SolidBrush(Color.Silver), e.Bounds);
                    break;
                case 3:
                    e.Graphics.FillRectangle(new SolidBrush(Color.Silver), e.Bounds);
                    break;
                case 4:
                    e.Graphics.FillRectangle(new SolidBrush(Color.Silver), e.Bounds);
                    break;
                case 5:
                    e.Graphics.FillRectangle(new SolidBrush(Color.Silver), e.Bounds);
                    break;
                case 6:
                    e.Graphics.FillRectangle(new SolidBrush(Color.Silver), e.Bounds);
                    break;
            }
            Rectangle bounds = e.Bounds;
            bounds.Inflate(-15, 0);
            e.Graphics.DrawString(adminPageTabControl.TabPages[e.Index].Text, font, brushTabText, bounds);
            /*if (adminPageTabControl.TabPages[0] == adminPageTab)
            {
                graphics.DrawString(this.adminPageTabControl.TabPages[0].Text, this.Font, new SolidBrush(Color.Black), tabStringAdmin);
            }
            if (adminPageTabControl.TabPages[1] == createCustomerTab)
            {
                graphics.DrawString(this.adminPageTabControl.TabPages[1].Text, this.Font, new SolidBrush(Color.Black), tabStringCC);
            }
            if (adminPageTabControl.TabPages[2] == viewCustomerTab)
            {
                graphics.DrawString(this.adminPageTabControl.TabPages[2].Text, this.Font, new SolidBrush(Color.Black), tabStringVC);
            }
            if (adminPageTabControl.TabPages[3] == editCustomerTab)
            {
                graphics.DrawString(this.adminPageTabControl.TabPages[3].Text, this.Font, new SolidBrush(Color.Black), tabStringEC);
            }
            if (adminPageTabControl.TabPages[4] == createCustomerOrderTab)
            {
                graphics.DrawString(this.adminPageTabControl.TabPages[4].Text, this.Font, new SolidBrush(Color.Black), tabStringCO);
            }
            if (adminPageTabControl.TabPages[5] == viewCustomerOrderTab)
            {
                graphics.DrawString(this.adminPageTabControl.TabPages[5].Text, this.Font, new SolidBrush(Color.Black), tabStringVCO);
            }
            if (adminPageTabControl.TabPages[6] == inventoryTab)
            {
                graphics.DrawString(this.adminPageTabControl.TabPages[6].Text, this.Font, new SolidBrush(Color.Black), tabStringI);
            }*/
        }
        //method for setting the adminpagetab string to give valid output to the clerk what he did
        public void setAdminTabLabelString(string setString)
        {
            adminTabLabel.Text = setString;
            adminTabLabel.Visible = true;
            
            //do an if statement here, start only the timer if something is created, edited etc. Else don't start.
            startTimer(timerLabel);
        }
        //Creating a timer for the adminPageTab string, such as it disapear when it's displayed for 10 seconds
        private void startTimer(Timer timer)
        {
            this.timerLabel = timer;
            //hack for nullreferenceExeption! :)
            if (timer != null)
                throw new InvalidOperationException("Already initialized");
            timer = new Timer();
            timer.Interval = 10000;
            timer.Tick += new EventHandler(timerLabel_Tick);
            timer.Start();
        }
        //Method to stop the timer, such as we can start it for other means.
        private void stopTimer(Timer timer)
        {
            this.timerLabel = timer;
           
            if (timer != null)
            {
                timer.Stop();
            }
            
        }
        //Whenever the timer reach 10 seconds, we stop and remove(such it's not displayed anymore) the string.
        private void timerLabel_Tick(object sender, EventArgs e)
        {
            stopTimer(timerLabel); 
            adminTabLabel.Visible = false;
        }
        

        private void adminPageTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(adminPageTabControl.SelectedIndex == 0)
            {
                AdminForm.ActiveForm.Text = "Admin Page";
            }
            if (adminPageTabControl.SelectedIndex == 1)
            {
                AdminForm.ActiveForm.Text = "Create customer";
            }
            if (adminPageTabControl.SelectedIndex == 2)
            {
                AdminForm.ActiveForm.Text = "View Customer";
            }
            if (adminPageTabControl.SelectedIndex == 3)
            {
                AdminForm.ActiveForm.Text = "Edit Customer";
            }
            if (adminPageTabControl.SelectedIndex == 4)
            {
                AdminForm.ActiveForm.Text = "Create customer order";
                searchCOLabel.Visible = true;
                searchCOTextbox.Visible = true;
                
            }
            if (adminPageTabControl.SelectedIndex == 5)
            {
                AdminForm.ActiveForm.Text = "View customer order";
                //Enable the searchbox, when this tab is selected
                searchVCTextbox.Enabled = true;
            }
            if (adminPageTabControl.SelectedIndex == 6)
            {
                AdminForm.ActiveForm.Text = "Inventory";
            }

        }
        //Customer Create Section ->>
        private void submitCCButton_Click(object sender, EventArgs e)
        {
            //if the entries label are visable, then we can submit the customer to the database.
            if (entriesCorrectCCLabel.Visible.Equals(true))
            {
                //Create customer method with connection to the database
                //add customer with all the text in every textbox to the database.
                setAdminTabLabelString("Customer " + "'customerid' " + "Created");
                
                adminPageTabControl.SelectedTab = adminPageTab;

                idCCTextbox.Clear();
                nameCCTextbox.Clear();
                phoneCCTextbox.Clear();
                adressCCTextbox.Clear();
                entriesCorrectCCLabel.Visible = false;
                idCCTextbox.Enabled = true;
                nameCCTextbox.Enabled = true;
                phoneCCTextbox.Enabled = true;
                adressCCTextbox.Enabled = true;
                cancelCCButton.Text = "Cancel";
                submitCCButton.Text = "Submit";
              
                
            }
            //when push submit, the text from the cancel button thus the functionality changes.
            else
            {
                entriesCorrectCCLabel.Visible = true;
                cancelCCButton.Text = "Edit";
                submitCCButton.Text = "Confirm";
                idCCTextbox.Enabled = false;
                nameCCTextbox.Enabled = false;
                phoneCCTextbox.Enabled = false;
                adressCCTextbox.Enabled = false;
            }
          

        }

        private void cancelCCButton_Click(object sender, EventArgs e)
        {
            //If the buttons text changes the buttons functionality changes as well.
            if (cancelCCButton.Text.Equals("Edit"))
            {
                entriesCorrectCCLabel.Visible = false;

                idCCTextbox.Enabled = true;
                nameCCTextbox.Enabled = true;
                phoneCCTextbox.Enabled = true;
                adressCCTextbox.Enabled = true;

                idCCTextbox.Focus();

                cancelCCButton.Text = "Cancel";
            }
            else 
            {
                adminPageTabControl.SelectedTab = adminPageTab;
                setAdminTabLabelString("You have not created a Customer");
            }
            if (submitCCButton.Text.Equals("Confirm"))
            {
                submitCCButton.Text = "Submit";
                //SyntaxCheck.CheckPath(); sadsa
            }
        }
        //<<- End customer create section

        //Start View customer section ->>
        private void searchKeypressedVC(object sender, KeyPressEventArgs key)
        {
            if (key.KeyChar == (char)13)
            {
                //enable searchlistbox whenever enter is pressed
                searchVCListbox.Visible = true;
            }
        }
        private void searchVCListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get customer from database if("customer.selected"){blablabla}
              idShowVCLabel.Text = customer.customerId;
              nameShowVCLabel.Text = customer.customerName;
              phoneShowVCLabel.Text = customer.customerPhone.ToString();
              adressShowVCLabel.Text = customer.customerAdress;
              blacklistShowVCLabel.Text = customer.customerBlacklister.ToString();
              //disable the searchtextbox after customer clicked
              searchVCListbox.Enabled = false;
              
        }
        private void okVCButton_Click(object sender, EventArgs e)
        {
            adminPageTabControl.SelectedTab = adminPageTab;
            setAdminTabLabelString("You have just viewed a customer");
        }
        //<<- end View customer section
        
        //Edit customer section ->>
        private void searchKeypressedEC(object sender, KeyPressEventArgs key)
        {
            if (key.KeyChar == (char)13)
            {
                //MessageBox.Show("Enter pressed!");
                searchECListbox.Visible = true;
            }
        }
        private void submitECButton_Click(object sender, EventArgs e)
        {
            if (entriesCorrectECLabel.Visible.Equals(true))
            {
                //Navigate you to adminpagetab with relevent output to whatever you did
                setAdminTabLabelString("Customer " + "'customerid' " + "Edited");
                adminPageTabControl.SelectedTab = adminPageTab;
                //Resetting Tab to default whenever you leave this.tab
                idECTextbox.Clear();
                nameECTextbox.Clear();
                phoneECTextbox.Clear();
                adressECTextbox.Clear();

                searchPCOLabel.Visible = false;
                searchPCOTextbox.Visible = false;
                searchPCOListbox.Visible = false;
                entriesCorrectECLabel.Visible = false;

                cancelECButton.Text = "Cancel";
                submitECButton.Text = "Submit edits";
            }
            else
            {
                entriesCorrectECLabel.Visible = true;
                cancelECButton.Text = "Edit";
                submitECButton.Text = "Confirm";
                searchECTextbox.Enabled = false;
                idECTextbox.Enabled = false;
                nameECTextbox.Enabled = false;
                phoneECTextbox.Enabled = false;
                adressECTextbox.Enabled = false;
            }
        }

        private void cancelECButton_Click(object sender, EventArgs e)
        {
            if (cancelECButton.Text.Equals("Edit"))
            {
                entriesCorrectECLabel.Visible = false;

                //searchECTextbox.Enabled = true;
                idECTextbox.Enabled = true;
                nameECTextbox.Enabled = true;
                phoneECTextbox.Enabled = true;
                adressECTextbox.Enabled = true;

                idECTextbox.Focus();

                cancelECButton.Text = "Cancel";
            }
            else
            {
                //Navigate you to adminpagetab with relevent output to whatever you did
                adminPageTabControl.SelectedTab = adminPageTab;
                setAdminTabLabelString("You have not Edited a Customer");
            }
            if (submitECButton.Text.Equals("Confirm"))
            {
                submitECButton.Text = "Submit edits";
                //SyntaxCheck.CheckPath(); sadsa
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if this customer is selected bla bla bla
            idECTextbox.Text = customer.customerId;
            nameECTextbox.Text = customer.customerName;
            phoneECTextbox.Text = customer.customerPhone.ToString();
            adressECTextbox.Text = customer.customerAdress;
            /*in the time given @ this project, we disable this to make the functionality easy.
            *but if it was a real project other functionality would be added, ask for explanation.
            */
            searchECTextbox.Enabled = false; 
        }
        //<--end Edit customer section

        //Create customer order section ->>

        //<--end Create customer order section
        //Select customer in listbox
        private void customerCOListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //whenever customer is selected we display the datagrid where we can add different products to.
            //Display customer and invoice number.
            customerCOLabel.Visible = true;
            invoiceCOLabel.Visible = true;

            //display and hide for the next section for searching products
            searchCOLabel.Visible = false;
            searchCOTextbox.Visible = false;
            searchCOListbox.Visible = false;

            searchPCOLabel.Visible = true;
            searchPCOTextbox.Visible = true;
            searchPCOListbox.Visible = true;
              
        }
        //Select products in Listbox
        private void searchPCOListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            productCODataGridView.Visible = true;
        }
        private void searchKeypressedCO(object sender, KeyPressEventArgs key)
        {
            if (key.KeyChar == (char)13)
            {
                //MessageBox.Show("Enter pressed!");
                searchCOListbox.Visible = true;
            }
        }
        private void submitCOButton_Click(object sender, EventArgs e)
        {
            if (entriesCorrectCOLabel.Visible.Equals(true))
            {
                //Navigate you to adminpagetab with relevent output to whatever you did
                setAdminTabLabelString("You have just created an order");
                adminPageTabControl.SelectedTab = adminPageTab;
                
                //Resetting Tab to default whenever you leave this.tab
                entriesCorrectCOLabel.Visible = false;
                customerCOLabel.Visible = false;
                invoiceCOLabel.Visible = false;
                submitCOButton.Text = "Submit order";
                cancelCOButton.Text = "Cancel";
            }
            else
            {
                entriesCorrectCOLabel.Visible = true;
                productCODataGridView.Enabled = false;
                cancelCOButton.Text = "Edit";
                submitCOButton.Text = "Confirm";
            }
            
        }

        private void cancelCOButton_Click(object sender, EventArgs e)
        {
            if (submitCOButton.Text == "Confirm")
            {
                //Go back to editing the order
                cancelCOButton.Text = "Cancel";
                submitCOButton.Text = "Submit order";
                entriesCorrectCOLabel.Visible = false;
                productCODataGridView.Enabled = true; 
            }
            //check if customer is selected, pupup message are you sure to cancel.
            //adminPageTabControl.SelectedTab = adminPageTab;
            //setAdminTabLabelString("You have not created an order");
        }
        //View customer order section ->>
        private void okVCOButton_Click(object sender, EventArgs e)
        {
            //Navigate you to adminpagetab with relevent output to whatever you did
            adminPageTabControl.SelectedTab = adminPageTab;
            setAdminTabLabelString("You have just viewed a customer order");
        }
        private void searchCusInvVCOListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            customerVCOStaticLabel.Visible = true;
            //get ID
            phoneVCOStaticLabel.Visible = true;
            //get phone
            adressVCOStaticLabel.Visible = true;
            //get adress
            invoiceVCOStaticLabel.Visible = true;
            //get invoice number

            //disable listbox after selected customer
            searchVCListbox.Visible = false;
            //for an easy implementation you need to view that and only that customer
            searchVCTextbox.Enabled = false;

        }
        private void generatePickingListVCOButton_Click(object sender, EventArgs e)
        {

        }
        //<--end View customer order section

        //Inventory section ->>
        private void okInventoryButton_Click(object sender, EventArgs e)
        {
            adminPageTabControl.SelectedTab = adminPageTab;
            setAdminTabLabelString("You have just viewed the inventory");
        }

        private void generateExpiredListIventoryButton_Click(object sender, EventArgs e)
        {
            //make the list enable = false;
        }
        //<--end Inventory section
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void adminForm_Load(object sender, EventArgs e)
        {

        }
    }
}
