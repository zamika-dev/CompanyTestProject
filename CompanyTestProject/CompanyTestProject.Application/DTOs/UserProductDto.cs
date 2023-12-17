namespace CompanyTestProject.Application.DTOs
{
    internal class UserProductDto : BaseDto
    {
        public required string UserId { get; set; }

        public required int ProductId { get; set; }
    }
}
