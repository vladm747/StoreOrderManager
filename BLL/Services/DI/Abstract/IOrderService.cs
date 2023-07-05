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
        Task<IEnumerable<OrderDTO>> GetAllAsync(int? page, int? pageSize);
        Task<OrderDTO> GetOrderByIdAsync(int id);
        Task UpdateAsync(int id, OrderDTO order);
        Task DeleteAsync(int id);
    }
}
