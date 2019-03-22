using System;
using System.Collections.Generic;
using Taskin.Models;

namespace Taskin.Services
{
    public interface ITodoServices
    {
        TodoTasks AddTodoTasks(TodoTasks tasks);
        Dictionary<string, TodoTasks> GetTodoItems();
    }
}
