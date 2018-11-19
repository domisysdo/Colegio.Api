using Abp.Localization;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using Colegio.Authorization.Roles;
using Colegio.Authorization.Users;
using Colegio.Configuration;
using Colegio.Localization;
using Colegio.MultiTenancy;
using Colegio.Timing;

namespace Colegio
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class ColegioCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            Configuration.Localization.IsEnabled = true;
            Configuration.Localization.WrapGivenTextIfNotFound = false;
            Configuration.Localization.Languages.Add(new LanguageInfo("es", "Español México", "famfamfam-flags mx", true));
            ColegioLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = ColegioConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ColegioCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
