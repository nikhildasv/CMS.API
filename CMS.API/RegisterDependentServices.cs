using Cms.Data.Repository.Repositories;
using Microsoft.AspNetCore.Mvc.Versioning;
namespace CMS.API
{
    public static class RegisterDependentServices
    {
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.RegisterMappingConfig();
            builder.Services.AddTransient<ICmsRepository, InMemoryCmsRepository>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddApiVersioning(opt =>
            {
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                // opt.ApiVersionReader = new QueryStringApiVersionReader("v");// use custom query string key eg: http://localhost:5147/Courses?api-version=2.0
                //opt.ApiVersionReader = new UrlSegmentApiVersionReader();// version within the url path
                //opt.ApiVersionReader = new HeaderApiVersionReader("X-Version");// reader version from header

                //sport multiple  api version readers.

                opt.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("v"),
                    new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader("X-Version")
                    );
            });
            return builder;
        }
    }
}
