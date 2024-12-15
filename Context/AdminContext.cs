using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Context
{
    public class AdminContext : DbContext
    {
        public AdminContext(DbContextOptions<AdminContext> options): base(options){}
        
        public DbSet<Administracao> Administracao { get; set; }
        public DbSet<Cliente> Cliente {get; set;}
        public DbSet<Fornecedor> Fornecedor {get; set;}
        public DbSet<Produto> Produto {get; set;}
        public DbSet<Vendas> Vendas {get; set;} 
        public DbSet<Colaborador> Colaborador {get; set;}
    }
}