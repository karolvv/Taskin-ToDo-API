using System;
using System.Collections.Generic;
using Taskin.Models;
using Taskin.Services;

namespace Taskin.Services 
{
    public class TaskListServices : ITaskListServices
    {
        private readonly Dictionary<string, Task> _tasks;

        public TaskListServices()
        {
            _tasks = new Dictionary<string, Task>();
        }

        public Task AddTask(Task tasks)
        {
            _tasks.Add(generateID(), tasks);

            // We are returning tasks from the parameter passed in,
            // which is not exactly good practice but this will do for now
            // as what we want is to capture what we are doing in the line 
            // `_todoTasks.Add(tasks.TaskName, tasks);` and returning that
            return tasks;
        }

        public Dictionary<string, Task> GetTasks()
        {
            return _tasks;
        }

        private string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
