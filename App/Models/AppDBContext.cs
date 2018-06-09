using App.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class AppDBContext : DbContext
    {
        //Realização do set das classes para serem acessível pelo contexto nas demais camadas da aplicação
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<TipoUsuarios> TipoUsuarios { get; set; }
        public virtual DbSet<UsuarioPermissoes> UsuarioPermissoes { get; set; }
        public virtual DbSet<Permissoes> Permissoes { get; set; }
        public virtual DbSet<Empresas> Empresas { get; set; }
        public virtual DbSet<Compras> Compras { get; set; }
        public virtual DbSet<Fornecedores> Fornecedores { get; set; }
        public virtual DbSet<CompraProdutos> CompraProdutos { get; set; }
        public virtual DbSet<Produtos> Produtos { get; set; }
        public virtual DbSet<Prateleiras> Prateleiras { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<TipoProdutos> TipoProdutos { get; set; }
        public virtual DbSet<ProdutosOrdens> ProdutosOrdens { get; set; }
        public virtual DbSet<OrdemServicos> OrdemServicos { get; set; }
        public virtual DbSet<TipoOrdemServicos> TipoOrdemServicos { get; set; }
        public virtual DbSet<LogOrdens> LogOrdens { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        //Mapeamento e especificações das propriedades das models
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>(builder => 
            {
                builder.HasKey(c => c.UsuarioId);

                builder.HasOne(c => c.TipoUsuario)
                    .WithMany(c => c.Usuarios)
                    .HasForeignKey(c => c.TipoUsuarioId)
                    .IsRequired();

                builder.HasOne(c => c.Empresa)
                    .WithMany(c => c.Usuarios)
                    .HasForeignKey(c => c.EmpresaId)
                    .IsRequired();

                builder.Property(c => c.Nome).HasMaxLength(150).IsRequired();

                builder.Property(c => c.Matricula).HasMaxLength(5).IsRequired();

                builder.Property(c => c.Senha).HasMaxLength(15).IsRequired();

                builder.Property(c => c.Email).HasMaxLength(50).IsRequired();

                builder.Property(c => c.DataCad).HasDefaultValue(DateTime.Now);

                builder.Property(c => c.Ativo).HasDefaultValue(true);
            });

            modelBuilder.Entity<TipoUsuarios>(builder =>
            {
                builder.HasKey(c => c.TipoUsarioId);

                builder.Property(c => c.Tipo).HasMaxLength(50).IsRequired();

                builder.Property(c => c.Ativo).HasDefaultValue(true);
            });

            modelBuilder.Entity<UsuarioPermissoes>(builder =>
            {
                builder.HasKey(c => c.UsuarioPermissaoId);

                builder.HasOne(c => c.Permissao)
                    .WithMany(c => c.UsuarioPermissoes)
                    .HasForeignKey(c => c.PermissaoId)
                    .IsRequired();

                builder.HasOne(c => c.TipoUsuario)
                    .WithMany(c => c.UsuarioPermissoes)
                    .HasForeignKey(c => c.TipoUsuarioId)
                    .IsRequired();
            });

            modelBuilder.Entity<Permissoes>(builder =>
            {
                builder.HasKey(c => c.PermissaoId);

                builder.Property(c => c.Permissao).HasMaxLength(50).IsRequired();

                builder.Property(c => c.Ativo).HasDefaultValue(true);
            });

            modelBuilder.Entity<Empresas>(builder =>
            {
                builder.HasKey(c => c.EmpresaId);

                builder.Property(c => c.Empresa).HasMaxLength(100).IsRequired();

                builder.Property(c => c.Cidade).HasMaxLength(50).IsRequired();

                builder.Property(c => c.Descricao).HasMaxLength(200).IsRequired();

                builder.Property(c => c.Ativo).HasDefaultValue(true);
            });

            modelBuilder.Entity<Compras>(builder =>
            {
                builder.HasKey(c => c.CompraId);

                builder.HasOne(c => c.Empresa)
                    .WithMany(c => c.Compras)
                    .HasForeignKey(c => c.EmpresaId)
                    .IsRequired();

                builder.HasOne(c => c.Fornecedor)
                    .WithMany(c => c.Compras)
                    .HasForeignKey(c => c.FornecedorId)
                    .IsRequired();

                builder.Property(c => c.DataCompra).HasDefaultValue(DateTime.Now);

                builder.Property(c => c.Total).HasMaxLength(10).IsRequired();
            });

            modelBuilder.Entity<Fornecedores>(builder =>
            {
                builder.HasKey(c => c.FornecedorId);

                builder.Property(c => c.Endereco).HasMaxLength(100).IsRequired();

                builder.Property(c => c.Telefone).HasMaxLength(16).IsRequired();

                builder.Property(c => c.Fornecedor).HasMaxLength(150).IsRequired();

                builder.Property(c => c.CNPJ).HasMaxLength(18).IsRequired();

                builder.Property(c => c.Ativo).HasDefaultValue(true);
            });

            modelBuilder.Entity<CompraProdutos>(builder =>
            {
                builder.HasKey(c => c.CompraProdutoId);

                builder.HasOne(c => c.Compra)
                    .WithMany(c => c.CompraProdutos)
                    .HasForeignKey(c => c.CompraId)
                    .IsRequired();

                builder.HasOne(c => c.Produto)
                    .WithMany(c => c.CompraProdutos)
                    .HasForeignKey(c => c.ProdutoId)
                    .IsRequired();

                builder.Property(c => c.Metro).HasMaxLength(10).IsRequired();

                builder.Property(c => c.Valor).HasMaxLength(10).IsRequired();
            });

            modelBuilder.Entity<Produtos>(builder =>
            {
                builder.HasKey(c => c.ProdutoId);

                builder.HasOne(c => c.Prateleira)
                    .WithMany(c => c.Produtos)
                    .HasForeignKey(c => c.PrateleiraId)
                    .IsRequired();

                builder.Property(c => c.Produto).HasMaxLength(150).IsRequired();

                builder.Property(c => c.Ativo).HasDefaultValue(true);
            });

            modelBuilder.Entity<Prateleiras>(builder =>
            {
                builder.HasKey(c => c.PrateleiraId);

                builder.HasOne(c => c.Categoria)
                    .WithMany(c => c.Prateleiras)
                    .HasForeignKey(c => c.CategoriaId)
                    .IsRequired();

                builder.Property(c => c.Descricao).HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<Categorias>(builder =>
            {
                builder.HasKey(c => c.CategoriaId);

                builder.HasOne(c => c.TipoProduto)
                    .WithMany(c => c.Categorias)
                    .HasForeignKey(c => c.TipoProdutoId)
                    .IsRequired();

                builder.Property(c => c.Categoria).HasMaxLength(50).IsRequired();

                builder.Property(c => c.Ativo).HasDefaultValue(true);
            });

            modelBuilder.Entity<TipoProdutos>(builder =>
            {
                builder.HasKey(c => c.TipoProdutoId);

                builder.Property(c => c.Tipo).HasMaxLength(10).IsRequired();

                builder.Property(c => c.Ativo).HasDefaultValue(true);
            });

            modelBuilder.Entity<ProdutosOrdens>(builder =>
            {
                builder.HasKey(c => c.ProdutoOrdemId);

                builder.HasOne(c => c.OrdemServico)
                    .WithMany(c => c.ProdutosOrdens)
                    .HasForeignKey(c => c.OrdemServicoId)
                    .IsRequired();

                builder.HasOne(c => c.Produto)
                    .WithMany(c => c.ProdutosOrdens)
                    .HasForeignKey(c => c.ProdutoId)
                    .IsRequired();

                builder.Property(c => c.Motivo).HasMaxLength(150).IsRequired();

                builder.Property(c => c.DataHora).HasDefaultValue(DateTime.Now).IsRequired();
            });

            modelBuilder.Entity<OrdemServicos>(builder =>
            {
                builder.HasKey(c => c.OrdemServicoId);

                builder.HasOne(c => c.TipoOrdemServico)
                    .WithMany(c => c.OrdemServicos)
                    .HasForeignKey(c => c.TipoOrdemServicoId)
                    .IsRequired();

                builder.HasOne(c => c.Usuario)
                    .WithMany(c => c.OrdemServicos)
                    .HasForeignKey(c => c.UsuarioId)
                    .IsRequired();

                builder.Property(c => c.Descricao).HasMaxLength(250).IsRequired();

                builder.Property(c => c.Cliente).HasMaxLength(150).IsRequired();

                builder.Property(c => c.Status).HasDefaultValue(0).IsRequired();
            });

            modelBuilder.Entity<TipoOrdemServicos>(builder =>
            {
                builder.HasKey(c => c.TipoOrdemServicoId);

                builder.Property(c => c.Tipo).HasMaxLength(50).IsRequired();

                builder.Property(c => c.Ativo).HasDefaultValue(true);
            });

            modelBuilder.Entity<LogOrdens>(builder =>
            {
                builder.HasKey(c => c.LogOrdemId);

                builder.HasOne(c => c.OrdemServico)
                    .WithMany(c => c.LogOrdens)
                    .HasForeignKey(c => c.OrdemServicoId)
                    .IsRequired();

                builder.Property(c => c.Data).HasDefaultValue(DateTime.Now);

                builder.Property(c => c.Descricao).HasMaxLength(150).IsRequired();

                builder.Property(c => c.StatusOrdem).IsRequired();
            });
        }
    }
}
