using CompanyTestProject.Application.DTOs.Product;
using CompanyTestProject.Application.Repositories;
using FluentValidation;

namespace CompanyTestProject.Application.Validator
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductRequestDto>
    {
        private readonly IProductRepository _ProductRepository;

        public CreateProductDtoValidator(IProductRepository productRepository)
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
                .WithMessage("{PropertyName} must not exceed 200 characters")
                .MustAsync(async (email, token) =>
                {
                    return await _ProductRepository.IsManufatureEmailUniqe(email);
                }).WithMessage("This {PropertyName} already exist");

            RuleFor(c => c.ProductDto.ProduceDate)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .MustAsync(async (date, token) =>
                {
                    return await _ProductRepository.IsValidDate(date.Value);
                }).WithMessage("{PropertyName} Is not valid")
                .MustAsync(async (date, token) =>
                {
                    return await _ProductRepository.IsProduceDateUniqe(date.Value);
                }).WithMessage("This {PropertyName} already exist");

            RuleFor(c => c.ProductDto.ManufacturePhone)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .MinimumLength(10)
                .WithMessage("{PropertyName} must not be less than 10 characters")
                .MaximumLength(15)
                .WithMessage("{PropertyName} must not exceed 15 characters");
        }
    }
}
