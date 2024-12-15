using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int CEP { get; set; }
        public string CNPJ { get; set; }
        public string numero { get; set; }
    }
}