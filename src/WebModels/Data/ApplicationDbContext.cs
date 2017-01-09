using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebModels.Models;
using Microsoft.EntityFrameworkCore;

namespace WebModels.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ///<summary>
            ///系统级
            /// </summary>
            builder.Entity<ApplicationUser>().ToTable("Tb_SysUsers");
            builder.Entity<ApplicationUser>().Property(b => b.LastDate)
                .ValueGeneratedOnAddOrUpdate();
            builder.Entity<ApplicationUser>()
                 .Property(b => b.LastDate)
                 .HasDefaultValueSql("getdate()");

            builder.Entity<IdentityRole>().ToTable("Tb_SysRoles");
            builder.Entity<IdentityUserRole<string>>().ToTable("Tb_SysUserRoles");
            builder.Entity<IdentityUserToken<string >>().ToTable("Tb_SysUserTokens");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("Tb_SysRoleClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("Tb_SysUserLogins");
            builder.Entity<IdentityUserClaim<string>>().ToTable("Tb_SysUserClaims");
            ///<summary>
            ///公司级
            /// </summary>
            /// 

            builder.Entity<Web_Com>().ToTable("Tb_Web_Com");
          

          
            
        }
    }
}
