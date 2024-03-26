﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using eBrew.Cloud.Storage.DataAccess.Impl;

#nullable disable

namespace eBrew.Cloud.Storage.DataAccess.Impl.Migrations
{
    [DbContext(typeof(StorageContext))]
    partial class StorageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("eBrew.Cloud.Storage.Model.Secret", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("VaultName")
                        .HasColumnType("character varying(100)");

                    b.Property<string>("VaultUserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("VaultName", "VaultUserId");

                    b.ToTable("Secrets");
                });

            modelBuilder.Entity("eBrew.Cloud.Storage.Model.Vault", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.HasKey("Name", "UserId");

                    b.ToTable("Vaults");
                });

            modelBuilder.Entity("eBrew.Cloud.Storage.Model.Secret", b =>
                {
                    b.HasOne("eBrew.Cloud.Storage.Model.Vault", null)
                        .WithMany("Secrets")
                        .HasForeignKey("VaultName", "VaultUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eBrew.Cloud.Storage.Model.Vault", b =>
                {
                    b.Navigation("Secrets");
                });
#pragma warning restore 612, 618
        }
    }
}
