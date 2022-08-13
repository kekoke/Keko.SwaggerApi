using Abp.EntityFrameworkCore;
using Keko.SwaggerApi.Core.Entities;
using Keko.SwaggerApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace Keko.SwaggerApi.EntityFrameworkCore
{
    public class SwaggerApiDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...
        public virtual DbSet<TodoItem> TodoItems { set; get; }
        public virtual DbSet<Contact> Contacts { set; get; }
        public virtual DbSet<Address> Addresss { get; set; }

        public SwaggerApiDbContext(DbContextOptions<SwaggerApiDbContext> options) 
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TodoItem>();
        }
    }
}
