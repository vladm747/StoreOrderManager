using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Entities;
using DAL.Infrustructure.DI.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DAL.Infrustructure.DI.Implementation
{
    public class OrderRepository: RepositoryBase<Order, int>, IOrderRepository
    {
        public OrderRepository(NorthwindContext context) : base(context) { }
    }
}
