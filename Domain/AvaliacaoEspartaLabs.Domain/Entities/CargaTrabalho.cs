using AvaliacaoEspartaLabs.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoEspartaLabs.Domain.Entities
{
    public class CargaTrabalho : Base
    {
        public int MyProperty { get; set; }
        public Servico Servico { get; set; }

        public int UnidadeTrabalho { get; set; }

        [ForeignKey("IdAgenda")]
        public int IdAgenda { get; set; }

        public Agenda Agenda { get; set; }

    }

    public enum Servico { 
        AlinhamentoRodas = 1,
        Lavacao = 2,
        TrocarOleo = 3,
        RevisaoBasica = 4,
        RevisaoCompleta = 5
    }
}
