using Cms.Data.Repository.Repositories;
using CMS.API;

 WebApplication.CreateBuilder(args)
                            .RegisterServices()
                            .Build()
                            .SetupMiddleware()
                            .Run();

