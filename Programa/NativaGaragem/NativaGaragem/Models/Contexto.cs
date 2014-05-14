using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace NativaGaragem.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Garagem> Garagens { get; set; }
        public DbSet<Limpeza> Limpezas { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Realizacao> Realizacoes { get; set; }
        public DbSet<Solicitacao> Solicitacoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Vaga> Vagas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        } 
    }
}