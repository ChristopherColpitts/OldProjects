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
    public partial class UpdateBudget : Form
    {
        private DataManager manager;
        private Budget budget;
        private static int Id;
        /// <summary>
        /// Get current budget information and allow user to update the information
        /// </summary>
        /// <param name="id"></param>
        public UpdateBudget(int id)
        {
            InitializeComponent();
            manager = new DataManager();
            Id = id;
            budget = new Budget();
            budget = manager.LoadBudgetByUserId(Id);
            maskedTextBoxTotal.Text = budget.Total.ToString();
            maskedTextBoxRent.Text = budget.Rent.ToString();
            maskedTextBoxBills.Text = budget.Bills.ToString();
            maskedTextBoxFood.Text = budget.Food.ToString();
            maskedTextBoxSavings.Text = budget.Saving.ToString();
            maskedTextBoxMiscellaneous.Text = budget.Miscellaneous.ToString();
        }

        private void UpdateBudget_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// send updated data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBoxTotal.Text != "" && maskedTextBoxRent.Text != "" && maskedTextBoxBills.Text != "" && maskedTextBoxFood.Text != ""
                && maskedTextBoxSavings.Text != "" && maskedTextBoxMiscellaneous.Text != "")
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please fill out all textbox with valid entry");
            }

        }
    }
}
