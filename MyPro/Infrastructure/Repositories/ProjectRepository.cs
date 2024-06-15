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
    public class ProjectRepository : IProjectRepository
    {
        private readonly FirebaseClient _firebaseClient;
        public ProjectRepository(FirebaseClient firebaseClient)
        {
            _firebaseClient = firebaseClient;
        }

        public async Task<Project> GetProjectByIdAsync(int projectId)
        {
            var project = await _firebaseClient.Child("Projects").Child(projectId.ToString()).OnceSingleAsync<Project>();
            return project;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsByUserIdAsync(int userId)
        {
            // Get all projects, then filter where the project's UsersIds list contains the userId
            var projects = await _firebaseClient.Child("Projects").OnceAsync<Project>();
            return projects.Select(p => p.Object).Where(p => p.UsersIds.Contains(userId));
        }

        public async Task AddProjectAsync(Project project)
        {
            await _firebaseClient.Child("Projects").PostAsync(project);
        }

        public async Task UpdateProjectAsync(Project project)
        {
            await _firebaseClient.Child("Projects").Child(project.Id.ToString()).PutAsync(project);
        }

        public async Task DeleteProjectAsync(int projectId)
        {
            await _firebaseClient.Child("Projects").Child(projectId.ToString()).DeleteAsync();
        }

        /*
        public void SubscribeToProjects(Action<Project> onProjectAdded, Action<Project> onProjectChanged, Action<Project> onProjectDeleted)
        {
            _firebaseClient
                .Child("projects")
                .AsObservable<Project>()
                .Subscribe(d =>
                {
                    if (d.EventType == FirebaseEventType.InsertOrUpdate)
                    {
                        onProjectAdded?.Invoke(d.Object);
                    }
                    else if (d.EventType == FirebaseEventType.Delete)
                    {
                        onProjectDeleted?.Invoke(d.Object);
                    }
                    else if (d.EventType == FirebaseEventType.Update)
                    {
                        onProjectChanged?.Invoke(d.Object);
                    }
                });
        }
        */
        public Task<IEnumerable<TaskItem>> GetTaskItemsOfProject()
        {
            throw new NotImplementedException();
        }
    }
}
