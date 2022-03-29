using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace Application.Abstractions.Services;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetEmployeesAsync(int pageNumber, int limit = 10);
}