using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiMeta.Models
{
    public class Contato
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Canal { get; set; }
        public string Valor { get; set; }
        public string Obs { get; set; }
    }
}
