using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taskin.Models;
using Taskin.Services;

namespace Taskin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoServices _services;

        [HttpPost]
        public ActionResult<TodoTasks> AddTodoTasks(TodoTasks tasks)
        {
            var todoTasks = _services.AddTodoTasks(tasks);
            if (todoTasks == null)
            {
                return NotFound();
            }
            return todoTasks();
        }
    }
}