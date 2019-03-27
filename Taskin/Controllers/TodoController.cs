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

        public TodoController(ITodoServices services)
        {
            _services = services;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "task1", "task2" };
        }

        [HttpPost]
        [Route("AddTodoTasks")]
        public ActionResult<TodoTasks> AddTodoTasks(TodoTasks tasks)
        {
            var todoTasks = _services.AddTodoTasks(tasks);
            if (todoTasks == null)
            {
                return NotFound();
            }
            return todoTasks;
        }

        [HttpGet]
        [Route("GetTodoTasks")]
        public ActionResult<Dictionary<string, TodoTasks>> GetTodoTasks() // We might want to create a new model that captures this to make it tidier, neater, and easier to read.
        {
            var todoTasks = _services.GetTodoItems();

            if (todoTasks.Count == 0)
            {
                return NotFound();
            }
            return todoTasks;
        }
    }
}