using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using TaskModel = Taskin.Models.Task;

namespace Taskin.Services
{
    public class TaskListServices : ITaskListServices
    {
        private readonly DynamoDBContext _context;

        public TaskListServices()
        {
            var dynamoClient = new AmazonDynamoDBClient(RegionEndpoint.APSoutheast2);
            _context = new DynamoDBContext(dynamoClient);
        }

        public async Task<TaskModel> AddTask(TaskModel task)
        {
            await _context.SaveAsync<TaskModel>(task);
            return task;
        }

        public List<TaskModel> AddTasks(List<TaskModel> tasks)
        {
            //await _context.SaveAsync<TaskModel>(tasks);
            foreach (TaskModel task in tasks)
            {

            }
            return tasks;
        }

        public async Task<List<TaskModel>> GetTasks()
        {
            var conditions = new List<ScanCondition>();
            return await _context.ScanAsync<TaskModel>(conditions).GetRemainingAsync();
        }

        private string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
