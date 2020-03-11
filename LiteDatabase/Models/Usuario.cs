using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteDatabase.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}
