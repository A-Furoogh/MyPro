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
    public class UserRepository : IUserRepository
    {
        private readonly FirebaseClient _firebaseClient;
        public UserRepository(FirebaseClient firebaseClient)
        {
            _firebaseClient = firebaseClient;
        }
        public async Task<User> GetUserByIdAsync(int userId)
        {
            var user = await _firebaseClient.Child("Users").Child(userId.ToString()).OnceSingleAsync<User>();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await _firebaseClient.Child("Users").OnceAsync<User>();
            return users.Select(u => u.Object);
        }

        public async Task AddUserAsync(User user)
        {
            try
            {
                var users = await _firebaseClient.Child("Users").OnceAsync<User>();
                if (users.Any(u => u.Object.Name == user.Name))
                {
                    throw new Exception("Benutzername is schon benutzt! Versuchen Sie mit einem anderen Benutzernamen");
                }
                await _firebaseClient.Child("Users").PostAsync(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateUserAsync(User user)
        {
            await _firebaseClient.Child("Users").Child(user.Id.ToString()).PutAsync(user);
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _firebaseClient.Child("Users").Child(userId.ToString()).DeleteAsync();
        }
    }
}
