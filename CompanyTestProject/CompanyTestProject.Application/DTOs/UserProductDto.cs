namespace CompanyTestProject.Application.DTOs
{
    public class UserProductDto : BaseDto
    {
        public required string UserId { get; set; }

        public required int ProductId { get; set; }
    }
}
