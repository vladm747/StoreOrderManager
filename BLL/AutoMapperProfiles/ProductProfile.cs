using AutoMapper;
using Common.DTO;
using DAL.Entities;

namespace BLL.AutoMapperProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDTO>();
    }
}