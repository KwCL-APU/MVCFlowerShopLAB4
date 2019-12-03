﻿// <auto-generated />
using System;
using MVCFlowerShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVCFlowerShop.Migrations
{
    [DbContext(typeof(MVCFlowerShopContext))]
    [Migration("20191203083254_Rating")]
    partial class Rating
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVCFlowerShop.Models.Flower", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FlowerName");

                    b.Property<DateTime>("FlowerProducedDate");

                    b.Property<decimal>("Price")
                        .HasColumnName("Price")
                        .HasColumnType("decimal(18,3)");

                    b.Property<string>("Rating");

                    b.Property<string>("Type");

                    b.HasKey("ID");

                    b.ToTable("Flower");
                });
#pragma warning restore 612, 618
        }
    }
}