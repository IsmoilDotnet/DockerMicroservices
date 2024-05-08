using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teacher.Application.UseCases.Teachers.Commands;
using Teacher.Application.UseCases.Teachers.Queries;
using Teacher.Domain.Entities;

namespace Teacher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeacherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTeacher(CreateTeacherCommand command)
        {
            var res = await _mediator.Send(command);

            return Ok(res);
        }

        [HttpGet]
        public async Task<ActionResult<List<TeacherModel>>> GetAllTeachers()
        {
            var res = await _mediator.Send(new GetAllTeachersQuery());

            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTeacher(UpdateTeacherCommand command)
        {
            var res = await _mediator.Send(command);

            return Ok(res);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTeacher(DeleteTeacherCommand command)
        {
            var res = await _mediator.Send(command);

            return Ok(res);
        }
    }
}
