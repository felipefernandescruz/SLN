using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Authentication.Migrations
{
    public partial class NovaestruturaDbCadastro_parte3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cd_user_Login",
                table: "tbl_User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tbl_Origin_Access",
                columns: table => new
                {
                    cd_origin_access = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ds_origin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Origin_Access", x => x.cd_origin_access);
                });

            migrationBuilder.CreateTable(
                name: "tbl_User_Login",
                columns: table => new
                {
                    cd_user_login_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cd_origin_access = table.Column<int>(nullable: false),
                    ds_password = table.Column<string>(maxLength: 16, nullable: true),
                    ds_username = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_User_Login", x => x.cd_user_login_id);
                    table.ForeignKey(
                        name: "FK_tbl_User_Login_tbl_Origin_Access_cd_origin_access",
                        column: x => x.cd_origin_access,
                        principalTable: "tbl_Origin_Access",
                        principalColumn: "cd_origin_access",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_User_cd_user_Login",
                table: "tbl_User",
                column: "cd_user_Login");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_User_Login_cd_origin_access",
                table: "tbl_User_Login",
                column: "cd_origin_access");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_User_tbl_User_Login_cd_user_Login",
                table: "tbl_User",
                column: "cd_user_Login",
                principalTable: "tbl_User_Login",
                principalColumn: "cd_user_login_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_User_tbl_User_Login_cd_user_Login",
                table: "tbl_User");

            migrationBuilder.DropTable(
                name: "tbl_User_Login");

            migrationBuilder.DropTable(
                name: "tbl_Origin_Access");

            migrationBuilder.DropIndex(
                name: "IX_tbl_User_cd_user_Login",
                table: "tbl_User");

            migrationBuilder.DropColumn(
                name: "cd_user_Login",
                table: "tbl_User");
        }
    }
}
