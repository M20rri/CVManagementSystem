using CVManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CVManagementSystem.Context
{
    public partial class CVContext : DbContext
    {
        public CVContext()
        {
        }

        public CVContext(DbContextOptions<CVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CV> CVs { get; set; }
        public virtual DbSet<ExperienceInformation> ExperienceInformations { get; set; }
        public virtual DbSet<PersonalInformation> PersonalInformations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CV>(entity =>
            {
                entity.ToTable("CV");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Experience_Information)
                    .WithMany(p => p.CVs)
                    .HasForeignKey(d => d.Experience_Information_Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CV_ExperienceInformation");

                entity.HasOne(d => d.Personal_Information)
                    .WithMany(p => p.CVs)
                    .HasForeignKey(d => d.Personal_Information_Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CV_PersonalInformation");
            });

            modelBuilder.Entity<ExperienceInformation>(entity =>
            {
                entity.ToTable("ExperienceInformation");

                entity.Property(e => e.City).HasMaxLength(225);

                entity.Property(e => e.CompanyField).HasMaxLength(225);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<PersonalInformation>(entity =>
            {
                entity.ToTable("PersonalInformation");

                entity.Property(e => e.Cityname).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
