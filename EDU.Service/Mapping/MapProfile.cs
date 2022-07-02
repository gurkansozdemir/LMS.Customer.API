﻿using AutoMapper;
using EDU.Core.DTOs.UserDTOs;
using EDU.Core.Entities;

namespace EDU.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<SetUserDto, User>();
            CreateMap<User, GetUserDto>().ReverseMap();
        }
    }
}