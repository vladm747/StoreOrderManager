using AutoMapper;
using Common.DTO;
using DAL.Entities;

namespace BLL.AutoMapperProfiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeDTO>();
    }
}