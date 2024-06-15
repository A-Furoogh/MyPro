using MyPro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPro.Application.Interfaces
{
    public interface IProjectRepository
    {
        Task<Project> GetProjectByIdAsync(int projectId);
        Task<IEnumerable<Project>> GetAllProjectsByUserIdAsync(int userId);
        Task AddProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(int projectId);
        Task<IEnumerable<TaskItem>> GetTaskItemsOfProject();
    }
}
