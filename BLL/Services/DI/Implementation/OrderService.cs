using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Services.DI.Abstract;
using DAL.Entities;
using DAL.Infrastructure.DI.Abstract;
using DAL.Infrastructure.DI.Implementation;

namespace BLL.Services.DI.Implementation
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public IEnumerable<OrderDTO> GetAllOrders(int? page, int? pageSize)
        {
            
            return _mapper.Map<IEnumerable<OrderDTO>>(_orderRepository.GetAll());
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
