using Education.Business.Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Education.Business.Mediator.Commands.Employee;
using Education.Business.Mediator.Commands.Employee.Delete;
using Education.Business.Mediator.Commands.Employee.Update;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
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
        public async Task<IActionResult> Create(CreateEmployeeComand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateEmployeeCommand command)
        {
            var query = new UpdateEmployeeCommand()
            {
                Id = id,
                Fullname=command.Fullname,
                PositionId=command.PositionId,
                Age=command.Age
            };
            return Ok(await _mediator.Send(query));
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var query = new DeleteEmployeeComand()
            {
                Id = id
            };
            return Ok(await _mediator.Send(query));
        }
    }
}
