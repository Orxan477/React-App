using Education.Business.Interfaces.Employee;
using Microsoft.AspNetCore.Mvc;

namespace Education.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Core.Entities.Employee employee= await _employeeService.Get(id);
            return Ok(employee);
        }
    }
}
