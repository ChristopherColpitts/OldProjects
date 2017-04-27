using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace BudgetItems
{
    [Table]
    public class Items
    {
        public Items() { }

        public Items(string item)
        {
            Item = item;
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id;

        [Column]
        public string Item;

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
