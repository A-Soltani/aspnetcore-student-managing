using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManaging.Application.Commands;

namespace StudentManaging.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator) => 
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [Authorize]
        [HttpPost("Add")]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentCommand addStudentCommand)
        {
            await _mediator.Send(addStudentCommand);
            return Ok();
        }
    }
}