﻿// <auto-generated />
using DevOpsSync.WebApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DevOpsSync.WebApp.API.Migrations
{
    [DbContext(typeof(DevOpsSyncDbContext))]
    partial class DevOpsSyncDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DevOpsSync.WebApp.API.Data.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "#00aeef",
                            ImageUrl = "https://assets.ifttt.com/images/channels/2107379463/icons/monochrome_large.png",
                            Name = "GitHub"
                        },
                        new
                        {
                            Id = 2,
                            Color = "#0da778",
                            ImageUrl = "",
                            Name = "Visual Studio Team Service"
                        });
                });

            modelBuilder.Entity("DevOpsSync.WebApp.API.Data.ServiceAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("Actions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Create Issue",
                            ServiceId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sample Action 2",
                            ServiceId = 1
                        });
                });

            modelBuilder.Entity("DevOpsSync.WebApp.API.Data.ServiceTriggerAction", b =>
                {
                    b.Property<int>("TriggerId")
                        .HasColumnType("int");

                    b.Property<int>("ActionId")
                        .HasColumnType("int");

                    b.HasKey("TriggerId", "ActionId");

                    b.HasIndex("ActionId");

                    b.ToTable("ServiceTriggerAction");

                    b.HasData(
                        new
                        {
                            TriggerId = 1,
                            ActionId = 1
                        });
                });

            modelBuilder.Entity("DevOpsSync.WebApp.API.Data.Trigger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("Triggers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "When something is pushed on",
                            Name = "Push",
                            ServiceId = 1
                        });
                });

            modelBuilder.Entity("DevOpsSync.WebApp.API.Data.ServiceAction", b =>
                {
                    b.HasOne("DevOpsSync.WebApp.API.Data.Service", "Service")
                        .WithMany("Actions")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DevOpsSync.WebApp.API.Data.ServiceTriggerAction", b =>
                {
                    b.HasOne("DevOpsSync.WebApp.API.Data.ServiceAction", "ServiceAction")
                        .WithMany("ServiceTriggerActions")
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DevOpsSync.WebApp.API.Data.Trigger", "Trigger")
                        .WithMany("ServiceTriggerActions")
                        .HasForeignKey("TriggerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("DevOpsSync.WebApp.API.Data.Trigger", b =>
                {
                    b.HasOne("DevOpsSync.WebApp.API.Data.Service", "Service")
                        .WithMany("Triggers")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
