using ExpenseTracker.DTOs;
using ExpenseTracker.Repositories;

namespace ExpenseTracker.Services
{
    public interface IAuthenticationService
    {
        bool Login(LoginDTO loginDTO);
    }
}
