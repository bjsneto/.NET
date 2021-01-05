using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain
{
    public class Pessoa
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
    }
}
