using System;
using System.Collections.Generic;
using Taskin.Models;

using TaskModel = Taskin.Models.Task;

namespace Taskin.Services
{
    public interface ITaskListServices
    {
        System.Threading.Tasks.Task<TaskModel> AddTask(Task tasks);
        System.Threading.Tasks.Task<List<TaskModel>> GetTasks();
    }
}
