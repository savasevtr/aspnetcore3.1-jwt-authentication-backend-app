using AutoMapper;
using SEProject.UdemyJwtProject.Entities.Concrete;
using SEProject.UdemyJwtProject.Entities.Dtos.AppUserDtos;
using SEProject.UdemyJwtProject.Entities.Dtos.ProductDtos;

namespace SEProject.UdemyJwtProject.WebApi.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ProductAddDto, Product>();
            CreateMap<Product, ProductAddDto>();

            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductUpdateDto>();

            CreateMap<AppUserAddDto, AppUser>();
            CreateMap<AppUser, AppUserAddDto>();
        }
    }
}