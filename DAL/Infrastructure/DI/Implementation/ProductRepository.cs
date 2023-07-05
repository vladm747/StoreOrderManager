using DAL.Context;
using DAL.Entities;
using DAL.Infrastructure.DI.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Infrastructure.DI.Implementation
{
    public class ProductRepository: RepositoryBase<Product, int>, IProductRepository
    {
        public ProductRepository(NorthwindContext context) : base(context) { }

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await Table
                .AsNoTracking()
                .Include(order => order.Category)
                .Include(order => order.Supplier)
                .Include(order => order.OrderDetails)
                .ToListAsync();

        }
        public override async Task<Product> FindAsync(int id)
        {
            return await Table
                .Where(order => order.Id == id)
                .Include(order => order.Category)
                .Include(order => order.Supplier)
                .Include(order => order.OrderDetails)
                .FirstOrDefaultAsync();

        }
    }
    
}
