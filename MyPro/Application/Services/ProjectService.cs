using MyPro.Application.Interfaces;
using MyPro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPro.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public Task<Project> GetProjectByIdAsync(int projectId)
        {
            return _projectRepository.GetProjectByIdAsync(projectId);
        }

        public Task<IEnumerable<Project>> GetAllProjectsByUserIdAsync(int userId)
        {
            return _projectRepository.GetAllProjectsByUserIdAsync(userId);
        }

        public Task AddProjectAsync(Project project)
        {
            return _projectRepository.AddProjectAsync(project);
        }

        public Task UpdateProjectAsync(Project project)
        {
            return _projectRepository.UpdateProjectAsync(project);
        }

        public Task DeleteProjectAsync(int projectId)
        {
            return _projectRepository.DeleteProjectAsync(projectId);
        }
        public Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return _projectRepository.GetAllProjectsAsync();
        }
    }
}
