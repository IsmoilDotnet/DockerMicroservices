using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Application.UseCases.Students.Commands;
using Student.Application.UseCases.Students.Queries;
using Student.Domain.Entities;

namespace Student.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult>  CreateStudent(CreateStudentCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentModel>>> GetAllStudents()
        {
            var result = await _mediator.Send(new GetAllStudentsQuery());

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateStudent(UpdateStudentCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteStudent(DeleteStudentCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }



    }
}
