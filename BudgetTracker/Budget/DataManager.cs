using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;

namespace BudgetItems
{
    public class DataManager
    {
        public List<User> users = new List<User>();
        public List<Budget> budgets = new List<Budget>();
        public List<BudgetTrack> budgetTracks = new List<BudgetTrack>();
        public List<Items> items = new List<Items>();

        private class DataHelper : DataContext
        {
            public DataHelper() :
                base("Data Source = (localdb)\\ProjectsV12;Initial Catalog = BudgetTracker; Integrated Security = True"
                + "AttachDbFilename=C:\\Users\\NSCCSTUDENT\\AppData\\Local\\Microsoft\\VisualStudio\\SSDT\\BudgetTracker.mdf ; Initial Catalog = BudgetTracker; Integrated Security = True")
            { }
            

            public Table<User> Users;
            public Table<Budget> Budgets;
            public Table<BudgetTrack> BudgetTracks;
            public Table<Items> Items;
        }

        private DataHelper data;

        public DataManager()
        {
            data = new DataHelper();
        }

        public void saveToDatabase()
        {
            data.Users.InsertAllOnSubmit(users);
            data.SubmitChanges();

            data.Budgets.InsertAllOnSubmit(budgets);
            data.SubmitChanges();

            data.BudgetTracks.InsertAllOnSubmit(budgetTracks);
            data.SubmitChanges();

            data.Items.InsertAllOnSubmit(items);
            data.SubmitChanges();
        }

        

        public void SaveUser(string username, string password)
        {
            User user;

            user = new User(username, password);
            users.Add(user);
        }

        public void SaveBudget(int Total, int Rent, int Bills, int Food, int Saving, int Miscellaneous, int UserId)
        {
            Budget budget;
            User user;

            user = LoadUserById(UserId);
            budget = new Budget(Total, Rent, Bills, Food, Saving, Miscellaneous);
            budget.user = user;
            budgets.Add(budget);
            

        }

        public void SaveItems(string itemItem, int UserId)
        {
            Items item;
            User user;

            user = LoadUserById(UserId);
            item = new Items(itemItem);
            item.user = user;
            items.Add(item);

        }

        public void clearItems()
        {
            items.Clear();
        }

        public void SaveBudgetTrack(int Total, int Rent, int Bills, int Food, int Saving, int Miscellaneous, int UserId)
        {
            BudgetTrack budgetTrack;
            User user;

            user = LoadUserById(UserId);
            budgetTrack = new BudgetTrack(Total, Rent, Bills, Food, Saving, Miscellaneous);
            budgetTrack.user = user;
            budgetTracks.Add(budgetTrack);

        }

        public User LoadUser(string username, string password)
        {

            User user = new User();

            IEnumerable<User> us = from u in data.Users
                                       where u.Username.Equals(username)
                                       && u.Password.Equals(password)
                                       orderby u.Id descending
                                       select u;

            foreach (User u in us)
            {
                user = u;
            }

            return user;
        }

        public List<Items> LoadItems(int id)
        {

            //List<Items> items = new List<Items>();
            this.items = new List<Items>();

            IEnumerable<Items> us = from u in data.Items
                                   where u.user.Id.Equals(id)
                                   orderby u.Id descending
                                   select u;

            foreach (Items u in us)
            {
                this.items.Add(u);
            }

            return this.items;
        }

        public User LoadUserById(int id)
        {

            User user = new User();

            IEnumerable<User> us = from u in data.Users
                                   where u.Id.Equals(id)
                                   orderby u.Id descending
                                   select u;

            foreach (User u in us)
            {
                user = u;
            }

            return user;

        }

        public Budget LoadBudgetByUserId(int id)
        {

            Budget budget = new Budget();

            IEnumerable<Budget> op = from o in data.Budgets
                                     where o.Id.Equals(id)
                                     orderby o.Id descending
                                     select o;

            foreach (Budget bu in op)
            {
                budget = bu;
            }

            return budget;

        }

        public BudgetTrack LoadBudgetTrack(int id)
        {
            BudgetTrack budgetTrack = new BudgetTrack();

            IEnumerable<BudgetTrack> op = from o in data.BudgetTracks
                                     where o.Id.Equals(id)
                                     orderby o.Id descending
                                     select o;

            foreach (BudgetTrack bu in op)
            {
                budgetTrack = bu;
            }

            return budgetTrack;
        }

        public void deleteItems(int id)
        {

            IEnumerable<Items> us = from u in data.Items
                                    where u.user.Id.Equals(id)
                                    orderby u.Id descending
                                    select u;

            data.Items.DeleteAllOnSubmit(us);
            data.SubmitChanges();
        }

    }
}
