using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}