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
        private readonly NorthwindContext _northwindContext;

        public OrderRepository(NorthwindContext context) : base(context)
        {
            _northwindContext = context;
        }
        public override IEnumerable<Order> GetAll()
        {
            var orders = _northwindContext.Orders
                .Include(order => order.Employee)
                .Include(order => order.Customer)
                .Include(order => order.OrderDetails)
                .Include(order => order.ShipViaNavigation);
            return orders;
        }
    }
}
