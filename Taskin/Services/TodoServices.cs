using System;
using System.Collections.Generic;
using Taskin.Models;

namespace Taskin.Services
{
    public class TodoServices : ITodoServices
    {
        private readonly Dictionary<string, TodoTasks> _todoTasks;
        public TodoServices()
        {
            _todoTasks = new Dictionary<string, TodoTasks>();
        }

        public TodoTasks AddTodoTasks(TodoTasks tasks)
        {
            _todoTasks.Add(tasks.TaskName, tasks);

            // We are returning tasks from the parameter passed in,
            // which is not exactly good practice but this will do for now
            // as what we want is to capture what we are doing in the line `_todoTasks.Add(tasks.TaskName, tasks);` and returning that
            return tasks;
        }

        public Dictionary<string, TodoTasks> GetTodoItems()
        {
            return _todoTasks;
        }
    }
}
