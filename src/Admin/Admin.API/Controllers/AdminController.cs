using Admin.Application.UseCases.Admins.Commands;
using Admin.Application.UseCases.Admins.Queries;
using Admin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAdmin(CreateAdminCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<AdminModel>>> GetAllAdmins()
        {
            var result = await _mediator.Send(new GetAllAdminsQuery());

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAdmin(UpdateAdminCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAdmin(DeleteAdminCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
