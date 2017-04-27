using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace BudgetItems
{
    [Table]
    public class Budget
    {
        public Budget() { }

        public Budget(int total, int rent, int bills, int food, int saving, int miscellaneous)
        {
            Total = total;
            Rent = rent;
            Bills = bills;
            Food = food;
            Saving = saving;
            Miscellaneous = miscellaneous;
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id;

        [Column]
        public int Total;

        [Column]
        public int Rent;

        [Column]
        public int Bills;

        [Column]
        public int Food;

        [Column]
        public int Saving;

        [Column]
        public int Miscellaneous;

        private EntityRef<User> _user = new EntityRef<User>();
        [Column]
        private int UserId;
        [Association(IsForeignKey = true, Storage = "_user", ThisKey = "UserId")]
        public User user
        {
            get { return _user.Entity; }
            set { _user.Entity = value; }
        }

    }
}
