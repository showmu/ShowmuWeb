using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebModels.Migrations
{
    public partial class _00 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DbVer",
                table: "Tb_Web_Com",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "DbName",
                table: "Tb_Web_Com",
                nullable: true,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "DbVer",
                table: "Tb_Web_Com",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "DbName",
                table: "Tb_Web_Com",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
