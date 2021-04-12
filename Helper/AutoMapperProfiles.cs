using AutoMapper;
using UniversityServer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityServer.Entities;
using UniversityServer.Extensions;

namespace UniversityServer.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.UserCourses))
                .ForMember(dest=> dest.Age, opt => opt.MapFrom(src=>src.DateOfBirth.CalculateAge()));

            CreateMap<Course, CourseDto>();

            CreateMap<Schedule, ScheduleDto>();
        }
    }
}
