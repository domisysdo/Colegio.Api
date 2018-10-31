using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Colegio.Configuration;
using Colegio.Web;

namespace Colegio.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ColegioDbContextFactory : IDesignTimeDbContextFactory<ColegioDbContext>
    {
        public ColegioDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ColegioDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ColegioDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ColegioConsts.ConnectionStringName));

            return new ColegioDbContext(builder.Options);
        }
    }
}
