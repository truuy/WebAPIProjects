﻿using AutoMapper;
using ExpenseTracker.DTOs;
using ExpenseTracker.Model;
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
   }
