using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Authentication.Migrations
{
    public partial class atualizacaoestruturabancodedadosDbCadastro2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_User_Login_tbl_Origin_Access_cd_origin_access",
                table: "tbl_User_Login");

            migrationBuilder.DropIndex(
                name: "IX_tbl_User_Login_cd_origin_access",
                table: "tbl_User_Login");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_User_Login_tbl_Origin_Access_cd_origin_access",
                table: "tbl_User_Login");

            migrationBuilder.DropIndex(
                name: "IX_tbl_User_Login_cd_origin_access",
                table: "tbl_User_Login");

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
