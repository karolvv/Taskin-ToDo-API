using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using TaskModel = Taskin.Models.Task;

namespace Taskin.Services
{
    public class TaskListServices : ITaskListServices
    {
        private readonly DynamoDBContext _context;
        private string tableName = "Tasks";

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

        public async Task<TaskModel> GetTask(int id)
        {
            var conditions = new List<ScanCondition>();
            conditions.Add(new ScanCondition("Id", ScanOperator.Equal, id));
            var allTasks = await _context.ScanAsync<TaskModel>(conditions).GetRemainingAsync();
            return allTasks.FirstOrDefault();
        }

        public async Task<List<TaskModel>> GetTasks()
        {
            var conditions = new List<ScanCondition>();
            return await _context.ScanAsync<TaskModel>(conditions).GetRemainingAsync();
        }

        public Task<TaskModel> UpdateTask(TaskModel task)
        {
            // Get Task to Update
            var conditions = new List<ScanCondition>();
            conditions.Add(new ScanCondition("Id", ScanOperator.Equal, task.Id));
            Task<TaskModel> retrievedTask = _context.LoadAsync<TaskModel>(task.Id);
            
            // Update Properties
            retrievedTask.Result.Updated = DateTime.Now;
            retrievedTask.Result.Name = task.Name;
            retrievedTask.Result.Priority = task.Priority;
            _context.SaveAsync(retrievedTask);
            
            Console.WriteLine("Task" + task.Id + task.Name + "updated.");
            
            // Retrieve Updated Task
            return _context.LoadAsync<TaskModel>(task.Id, new DynamoDBContextConfig
            {
                ConsistentRead = true
            });
        }

        public TaskModel DeleteTask(TaskModel task)
        {
            // Delete task
            _context.DeleteAsync<TaskModel>(task.Id);
            
            // Retrieve deleted book. Should return null
            var deletedTask = _context.LoadAsync<TaskModel>(task.Id, new DynamoDBContextConfig
            {
                ConsistentRead = true
            });
            if (deletedTask == null) 
                Console.WriteLine("Task" + task.Id + task.Name + "deleted.");

            return task;
        }

        public void RemoveTask()
        {
            
        }

        private string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
