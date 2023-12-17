using AutoMapper;
using Online_courses_CourseP_.Domain.SchoolEntities;

namespace Online_courses_CourseP_.Domain
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<Admin, Admin>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) 
                .ForMember(dest => dest.ConcurrencyStamp, opt => opt.Ignore()) 
                .ForMember(dest => dest.SecurityStamp, opt => opt.Ignore()) 
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()); 
        }
    }
}
