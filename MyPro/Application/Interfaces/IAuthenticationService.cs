using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPro.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateUserAsync(string username, string password);
        bool IsUserAuthenticated();
        int GetUserIdAsync();

        void Logout();
    }
}
