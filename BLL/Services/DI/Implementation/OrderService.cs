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

        public async Task<IEnumerable<OrderDTO>> GetAllAsync(int? page, int? pageSize)
        {
            var orders = await _orderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public async Task<OrderDTO> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.FindAsync(id);
            if (order == null)
                throw new ArgumentException($"There is no order with id {id} in the database");
            return _mapper.Map<OrderDTO>(order);
        }

        public Task<OrderDTO> UpdateOrder(int id, OrderDTO order)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _orderRepository.FindAsync(id);
            if (order == null)
                throw new InvalidOperationException(
                    $"Order with id {id}, that you are trying to delete doesn't exist in the database.");
            await _orderRepository.DeleteAsync(order);
        }
    }
}
