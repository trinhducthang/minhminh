using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace onlan4.Models
{
    public partial class QLNSContext : DbContext
    {
        public QLNSContext()
        {
        }

        public QLNSContext(DbContextOptions<QLNSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DuAn> DuAns { get; set; } = null!;
        public virtual DbSet<NhanVien> NhanViens { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QLNS;Integrated Security=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DuAn>(entity =>
            {
                entity.HasKey(e => e.MaDa)
                    .HasName("PK__DuAn__2725867AB5B174CD");

                entity.ToTable("DuAn");

                entity.Property(e => e.MaDa)
                    .ValueGeneratedNever()
                    .HasColumnName("MaDA");

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.Property(e => e.NgayBatDau).HasColumnType("date");

                entity.Property(e => e.TenDuAn).HasMaxLength(100);

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.DuAns)
                    .HasForeignKey(d => d.MaNv)
                    .HasConstraintName("FK_DuAn_NhanVien");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNv)
                    .HasName("PK__NhanVien__2725D70AB19831F6");

                entity.ToTable("NhanVien");

                entity.Property(e => e.MaNv)
                    .ValueGeneratedNever()
                    .HasColumnName("MaNV");

                entity.Property(e => e.ChucVu).HasMaxLength(50);

                entity.Property(e => e.HoTen).HasMaxLength(100);

                entity.Property(e => e.PhongBan).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
