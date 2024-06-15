using MyPro.Application.Interfaces;
using MyPro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPro.Application.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _taskItemRepository;

        public TaskItemService(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }

        public Task<TaskItem> GetTaskItemByIdAsync(int taskId)
        {
            return _taskItemRepository.GetTaskItemByIdAsync(taskId);
        }

        public Task<IEnumerable<TaskItem>> GetAllTaskItemsByProjectIdAsync(int projectId)
        {
            return _taskItemRepository.GetAllTaskItemsByProjectIdAsync(projectId);
        }
        /*
        public Task<IEnumerable<TaskItem>> GetTaskItemsByProjectIdAsync(int projectId)
        {
            return _taskItemRepository.GetTaskItemsByProjectIdAsync(projectId);
        }
        */

        public Task AddTaskItemAsync(TaskItem taskItem)
        {
            return _taskItemRepository.AddTaskItemAsync(taskItem);
        }

        public Task UpdateTaskItemAsync(TaskItem taskItem)
        {
            return _taskItemRepository.UpdateTaskItemAsync(taskItem);
        }

        public Task DeleteTaskItemAsync(int taskId)
        {
            return _taskItemRepository.DeleteTaskItemAsync(taskId);
        }
    }
}
