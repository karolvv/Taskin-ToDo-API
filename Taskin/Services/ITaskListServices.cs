using System;
using System.Collections.Generic;
using Taskin.Models;

namespace Taskin.Services
{
    public interface ITaskListServices
    {
        Task AddTask(Task tasks);
        Dictionary<string, Task> GetTasks();
    }
}
