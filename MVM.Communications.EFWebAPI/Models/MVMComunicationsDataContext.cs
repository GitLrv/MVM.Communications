using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MVM.Communications.EFWebAPI.Models
{
    public partial class MVMComunicationsDataContext : DbContext
    {
        public MVMComunicationsDataContext()
        {
        }

        public MVMComunicationsDataContext(DbContextOptions<MVMComunicationsDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConsecutiveControl> ConsecutiveControls { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactType> ContactTypes { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Digitalization> Digitalizations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<MediaType> MediaTypes { get; set; }
        public virtual DbSet<MsgContact> MsgContacts { get; set; }
        public virtual DbSet<MsgRecord> MsgRecords { get; set; }
        public virtual DbSet<MsgStatus> MsgStatuses { get; set; }
        public virtual DbSet<MsgType> MsgTypes { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=AE2020\\DATASQL;Database=MVMComunicationsData;Persist Security Info=True;User ID=sa;Password=data2021;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ConsecutiveControl>(entity =>
            {
                entity.ToTable("ConsecutiveControl");

                entity.Property(e => e.ConsecutiveLength).HasColumnName("Consecutive_Length");

                entity.Property(e => e.DateControl)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_Control")
                    .HasComment("The last number asignated");

                entity.Property(e => e.Prefix)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.MsgType)
                    .WithMany(p => p.ConsecutiveControls)
                    .HasForeignKey(d => d.MsgTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConsecutiveControl_MsgType");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.FirsName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Mobil).HasMaxLength(20);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contacts_Employee1");
            });

            modelBuilder.Entity<ContactType>(entity =>
            {
                entity.ToTable("ContactType");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Department_Organization");
            });

            modelBuilder.Entity<Digitalization>(entity =>
            {
                entity.ToTable("Digitalization");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_Create");

                entity.Property(e => e.ResourcePath).HasMaxLength(500);

                entity.HasOne(d => d.MediaType)
                    .WithMany(p => p.Digitalizations)
                    .HasForeignKey(d => d.MediaTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Digitalization_MediaType");

                entity.HasOne(d => d.MsgRecordSecNavigation)
                    .WithMany(p => p.Digitalizations)
                    .HasPrincipalKey(p => p.Sec)
                    .HasForeignKey(d => d.MsgRecordSec)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Digitalization_MsgRecord");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Department");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Profile");
            });

            modelBuilder.Entity<MediaType>(entity =>
            {
                entity.ToTable("MediaType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MsgContact>(entity =>
            {
                entity.ToTable("MsgContact");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.MsgContacts)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MsgContact_Contacts");

                entity.HasOne(d => d.ContactType)
                    .WithMany(p => p.MsgContacts)
                    .HasForeignKey(d => d.ContactTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MsgContact_ContactType");

                entity.HasOne(d => d.MsgRecordSecNavigation)
                    .WithMany(p => p.MsgContacts)
                    .HasPrincipalKey(p => p.Sec)
                    .HasForeignKey(d => d.MsgRecordSec)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MsgContact_MsgRecord");
            });

            modelBuilder.Entity<MsgRecord>(entity =>
            {
                entity.ToTable("MsgRecord");

                //entity.HasIndex(e => e.Sec, "UC_MsgRecord")
                //   .IsUnique();

                entity.Property(e => e.DeliveredDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Delivered_Date");

                entity.Property(e => e.Digitalization).HasComment("Determina si la comunicación ya fue digitalizada.");

                entity.Property(e => e.MsgTypeId).HasComment("Communication Type");

                entity.Property(e => e.Prefix)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ReceivedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Received_Date");

                entity.HasOne(d => d.DocManagerContact)
                    .WithMany(p => p.MsgRecords)
                    .HasForeignKey(d => d.DocManagerContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MsgRecord_Contacts");

                entity.HasOne(d => d.MsgStatus)
                    .WithMany(p => p.MsgRecords)
                    .HasForeignKey(d => d.MsgStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MsgRecord_MsgStatus");

                entity.HasOne(d => d.MsgType)
                    .WithMany(p => p.MsgRecords)
                    .HasForeignKey(d => d.MsgTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MsgRecord_MsgType");
            });

            modelBuilder.Entity<MsgStatus>(entity =>
            {
                entity.ToTable("MsgStatus");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MsgType>(entity =>
            {
                entity.ToTable("MsgType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("Organization");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("Profile");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
