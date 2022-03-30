using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Abstractions.Providers;
using Application.Abstractions.Services;
using Application.Enums;
using Domain;

namespace Application.Services
{
    internal class EmployeeService  : IEmployeeService
    {
        private readonly IEmployeeProviderFactory _employeeProviderFactory;

        public EmployeeService(IEmployeeProviderFactory employeeProviderFactory)
        {
            _employeeProviderFactory = employeeProviderFactory ?? throw new ArgumentNullException(nameof(employeeProviderFactory));
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(int pageNumber, int limit)
        {
            var provider = _employeeProviderFactory.GetEmployeeProvider(EmployeeDataSource.Mock); // This could be passed from request to support both mock and live data

            return await provider.GetEmployeesAsync(pageNumber, limit);
        }
    }
}
