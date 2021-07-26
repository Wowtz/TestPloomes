using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TestPloomes.Model
{
    public partial class catsdb : DbContext
    {
        public catsdb()
        {
        }

        public catsdb(DbContextOptions<catsdb> options)
            : base(options)
        {
        }

        public virtual DbSet<Tblcat> Tblcats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:testeploomes.database.windows.net,1433;Initial Catalog=catsdb;Persist Security Info=False;User ID=adminploomes;Password=waltinho123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Tblcat>(entity =>
            {
                entity.Property(e => e.Cor).IsUnicode(false);

                entity.Property(e => e.NomeGato).IsUnicode(false);

                entity.Property(e => e.Raça).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
