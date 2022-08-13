using EDU.Core.DTOs;
using EDU.Core.DTOs.LessonDTOs;
using EDU.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Core.Services
{
    public interface ILessonService : IService<Lesson>
    {
        Task<CustomResponseDto<List<GetLessonDto>>> GetByEducationIdAsync(int id);
    }
}
