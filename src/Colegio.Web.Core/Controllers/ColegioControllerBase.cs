using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Colegio.Controllers
{
    public abstract class ColegioControllerBase: AbpController
    {
        protected ColegioControllerBase()
        {
            LocalizationSourceName = ColegioConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
