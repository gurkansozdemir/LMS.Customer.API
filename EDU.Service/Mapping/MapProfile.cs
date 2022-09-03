using AutoMapper;
using EDU.Core.DTOs.ActivityDTOs;
using EDU.Core.DTOs.AdvertDTOs;
using EDU.Core.DTOs.ClassroomDTOs;
using EDU.Core.DTOs.EducationDTOs;
using EDU.Core.DTOs.InpectionDTOs;
using EDU.Core.DTOs.LessonDTOs;
using EDU.Core.DTOs.RegisterDTOs;
using EDU.Core.DTOs.UserDTOs;
using EDU.Core.Entities;

namespace EDU.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<LoginDto, User>();
            CreateMap<User, GetUserDto>().ReverseMap();
            CreateMap<SetUserDto, User>();
            CreateMap<Classroom, GetClassroomDto>();
            CreateMap<Education, GetEducationDto>();
            CreateMap<IncludeStudentDto, StudentOfClassroom>();
            CreateMap<SetClassroomDto,Classroom>();
            CreateMap<Activity, ActivityDto>().ReverseMap();
            CreateMap<SetInspectionDto, Inspection>().ReverseMap();
            CreateMap<Inspection, GetInspectionDto>();
            CreateMap<Lesson, GetLessonDto>();
            CreateMap<SetEducationDto, Education>();
            CreateMap<Advert, GetAdvertDto>();
            CreateMap<SetAdvertDto, Advert>();
            CreateMap<Register, GetRegisterDto>();
            CreateMap<SetRegisterDto, Register>();
            CreateMap<MenuItem, MenuItemDto>(); 
        }
    }
}
