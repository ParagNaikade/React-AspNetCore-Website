using System.Collections.Generic;
using Application.Abstractions.Providers;
using Application.EmployeeDataProvider;
using Application.Enums;
using FluentAssertions;
using Moq;
using Xunit;

namespace Application.UnitTests
{
    public class EmployeeDataProviderFactoryTests
    {
        private readonly EmployeeDataProviderFactory _factory;

        public EmployeeDataProviderFactoryTests()
        {
            var liveDataProviderMock = new Mock<IEmployeeProvider>();
            liveDataProviderMock.Setup(x => x.DataSource).Returns(EmployeeDataSource.Live);

            var mockDataProviderMock = new Mock<IEmployeeProvider>();
            mockDataProviderMock.Setup(x => x.DataSource).Returns(EmployeeDataSource.Mock);

            var allProviders = new List<IEmployeeProvider>()
            {
                liveDataProviderMock.Object,
                mockDataProviderMock.Object
            };

            _factory = new EmployeeDataProviderFactory(allProviders);
        }

        [Theory]
        [InlineData(EmployeeDataSource.Live, EmployeeDataSource.Live)]
        [InlineData(EmployeeDataSource.Mock, EmployeeDataSource.Mock)]
        public void GetEmployeeProviderTests(EmployeeDataSource inputDataSource, EmployeeDataSource expectedProviderSource)
        {
            var provider = _factory.GetEmployeeProvider(inputDataSource);

            provider.DataSource.Should().Be(expectedProviderSource);
        }
    }
}
