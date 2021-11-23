using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ContractManager1.Models
{
    public partial class contractContext : DbContext
    {
        public contractContext()
        {
        }

        public contractContext(DbContextOptions<contractContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContractDetail> ContractDetails { get; set; }
        public virtual DbSet<Domain> Domains { get; set; }
        public virtual DbSet<Emp> Emps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("data source=.;initial catalog=contract;integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ContractDetail>(entity =>
            {
                entity.HasKey(e => e.ContractId)
                    .HasName("PK__contract__F8D66423E97A42E3");

                entity.ToTable("contract_details");

                entity.Property(e => e.ContractId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contract_id");

                entity.Property(e => e.Amount)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("amount");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.CurrentAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("current_address");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.DescriptionDetails)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("description_details");

                entity.Property(e => e.Domain)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("domain");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.FilePath)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("file_path");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date");

                entity.Property(e => e.Project)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("project");

                entity.Property(e => e.RecordStatus)
                    .HasColumnName("record_status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StartDatee)
                    .HasColumnType("datetime")
                    .HasColumnName("start_datee");

                entity.Property(e => e.WorkLocation)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("work_location");

                entity.Property(e => e.WorkerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("worker_name");

                entity.Property(e => e.WorkerNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("worker_number");
            });

            modelBuilder.Entity<Domain>(entity =>
            {
                entity.HasKey(e => e.Alldomains)
                    .HasName("PK__Domain__7F7073DBC7DE6095");

                entity.ToTable("Domain");

                entity.Property(e => e.Alldomains)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("alldomains");
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EMP");

                entity.Property(e => e.Comm)
                    .HasColumnType("numeric(7, 2)")
                    .HasColumnName("COMM");

                entity.Property(e => e.Deptno)
                    .HasColumnType("numeric(2, 0)")
                    .HasColumnName("DEPTNO");

                entity.Property(e => e.Empno)
                    .HasColumnType("numeric(4, 0)")
                    .HasColumnName("EMPNO");

                entity.Property(e => e.Ename)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENAME");

                entity.Property(e => e.Hiredate)
                    .HasColumnType("datetime")
                    .HasColumnName("HIREDATE");

                entity.Property(e => e.Job)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("JOB");

                entity.Property(e => e.Mgr)
                    .HasColumnType("numeric(4, 0)")
                    .HasColumnName("MGR");

                entity.Property(e => e.Sal)
                    .HasColumnType("numeric(7, 2)")
                    .HasColumnName("SAL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
