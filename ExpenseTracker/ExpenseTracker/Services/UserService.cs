using ExpenseTracker.Repositories;
using AutoMapper;
using ExpenseTracker.DTOs;
using ExpenseTracker.Models;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace ExpenseTracker.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        public UserDTO GetUserById(Guid userId)
        {
            var user = _userRepository.GetUserById(userId);
            return _mapper.Map<UserDTO>(user);  
        }

        public UserDTO GetUserByUsername(string username)
        {
            var user = _userRepository.GetByUsername(username);
            return _mapper.Map<UserDTO>(user);
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public void CreateUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);

            // Hash the password
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);
            user.Password = hashedPassword;

            _userRepository.AddUser(user);
        }

        public bool IsValidEmail(string email)
        {
           return Regex.IsMatch(email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$");
            
        }

        public void UpdateUser(UserDTO userDTO)
        {
            var existingUser = _userRepository.GetUserById(userDTO.UserId);
            if (existingUser == null)
            {
                Console.WriteLine("Error 404: User not found");
            }

            //Update user with new data
            existingUser.Username = userDTO.Username;
            existingUser.Email = userDTO.Email;

            //Update user
            _userRepository.UpdateUser(existingUser);
        }

        public void DeleteUser(Guid userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                Console.WriteLine("Error 404: User not found");
            }

            _userRepository.DeleteUser(user);
        }

    }
}
