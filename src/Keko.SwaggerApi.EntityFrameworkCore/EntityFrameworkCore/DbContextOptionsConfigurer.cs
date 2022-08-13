using Microsoft.EntityFrameworkCore;

namespace Keko.SwaggerApi.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<SwaggerApiDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for SwaggerApiDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
