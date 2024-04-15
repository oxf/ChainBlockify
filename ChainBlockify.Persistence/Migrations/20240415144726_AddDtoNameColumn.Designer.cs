﻿// <auto-generated />
using System;
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
    [Migration("20240415144726_AddDtoNameColumn")]
    partial class AddDtoNameColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ChainBlockify.Domain.Entities.Blockchain", b =>
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

            modelBuilder.Entity("ChainBlockify.Domain.Entities.BlockchainBlockchainSource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BlockchainSourceId")
                        .HasColumnType("int");

                    b.Property<int>("BlockchainsId")
                        .HasColumnType("int");

                    b.Property<string>("DtoName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BlockchainSourceId");

                    b.HasIndex("BlockchainsId");

                    b.ToTable("BlockchainBlockchainSource");
                });

            modelBuilder.Entity("ChainBlockify.Domain.Entities.BlockchainInfoBtc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("HighFeePerKB")
                        .HasColumnType("int");

                    b.Property<string>("LastForkHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LastForkHeight")
                        .HasColumnType("int");

                    b.Property<string>("LatestUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LowFeePerKB")
                        .HasColumnType("int");

                    b.Property<int>("MediumFeePerKB")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PeerCount")
                        .HasColumnType("int");

                    b.Property<string>("PreviousHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreviousUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("UnconfirmedCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BlockchainInfoBtcDbSet");
                });

            modelBuilder.Entity("ChainBlockify.Domain.Entities.BlockchainInfoDash", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("HighFeePerKB")
                        .HasColumnType("int");

                    b.Property<string>("LastForkHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LastForkHeight")
                        .HasColumnType("int");

                    b.Property<string>("LatestUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LowFeePerKB")
                        .HasColumnType("int");

                    b.Property<int>("MediumFeePerKB")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PeerCount")
                        .HasColumnType("int");

                    b.Property<string>("PreviousHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreviousUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("UnconfirmedCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BlockchainInfoDash");
                });

            modelBuilder.Entity("ChainBlockify.Domain.Entities.BlockchainInfoEth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("BaseFee")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<long>("HighGasPrice")
                        .HasColumnType("bigint");

                    b.Property<long>("HighPriorityFee")
                        .HasColumnType("bigint");

                    b.Property<string>("LastForkHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LastForkHeight")
                        .HasColumnType("int");

                    b.Property<string>("LatestUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("LowGasPrice")
                        .HasColumnType("bigint");

                    b.Property<long>("LowPriorityFee")
                        .HasColumnType("bigint");

                    b.Property<long>("MediumGasPrice")
                        .HasColumnType("bigint");

                    b.Property<long>("MediumPriorityFee")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PeerCount")
                        .HasColumnType("int");

                    b.Property<string>("PreviousHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreviousUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("UnconfirmedCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BlockchainInfoEth");
                });

            modelBuilder.Entity("ChainBlockify.Domain.Entities.BlockchainSource", b =>
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

            modelBuilder.Entity("ChainBlockify.Domain.Entities.BlockchainBlockchainSource", b =>
                {
                    b.HasOne("ChainBlockify.Domain.Entities.BlockchainSource", "BlockchainSource")
                        .WithMany()
                        .HasForeignKey("BlockchainSourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChainBlockify.Domain.Entities.Blockchain", "Blockchains")
                        .WithMany("Sources")
                        .HasForeignKey("BlockchainsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BlockchainSource");

                    b.Navigation("Blockchains");
                });

            modelBuilder.Entity("ChainBlockify.Domain.Entities.Blockchain", b =>
                {
                    b.Navigation("Sources");
                });
#pragma warning restore 612, 618
        }
    }
}
