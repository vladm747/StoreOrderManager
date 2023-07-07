using AutoMapper;
using Common.DTO;
using DAL.Entities;

namespace BLL.AutoMapperProfiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerDTO>();
    }
}