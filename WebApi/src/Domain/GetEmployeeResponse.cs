using System.Collections.Generic;

namespace Domain
{
    public class GetEmployeeResponse
    {
        public IEnumerable<Employee> Employees { get; set; }

        public int TotalCount { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }
    }
}
