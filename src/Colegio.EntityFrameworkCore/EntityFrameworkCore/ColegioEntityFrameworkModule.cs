using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using Colegio.EntityFrameworkCore.Seed;

namespace Colegio.EntityFrameworkCore
{
    [DependsOn(
        typeof(ColegioCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class ColegioEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<ColegioDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        ColegioDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        ColegioDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ColegioEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
