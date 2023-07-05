using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Entities;
using DAL.Infrastructure.DI.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DAL.Infrastructure.DI.Implementation
{
    public class OrderRepository: RepositoryBase<Order, int>, IOrderRepository
    {
        public OrderRepository(NorthwindContext context) : base(context)
        {
           
        }
        public override async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await Table
                .AsNoTracking()
                .Include(order => order.Employee)
                .Include(order => order.Customer)
                .Include(order => order.OrderDetails)
                .ToListAsync();
            
        }

        public override async Task<Order> FindAsync(int id)
        {
            return await Table
                .Where(order => order.Id == id)
                .Include(order => order.Employee)
                .Include(order => order.Customer)
                .Include(order => order.OrderDetails)
                .FirstOrDefaultAsync();

        }
    }
}
