using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DbFirstEg.Model
{
    public partial class ARONContext : DbContext
    {
        public ARONContext()
        {
        }

        public ARONContext(DbContextOptions<ARONContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<V1> V1s { get; set; }
        public virtual DbSet<V2> V2s { get; set; }
        public virtual DbSet<V3> V3s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=CIWE-MTP-SQL1;Database=ARON;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Did)
                    .HasName("PK__Departme__D877D2161B5C7F48");

                entity.HasIndex(e => e.Dname, "UQ__Departme__6B0C41ADA264E25C")
                    .IsUnique();

                entity.Property(e => e.Did).HasColumnName("did");

                entity.Property(e => e.Dname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("dname");

                entity.Property(e => e.Location)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("location");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Empid)
                    .HasName("PK__Employee__AF2EBFA16878666B");

                entity.ToTable("Employee");

                entity.Property(e => e.Empid).ValueGeneratedNever();

                entity.Property(e => e.Deptid).HasColumnName("deptid");

                entity.Property(e => e.Doj).HasColumnType("date");

                entity.Property(e => e.Empname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Manager).HasColumnName("manager");

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Deptid)
                    .HasConstraintName("FK__Employee__deptid__21B6055D");
            });

            modelBuilder.Entity<V1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V1");

                entity.Property(e => e.Empid).HasColumnName("EMPID");

                entity.Property(e => e.Empname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMPNAME");

                entity.Property(e => e.Salary).HasColumnName("SALARY");
            });

            modelBuilder.Entity<V2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V2");

                entity.Property(e => e.Dname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNAME");

                entity.Property(e => e.Empid).HasColumnName("EMPID");

                entity.Property(e => e.Empname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMPNAME");
            });

            modelBuilder.Entity<V3>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V3");

                entity.Property(e => e.Cc)
                    .IsRequired()
                    .HasMaxLength(63)
                    .IsUnicode(false)
                    .HasColumnName("CC");

                entity.Property(e => e.Empid).HasColumnName("EMPID");

                entity.Property(e => e.Empname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMPNAME");

                entity.Property(e => e.Salary).HasColumnName("SALARY");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
