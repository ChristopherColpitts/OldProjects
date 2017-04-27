using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace BudgetItems
{
    [Table]
    public class User
    {
        public User() { }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id;

        [Column]
        public string Username;

        [Column]
        public string Password;

        private EntitySet<Budget> _budgets = new EntitySet<Budget>();

        [Association(Storage = "_budgets", OtherKey = "UserId", ThisKey = "Id")]
        public ICollection<Budget> budgets
        {
            get { return _budgets; }
            set { _budgets.Assign(value); }
        }

        private EntitySet<BudgetTrack> _budgetTracks = new EntitySet<BudgetTrack>();

        [Association(Storage = "_budgetTracks", OtherKey = "UserId", ThisKey = "Id")]
        public ICollection<BudgetTrack> budgetTracks
        {
            get { return _budgetTracks; }
            set { _budgetTracks.Assign(value); }
        }

        private EntitySet<Items> _items = new EntitySet<Items>();

        [Association(Storage = "_items", OtherKey = "UserId", ThisKey = "Id")]
        public ICollection<Items> items
        {
            get { return _items; }
            set { _items.Assign(value); }
        }
    }
}
