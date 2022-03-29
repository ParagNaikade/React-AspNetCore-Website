using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Abstractions.Providers;
using Application.Enums;

namespace Infrastructure.Employees
{
    internal class LiveDataProvider : IEmployeeProvider
    {
        public EmployeeDataSource DataSource => EmployeeDataSource.Live;

        public Task<IEnumerable<Domain.Employee>> GetEmployeesAsync(int pageNumber, int limit = 10)
        {
            throw new NotSupportedException();
        }
    }
}
