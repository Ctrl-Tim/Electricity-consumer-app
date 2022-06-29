﻿// <auto-generated />
using System;
using ElectricityConsumerDatabaseImplement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ElectricityConsumerDatabaseImplement.Migrations
{
    [DbContext(typeof(ElectricityConsumerDatabase))]
    partial class ElectricityConsumerDatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ElectricityConsumerDatabaseImplement.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConsumerId")
                        .HasColumnType("int");

                    b.Property<int>("Flat")
                        .HasColumnType("int");

                    b.Property<int>("House")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConsumerId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("ElectricityConsumerDatabaseImplement.Models.Consumer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Consumers");
                });

            modelBuilder.Entity("ElectricityConsumerDatabaseImplement.Models.CounterReadings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("BeginningOfMonth")
                        .HasColumnType("real");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ElectricMeterId")
                        .HasColumnType("int");

                    b.Property<float>("EndOfMonth")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ElectricMeterId");

                    b.ToTable("CounterReadingss");
                });

            modelBuilder.Entity("ElectricityConsumerDatabaseImplement.Models.ElectricMeter", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfCheck")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FinalInspection")
                        .HasColumnType("datetime2");

                    b.Property<int>("InspectionPeriod")
                        .HasColumnType("int");

                    b.Property<decimal>("Number")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("ElectricMeters");
                });

            modelBuilder.Entity("ElectricityConsumerDatabaseImplement.Models.TypeElectricMeter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("ElectricityConsumerDatabaseImplement.Models.Address", b =>
                {
                    b.HasOne("ElectricityConsumerDatabaseImplement.Models.Consumer", "Consumer")
                        .WithMany("Addresses")
                        .HasForeignKey("ConsumerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consumer");
                });

            modelBuilder.Entity("ElectricityConsumerDatabaseImplement.Models.CounterReadings", b =>
                {
                    b.HasOne("ElectricityConsumerDatabaseImplement.Models.ElectricMeter", "ElectricMeter")
                        .WithMany("CounterReadingss")
                        .HasForeignKey("ElectricMeterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ElectricMeter");
                });

            modelBuilder.Entity("ElectricityConsumerDatabaseImplement.Models.ElectricMeter", b =>
                {
                    b.HasOne("ElectricityConsumerDatabaseImplement.Models.Address", "Address")
                        .WithOne("ElectricMeter")
                        .HasForeignKey("ElectricityConsumerDatabaseImplement.Models.ElectricMeter", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectricityConsumerDatabaseImplement.Models.TypeElectricMeter", "Type")
                        .WithMany("ElectricMeters")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("ElectricityConsumerDatabaseImplement.Models.Address", b =>
                {
                    b.Navigation("ElectricMeter");
                });

            modelBuilder.Entity("ElectricityConsumerDatabaseImplement.Models.Consumer", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("ElectricityConsumerDatabaseImplement.Models.ElectricMeter", b =>
                {
                    b.Navigation("CounterReadingss");
                });

            modelBuilder.Entity("ElectricityConsumerDatabaseImplement.Models.TypeElectricMeter", b =>
                {
                    b.Navigation("ElectricMeters");
                });
#pragma warning restore 612, 618
        }
    }
}
