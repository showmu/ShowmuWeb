using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

using ShopModels.Models;

namespace ShopModels.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext() : base()
        {
           
        }
        string a = @"Server=HOME_PC;Database=Shop;Trusted_Connection=True;MultipleActiveResultSets=true";
        public ShopDbContext(string strSQL)
        {
            Test.AddUser( strSQL);
        }

        public ShopDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(a);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



            ///<summary>
            ///店面级
            /// </summary>
            builder.Entity<Address>().ToTable("Tb_ShopAddress");

        }
    }
}
