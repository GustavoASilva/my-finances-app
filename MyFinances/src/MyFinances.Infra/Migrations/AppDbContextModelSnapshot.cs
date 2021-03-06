// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyFinances.Infra;

#nullable disable

namespace MyFinances.Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MyFinances.Core.SyncedAggregates.Origin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("HouseholdId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Origins");
                });

            modelBuilder.Entity("MyFinances.Core.SyncedAggregates.Recurrence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("DaysInterval")
                        .HasColumnType("int");

                    b.Property<DateOnly>("End")
                        .HasColumnType("date");

                    b.Property<int>("HouseholdId")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("LatestOccurrence")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("NextOccurrence")
                        .HasColumnType("date");

                    b.Property<int>("OriginId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Start")
                        .HasColumnType("date");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("_transactionCategoryId")
                        .HasColumnType("int")
                        .HasColumnName("TransactionCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("_transactionCategoryId");

                    b.ToTable("Recurrences");
                });

            modelBuilder.Entity("MyFinances.Core.SyncedAggregates.TransactionCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TransactionCategory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mercado"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Refeição"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Pets"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Outros"
                        });
                });

            modelBuilder.Entity("MyFinances.Core.TransactionAggregate.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("ConfirmedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("EstimatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("HouseholdId")
                        .HasColumnType("int");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("OriginId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("_categoryId")
                        .HasColumnType("int")
                        .HasColumnName("TransactionCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("OriginId");

                    b.HasIndex("_categoryId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("MyFinances.Core.SyncedAggregates.Recurrence", b =>
                {
                    b.HasOne("MyFinances.Core.SyncedAggregates.TransactionCategory", "TransactionCategory")
                        .WithMany()
                        .HasForeignKey("_transactionCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TransactionCategory");
                });

            modelBuilder.Entity("MyFinances.Core.TransactionAggregate.Transaction", b =>
                {
                    b.HasOne("MyFinances.Core.SyncedAggregates.Origin", null)
                        .WithMany()
                        .HasForeignKey("OriginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyFinances.Core.SyncedAggregates.TransactionCategory", "Category")
                        .WithMany()
                        .HasForeignKey("_categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
