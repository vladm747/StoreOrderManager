using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Services.DI.Abstract
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetAllAsync(int? page, int? pageSize);
        Task<OrderDTO> GetOrderByIdAsync(int id);
        Task AddOrder(Order order);
        Task<OrderDTO> UpdateOrder(int id, OrderDTO order);
        Task<bool> DeleteOrder(int id);
    }
}
