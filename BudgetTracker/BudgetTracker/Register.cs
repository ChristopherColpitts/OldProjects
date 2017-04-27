using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BudgetItems;

namespace BudgetTracker
{
    public partial class Register : Form
    {
        private DataManager manager;
        public Register()
        {
            InitializeComponent();
            manager = new DataManager();
        }

        /// <summary>
        /// Register a user and store username and password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerBtn_Click(object sender, EventArgs e)
        {
            if(textBoxUserName.Text != "" && textBoxPassword.Text != "")
            {
                manager.SaveUser(textBoxUserName.Text, textBoxPassword.Text);
                manager.saveToDatabase();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please fill all fields correctly");
            }
            
        }
    }
}
