﻿// <auto-generated />
using System;
using IMT_Planner_DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IMT_Planner_DAL.Migrations
{
    [DbContext(typeof(IMTPlannerDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("IMT_Planner_Model.Element", b =>
                {
                    b.Property<int>("ElementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ElementId");

                    b.ToTable("Elements");

                    b.HasData(
                        new
                        {
                            ElementId = 1,
                            Name = "Nature"
                        },
                        new
                        {
                            ElementId = 2,
                            Name = "Frost"
                        },
                        new
                        {
                            ElementId = 3,
                            Name = "Flame"
                        },
                        new
                        {
                            ElementId = 4,
                            Name = "Light"
                        },
                        new
                        {
                            ElementId = 5,
                            Name = "Dark"
                        },
                        new
                        {
                            ElementId = 6,
                            Name = "Wind"
                        },
                        new
                        {
                            ElementId = 7,
                            Name = "Sand"
                        },
                        new
                        {
                            ElementId = 8,
                            Name = "Water"
                        });
                });

            modelBuilder.Entity("IMT_Planner_Model.Passive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("AttributeValue")
                        .HasColumnType("REAL");

                    b.Property<int>("PassiveAttributeNameId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PromoRequirement")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SuperManagerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PassiveAttributeNameId");

                    b.HasIndex("SuperManagerId");

                    b.ToTable("Passives");
                });

            modelBuilder.Entity("IMT_Planner_Model.PassiveAttributeName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PassiveAttributeNames");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Abbreviation = "MIF",
                            Description = "Mine Income Factor"
                        },
                        new
                        {
                            Id = 2,
                            Abbreviation = "CIF",
                            Description = "Continental Income Factor"
                        },
                        new
                        {
                            Id = 3,
                            Abbreviation = "CR",
                            Description = "Cost reduction for current shaft lvl"
                        },
                        new
                        {
                            Id = 4,
                            Abbreviation = "SUCR",
                            Description = "Shaft unlock cost reduction"
                        });
                });

            modelBuilder.Entity("IMT_Planner_Model.SuperManager", b =>
                {
                    b.Property<int>("SuperManagerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CurrentFragments")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Promoted")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Rank")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Rarity")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Unlocked")
                        .HasColumnType("INTEGER");

                    b.HasKey("SuperManagerId");

                    b.ToTable("SuperManagers");
                });

            modelBuilder.Entity("IMT_Planner_Model.SuperManagerElement", b =>
                {
                    b.Property<int>("SuperManagerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ElementId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EffectivenessType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RankRequirement")
                        .HasColumnType("INTEGER");

                    b.HasKey("SuperManagerId", "ElementId");

                    b.HasIndex("ElementId");

                    b.ToTable("SuperManagerElements");
                });

            modelBuilder.Entity("IMT_Planner_Model.Passive", b =>
                {
                    b.HasOne("IMT_Planner_Model.PassiveAttributeName", "Name")
                        .WithMany("PassiveAttributes")
                        .HasForeignKey("PassiveAttributeNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IMT_Planner_Model.SuperManager", "SuperManager")
                        .WithMany("Passives")
                        .HasForeignKey("SuperManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Name");

                    b.Navigation("SuperManager");
                });

            modelBuilder.Entity("IMT_Planner_Model.SuperManagerElement", b =>
                {
                    b.HasOne("IMT_Planner_Model.Element", "Element")
                        .WithMany("SuperManagerElements")
                        .HasForeignKey("ElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IMT_Planner_Model.SuperManager", "SuperManager")
                        .WithMany("SuperManagerElements")
                        .HasForeignKey("SuperManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Element");

                    b.Navigation("SuperManager");
                });

            modelBuilder.Entity("IMT_Planner_Model.Element", b =>
                {
                    b.Navigation("SuperManagerElements");
                });

            modelBuilder.Entity("IMT_Planner_Model.PassiveAttributeName", b =>
                {
                    b.Navigation("PassiveAttributes");
                });

            modelBuilder.Entity("IMT_Planner_Model.SuperManager", b =>
                {
                    b.Navigation("Passives");

                    b.Navigation("SuperManagerElements");
                });
#pragma warning restore 612, 618
        }
    }
}
