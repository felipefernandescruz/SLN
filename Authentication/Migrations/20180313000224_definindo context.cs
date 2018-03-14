using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Authentication.Migrations
{
    public partial class definindocontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_User_Login_tbl_Origin_Access_cd_origin_access",
                table: "tbl_User_Login");

            migrationBuilder.DropIndex(
                name: "IX_tbl_User_Login_cd_origin_access",
                table: "tbl_User_Login");

            migrationBuilder.AddColumn<int>(
                name: "originAccessID",
                table: "tbl_User_Login",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ds_first_name",
                table: "tbl_User",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ds_email",
                table: "tbl_User",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ds_last_name",
                table: "tbl_User",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_User_Login_originAccessID",
                table: "tbl_User_Login",
                column: "originAccessID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_User_Login_tbl_Origin_Access_originAccessID",
                table: "tbl_User_Login",
                column: "originAccessID",
                principalTable: "tbl_Origin_Access",
                principalColumn: "cd_origin_access",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_User_Login_tbl_Origin_Access_originAccessID",
                table: "tbl_User_Login");

            migrationBuilder.DropIndex(
                name: "IX_tbl_User_Login_originAccessID",
                table: "tbl_User_Login");

            migrationBuilder.DropColumn(
                name: "originAccessID",
                table: "tbl_User_Login");

            migrationBuilder.AlterColumn<string>(
                name: "ds_last_name",
                table: "tbl_User",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ds_first_name",
                table: "tbl_User",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ds_email",
                table: "tbl_User",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_User_Login_cd_origin_access",
                table: "tbl_User_Login",
                column: "cd_origin_access");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_User_Login_tbl_Origin_Access_cd_origin_access",
                table: "tbl_User_Login",
                column: "cd_origin_access",
                principalTable: "tbl_Origin_Access",
                principalColumn: "cd_origin_access",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
