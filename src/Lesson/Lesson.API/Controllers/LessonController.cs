using Lesson.Application.UseCases.Lessons.Commands;
using Lesson.Application.UseCases.Lessons.Queries;
using Lesson.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

namespace Lesson.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LessonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateLesson(CreateLessonCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<LessonModel>>> GetAllLessons()
        {
            var result = await _mediator.Send(new GetAllLessonsQuery());

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateLesson(UpdateLessonCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult>  DeleteLesson(DeleteLessonCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
