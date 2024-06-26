﻿// <auto-generated />
using ChainBlockify.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChainBlockify.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240412171648_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ChainBlockify.Domain.Blockchain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Blockchain");
                });

            modelBuilder.Entity("ChainBlockify.Domain.BlockchainBlockchainSource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BlockchainSourceId")
                        .HasColumnType("int");

                    b.Property<int>("BlockchainsId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BlockchainSourceId");

                    b.HasIndex("BlockchainsId");

                    b.ToTable("BlockchainBlockchainSource");
                });

            modelBuilder.Entity("ChainBlockify.Domain.BlockchainSource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BlockchainSource");
                });

            modelBuilder.Entity("ChainBlockify.Domain.BlockchainBlockchainSource", b =>
                {
                    b.HasOne("ChainBlockify.Domain.BlockchainSource", "BlockchainSource")
                        .WithMany()
                        .HasForeignKey("BlockchainSourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChainBlockify.Domain.Blockchain", "Blockchains")
                        .WithMany("Sources")
                        .HasForeignKey("BlockchainsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BlockchainSource");

                    b.Navigation("Blockchains");
                });

            modelBuilder.Entity("ChainBlockify.Domain.Blockchain", b =>
                {
                    b.Navigation("Sources");
                });
#pragma warning restore 612, 618
        }
    }
}
