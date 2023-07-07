using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Infrastructure.DI.Abstract
{
    public interface IOrderRepository: IRepositoryBase<Order, int>
    {
        Task<IEnumerable<Order>> GetPageAsync(int countSkip, int pageSize);
        Task<IEnumerable<Order>> FindByProperty(string searchQuery);
        Task<IEnumerable<Order>> FindByCustomer(string searchQuery);
        Task<IEnumerable<Order>> FindByEmployee(string searchQuery);
        Task<IEnumerable<Order>> FindByShipper(string searchQuery);
    }
}
