﻿// <auto-generated />
using Authentication.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Authentication.Migrations
{
    [DbContext(typeof(CadastroContext))]
    partial class AuthenticaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Authentication.Model.OriginAccess", b =>
                {
                    b.Property<int>("originAccessID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cd_origin_access");

                    b.Property<string>("originAccess")
                        .HasColumnName("ds_origin");

                    b.HasKey("originAccessID");

                    b.ToTable("tbl_Origin_Access");
                });

            modelBuilder.Entity("Authentication.Model.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cd_user_id");

                    b.Property<DateTime>("dtRegister")
                        .HasColumnName("dt_cadastro");

                    b.Property<string>("email")
                        .HasColumnName("ds_email")
                        .HasMaxLength(32);

                    b.Property<string>("firstName")
                        .HasColumnName("ds_first_name")
                        .HasMaxLength(15);

                    b.Property<int>("idFacebook")
                        .HasColumnName("cd_facebook");

                    b.Property<string>("lastName")
                        .HasColumnName("ds_last_name")
                        .HasMaxLength(15);

                    b.Property<int>("userLoginId")
                        .HasColumnName("cd_user_Login");

                    b.HasKey("userId");

                    b.HasIndex("userLoginId");

                    b.ToTable("tbl_User");
                });

            modelBuilder.Entity("Authentication.Model.UserLogin", b =>
                {
                    b.Property<int>("userLoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cd_user_login_id");

                    b.Property<int>("originAccess")
                        .HasColumnName("cd_origin_access");

                    b.Property<int?>("originAccessID");

                    b.Property<string>("password")
                        .HasColumnName("ds_password")
                        .HasMaxLength(16);

                    b.Property<string>("userName")
                        .HasColumnName("ds_username")
                        .HasMaxLength(20);

                    b.HasKey("userLoginId");

                    b.HasIndex("originAccessID");

                    b.ToTable("tbl_User_Login");
                });

            modelBuilder.Entity("Authentication.Model.User", b =>
                {
                    b.HasOne("Authentication.Model.UserLogin", "userLogin")
                        .WithMany()
                        .HasForeignKey("userLoginId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Authentication.Model.UserLogin", b =>
                {
                    b.HasOne("Authentication.Model.OriginAccess", "origin")
                        .WithMany()
                        .HasForeignKey("originAccessID");
                });
#pragma warning restore 612, 618
        }
    }
}