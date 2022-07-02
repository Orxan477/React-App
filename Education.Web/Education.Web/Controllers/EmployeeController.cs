using Education.Business.Interfaces.Employee;
using Education.Business.Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Education.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetEmployeeByIdQuery() { Id = id };
            return Ok(await _mediator.Send(query));
        }
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetEmployeeAllQuery() {};
            return Ok(await _mediator.Send(query));
        }
        [HttpPost()]
        public async Task<IActionResult> Create()
        {
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update()
        {
            return Ok();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }
    }
}
