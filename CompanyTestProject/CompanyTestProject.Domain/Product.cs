using System.ComponentModel.DataAnnotations;

namespace CompanyTestProject.Domain
{
    public class Product : Base
    {
        [MaxLength(100)]
        public required string Name { get; set; }

        [EmailAddress]
        [MaxLength(200)]
        public string? ManufactureEmail { get; set; }

        [MaxLength(15)]
        public string? ManufacturePhone { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ProduceDate { get; set; }

        public bool IsAvailable { get; set; }

        #region Relations

        public virtual ICollection<UserProduct> UserProducts { get; set; } = null!;

        #endregion
    }
}
