using CompanyTestProject.Application.DTOs.Product;
using CompanyTestProject.Application.Repositories;
using FluentValidation;

namespace CompanyTestProject.Application.Validator
{
    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductRequestDto>
    {
        private readonly IProductRepository _ProductRepository;

        public UpdateProductDtoValidator(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;

            RuleFor(c => c.ProductDto.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .MaximumLength(100)
                .WithMessage("{PropertyName} must not exceed 100 characters");

            RuleFor(c => c.ProductDto.ManufactureEmail)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("Email is not valid")
                .MaximumLength(200)
                .WithMessage("{PropertyName} must not exceed 200 characters");

            RuleFor(c => c.ProductDto.ProduceDate)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .MustAsync(async (date, token) =>
                {
                    return await _ProductRepository.IsValidDate(date.Value);
                }).WithMessage("{PropertyName} Is not valid");

            RuleFor(c => c.ProductDto.ManufacturePhone)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .MinimumLength(10)
                .WithMessage("{PropertyName} must not be less than 10 characters")
                .MaximumLength(15)
                .WithMessage("{PropertyName} must not exceed 15 characters");

            RuleFor(x => x).MustAsync((x, token) => { return IsManufatureEmailUniqe(x); })
                .WithMessage("Email is already Taken")
                .MustAsync((x, token) => { return IsProduceDateUniqe(x); })
                .WithMessage("Produce Date is Duplicated");
        }

        private async Task<bool> IsManufatureEmailUniqe(UpdateProductRequestDto r)
        {
            return await _ProductRepository.Update_IsManufatureEmailUniqe(r.ProductDto.ManufactureEmail, r.Id);
        }
        private async Task<bool> IsProduceDateUniqe(UpdateProductRequestDto r)
        {
            return await _ProductRepository.Update_IsProduceDateUniqe(r.ProductDto.ProduceDate.Value, r.Id);
        }
    }
}
