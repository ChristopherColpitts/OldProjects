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
    public partial class Welcome : Form
    {
        public static string str = "HI";   
        private DataManager manager;
        public Welcome()
        {
            InitializeComponent();
            manager = new DataManager();
        }

        /// <summary>
        /// Allow user to create a user account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getStartedBtn_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            if (register.ShowDialog() == DialogResult.OK)
            {

            }
        }

        /// <summary>
        /// if username and password are a match and user has created a budget proceed, else have user create a budget
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxUserName.Text != "" && textBoxPassword.Text != "")
            {
                User user = new User();
                user = manager.LoadUser(textBoxUserName.Text, textBoxPassword.Text);
                if (user.Username != null && user.Password != null)
                {
                    Budget budget = new Budget();
                    budget = manager.LoadBudgetByUserId(user.Id);
                    if (budget.Total == 0)
                    {
                        CreateBudget budgetForm = new CreateBudget(user.Id);
                        if (budgetForm.ShowDialog() == DialogResult.OK)
                        {
                            int Total = Convert.ToInt32(budgetForm.maskedTextBoxTotal.Text);
                            int Rent = Convert.ToInt32(budgetForm.maskedTextBoxRent.Text);
                            int Bills = Convert.ToInt32(budgetForm.maskedTextBoxBills.Text);
                            int Food = Convert.ToInt32(budgetForm.maskedTextBoxFood.Text);
                            int Savings = Convert.ToInt32(budgetForm.maskedTextBoxSavings.Text);
                            int Miscellaneous = Convert.ToInt32(budgetForm.maskedTextBoxMiscellaneous.Text);
                            manager.SaveBudget(Total, Rent, Bills, Food, Savings, Miscellaneous, user.Id);
                            manager.SaveBudgetTrack(0, 0, 0, 0, 0, 0, user.Id);
                            manager.saveToDatabase();
                            
                        }

                    }

                    this.Hide();
                    BudgetTracker form = new BudgetTracker(user.Id);
                    form.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Incorrect username or password, please try again!");
                }
            }
            else
            {
                MessageBox.Show("Please fill all fields correctly");
            }
        }
    }
}
