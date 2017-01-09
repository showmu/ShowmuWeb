using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ShopModels.Data;

namespace ShopModels.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    [Migration("20161230070724_updatedb")]
    partial class updatedb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShopModels.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DetailAddress");

                    b.Property<bool>("IsDefault");

                    b.Property<string>("Name");

                    b.Property<string>("OpenId");

                    b.Property<string>("Tel");

                    b.HasKey("Id");

                    b.ToTable("Tb_ShopAddress");
                });
        }
    }
}
