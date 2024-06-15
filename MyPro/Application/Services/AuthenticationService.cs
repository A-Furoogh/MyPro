using MyPro.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPro.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private bool _isAuthenticated;
        public AuthenticationService(IAuthenticationRepository authenticationService)
        {
            _authenticationRepository = authenticationService;
        }
        public bool IsUserAuthenticated()
        {
            return _isAuthenticated;
        }

        public async Task<bool> AuthenticateUserAsync(string username, string password)
        {
            bool isAuthenticated = await _authenticationRepository.AuthenticateUserAsync(username, password);
            if (isAuthenticated)
            {
                _isAuthenticated = true;
                return true;
            }
            else
            {
                _isAuthenticated = false;
                return false;
            }
        }
        public int GetUserIdAsync()
        {
            return _authenticationRepository.GetUserIdAsync();
        }

        public void Logout()
        {
            _isAuthenticated = false;
        }
    }
}
