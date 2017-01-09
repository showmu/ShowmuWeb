using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebModels.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_SysRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_SysRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_SysUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_SysUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "Tb_SysUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LastDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_SysUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_SysRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_SysRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_SysRoleClaims_Tb_SysRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Tb_SysRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_SysUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_SysUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_SysUserClaims_Tb_SysUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "Tb_SysUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_SysUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_SysUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_Tb_SysUserLogins_Tb_SysUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "Tb_SysUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_SysUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_SysUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_Tb_SysUserRoles_Tb_SysRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Tb_SysRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_SysUserRoles_Tb_SysUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "Tb_SysUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Web_Com",
                columns: table => new
                {
                    ComId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComName = table.Column<string>(maxLength: 50, nullable: false),
                    CreateUserId = table.Column<string>(nullable: true),
                    DbName = table.Column<decimal>(nullable: false),
                    DbVer = table.Column<decimal>(nullable: false),
                    DetailAddress = table.Column<string>(nullable: true),
                    EditDate = table.Column<DateTime>(nullable: false),
                    EditUserId = table.Column<string>(nullable: true),
                    InDate = table.Column<DateTime>(nullable: false),
                    Money = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Pid = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Web_Com", x => x.ComId);
                    table.ForeignKey(
                        name: "FK_Tb_Web_Com_Tb_SysUsers_CreateUserId",
                        column: x => x.CreateUserId,
                        principalTable: "Tb_SysUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_Web_Com_Tb_SysUsers_EditUserId",
                        column: x => x.EditUserId,
                        principalTable: "Tb_SysUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Tb_SysRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_SysRoleClaims_RoleId",
                table: "Tb_SysRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_SysUserClaims_UserId",
                table: "Tb_SysUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_SysUserLogins_UserId",
                table: "Tb_SysUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_SysUserRoles_RoleId",
                table: "Tb_SysUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Tb_SysUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Tb_SysUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Web_Com_CreateUserId",
                table: "Tb_Web_Com",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Web_Com_EditUserId",
                table: "Tb_Web_Com",
                column: "EditUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_SysRoleClaims");

            migrationBuilder.DropTable(
                name: "Tb_SysUserClaims");

            migrationBuilder.DropTable(
                name: "Tb_SysUserLogins");

            migrationBuilder.DropTable(
                name: "Tb_SysUserRoles");

            migrationBuilder.DropTable(
                name: "Tb_SysUserTokens");

            migrationBuilder.DropTable(
                name: "Tb_Web_Com");

            migrationBuilder.DropTable(
                name: "Tb_SysRoles");

            migrationBuilder.DropTable(
                name: "Tb_SysUsers");
        }
    }
}
