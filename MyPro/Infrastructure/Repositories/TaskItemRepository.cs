using Firebase.Database;
using Firebase.Database.Query;
using MyPro.Application.Interfaces;
using MyPro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPro.Infrastructure.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly FirebaseClient _firebaseClient;
        public TaskItemRepository(FirebaseClient firebaseClient)
        {
            _firebaseClient = firebaseClient;
        }
        public async Task<TaskItem> GetTaskItemByIdAsync(int taskId)
        {
            var taskItem = await _firebaseClient.Child("TaskItems").Child(taskId.ToString()).OnceSingleAsync<TaskItem>();
            return taskItem;
        }

        public async Task<IEnumerable<TaskItem>> GetAllTaskItemsByProjectIdAsync(int projectId)
        {
            // First, get all task items, then filter, where ProjectId is equal to projectId
            var taskItems = await _firebaseClient.Child("TaskItems").OnceAsync<TaskItem>();
            return taskItems.Select(t => t.Object).Where(t => t.ProjectId == projectId);
        }

        public async Task AddTaskItemAsync(TaskItem taskItem)
        {
            await _firebaseClient.Child("TaskItems").PostAsync(taskItem);
        }

        public async Task UpdateTaskItemAsync(TaskItem taskItem)
        {
            await _firebaseClient.Child("TaskItems").Child(taskItem.Id.ToString()).PutAsync(taskItem);
        }

        public async Task DeleteTaskItemAsync(int taskId)
        {
            await _firebaseClient.Child("TaskItems").Child(taskId.ToString()).DeleteAsync();
        }
    }
}
