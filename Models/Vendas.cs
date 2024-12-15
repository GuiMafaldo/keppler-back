using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Vendas
    {
        public int Id { get; set; }
        public string NumeroNfse { get; set; }
        public  DateTime Data { get; set; }
        public string NameVendedor { get; set; }
        public int ClienteId { get; set; }
        public int ProdutoId {get; set;}
    }
} 