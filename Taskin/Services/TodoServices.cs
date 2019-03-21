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

        public TodoServices AddTodoTasks(TodoTasks tasks)
        {
            throw new NotImplementedException();
        }
    }
}
