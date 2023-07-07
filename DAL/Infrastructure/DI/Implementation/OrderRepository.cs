using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using DAL.Context;
using DAL.Entities;
using DAL.Infrastructure.DI.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DAL.Infrastructure.DI.Implementation
{
    public class OrderRepository: RepositoryBase<Order, int>, IOrderRepository
    {
        public OrderRepository(NorthwindContext context) : base(context) { }
        internal OrderRepository(DbContextOptions<NorthwindContext> options) : base(options) { }
        public override async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await Table
                .AsNoTracking()
                .Include(order => order.Employee)
                .Include(order => order.Customer)
                .Include(order => order.OrderDetails)
                .ToListAsync();
            
        }
        public async Task<IEnumerable<Order>> GetPageAsync(int countSkip, int pageSize)
        {
            return await Table.OrderBy(order => order.Id).Skip(countSkip)
                .Take(pageSize).ToListAsync();
        }

        public async Task<IEnumerable<Order>> FindByProperty(string searchQuery)
        {
            return await Table
                .Where(order =>
                    order.Id.ToString().Contains(searchQuery) ||
                    order.CustomerId!.Contains(searchQuery) ||
                    order.EmployeeId.ToString()!.Contains(searchQuery) ||
                    order.Freight.ToString()!.Contains(searchQuery) ||
                    order.ShipperId.ToString()!.Contains(searchQuery) ||
                    order.ShipAddress!.Contains(searchQuery) ||
                    order.ShipCity!.Contains(searchQuery) ||
                    order.ShipCountry!.Contains(searchQuery) ||
                    order.ShippedDate.ToString()!.Contains(searchQuery) ||
                    order.ShipName!.Contains(searchQuery) ||
                    order.ShipRegion!.Contains(searchQuery) ||
                    order.ShipPostalCode!.Contains(searchQuery))
                .Include(order => order.Employee)
                .Include(order => order.Customer)
                .Include(order => order.OrderDetails)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Order>> FindByCustomer(string searchQuery)
        {
            return await Table
                .Include(order => order.Customer)
                .Where(order => order.Customer != null &&
                                (order.Customer.ContactName!.Contains(searchQuery) ||
                                 order.Customer.ContactTitle!.Contains(searchQuery) ||
                                 order.Customer.CompanyName!.Contains(searchQuery) ))
                                .Include(order => order.Employee)
                                .Include(order => order.OrderDetails)
                                .Include(order => order.ShipperNavigation)
                                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> FindByEmployee(string searchQuery)
        {
            return await Table
                .Include(order => order.Employee)
                .Where(order => order.Employee != null &&
                                (order.Employee.FirstName!.Contains(searchQuery) ||
                                 order.Employee.LastName!.Contains(searchQuery) ||
                                 order.Employee.Title!.Contains(searchQuery) ||
                                 order.Employee.TitleOfCourtesy!.Contains(searchQuery)))
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> FindByShipper(string searchQuery)
        {
            return await Table
                .Include(order => order.ShipperNavigation)
                .Where(order => order.ShipperNavigation != null && order.ShipperNavigation.CompanyName!.Contains(searchQuery))
                .Include(order => order.Customer)
                .Include(order => order.Employee)
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
