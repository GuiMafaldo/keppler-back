using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Administracao
    {
        public int Id { get; set; }
        public string? Name {get; set;}
        public string Username {get; set;}
        public string Password {get; set;}
    }
}