
using ExpenseTracker.DTOs;
using ExpenseTracker.Repositories;

namespace ExpenseTracker.Services
{
    
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public  bool Login(LoginDTO loginDTO)
        {
            // Get the user by username
            var user =  _userRepository.GetByUsername(loginDTO.Username);
            if (user == null)
            {
                // User not found
                return false;
            }

            // Validate the password
            if (!VerifyPassword(loginDTO.Password, user.Password))
            {
                // Invalid password
                return false;
            }

            // Authentication successful
            return true;
        }

        private bool VerifyPassword(string password, string passwordHash)
        {
            // Compare the provided password with the stored password hash

            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }


    }
}
