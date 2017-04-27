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
    public partial class CreateBudget : Form
    {
        private DataManager manager;
        private int Id;
        public CreateBudget(int id)
        {
            InitializeComponent();
            manager = new DataManager();
            Id = id;
        }

        /// <summary>
        /// Get data to create a users budget
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
