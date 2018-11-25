using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Colegio.Authorization;
using Colegio.Models.Inscripcion.EstudianteNs;

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

            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                cfg.AddProfiles(thisAssembly);
            });
        }
    }
}
