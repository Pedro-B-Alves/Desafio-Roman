using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Projeto_Roman.Domains;

#nullable disable

namespace Projeto_Roman.Contexts
{
    public partial class Roman : DbContext
    {
        public Roman()
        {
        }

        public Roman(DbContextOptions<Roman> options)
            : base(options)
        {
        }

        public virtual DbSet<Atividade> Atividades { get; set; }
        public virtual DbSet<Equipe> Equipes { get; set; }
        public virtual DbSet<Projeto> Projetos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-LFIP8ID; Initial Catalog= Roman; Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Atividade>(entity =>
            {
                entity.HasKey(e => e.IdAtividade)
                    .HasName("PK__Atividad__E6E8EAE2BD0982D2");

                entity.ToTable("Atividade");

                entity.HasIndex(e => e.Atividade1, "UQ__Atividad__72D650F37E4DD02A")
                    .IsUnique();

                entity.Property(e => e.IdAtividade).HasColumnName("idAtividade");

                entity.Property(e => e.Atividade1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("atividade");
            });

            modelBuilder.Entity<Equipe>(entity =>
            {
                entity.HasKey(e => e.IdEquipe)
                    .HasName("PK__Equipe__981ACF45A99EE8B2");

                entity.ToTable("Equipe");

                entity.HasIndex(e => e.NomeEquipe, "UQ__Equipe__253868869A1E4645")
                    .IsUnique();

                entity.Property(e => e.IdEquipe).HasColumnName("idEquipe");

                entity.Property(e => e.NomeEquipe)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeEquipe");
            });

            modelBuilder.Entity<Projeto>(entity =>
            {
                entity.HasKey(e => e.IdProjeto)
                    .HasName("PK__Projeto__8FCCED765197D24A");

                entity.ToTable("Projeto");

                entity.Property(e => e.IdProjeto).HasColumnName("idProjeto");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdAtividade).HasColumnName("idAtividade");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Projeto1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("projeto");

                entity.Property(e => e.Tema)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("tema");

                entity.HasOne(d => d.IdAtividadeNavigation)
                    .WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.IdAtividade)
                    .HasConstraintName("FK__Projeto__idAtivi__3B75D760");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Projeto__idUsuar__3A81B327");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__03006BFF14A52A6C");

                entity.ToTable("TipoUsuario");

                entity.HasIndex(e => e.TipoUsuario1, "UQ__TipoUsua__A9585C05DC15B89E")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.TipoUsuario1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("tipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A68D3250AF");

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.Email, "UQ__Usuario__AB6E616489369954")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdEquipe).HasColumnName("idEquipe");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdEquipeNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdEquipe)
                    .HasConstraintName("FK__Usuario__idEquip__37A5467C");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__idTipoU__36B12243");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
