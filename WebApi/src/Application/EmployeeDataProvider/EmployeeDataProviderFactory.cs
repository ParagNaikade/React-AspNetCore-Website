using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Application.Abstractions.Providers;
using Application.Enums;

[assembly: InternalsVisibleTo("Application.UnitTests")]
namespace Application.EmployeeDataProvider
{
    internal class EmployeeDataProviderFactory : IEmployeeProviderFactory
    {
        private readonly IEnumerable<IEmployeeProvider> _allProviders;

        public EmployeeDataProviderFactory(IEnumerable<IEmployeeProvider> allProviders)
        {
            _allProviders = allProviders ?? throw new ArgumentNullException(nameof(allProviders));
        }

        public IEmployeeProvider GetEmployeeProvider(EmployeeDataSource dataSource)
        {
            return _allProviders.SingleOrDefault(p => p.DataSource == dataSource);
        }
    }
}
