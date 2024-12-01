using CafeManagement.Application.Features.Cafe.Create;
using CafeManagement.Application.Features.Cafe.Delete;
using CafeManagement.Application.Features.Cafe.Get;
using CafeManagement.Application.Features.Cafe.Update;
using CafeManagement.Application.Features.Employee.Create;
using CafeManagement.Application.Features.Employee.Delete;
using CafeManagement.Application.Features.Employee.Get;
using CafeManagement.Application.Features.Employee.Update;
using CafeManagement.WebAPI.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RetailSystemBackEnd.WebAPI.Controllers
{
    public class EmployeesController : BaseController
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees([FromQuery] string cafeName)
        {
            // Request to get cafes filtered by location
            var query = new GetEmployeeQueryRequest(cafeName);
            var employees = await _mediator.Send(query);
            return Ok(employees);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommandRequest request)
        {
            if (request.ID == Guid.Empty)
                return BadRequest(request.ID);

            await _mediator.Send(request);

            return Ok(); // Returns the updated response
        }

        [HttpPost()]
        public async Task<IActionResult> CreateCafe([FromBody] AddEmployeeCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response); // Returns the updated response
        }

        // DELETE: api/cafe/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCafe(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest(id);

            var request = new DeleteEmployeeCommandRequest(id);
            await _mediator.Send(request);
            return NoContent(); // No content to return, but signifies successful deletion
        }
    }
}
