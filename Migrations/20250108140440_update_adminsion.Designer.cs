﻿// <auto-generated />
using BeApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250108140440_update_adminsion")]
    partial class update_adminsion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BeApi.Models.Admission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdmissionProfileCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AvatarPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BirthCertificatePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CitizenIdentificationCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CitizenIdentificationCardAfterPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CitizenIdentificationCardBeforPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HealthInsuranceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMatriculated")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSendMail")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PermanentAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admission");
                });

            modelBuilder.Entity("BeApi.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FacultyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MajorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Faculty");
                });

            modelBuilder.Entity("BeApi.Models.FileImport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfFalseRecords")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfRecords")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FileImport");
                });

            modelBuilder.Entity("BeApi.Models.Major", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MajorName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Major");
                });

            modelBuilder.Entity("BeApi.Models.StudentClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClassName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FacultyId")
                        .HasColumnType("int");

                    b.Property<int>("MajorId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("StudentClass");
                });

            modelBuilder.Entity("BeApi.Models.StudentProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdmissionYear")
                        .HasColumnType("int");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CitizenIdentificationCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FacultyId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HealthInsuranceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MajorId")
                        .HasColumnType("int");

                    b.Property<string>("PermanentAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentClassId")
                        .HasColumnType("int");

                    b.Property<string>("StudentCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.HasIndex("MajorId");

                    b.HasIndex("StudentClassId");

                    b.HasIndex("UserId");

                    b.ToTable("StudentProfile");
                });

            modelBuilder.Entity("BeApi.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BeApi.Models.StudentProfile", b =>
                {
                    b.HasOne("BeApi.Models.Faculty", "Faculty")
                        .WithMany("StudentProfiles")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeApi.Models.Major", "Major")
                        .WithMany("StudentProfiles")
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeApi.Models.StudentClass", "StudentClass")
                        .WithMany("StudentProfiles")
                        .HasForeignKey("StudentClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeApi.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");

                    b.Navigation("Major");

                    b.Navigation("StudentClass");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("BeApi.Models.Faculty", b =>
                {
                    b.Navigation("StudentProfiles");
                });

            modelBuilder.Entity("BeApi.Models.Major", b =>
                {
                    b.Navigation("StudentProfiles");
                });

            modelBuilder.Entity("BeApi.Models.StudentClass", b =>
                {
                    b.Navigation("StudentProfiles");
                });
#pragma warning restore 612, 618
        }
    }
}
