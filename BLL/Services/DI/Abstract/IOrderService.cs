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
        List<Order> GetAllOrders(int page, int pageSize);
        Task<Order> GetOrderById(int id);
        Task AddOrder(Order order);
        Task<Order> UpdateOrder(int id, OrderDTO order);
        Task<bool> DeleteOrder(int id);
    }
}
