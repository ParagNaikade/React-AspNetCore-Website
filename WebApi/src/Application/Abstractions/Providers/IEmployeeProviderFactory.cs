using Application.Enums;

namespace Application.Abstractions.Providers
{
    public interface IEmployeeProviderFactory
    {
        IEmployeeProvider GetEmployeeProvider(EmployeeDataSource dataSource);
    }
}