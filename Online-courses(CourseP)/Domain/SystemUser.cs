using Microsoft.AspNetCore.Identity;

namespace MyCompany.Domain
{
    public class SystemUser : IdentityUser<int>
    {
        public SystemUser() : base()
        {
        }
    }
}
