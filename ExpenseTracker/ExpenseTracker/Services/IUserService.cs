using ExpenseTracker.DTOs;

namespace ExpenseTracker.Services
{
    public interface IUserService
    {
        UserDTO GetUserById(Guid userId);
        UserDTO GetUserByUsername(string username);
        IEnumerable<UserDTO> GetAllUsers();
        void CreateUser(UserDTO userDTO);
        void UpdateUser(UserDTO userDTO);
        void DeleteUser(Guid userId);
        bool IsValidEmail(string email);
    }
}
