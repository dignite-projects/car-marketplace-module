﻿// <auto-generated />
using System;
using Dignite.CarMarketplace.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Volo.Abp.EntityFrameworkCore;

#nullable disable

namespace Dignite.CarMarketplace.Migrations
{
    [DbContext(typeof(CarMarketplaceHttpApiHostMigrationsDbContext))]
    [Migration("20231204052143_add-cmskit-tag")]
    partial class addcmskittag
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("_Abp_DatabaseProvider", EfCoreDatabaseProvider.SqlServer)
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dignite.CarMarketplace.Cars.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreationTime");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CreatorId");

                    b.Property<string>("FirstLetter")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("cmpBrands", (string)null);
                });

            modelBuilder.Entity("Dignite.CarMarketplace.Cars.ConfigurationItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("cmpConfigurationItems", (string)null);
                });

            modelBuilder.Entity("Dignite.CarMarketplace.Cars.Model", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreationTime");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CreatorId");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("cmpModels", (string)null);
                });

            modelBuilder.Entity("Dignite.CarMarketplace.Cars.SaleCar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("ContactPerson")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreationTime");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CreatorId");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TenantId");

                    b.Property<float>("TotalMileage")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("cmpSaleCars", (string)null);
                });

            modelBuilder.Entity("Dignite.CarMarketplace.Cars.Trim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("ConcurrencyStamp");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreationTime");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CreatorId");

                    b.Property<string>("ExtraProperties")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ExtraProperties");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("cmpTrims", (string)null);
                });

            modelBuilder.Entity("Dignite.CarMarketplace.Cars.UsedCar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<DateTime?>("CommercialInsuranceExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CompulsoryInsuranceExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreationTime");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CreatorId");

                    b.Property<Guid>("DealerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DeleterId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("DeleterId");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletionTime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("LastModificationTime");

                    b.Property<Guid?>("LastModifierId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("LastModifierId");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModelLevel")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PowerType")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TenantId");

                    b.Property<float>("TotalMileage")
                        .HasColumnType("real");

                    b.Property<int>("TransfersCount")
                        .HasColumnType("int");

                    b.Property<string>("TransmissionType")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<Guid>("TrimId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("Color");

                    b.HasIndex("CreationTime");

                    b.HasIndex("ModelId");

                    b.HasIndex("ModelLevel");

                    b.HasIndex("PowerType");

                    b.HasIndex("Price");

                    b.HasIndex("RegistrationDate");

                    b.HasIndex("TransmissionType");

                    b.HasIndex("TrimId");

                    b.ToTable("cmpUsedCars", (string)null);
                });

            modelBuilder.Entity("Dignite.CarMarketplace.Dealers.Dealer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("AuthenticationStatus")
                        .HasColumnType("int");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("ContactPerson")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreationTime");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CreatorId");

                    b.Property<Guid?>("DeleterId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("DeleterId");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletionTime");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("LastModificationTime");

                    b.Property<Guid?>("LastModifierId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("LastModifierId");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TenantId");

                    b.HasKey("Id");

                    b.ToTable("cmpDealers", (string)null);
                });

            modelBuilder.Entity("Dignite.CarMarketplace.Dealers.DealerAdministrator", b =>
                {
                    b.Property<Guid>("DealerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TenantId");

                    b.HasKey("DealerId", "UserId");

                    b.HasIndex("DealerId");

                    b.HasIndex("UserId");

                    b.ToTable("cmpDealerAdministrators", (string)null);
                });

            modelBuilder.Entity("Dignite.CmsKit.Favourites.Favourite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreationTime");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CreatorId");

                    b.Property<string>("EntityId")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("EntityType")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TenantId", "EntityType", "EntityId", "CreatorId");

                    b.ToTable("CmsFavourites", (string)null);
                });

            modelBuilder.Entity("Dignite.CmsKit.Visits.Visit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClientIpAddress")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreationTime");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CreatorId");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("EntityId")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("EntityType")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserAgent")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("TenantId", "EntityType", "EntityId", "ClientIpAddress");

                    b.HasIndex("TenantId", "EntityType", "EntityId", "CreatorId");

                    b.ToTable("CmsVisits", (string)null);
                });

            modelBuilder.Entity("Dignite.FileExplorer.Directories.DirectoryDescriptor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("ConcurrencyStamp");

                    b.Property<string>("ContainerName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreationTime");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CreatorId");

                    b.Property<string>("ExtraProperties")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ExtraProperties");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("LastModificationTime");

                    b.Property<Guid?>("LastModifierId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("LastModifierId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TenantId");

                    b.HasKey("Id");

                    b.HasIndex("TenantId", "ContainerName", "CreatorId", "ParentId");

                    b.ToTable("FepDirectoryDescriptors", (string)null);
                });

            modelBuilder.Entity("Dignite.FileExplorer.Files.FileDescriptor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BlobName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("BlobName");

                    b.Property<string>("CellName")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("ConcurrencyStamp");

                    b.Property<string>("ContainerName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("ContainerName");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreationTime");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CreatorId");

                    b.Property<Guid?>("DeleterId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("DeleterId");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletionTime");

                    b.Property<Guid?>("DirectoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EntityId")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ExtraProperties")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ExtraProperties");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("IsDeleted");

                    b.Property<string>("Md5")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("Md5");

                    b.Property<string>("MimeType")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("MimeType");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("Name");

                    b.Property<string>("ReferBlobName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("ReferBlobName");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TenantId");

                    b.HasKey("Id");

                    b.HasIndex("TenantId", "ContainerName", "BlobName");

                    b.HasIndex("TenantId", "ContainerName", "CreationTime", "CreatorId", "DirectoryId");

                    b.ToTable("FepFileDescriptors", (string)null);
                });

            modelBuilder.Entity("Volo.CmsKit.Tags.EntityTag", b =>
                {
                    b.Property<string>("EntityId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TenantId");

                    b.HasKey("EntityId", "TagId");

                    b.HasIndex("TenantId", "EntityId", "TagId");

                    b.ToTable("CmsEntityTags", (string)null);
                });

            modelBuilder.Entity("Volo.CmsKit.Tags.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("ConcurrencyStamp");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreationTime");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CreatorId");

                    b.Property<Guid?>("DeleterId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("DeleterId");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletionTime");

                    b.Property<string>("EntityType")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("ExtraProperties")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ExtraProperties");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("LastModificationTime");

                    b.Property<Guid?>("LastModifierId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("LastModifierId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TenantId");

                    b.HasKey("Id");

                    b.HasIndex("TenantId", "Name");

                    b.ToTable("CmsTags", (string)null);
                });

            modelBuilder.Entity("Volo.CmsKit.Users.CmsUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("ConcurrencyStamp");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("Email");

                    b.Property<bool>("EmailConfirmed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("EmailConfirmed");

                    b.Property<string>("ExtraProperties")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ExtraProperties");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("Name");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)")
                        .HasColumnName("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("PhoneNumberConfirmed");

                    b.Property<string>("Surname")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("Surname");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TenantId");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("UserName");

                    b.HasKey("Id");

                    b.HasIndex("TenantId", "Email");

                    b.HasIndex("TenantId", "UserName");

                    b.ToTable("CmsUsers", (string)null);
                });

            modelBuilder.Entity("Dignite.CarMarketplace.Cars.Model", b =>
                {
                    b.HasOne("Dignite.CarMarketplace.Cars.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Dignite.CarMarketplace.Cars.SaleCar", b =>
                {
                    b.HasOne("Dignite.CarMarketplace.Cars.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Dignite.CarMarketplace.Cars.Trim", b =>
                {
                    b.HasOne("Dignite.CarMarketplace.Cars.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Dignite.CarMarketplace.Dealers.DealerAdministrator", b =>
                {
                    b.HasOne("Dignite.CarMarketplace.Dealers.Dealer", null)
                        .WithMany("Administrators")
                        .HasForeignKey("DealerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dignite.CarMarketplace.Dealers.Dealer", b =>
                {
                    b.Navigation("Administrators");
                });
#pragma warning restore 612, 618
        }
    }
}
