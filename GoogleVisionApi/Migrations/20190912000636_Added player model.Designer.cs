﻿// <auto-generated />
using System;
using GoogleVisionApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GoogleVisionApi.Migrations
{
    [DbContext(typeof(ImageStoreContext))]
    [Migration("20190912000636_Added player model")]
    partial class Addedplayermodel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GoogleVisionApi.Models.ImageStore", b =>
                {
                    b.Property<int>("ImageStoreId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("ImageBase64String");

                    b.Property<int?>("PlayerId1");

                    b.HasKey("ImageStoreId");

                    b.HasIndex("PlayerId1");

                    b.ToTable("ImageStore");
                });

            modelBuilder.Entity("GoogleVisionApi.Models.PlayerModel", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FunniestPictures");

                    b.Property<string>("GameStartTimeStamp");

                    b.Property<string>("PlayerName");

                    b.Property<string>("Score");

                    b.Property<bool>("Win");

                    b.HasKey("PlayerId");

                    b.ToTable("PlayerModel");
                });

            modelBuilder.Entity("GoogleVisionApi.Models.ImageStore", b =>
                {
                    b.HasOne("GoogleVisionApi.Models.PlayerModel", "PlayerId")
                        .WithMany("ImageList")
                        .HasForeignKey("PlayerId1");
                });
#pragma warning restore 612, 618
        }
    }
}