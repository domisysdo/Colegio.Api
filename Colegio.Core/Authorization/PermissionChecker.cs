using Abp.Authorization;
using Colegio.Authorization.Roles;
using Colegio.Authorization.Users;

namespace Colegio.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
