using Microsoft.EntityFrameworkCore;
using backend.Models; 

namespace backend.Context
{
    public class ClienteContext :DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options): base(options) {}

    }
}