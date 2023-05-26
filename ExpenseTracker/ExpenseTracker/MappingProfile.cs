using AutoMapper;
using ExpenseTracker.DTOs;
using ExpenseTracker.Models;
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
   }
