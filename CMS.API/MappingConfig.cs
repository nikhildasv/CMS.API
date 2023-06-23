using Cms.Data.Repository.Models;
using CMS.API.DTOs;
using Mapster;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CMS.API
{
    public static class MappingConfig
    {
        public static void RegisterMappingConfig(this IServiceCollection services)
        {
            TypeAdapterConfig<Course, CourseDTO>.NewConfig().TwoWays()
                .Map(dest => dest.CourseIdentifier, src => src.CourseId)
                .Map(dest => dest.CourseName, src => src.CourseName)
                .Map(dest => dest.Duration, src => src.CourseDuration)
                .Map(dest => dest.CourseType, src => src.CourseType);

            TypeAdapterConfig<Student, StudentDto>.NewConfig().TwoWays()
                .Map(dest => dest.StudentId, src => src.StudentId)
                .Map(dest => dest.FirstName, src => src.FirstName)
                .Map(dest => dest.LastName, src => src.LastName)
                .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
             .Map(dest => dest.CourseName, src => src.Course.CourseName)
              .Map(dest => dest.CourseId, src => src.Course.CourseId);

        }

    }
}
