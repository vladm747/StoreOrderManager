using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Services.DI.Abstract;
using Common.DTO;
using DAL.Entities;
using DAL.Infrastructure.DI.Abstract;
using DAL.Infrastructure.DI.Implementation;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace BLL.Services.DI.Implementation
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public int TotalOrders { get; }
        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            TotalOrders = _orderRepository.Table.Count();
        }

        public async Task<IEnumerable<OrderDTO>> GetAllAsync(int? page, int? pageSize)
        {
            var orders = await _orderRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public async Task<IEnumerable<OrderDTO>> GetOrderPageAsync(int page, int pageSize)
        {
            if(page < 1) page = 1;
            var orders = await _orderRepository.GetPageAsync((page-1)*pageSize, pageSize);
            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public async Task<OrderDTO> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.FindAsync(id);

            if (order == null)
                throw new ArgumentException($"There is no order with id {id} in the database");

            return _mapper.Map<OrderDTO>(order);
        }

        public async Task UpdateAsync(int id, OrderDTO order)
        {
            Order? item = await _orderRepository.FindAsync(id);

            if (item == null)
                throw new KeyNotFoundException($"Order with id {id} doesn't exist in database!");

            _mapper.Map(order, item);

            await _orderRepository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _orderRepository.FindAsync(id);

            if (order == null)
                throw new KeyNotFoundException($"Order with id {id} doesn't exist in database!");

            await _orderRepository.DeleteAsync(order);
        }
    }
}
