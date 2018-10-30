using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using Colegio.Authorization.Roles;
using Colegio.Authorization.Users;
using Colegio.MultiTenancy;

namespace Colegio.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options, 
            SignInManager signInManager,
            ISystemClock systemClock) 
            : base(
                  options, 
                  signInManager, 
                  systemClock)
        {
        }
    }
}
