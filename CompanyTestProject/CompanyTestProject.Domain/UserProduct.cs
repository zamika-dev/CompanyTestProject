using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyTestProject.Domain
{
    public class UserProduct : Base
    {
        [ForeignKey("User")]
        public required string UserId { get; set; }

        [ForeignKey("Product")]
        public required int ProductId { get; set; }

        #region Relations

        public virtual Product Product { get; set; } = null!;
        public virtual User User { get; set; } = null!;

        #endregion
    }
}
