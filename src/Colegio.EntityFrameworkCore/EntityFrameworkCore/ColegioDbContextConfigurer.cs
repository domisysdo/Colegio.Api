using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Colegio.EntityFrameworkCore
{
    public static class ColegioDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ColegioDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ColegioDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
