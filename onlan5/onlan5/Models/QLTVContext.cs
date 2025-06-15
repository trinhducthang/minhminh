using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace onlan5.Models
{
    public partial class QLTVContext : DbContext
    {
        public QLTVContext()
        {
        }

        public QLTVContext(DbContextOptions<QLTVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MuonSach> MuonSaches { get; set; } = null!;
        public virtual DbSet<Sach> Saches { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QLTV;Integrated Security=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MuonSach>(entity =>
            {
                entity.HasKey(e => e.MaMuon)
                    .HasName("PK__MuonSach__0A9BE5E040ABA60A");

                entity.ToTable("MuonSach");

                entity.Property(e => e.MaMuon).ValueGeneratedNever();

                entity.Property(e => e.NgayMuon).HasColumnType("date");

                entity.Property(e => e.NgayTra).HasColumnType("date");

                entity.HasOne(d => d.MaSachNavigation)
                    .WithMany(p => p.MuonSaches)
                    .HasForeignKey(d => d.MaSach)
                    .HasConstraintName("FK__MuonSach__MaSach__38996AB5");
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.HasKey(e => e.MaSach)
                    .HasName("PK__Sach__B235742D972C0A78");

                entity.ToTable("Sach");

                entity.Property(e => e.MaSach).ValueGeneratedNever();

                entity.Property(e => e.TacGia).HasMaxLength(255);

                entity.Property(e => e.TenSach).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
