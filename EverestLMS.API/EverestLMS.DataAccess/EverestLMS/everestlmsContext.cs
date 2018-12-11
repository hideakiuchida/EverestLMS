using EverestLMS.Entities.POCO;
using Microsoft.EntityFrameworkCore;

namespace EverestLMS.DataAccess
{
    //dotnet ef dbcontext scaffold "server=localhost;port=3306;user=root;password=mysql;database=everestlms" MySql.Data.EntityFrameworkCore -o ../EverestLMS.DataAccess/EverestLMS -f
    public partial class everestlmsContext : DbContext
    {
        public everestlmsContext()
        {
        }

        public everestlmsContext(DbContextOptions<everestlmsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Conocimiento> Conocimiento { get; set; }
        public virtual DbSet<ConocimientoParticipante> Conocimientoparticipante { get; set; }
        public virtual DbSet<LineaCarrera> Lineacarrera { get; set; }
        public virtual DbSet<Nivel> Nivel { get; set; }
        public virtual DbSet<Participante> Participante { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conocimiento>(entity =>
            {
                entity.HasKey(e => e.IdConocimiento);

                entity.ToTable("conocimiento", "everestlms");

                entity.Property(e => e.IdConocimiento)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ConocimientoParticipante>(entity =>
            {
                entity.HasKey(e => e.IdConocimientoParticipante);

                entity.ToTable("conocimientoparticipante", "everestlms");

                entity.HasIndex(e => e.IdConocimiento)
                    .HasName("FX_Conocimiento_idx");

                entity.HasIndex(e => e.IdParticipante)
                    .HasName("FX_Participante_idx");

                entity.Property(e => e.IdConocimientoParticipante)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdConocimiento).HasColumnType("int(11)");

                entity.Property(e => e.IdParticipante).HasColumnType("int(11)");

                entity.HasOne(d => d.IdConocimientoNavigation)
                    .WithMany(p => p.ConocimientoParticipantes)
                    .HasForeignKey(d => d.IdConocimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FX_Conocimiento");

                entity.HasOne(d => d.IdParticipanteNavigation)
                    .WithMany(p => p.ConocimientoParticipantes)
                    .HasForeignKey(d => d.IdParticipante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FX_Participante");
            });

            modelBuilder.Entity<LineaCarrera>(entity =>
            {
                entity.HasKey(e => e.IdLineaCarrera);

                entity.ToTable("lineacarrera", "everestlms");

                entity.Property(e => e.IdLineaCarrera)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Nivel>(entity =>
            {
                entity.HasKey(e => e.IdNivel);

                entity.ToTable("nivel", "everestlms");

                entity.Property(e => e.IdNivel)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Participante>(entity =>
            {
                entity.HasKey(e => e.IdParticipante);

                entity.ToTable("participante", "everestlms");

                entity.HasIndex(e => e.IdLineaCarrera)
                    .HasName("FK_LineaCarrera_idx");

                entity.HasIndex(e => e.IdNivel)
                    .HasName("FK_Nivel_idx");

                entity.HasIndex(e => e.IdParticipante)
                    .HasName("IDX_idParticipante");

                entity.HasIndex(e => e.IdSherpa)
                    .HasName("FK_Sherpa_idx");

                entity.HasIndex(e => e.Rol)
                    .HasName("IDX_idRol");

                entity.Property(e => e.IdParticipante)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Activo).HasColumnType("int(11)");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AñosExperiencia).HasColumnType("int(11)");

                entity.Property(e => e.Calificacion).HasColumnType("decimal(4,2)");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.IdLineaCarrera)
                    .HasColumnName("idLineaCarrera")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdNivel)
                    .HasColumnName("idNivel")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdSherpa)
                    .HasColumnName("idSherpa")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Sede)
                   .IsRequired()
                   .HasMaxLength(100)
                   .IsUnicode(false);

                entity.Property(e => e.Puntaje).HasColumnType("int(11)");

                entity.Property(e => e.Rol).HasColumnType("int(11)");

                entity.HasOne(d => d.IdLineaCarreraNavigation)
                    .WithMany(p => p.Participante)
                    .HasForeignKey(d => d.IdLineaCarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LineaCarrera");

                entity.HasOne(d => d.IdNivelNavigation)
                    .WithMany(p => p.Participante)
                    .HasForeignKey(d => d.IdNivel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Nivel");

                entity.HasOne(d => d.IdSherpaNavigation)
                    .WithMany(p => p.InverseIdSherpaNavigation)
                    .HasForeignKey(d => d.IdSherpa)
                    .HasConstraintName("FK_Sherpa");
            });
        }
    }
}
