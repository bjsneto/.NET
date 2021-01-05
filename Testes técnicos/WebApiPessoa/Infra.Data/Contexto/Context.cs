using System;
using System.Collections.Generic;
using System.Text;
using Domain.Domain;
using Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Contexto
{
    public class Context : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pessoa>(new PessoaMap().Configure);
        }
    }
}
