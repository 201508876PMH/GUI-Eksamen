﻿// <auto-generated />
using EksamenAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EksamenAPI.Migrations
{
    [DbContext(typeof(ModelContext))]
    [Migration("20190103102659_InitialSchema")]
    partial class InitialSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EksamenAPI.Models.Model", b =>
                {
                    b.Property<int>("ModelId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Comments");

                    b.Property<string>("HairColor");

                    b.Property<int>("Height");

                    b.Property<string>("Name");

                    b.Property<int>("TelephoneNumber");

                    b.Property<int>("Weight");

                    b.HasKey("ModelId");

                    b.ToTable("Models");
                });
#pragma warning restore 612, 618
        }
    }
}