using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ShoppingList.Entities;

namespace ShoppingList.Migrations
{
    [DbContext(typeof(ShoppingListContext))]
    [Migration("20171114141844_InitalCreate")]
    partial class InitalCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.3");

            modelBuilder.Entity("ShoppingList.Models.Item", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("ItemName");

                    b.Property<int>("Quantity");

                    b.Property<DateTime>("Time");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });
        }
    }
}
