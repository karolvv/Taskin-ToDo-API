using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taskin.Services;
using Taskin.Models;

namespace Taskin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        private readonly ITaskListServices _services;

        public TaskListController(ITaskListServices services)
        {
            _services = services;
        }

        // GET /api/TaskList/
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "task1", "task2" };
        }

        // POST /api/TaskList/AddTask
        [HttpPost]
        [Route("AddTask")]
        public async Task<ActionResult<TaskModel>> AddTask(TaskModel task)
        {
            await _services.AddTask(task);
            return task;
        }

        // POST /api/TaskList/AddTasks
        [HttpPost]
        [Route("AddTasks")]
        public Task<TaskModel> AddTasks(TaskModel task)
        {
            Task<TaskModel> newTask = _services.AddTask(task);
            return newTask;
        }

        // GET /api/TaskList/GetTasks
        [HttpGet]
        [Route("GetTasks")]
        public Task<List<TaskModel>> GetTasks() // We might want to create a new model that captures this to make it tidier, neater, and easier to read.
        {
            var tasks = _services.GetTasks();

            return tasks;
        }
    }
}