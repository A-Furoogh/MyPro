using MyPro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPro.Application.Interfaces
{
    public interface ITaskItemRepository
    {
        Task<TaskItem> GetTaskItemByIdAsync(int taskId);
        Task<IEnumerable<TaskItem>> GetAllTaskItemsByProjectIdAsync(int projectId);
        Task AddTaskItemAsync(TaskItem taskItem);
        Task UpdateTaskItemAsync(TaskItem taskItem);
        Task DeleteTaskItemAsync(int taskId);
    }
}
