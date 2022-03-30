using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Application.Abstractions.Providers;
using Application.Enums;
using AutoMapper;
using Domain;

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

        public async Task<GetEmployeeResponse> GetEmployeesAsync(int pageNumber, int limit)
        {
            var path = Path.Combine(AppContext.BaseDirectory, @"Employees\MOCK_DATA.json");

            await using var fs = File.OpenRead(path);

            var employees = await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>(fs);

            var result = _mapper.Map<List<Domain.Employee>>(employees);

            return new GetEmployeeResponse
            {
                Employees = result.Skip((pageNumber - 1) * limit).Take(limit),
                CurrentPage = pageNumber,
                PageSize = limit,
                TotalCount = result.Count,
            };
        }
    }
}
