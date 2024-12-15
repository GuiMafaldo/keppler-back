using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Context
{
    public class FornecedorContext : DbContext
    {
        public FornecedorContext(DbContextOptions<FornecedorContext> options): base(options) {}
       
    }
}