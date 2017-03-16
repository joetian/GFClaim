using OnlineShoppingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Domain.Concrete
{
    public class EFDbContext : DbContext   // exactly same as web.config.connectionString
    {
        public DbSet<Product> Products { get; set; }     // map to all tables in DB

    }
}
