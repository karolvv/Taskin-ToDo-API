using System.Collections.Generic;
using Taskin.Models;

using TaskModel = Taskin.Models.Task;

namespace Taskin.Services
{
    public interface ITaskListServices
    {
        System.Threading.Tasks.Task<TaskModel> AddTask(TaskModel tasks);
        System.Threading.Tasks.Task<List<TaskModel>> GetTasks();
    }
}
