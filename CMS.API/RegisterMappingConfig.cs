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
                .Map(dest => dest.CourseId, src => src.CourseId)
                .Map(dest => dest.CourseName, src => src.CourseName)
                .Map(dest => dest.CourseDuration, src => src.CourseDuration)
                .Map(dest => dest.CourseType, src => src.CourseType);         
                
                }
        
    }
}
