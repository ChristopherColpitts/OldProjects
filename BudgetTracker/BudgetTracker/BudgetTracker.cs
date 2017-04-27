using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Graph = System.Windows.Forms.DataVisualization.Charting;
using BudgetItems;

namespace BudgetTracker
{
    public partial class BudgetTracker : Form
    {
        private DataManager manager;
        private Budget budget;
        private User user;
        private BudgetTrack budgetTrack;
        private static int Id;

        /// <summary>
        /// Initalize all values for form
        /// </summary>
        /// <param name="id"></param>
        public BudgetTracker(int id)
        {
            InitializeComponent();
            comboBox1.Items.Add("Rent");
            comboBox1.Items.Add("Bills");
            comboBox1.Items.Add("Food");
            comboBox1.Items.Add("Savings");
            comboBox1.Items.Add("Miscellaneous");
            comboBox1.SelectedItem = "Rent";
            manager = new DataManager();
            user = new User();
            budgetTrack = new BudgetTrack();
            Welcome welcome = new Welcome();
            user = manager.LoadUserById(id);
            Id = id;
            budget = new Budget();
            budget = manager.LoadBudgetByUserId(Id);
            budgetTrack = manager.LoadBudgetTrack(Id);
            loadLabels(budget);
            loadTextBoxs(budgetTrack);
            if (budget.Total != 0)
            {
                updateBudgetToolStripMenuItem.Enabled = false;
            }
            List <Items> itemsList = manager.LoadItems(Id);
            int size = itemsList.Count;
            int i = 0;
            while(i < size)
            {
                listBox1.Items.Add(i + ". " + itemsList[i].Item);
                i++;
            }
            nameLabel.Text = user.Username;
            manager.clearItems();

        }

        /// <summary>
        /// Allow user to create a budget if they have not already done so
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateBudgetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateBudget budgetForm = new CreateBudget(Id);
            if (budgetForm.ShowDialog() == DialogResult.OK)
            {
                User user = new User();
                user = manager.LoadUserById(Id);
                int Total = Convert.ToInt32(budgetForm.maskedTextBoxTotal.Text);
                int Rent = Convert.ToInt32(budgetForm.maskedTextBoxRent.Text);
                int Bills = Convert.ToInt32(budgetForm.maskedTextBoxBills.Text);
                int Food = Convert.ToInt32(budgetForm.maskedTextBoxFood.Text);
                int Savings = Convert.ToInt32(budgetForm.maskedTextBoxSavings.Text);
                int Miscellaneous = Convert.ToInt32(budgetForm.maskedTextBoxMiscellaneous.Text);
                labelTotal.Text = Total.ToString();
                labelRent.Text = Rent.ToString();
                labelBills.Text = Bills.ToString();
                labelFood.Text = Food.ToString();
                labelSavings.Text = Savings.ToString();
                LabelMiscellaneous.Text = Miscellaneous.ToString();
                manager.SaveBudget(Total, Rent, Bills, Food, Savings, Miscellaneous, user.Id);
                manager.SaveBudgetTrack(0, 0, 0, 0, 0, 0, user.Id);
                manager.saveToDatabase();
                updateBudgetToolStripMenuItem.Enabled = false;
                updateChart();
            }
        }

        /// <summary>
        /// Load labels for budget information from Budget table
        /// </summary>
        /// <param name="budget"></param>
        public void loadLabels(Budget budget)
        {
            labelTotal.Text = budget.Total.ToString();
            labelRent.Text = budget.Rent.ToString();
            labelBills.Text = budget.Bills.ToString();
            labelFood.Text = budget.Food.ToString();
            labelSavings.Text = budget.Saving.ToString();
            LabelMiscellaneous.Text = budget.Miscellaneous.ToString();
        }

        /// <summary>
        /// load budget tracker labels from the BudgetTracker table
        /// </summary>
        /// <param name="budgetTrack"></param>
        public void loadTextBoxs(BudgetTrack budgetTrack)
        {
            labelTotal1.Text = budgetTrack.Total.ToString();
            labelRent1.Text = budgetTrack.Rent.ToString();
            labelBills1.Text = budgetTrack.Bills.ToString();
            labelFood1.Text = budgetTrack.Food.ToString();
            labelSavings1.Text = budgetTrack.Saving.ToString();
            labelMiscellaneous1.Text = budgetTrack.Miscellaneous.ToString();
        }

