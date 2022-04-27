using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ListaComandos.DAL.Entities
{
    public partial class ComandosContext : DbContext
    {
        public ComandosContext()
        {
        }

        public ComandosContext(DbContextOptions<ComandosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbComando> TbComandos { get; set; }
        public virtual DbSet<TbSistema> TbSistemas { get; set; }
        public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=FELIPEDESKTOP\\SQLEXPRESS;Database=Comandos;user=sa;password=idkfa3512fmc");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<TbComando>(entity =>
            {
                entity.ToTable("tb_Comando");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comando)
                    .IsRequired()
                    .HasColumnName("comando");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_creacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdSistema).HasColumnName("id_sistema");

                entity.HasOne(d => d.IdSistemaNavigation)
                    .WithMany(p => p.TbComandos)
                    .HasForeignKey(d => d.IdSistema)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sistema");
            });

            modelBuilder.Entity<TbSistema>(entity =>
            {
                entity.ToTable("tb_Sistema");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Sistema)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sistema");
            });

            modelBuilder.Entity<TbUsuario>(entity =>
            {
                entity.ToTable("tb_Usuario");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
