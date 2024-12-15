using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Context
{
    public class VendaContext : DbContext
    {
        public VendaContext(DbContextOptions<VendaContext> options): base(options) {}
        
    }
}