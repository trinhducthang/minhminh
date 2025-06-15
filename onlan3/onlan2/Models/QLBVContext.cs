using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace onlan2.Models
{
    public partial class QLBVContext : DbContext
    {
        public QLBVContext()
        {
        }

        public QLBVContext(DbContextOptions<QLBVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BenhNhan> BenhNhans { get; set; } = null!;
        public virtual DbSet<HoSoBenhAn> HoSoBenhAns { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QLBV;Integrated Security=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BenhNhan>(entity =>
            {
                entity.HasKey(e => e.MaBn)
                    .HasName("PK__BenhNhan__272475ADDC84DFDF");

                entity.ToTable("BenhNhan");

                entity.Property(e => e.MaBn)
                    .ValueGeneratedNever()
                    .HasColumnName("MaBN");

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.HoTen).HasMaxLength(100);

                entity.Property(e => e.NgaySinh).HasColumnType("date");
            });

            modelBuilder.Entity<HoSoBenhAn>(entity =>
            {
                entity.HasKey(e => e.MaHsba)
                    .HasName("PK__HoSoBenh__1D20D7A7CB7CA7CB");

                entity.ToTable("HoSoBenhAn");

                entity.Property(e => e.MaHsba)
                    .ValueGeneratedNever()
                    .HasColumnName("MaHSBA");

                entity.Property(e => e.ChuanDoan).HasMaxLength(200);

                entity.Property(e => e.MaBn).HasColumnName("MaBN");

                entity.Property(e => e.NgayKham).HasColumnType("date");

                entity.HasOne(d => d.MaBnNavigation)
                    .WithMany(p => p.HoSoBenhAns)
                    .HasForeignKey(d => d.MaBn)
                    .HasConstraintName("FK_HSBA_BN");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
