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
        public DbSet<Transaction> Db_transaction { get; set; }  
        public DbSet<Database_bikes> Db_bikes { get; set; }
        public DbSet<Bike> Db_bike { get; set; }
        public DbSet<KidsBike> Db_kbike { get; set; }
        public DbSet<Database_clients> Db_clients { get; set; }
        public DbSet<Company> Db_company { get; set; }  
        public DbSet<Private_person> Db_private_person { get; set; }


    }
}
