using AutoMapper;
using Prova.MarQ.API.DTOs;
using Prova.MarQ.Domain.Entities;

namespace Prova.MarQ.API.Configuration.AutoMapping;

public class AutoMappingProfile : Profile
{
    public AutoMappingProfile()
    {
        CreateMap<Company, CompanyDTO>()
        .ReverseMap();
        CreateMap<Employee, EmployeeDTO>()
        .ReverseMap();
        CreateMap<TimeRecord, TimeRecordDTO>()
        .ReverseMap();

    }
}
