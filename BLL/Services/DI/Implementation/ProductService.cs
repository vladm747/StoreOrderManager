using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Services.DI.Abstract;
using Common.DTO;
using DAL.Infrastructure.DI.Abstract;
using DAL.Infrastructure.DI.Implementation;

namespace BLL.Services.DI.Implementation
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var orders = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(orders);
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var order = await _productRepository.FindAsync(id);
    /*        if (order == null)
                throw new ArgumentException($"There is no product with id {id} in the database");*/
            return _mapper.Map<ProductDTO>(order);
        }
    }
}
