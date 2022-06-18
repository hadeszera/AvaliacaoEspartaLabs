using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoEspartaLabs.Domain.Entities
{
    public class AddAgendamento
    {
        public DateTime DataAgendamento { get; set; }

        public Servico Servico { get; set; }

        public int IdOficina { get; set; }
    }
}
