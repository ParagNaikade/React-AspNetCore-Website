using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Application.Abstractions.Providers;
using Application.Enums;
using AutoMapper;

namespace Infrastructure.Employees
{
    internal class MockDataProvider : IEmployeeProvider
    {
        private readonly IMapper _mapper;

        public EmployeeDataSource DataSource => EmployeeDataSource.Mock;

        public MockDataProvider(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<Domain.Employee>> GetEmployeesAsync(int pageNumber, int limit = 10)
        {
            var path = Path.Combine(AppContext.BaseDirectory, @"Employees\MOCK_DATA.json");

            await using var fs = File.OpenRead(path);

            var employees = await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>(fs);
            return _mapper.Map<IEnumerable<Domain.Employee>>(employees);
        }
    }
}
