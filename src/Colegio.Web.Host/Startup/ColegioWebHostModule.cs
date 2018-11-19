using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Colegio.Configuration;

namespace Colegio.Web.Host.Startup
{
    [DependsOn(
       typeof(ColegioWebCoreModule))]
    public class ColegioWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ColegioWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ColegioWebHostModule).GetAssembly());
        }
    }
}
