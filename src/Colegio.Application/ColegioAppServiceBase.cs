using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Colegio.Authorization.Users;
using Colegio.MultiTenancy;

namespace Colegio
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class ColegioAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected ColegioAppServiceBase()
        {
            LocalizationSourceName = ColegioConsts.LocalizationSourceName;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
