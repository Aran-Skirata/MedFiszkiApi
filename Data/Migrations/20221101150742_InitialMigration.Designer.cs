// <auto-generated />
using MedFiszkiApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MedFiszkiApi.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221101150742_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("MedFiszkiApi.Entities.AnatomyTranslation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("InEnglish")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("InPolish")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PartId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PartId");

                    b.ToTable("AnatomyTranslations");
                });

            modelBuilder.Entity("MedFiszkiApi.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MedFiszkiApi.Entities.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PartName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("MedFiszkiApi.Entities.AnatomyTranslation", b =>
                {
                    b.HasOne("MedFiszkiApi.Entities.Category", "Category")
                        .WithMany("AnatomyTranslations")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedFiszkiApi.Entities.Part", "Part")
                        .WithMany("AnatomyTranslations")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Part");
                });

            modelBuilder.Entity("MedFiszkiApi.Entities.Category", b =>
                {
                    b.Navigation("AnatomyTranslations");
                });

            modelBuilder.Entity("MedFiszkiApi.Entities.Part", b =>
                {
                    b.Navigation("AnatomyTranslations");
                });
#pragma warning restore 612, 618
        }
    }
}
