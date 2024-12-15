using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Context
{
    public class ColaboradorContext : DbContext 
    {
        public ColaboradorContext(DbContextOptions<ColaboradorContext> options): base(options){}
       
    }
}