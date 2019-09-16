﻿// <auto-generated />
using System;
using GoogleVisionApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GoogleVisionApi.Migrations
{
    [DbContext(typeof(ImageStoreContext))]
    partial class ImageStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GoogleVisionApi.Models.ImageStore", b =>
                {
                    b.Property<int>("ImageStoreId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AngerLikelihood");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("ImageBase64String");

                    b.Property<string>("JoyLikelihood");

                    b.Property<int>("PlayerId");

                    b.Property<string>("SorrowLikelihood");

                    b.Property<string>("SurpriseLikelihood");

                    b.HasKey("ImageStoreId");

                    b.HasIndex("PlayerId");

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
                    b.HasOne("GoogleVisionApi.Models.PlayerModel", "Player")
                        .WithMany("ImageList")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
