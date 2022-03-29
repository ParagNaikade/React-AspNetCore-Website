using AutoMapper;

namespace Infrastructure.Employees.Maps
{
    internal class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, Domain.Employee>();
        }
    }
}
