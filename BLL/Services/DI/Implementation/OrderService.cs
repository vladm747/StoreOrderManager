using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Services.DI.Abstract;
using DAL.Entities;

namespace BLL.Services.DI.Implementation
{
    public class OrderService: IOrderService
    {
        public List<Order> GetAllOrders(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrder(int id, OrderDTO order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }
    }
}
