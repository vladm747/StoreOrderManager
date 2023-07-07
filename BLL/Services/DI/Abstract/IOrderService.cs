using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTO;
using DAL.Entities;

namespace BLL.Services.DI.Abstract
{
    public interface IOrderService
    {
        int TotalOrders { get; }
        Task<IEnumerable<OrderDTO>> GetAllAsync(int? page, int? pageSize);
        Task<IEnumerable<OrderDTO>> GetOrderPageAsync(int page, int pageSize);
        Task<IEnumerable<OrderDTO>> SearchOrdersByQueryAsync(string searchQuery);
        Task<OrderDTO> GetOrderByIdAsync(int id);
        Task UpdateAsync(int id, OrderDTO order);
        Task DeleteAsync(int id);
    }
}
