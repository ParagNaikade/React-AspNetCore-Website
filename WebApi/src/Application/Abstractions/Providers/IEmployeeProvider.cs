using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Enums;
using Domain;

namespace Application.Abstractions.Providers
{
    public interface IEmployeeProvider
    {
        EmployeeDataSource DataSource { get; }

        Task<GetEmployeeResponse> GetEmployeesAsync(int pageNumber, int limit = 10);
    }
}