        /// <summary>
        /// Set chart to blank and update with current information from the BudgetTrack and Budget Table
        /// </summary>
        void updateChart()
        {

            chart1.Series.Clear();
            chart1.Titles.Clear();
            
            // Data arrays.
            string[] seriesArray = { "Total Allocation", "Total Expenditure", "Rent Allocation", "Rent Expenditure"
            , "Bills Allocation", "Bills Expenditure" , "Food Allocation", "Food Expenditure", "Savings Allocation", "Savings Expenditure"
            , "Miscellaneous Allocation", "Miscellaneous Expenditure"};
            int[] pointsArray = { budget.Total, budgetTrack.Total, budget.Rent, budgetTrack.Rent, budget.Bills, budgetTrack.Bills
            , budget.Food, budgetTrack.Food, budget.Saving, budgetTrack.Saving, budget.Miscellaneous, budgetTrack.Miscellaneous};

            // Set palette.
            this.chart1.Palette = ChartColorPalette.Excel;

            // Set title.
            this.chart1.Titles.Add("Consumption Comparison");

            chart1.ChartAreas[0].AxisX.Maximum = 1.5;
            chart1.ChartAreas[0].AxisX.Minimum = 0.5;
            // Add series.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                // Add series.
                Series series = this.chart1.Series.Add(seriesArray[i]);

                // Add point.
                series.Points.Add(pointsArray[i], i);
            }
        }

        /// <summary>
        /// Update chart on form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BudgetTracker_Load(object sender, EventArgs e)
        {
            updateChart();
        }

        /// <summary>
        /// Allow user to update information on their budget and store information to Budget Table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createBudgetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateBudget updateBudgetForm = new UpdateBudget(Id);
            if (updateBudgetForm.ShowDialog() == DialogResult.OK)
            {
                this.Show();
                budget = new Budget();
                budget = manager.LoadBudgetByUserId(Id);
                budget.Total = Convert.ToInt32(updateBudgetForm.maskedTextBoxTotal.Text);
                budget.Rent = Convert.ToInt32(updateBudgetForm.maskedTextBoxRent.Text);
                budget.Bills = Convert.ToInt32(updateBudgetForm.maskedTextBoxBills.Text);
                budget.Food = Convert.ToInt32(updateBudgetForm.maskedTextBoxFood.Text);
                budget.Saving = Convert.ToInt32(updateBudgetForm.maskedTextBoxSavings.Text);
                budget.Miscellaneous = Convert.ToInt32(updateBudgetForm.maskedTextBoxMiscellaneous.Text);
                manager.saveToDatabase();
                loadLabels(budget);
                updateChart();
            }
        }

        /// <summary>
        /// Allow user to add items to items Table and update the information in the BudgetTrack Table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxItem.Text != "")
            {
                if (comboBox1.SelectedItem.ToString() == "Rent")
                {
                    User user = new User();
                    user = manager.LoadUserById(Id);
                    budgetTrack = new BudgetTrack();
                    budgetTrack = manager.LoadBudgetTrack(Id);
                    budgetTrack.Total = Convert.ToInt32(labelTotal1.Text) + Convert.ToInt32(maskedTextBoxAddItem.Text);
                    budgetTrack.Rent = Convert.ToInt32(labelRent1.Text) + Convert.ToInt32(maskedTextBoxAddItem.Text);
                    budgetTrack.Bills = Convert.ToInt32(labelBills1.Text);
                    budgetTrack.Food = Convert.ToInt32(labelFood1.Text);
                    budgetTrack.Saving = Convert.ToInt32(labelSavings1.Text);
                    budgetTrack.Miscellaneous = Convert.ToInt32(labelMiscellaneous1.Text);
                    manager.saveToDatabase();
                }
                else if (comboBox1.SelectedItem.ToString() == "Bills")
                {
                    User user = new User();
                    user = manager.LoadUserById(Id);
                    budgetTrack = new BudgetTrack();
                    budgetTrack = manager.LoadBudgetTrack(Id);
                    budgetTrack.Total = Convert.ToInt32(labelTotal1.Text) + Convert.ToInt32(maskedTextBoxAddItem.Text);
                    budgetTrack.Rent = Convert.ToInt32(labelRent1.Text);
                    budgetTrack.Bills = Convert.ToInt32(labelBills1.Text) + Convert.ToInt32(maskedTextBoxAddItem.Text);
                    budgetTrack.Food = Convert.ToInt32(labelFood1.Text);
                    budgetTrack.Saving = Convert.ToInt32(labelSavings1.Text);
                    budgetTrack.Miscellaneous = Convert.ToInt32(labelMiscellaneous1.Text);
                    manager.saveToDatabase();
                }
                else if (comboBox1.SelectedItem.ToString() == "Food")
                {
                    User user = new User();
                    user = manager.LoadUserById(Id);
                    budgetTrack = new BudgetTrack();
                    budgetTrack = manager.LoadBudgetTrack(Id);
                    budgetTrack.Total = Convert.ToInt32(labelTotal1.Text) + Convert.ToInt32(maskedTextBoxAddItem.Text);
                    budgetTrack.Rent = Convert.ToInt32(labelRent1.Text);
                    budgetTrack.Bills = Convert.ToInt32(labelBills1.Text);
                    budgetTrack.Food = Convert.ToInt32(labelFood1.Text) + Convert.ToInt32(maskedTextBoxAddItem.Text);
                    budgetTrack.Saving = Convert.ToInt32(labelSavings1.Text);
                    budgetTrack.Miscellaneous = Convert.ToInt32(labelMiscellaneous1.Text);
                    manager.saveToDatabase();
                }
                else if (comboBox1.SelectedItem.ToString() == "Savings")
                {
                    User user = new User();
                    user = manager.LoadUserById(Id);
                    budgetTrack = new BudgetTrack();
                    budgetTrack = manager.LoadBudgetTrack(Id);
                    budgetTrack.Total = Convert.ToInt32(labelTotal1.Text) + Convert.ToInt32(maskedTextBoxAddItem.Text);
                    budgetTrack.Rent = Convert.ToInt32(labelRent1.Text);
                    budgetTrack.Bills = Convert.ToInt32(labelBills1.Text);
                    budgetTrack.Food = Convert.ToInt32(labelFood1.Text);
                    budgetTrack.Saving = Convert.ToInt32(labelSavings1.Text) + Convert.ToInt32(maskedTextBoxAddItem.Text);
                    budgetTrack.Miscellaneous = Convert.ToInt32(labelMiscellaneous1.Text);
                    manager.saveToDatabase();
                }
                else if (comboBox1.SelectedItem.ToString() == "Miscellaneous")
                {
                    User user = new User();
                    user = manager.LoadUserById(Id);
                    budgetTrack = new BudgetTrack();
                    budgetTrack = manager.LoadBudgetTrack(Id);
                    budgetTrack.Total = Convert.ToInt32(labelTotal1.Text) + Convert.ToInt32(maskedTextBoxAddItem.Text);
                    budgetTrack.Rent = Convert.ToInt32(labelRent1.Text);
                    budgetTrack.Bills = Convert.ToInt32(labelBills1.Text);
                    budgetTrack.Food = Convert.ToInt32(labelFood1.Text);
                    budgetTrack.Saving = Convert.ToInt32(labelSavings1.Text);
                    budgetTrack.Miscellaneous = Convert.ToInt32(labelMiscellaneous1.Text) + Convert.ToInt32(maskedTextBoxAddItem.Text);
                    manager.saveToDatabase();
                }

                loadTextBoxs(budgetTrack);
                Items item = new Items();
                manager.SaveItems(textBoxItem.Text, Id);
                manager.saveToDatabase();
            manager.clearItems();

        }
            else
            {
                MessageBox.Show("Please enter name of Item");
            }

    List<Items> itemsList = manager.LoadItems(Id);
            int size = itemsList.Count;
            int i = 0;
            listBox1.Items.Clear();
            while (i < size)
            {
                listBox1.Items.Add(i + ". " + itemsList[i].Item);
                i++;
            }
            manager.clearItems();
            updateChart();

        }

        /// <summary>
        /// Reset BudgetTracking items on the form and reset BudgetTrack Table and update chart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResetExpenditure_Click(object sender, EventArgs e)
        {
            manager.deleteItems(Id);
            budgetTrack.Total = 0;
            budgetTrack.Rent = 0;
            budgetTrack.Bills = 0;
            budgetTrack.Food = 0;
            budgetTrack.Saving = 0;
            budgetTrack.Miscellaneous = 0;
            manager.saveToDatabase();
            manager.clearItems();
            labelTotal1.Text = "0";
            labelRent1.Text = "0";
            labelBills1.Text = "0";
            labelFood1.Text = "0";
            labelSavings1.Text = "0";
            labelMiscellaneous1.Text = "0";
            a: if (listBox1.Items.Count > 0)
            {
                listBox1.Items.RemoveAt(0);
                goto a;
            }
            updateChart();
        }

        /// <summary>
        /// Allow user to switch their profile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome();
            this.Hide();
            welcome.ShowDialog();
        }
    }
}
