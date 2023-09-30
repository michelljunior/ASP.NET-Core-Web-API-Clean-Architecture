using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ApiTeste.Domain.Entities;

namespace ApiTeste.Persistence.Entities;

public partial class BancoApiTesteContext : DbContext
{
    public BancoApiTesteContext()
    {
    }

    public BancoApiTesteContext(DbContextOptions<BancoApiTesteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblLivro> TblLivros { get; set; }

    public virtual DbSet<TblPessoaFisica> TblPessoaFisicas { get; set; }

    public virtual DbSet<TblUsuario> TblUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=bancoApiTeste;Integrated Security=True");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblLivro>(entity =>
        {
            modelBuilder.Entity<TblLivro>()
            .HasKey(l => new { l.Autor, l.Titulo });

            entity.Property(e => e.Autor)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DthDelete)
                .HasColumnType("datetime")
                .HasColumnName("DTH_Delete");
            entity.Property(e => e.DthInsert)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("DTH_Insert");
            entity.Property(e => e.DthUpdate)
                .HasColumnType("datetime")
                .HasColumnName("DTH_Update");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioIdDelete).HasColumnName("UsuarioId_Delete");
            entity.Property(e => e.UsuarioIdInsert).HasColumnName("UsuarioId_Insert");
            entity.Property(e => e.UsuarioIdUpdate).HasColumnName("UsuarioId_Update");
        });

        modelBuilder.Entity<TblPessoaFisica>(entity =>
        {
            entity.HasKey(e => e.Cpf);

            entity.ToTable("TblPessoaFisica");

            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("CPF");
            entity.Property(e => e.Celular)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.DthDelete)
                .HasColumnType("datetime")
                .HasColumnName("DTH_Delete");
            entity.Property(e => e.DthInsert)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("DTH_Insert");
            entity.Property(e => e.DthUpdate)
                .HasColumnType("datetime")
                .HasColumnName("DTH_Update");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioIdDelete).HasColumnName("UsuarioId_Delete");
            entity.Property(e => e.UsuarioIdInsert).HasColumnName("UsuarioId_Insert");
            entity.Property(e => e.UsuarioIdUpdate).HasColumnName("UsuarioId_Update");
        });

        modelBuilder.Entity<TblUsuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId);

            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("CPF");
            entity.Property(e => e.DthDelete)
                .HasColumnType("datetime")
                .HasColumnName("DTH_Delete");
            entity.Property(e => e.DthInsert)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("DTH_Insert");
            entity.Property(e => e.DthUpdate)
                .HasColumnType("datetime")
                .HasColumnName("DTH_Update");
            entity.Property(e => e.Senha)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioIdDelete).HasColumnName("UsuarioId_Delete");
            entity.Property(e => e.UsuarioIdInsert).HasColumnName("UsuarioId_Insert");
            entity.Property(e => e.UsuarioIdUpdate).HasColumnName("UsuarioId_Update");

            entity.HasOne(d => d.CpfNavigation).WithMany(p => p.TblUsuarios)
                .HasForeignKey(d => d.Cpf)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblUsuarios_TblPessoaFisica");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
