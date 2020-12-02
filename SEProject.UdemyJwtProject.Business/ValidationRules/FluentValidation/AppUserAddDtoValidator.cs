using FluentValidation;
using SEProject.UdemyJwtProject.Entities.Dtos.AppUserDtos;

namespace SEProject.UdemyJwtProject.Business.ValidationRules.FluentValidation
{
    class AppUserAddDtoValidator : AbstractValidator<AppUserAddDto>
    {
        public AppUserAddDtoValidator()
        {
            RuleFor(I => I.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(I => I.FullName).NotEmpty().WithMessage("Ad Soyad boş geçilemez");
        }
    }
}