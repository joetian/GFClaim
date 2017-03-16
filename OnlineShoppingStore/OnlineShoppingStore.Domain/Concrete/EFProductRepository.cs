using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShoppingStore.Domain.Abstract;
using OnlineShoppingStore.Domain.Entities;

namespace OnlineShoppingStore.Domain.Concrete
{
    public class EFProductRepository: IProductRepository
    {
        public readonly EFDbContext context = new EFDbContext();
        public IEnumerable<Product> Products
        {
            get
            {
                { return context.Products; }
            }
        }
    }
}
