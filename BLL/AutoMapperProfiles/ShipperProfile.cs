using AutoMapper;
using Common.DTO;
using DAL.Entities;

namespace BLL.AutoMapperProfiles
{
    public class ShipperProfile: Profile
    {
        public ShipperProfile()
        {
            CreateMap<Shipper, ShipperDTO>();
        }
    }
}
