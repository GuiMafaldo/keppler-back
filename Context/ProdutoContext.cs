using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Context
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options): base(options){}
        
    }
}