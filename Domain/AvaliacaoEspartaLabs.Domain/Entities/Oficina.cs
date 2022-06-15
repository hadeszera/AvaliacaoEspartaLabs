using AvaliacaoEspartaLabs.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoEspartaLabs.Domain.Entities
{
    public class Oficina : Base
    {
        public string Nome { get; set; }

        [Column]
        public string CNPJ { get; set; }

        public IEnumerable<Agenda> Agendas { get; set; }
        public string Senha { get; set; }
    }
}
