using System;
using System.Threading.Tasks;
using Application.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] int pageNumber = 1, [FromQuery] int limit = 10)
        {
            var result = await _employeeService.GetEmployeesAsync(pageNumber, limit);

            return Ok(result);
        }
    }
}
