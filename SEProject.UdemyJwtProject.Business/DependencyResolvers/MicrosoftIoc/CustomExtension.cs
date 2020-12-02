using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SEProject.UdemyJwtProject.Business.Concrete;
using SEProject.UdemyJwtProject.Business.Interfaces;
using SEProject.UdemyJwtProject.Business.ValidationRules.FluentValidation;
using SEProject.UdemyJwtProject.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using SEProject.UdemyJwtProject.DataAccess.Interfaces;
using SEProject.UdemyJwtProject.Entities.Dtos.AppUserDtos;
using SEProject.UdemyJwtProject.Entities.Dtos.ProductDtos;

namespace SEProject.UdemyJwtProject.Business.DependencyResolvers.MicrosoftIoc
{
    public static class CustomExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductRepository>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();

            services.AddScoped<IAppRoleService, AppRoleManager>();
            services.AddScoped<IAppRoleDal, EfAppRoleRepository>();

            services.AddScoped<IAppUserRoleService, AppUserRoleManager>();
            services.AddScoped<IAppUserRoleDal, EfAppUserRoleRepository>();

            services.AddScoped<IJwtService, JwtManager>();

            services.AddTransient<IValidator<ProductAddDto>, ProductAddDtoValidator>();
            services.AddTransient<IValidator<ProductUpdateDto>, ProductUpdateDtoValidator>();

            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();
        }
    }
}