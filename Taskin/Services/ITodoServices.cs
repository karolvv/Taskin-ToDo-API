using System;
using Taskin.Models;

namespace Taskin.Services
{
    public interface ITodoServices
    {
        TodoServices AddTodoTasks(TodoTasks tasks);
    }
}
