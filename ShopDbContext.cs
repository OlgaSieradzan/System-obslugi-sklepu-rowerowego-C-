using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project 
{
    internal class ShopDbContext : DbContext
    {

        public DbSet<Database_transaction> Db_transactions { get; set; }
        public DbSet<Database_bikes> Db_bikes { get; set; }
        public DbSet<Database_clients> Db_clients { get; set; }


    }
}
