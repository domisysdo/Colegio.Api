using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Colegio.Authorization;

namespace Colegio
{
    [DependsOn(
        typeof(ColegioCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ColegioApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ColegioAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ColegioApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
