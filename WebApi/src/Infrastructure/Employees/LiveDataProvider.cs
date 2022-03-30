using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Abstractions.Providers;
using Application.Enums;
using Domain;

namespace Infrastructure.Employees
{
    internal class LiveDataProvider : IEmployeeProvider
    {
        public EmployeeDataSource DataSource => EmployeeDataSource.Live;

        public Task<GetEmployeeResponse> GetEmployeesAsync(int pageNumber, int limit = 10)
        {
            throw new NotSupportedException();
        }
    }
}
