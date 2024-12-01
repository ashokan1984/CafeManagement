using CafeManagement.Application.Features.Cafe.Create;
using CafeManagement.Application.Features.Cafe.Delete;
using CafeManagement.Application.Features.Cafe.Get;
using CafeManagement.Application.Features.Cafe.Update;
using CafeManagement.WebAPI.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CafeManagement.WebAPI.Controllers
{
    public class CafesController : BaseController
    {
        private readonly IMediator _mediator;

        public CafesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/cafe
        [HttpGet]
        public async Task<IActionResult> GetCafes([FromQuery] string location)
        {
            // Request to get cafes filtered by location
            var query = new GetCafeQueryRequest(location);
            var cafes = await _mediator.Send(query);
            return Ok(cafes);
        }


        // PUT: api/cafe/{id}
        [HttpPut()]
        public async Task<IActionResult> UpdateCafe([FromBody] UpdateCafeCommandRequest request)
        {
            if(request.ID == Guid.Empty)
                return BadRequest(request.ID);

            await _mediator.Send(request);

            return Ok(); // Returns the updated response
        }

        [HttpPost()]
        public async Task<IActionResult> CreateCafe([FromBody] AddCafeCommandRequest request)
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

            var request = new DeleteCafeCommandRequest(id);
            await _mediator.Send(request);
            return NoContent(); // No content to return, but signifies successful deletion
        }
    }
}
