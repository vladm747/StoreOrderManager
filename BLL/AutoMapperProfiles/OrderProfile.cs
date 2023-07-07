using AutoMapper;
using Common.DTO;
using DAL.Entities;

namespace BLL.AutoMapperProfiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        var mapper = new Mapper(new MapperConfiguration(config => config.AddProfiles(new Profile[]
            {new OrderDetailProfile(), new CustomerProfile(), new EmployeeProfile(), new ShipperProfile()})));

        CreateMap<Order, OrderDTO>()
            .ForMember(dest => dest.OrderDetails,
                opt => opt.MapFrom(src => mapper.Map<ICollection<OrderDetailDTO>>(src.OrderDetails)))
            .ForMember(dest => dest.ShipViaNavigation,
                opt => opt.MapFrom(src => mapper.Map<ShipperDTO>(src.ShipperNavigation)))
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => mapper.Map<CustomerDTO>(src.Customer)))
            .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => mapper.Map<EmployeeDTO>(src.Employee)));

        CreateMap<OrderDTO, Order>()
            .ForMember(dest => dest.OrderDetails,
                opt => opt.MapFrom(src => mapper.Map<List<OrderDetail>>(src.OrderDetails)));
    }
}