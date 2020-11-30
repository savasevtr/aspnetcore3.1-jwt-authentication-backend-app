using FluentValidation;
using SEProject.UdemyJwtProject.Entities.Dtos.ProductDtos;

namespace SEProject.UdemyJwtProject.Business.ValidationRules.FluentValidation
{
    public class ProductAddDtoValidator : AbstractValidator<ProductAddDto>
    {
        public ProductAddDtoValidator()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");
        }
    }
}