using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taskin.Services;

using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Runtime;

using TaskModel = Taskin.Models.Task;


namespace Taskin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        private readonly ITaskListServices _services;
        private readonly DynamoDBContext _context;

        public TaskListController(ITaskListServices services)
        {
            _services = services;
            var dynamoClient = new AmazonDynamoDBClient(RegionEndpoint.APSoutheast2);
            _context = new DynamoDBContext(dynamoClient);
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
            await _context.SaveAsync<TaskModel>(task);
            return task;
        }

        // POST /api/TaskList/AddTasks
        [HttpPost]
        [Route("AddTasks")]
        public ActionResult<TaskModel> AddTasks(Models.Task task)
        {
            var newTask = _services.AddTask(task);
            if (newTask == null)
            {
                return NotFound();
            }
            return newTask;
        }

        // GET /api/TaskList/GetTasks
        [HttpGet]
        [Route("GetTasks")]
        public ActionResult<Dictionary<string, TaskModel>> GetTasks() // We might want to create a new model that captures this to make it tidier, neater, and easier to read.
        {
            var tasks = _services.GetTasks();

            if (tasks.Count == 0)
            {
                return NotFound();
            }
            return tasks;
        }
    }
}