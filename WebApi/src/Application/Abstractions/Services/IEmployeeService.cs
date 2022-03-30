using System.Threading.Tasks;
using Domain;

namespace Application.Abstractions.Services;

public interface IEmployeeService
{
    Task<GetEmployeeResponse> GetEmployeesAsync(int pageNumber, int limit = 10);
}