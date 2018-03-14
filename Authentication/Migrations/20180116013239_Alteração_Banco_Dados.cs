using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Authentication.Migrations
{
    public partial class Alteração_Banco_Dados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "login");

            migrationBuilder.DropTable(
                name: "register");

            migrationBuilder.CreateTable(
                name: "tbl_CadastroUsuario",
                columns: table => new
                {
                    cd_user_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ds_sobrenome_usuario = table.Column<string>(maxLength: 15, nullable: true),
                    dt_cadastro = table.Column<DateTime>(nullable: false),
                    ds_nome_usuario = table.Column<string>(maxLength: 15, nullable: true),
                    senha = table.Column<string>(maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_CadastroUsuario", x => x.cd_user_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_CadastroUsuario");

            migrationBuilder.CreateTable(
                name: "login",
                columns: table => new
                {
                    UserLoginId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    password = table.Column<string>(maxLength: 16, nullable: true),
                    token = table.Column<string>(nullable: true),
                    user = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_login", x => x.UserLoginId);
                });

            migrationBuilder.CreateTable(
                name: "register",
                columns: table => new
                {
                    UserRegisterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dtRegister = table.Column<DateTime>(nullable: false),
                    firstNameUser = table.Column<string>(maxLength: 15, nullable: true),
                    lastNameUser = table.Column<string>(maxLength: 15, nullable: true),
                    password = table.Column<string>(maxLength: 16, nullable: true),
                    token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_register", x => x.UserRegisterId);
                });
        }
    }
}
