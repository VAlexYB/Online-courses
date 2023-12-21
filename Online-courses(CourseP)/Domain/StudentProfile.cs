using AutoMapper;
using Online_courses_CourseP_.Domain.SchoolEntities;

namespace Online_courses_CourseP_.Domain
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, Student>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ConcurrencyStamp, opt => opt.Ignore())
                .ForMember(dest => dest.SecurityStamp, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
        }
    }
}
