using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taskin.Models;

namespace Taskin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        [HttpPost]
        public ActionResult<TodoTasks> AddTodoTasks()
        {
            return Ok();
        }
    }
}