using MyPro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPro.Application.Interfaces
{
    public interface ITaskItemService
    {
        Task<TaskItem> GetTaskItemByIdAsync(int taskItemId);
        Task<IEnumerable<TaskItem>> GetAllTaskItemsByProjectIdAsync(int projectId);
        Task AddTaskItemAsync(TaskItem taskItem);
        Task UpdateTaskItemAsync(TaskItem taskItem);
        Task DeleteTaskItemAsync(int taskItemId);
    }
}
