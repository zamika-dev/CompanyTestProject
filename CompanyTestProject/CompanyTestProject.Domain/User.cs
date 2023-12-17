using Microsoft.AspNetCore.Identity;

namespace CompanyTestProject.Domain
{
    public class User : IdentityUser
    {
        #region Relations

        public virtual ICollection<UserProduct> UserProducts { get; set; } = null!;

        #endregion
    }
}
