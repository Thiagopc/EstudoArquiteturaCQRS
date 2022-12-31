using Microsoft.EntityFrameworkCore;
using ProjetoEstudoCQRS.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudoCQRS.infra.Connection
{
    public class ConnectionDb : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }

        public ConnectionDb(DbContextOptions<ConnectionDb> options)
            :base(options)
        {            
            this.Database.EnsureCreated();
        }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .ToTable("usuario");

            modelBuilder.Entity<Usuario>()
                .HasKey(property => property.Id);

            modelBuilder.Entity<Usuario>()
                .Property(property => property.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Usuario>()
                .Property(property => property.Idade)
                .HasColumnName("idade");


            modelBuilder.Entity<Usuario>()
                .Property(property => property.Nome)
                .HasColumnName("nome");

        }


    }
}
